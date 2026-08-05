# Eigenverft.NetLib.SerilogThemes

Curated ANSI console themes for the Serilog console sink. The repository carries forward the useful theme catalog from `BlackBytesBox.Serilog.AnsiConsoleThemes`, adapts it to the current Eigenverft repository structure, and adds an Eigenverft-specific dark terminal theme.

The repository is currently a private incubation project. It has no NuGet release, CI/CD workflow, or integration into another Eigenverft application yet.

## Projects

```text
src/
├── Eigenverft.NetLib.SerilogThemes.slnx
├── prj/
│   ├── Eigenverft.NetLib.SerilogThemes/
│   └── Eigenverft.NetLib.SerilogThemes.Tests/
└── wrk/
```

The library targets `net8.0` and `net10.0`. The test project targets `net10.0`.

## Available themes

- `Aurora` — balanced aqua, mint, gold, and coral accents.
- `Bloodline` — intentionally dramatic red-and-white styling.
- `ClarionDusk` — bright dusk colors with clear log-level separation.
- `CodingNight` — a Visual Studio-inspired 256-color coding theme.
- `EigenverftDark` — the current Eigenverft dark palette expressed as ANSI true color.
- `ProfessionalNoir` — high-contrast neutrals with restrained accents.
- `RetroGreen` — a green-centric monochrome CRT style.

## Usage

Until packaging is standardized, consume the library through a project reference:

```xml
<ItemGroup>
  <ProjectReference Include="..\Eigenverft.NetLib.SerilogThemes\src\prj\Eigenverft.NetLib.SerilogThemes\Eigenverft.NetLib.SerilogThemes.csproj" />
</ItemGroup>
```

Configure the Serilog console sink with one of the catalog properties:

```csharp
using Eigenverft.NetLib.SerilogThemes;

using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(theme: AnsiConsoleThemes.EigenverftDark)
    .CreateLogger();
```

ANSI rendering depends on the target terminal. `Bloodline` additionally uses text attributes such as underline, reverse video, and blink whose support varies between terminals.

## Eigenverft dark palette

`EigenverftDark` is intended for a near-black terminal background comparable to the Eigenverft **Tarink** value `rgb(9, 14, 15)`. Its ordinary text and structured-value styles use the current **Icesail** palette as ANSI true-color sequences. Fatal events use **Creammap** text on **Bluecoat Red**.

The theme deliberately does not force an ordinary message background. The terminal remains responsible for its normal background and only the fatal level uses an explicit background color.

## Build and test

Run from the repository root:

```powershell
dotnet build src/Eigenverft.NetLib.SerilogThemes.slnx --configuration Release
dotnet test src/Eigenverft.NetLib.SerilogThemes.slnx --configuration Debug
```

The tests verify the public theme catalog, complete `ConsoleThemeStyle` coverage for every theme, and the exact current palette sequences used by `EigenverftDark`.

## Agent template refresh

The repository-local helper refreshes distributed agent instructions and skills from `Eigenverft.Template.Agents` without committing or pushing changes:

```powershell
./distribute.ps1
```

Use `-WhatIf` to preview the overlay or `-ForceSkillReplacement` to replace the complete local `.agents` tree before copying the current template snapshot.

## Origin and license

The six original themes were adapted from `carsten-riedel/BlackBytesBox.Serilog.AnsiConsoleThemes`, which is licensed under the MIT License. `EigenverftDark`, the modern project structure, and the automated structural tests were added for this repository. See [NOTICE.md](NOTICE.md) and [LICENSE](LICENSE).
