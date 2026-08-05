# Refreshes this repository's distributed agent instructions and skills from
# Eigenverft.Template.Agents. The script changes files only; it never commits or pushes.
[CmdletBinding(SupportsShouldProcess)]
param(
    [string]$TemplateRepositoryUrl = 'https://github.com/eigenverft/Eigenverft.Template.Agents.git',

    [switch]$ForceSkillReplacement
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

function Test-FileContentEqual {
    param(
        [Parameter(Mandatory)]
        [string]$SourcePath,

        [Parameter(Mandatory)]
        [string]$DestinationPath
    )

    if (-not [System.IO.File]::Exists($DestinationPath)) {
        return $false
    }

    $source = [System.IO.FileInfo]::new($SourcePath)
    $destination = [System.IO.FileInfo]::new($DestinationPath)
    if ($source.Length -ne $destination.Length) {
        return $false
    }

    $sourceBytes = [System.IO.File]::ReadAllBytes($SourcePath)
    $destinationBytes = [System.IO.File]::ReadAllBytes($DestinationPath)
    return [System.Collections.StructuralComparisons]::StructuralEqualityComparer.Equals(
        $sourceBytes,
        $destinationBytes)
}

function Get-TemplateFiles {
    param(
        [Parameter(Mandatory)]
        [string]$TemplateRoot
    )

    $files = [System.Collections.Generic.List[object]]::new()

    foreach ($rootFile in @('.gitattributes', 'AGENTS.md')) {
        $path = Join-Path $TemplateRoot $rootFile
        if (Test-Path -LiteralPath $path -PathType Leaf) {
            [void]$files.Add([pscustomobject]@{
                FullName = $path
                RelativePath = $rootFile
            })
        }
    }

    foreach ($rootDirectory in @('.agents', 'AGENTS')) {
        $path = Join-Path $TemplateRoot $rootDirectory
        if (-not (Test-Path -LiteralPath $path -PathType Container)) {
            continue
        }

        $prefix = $TemplateRoot.TrimEnd('\', '/') + [System.IO.Path]::DirectorySeparatorChar
        Get-ChildItem -LiteralPath $path -Recurse -File -Force | ForEach-Object {
            [void]$files.Add([pscustomobject]@{
                FullName = $_.FullName
                RelativePath = $_.FullName.Substring($prefix.Length)
            })
        }
    }

    return $files
}

$tempRoot = Join-Path ([System.IO.Path]::GetTempPath()) (
    'eigenverft-agents-' + [guid]::NewGuid().ToString('N'))
$templateRoot = Join-Path $tempRoot 'template'
$changedFiles = [System.Collections.Generic.List[string]]::new()

try {
    New-Item -ItemType Directory -Path $tempRoot -Force -WhatIf:$false | Out-Null

    Write-Host "Cloning agent template from $TemplateRepositoryUrl ..."
    git clone --depth 1 $TemplateRepositoryUrl $templateRoot
    if ($LASTEXITCODE -ne 0) {
        throw "git clone failed with exit code $LASTEXITCODE."
    }

    $templateFiles = @(Get-TemplateFiles -TemplateRoot $templateRoot)
    if ($templateFiles.Count -eq 0) {
        throw 'The template snapshot did not contain any distributable agent files.'
    }

    $targetAgentsPath = Join-Path $PSScriptRoot '.agents'
    if ($ForceSkillReplacement -and (Test-Path -LiteralPath $targetAgentsPath)) {
        if ($PSCmdlet.ShouldProcess(
            $targetAgentsPath,
            'Remove the existing .agents tree before distributing the current template')) {
            Remove-Item -LiteralPath $targetAgentsPath -Recurse -Force
            [void]$changedFiles.Add('.agents/')
        }
    }

    foreach ($source in $templateFiles) {
        $destinationPath = Join-Path $PSScriptRoot $source.RelativePath
        if (Test-FileContentEqual -SourcePath $source.FullName -DestinationPath $destinationPath) {
            continue
        }

        if (-not $PSCmdlet.ShouldProcess(
            $destinationPath,
            "Copy $($source.RelativePath) from the current agent template")) {
            continue
        }

        $destinationDirectory = Split-Path -Path $destinationPath -Parent
        if (-not (Test-Path -LiteralPath $destinationDirectory -PathType Container)) {
            New-Item -ItemType Directory -Path $destinationDirectory -Force | Out-Null
        }

        Copy-Item -LiteralPath $source.FullName -Destination $destinationPath -Force
        [void]$changedFiles.Add($source.RelativePath.Replace('\', '/'))
    }

    if ($WhatIfPreference) {
        Write-Host 'WhatIf preview complete; no files were changed.'
    }
    elseif ($changedFiles.Count -eq 0) {
        Write-Host 'Agent instructions and skills are already up to date.'
    }
    else {
        Write-Host ("Distributed {0} changed path(s):" -f $changedFiles.Count)
        $changedFiles | Sort-Object -Unique | ForEach-Object { Write-Host "  - $_" }
    }
}
finally {
    if (Test-Path -LiteralPath $tempRoot) {
        Remove-Item -LiteralPath $tempRoot -Recurse -Force -ErrorAction SilentlyContinue -WhatIf:$false
    }
}
