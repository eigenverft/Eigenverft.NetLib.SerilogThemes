# 🎨 Eigenverft.NetLib.SerilogThemes

[![NuGet Version](https://img.shields.io/nuget/v/Eigenverft.NetLib.SerilogThemes?label=NuGet&logo=nuget)](https://www.nuget.org/packages/Eigenverft.NetLib.SerilogThemes) [![NuGet Downloads](https://img.shields.io/nuget/dt/Eigenverft.NetLib.SerilogThemes?label=Downloads&logo=nuget)](https://www.nuget.org/packages/Eigenverft.NetLib.SerilogThemes) [![Build Status](https://img.shields.io/github/actions/workflow/status/eigenverft/Eigenverft.NetLib.SerilogThemes/cicd.yml?branch=main&label=build)](https://github.com/eigenverft/Eigenverft.NetLib.SerilogThemes/actions/workflows/cicd.yml) [![Targets](https://img.shields.io/badge/targets-net462%20%7C%20.NET%206%20%7C%208%20%7C%2010-512BD4?logo=dotnet&logoColor=white)](#-target-frameworks) [![License](https://img.shields.io/github/license/eigenverft/Eigenverft.NetLib.SerilogThemes?logo=mit)](LICENSE)

Curated ANSI console themes for [`Serilog.Sinks.Console`](https://github.com/serilog/serilog-sinks-console), including the Eigenverft dark terminal palette.

Small package, focused API: pick a theme and pass it directly to `WriteTo.Console(...)`.

> [!IMPORTANT]
> This package is currently **pre-1.0**. Theme names and palettes may still evolve between releases.

---

## ✨ At a glance

| | |
| --- | --- |
| Package | `Eigenverft.NetLib.SerilogThemes` |
| API | `AnsiConsoleThemes.<ThemeName>` |
| Themes | 9 curated ANSI palettes |
| Target frameworks | .NET Framework 4.6.2 and .NET 6, 8, and 10 |
| Console sink | `Serilog.Sinks.Console` |
| License | MIT |

## 📦 Installation

```shell
dotnet add package Eigenverft.NetLib.SerilogThemes
```

Or with the NuGet Package Manager:

```powershell
Install-Package Eigenverft.NetLib.SerilogThemes
```

## 🚀 Quick start

```csharp
using Eigenverft.NetLib.SerilogThemes;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(theme: AnsiConsoleThemes.EigenverftDark)
    .CreateLogger();
```

Switching the visual identity is intentionally simple:

```csharp
.WriteTo.Console(theme: AnsiConsoleThemes.Aurora)
```

## 🌈 Available themes

| Theme | Character |
| --- | --- |
| 🌌 `Aurora` | Aqua, mint, gold, and coral accents |
| 🩸 `Bloodline` | Dramatic red-and-white styling with text attributes |
| 🌆 `ClarionDusk` | Bright dusk colors with clear log-level separation |
| 🌙 `CodingNight` | Visual Studio-inspired 256-color palette |
| ⚓ `EigenverftDark` | Near-black Eigenverft palette using ANSI true color |
| 🌊 `EigenverftHarbor` | Color-rich Eigenverft palette with bright harbor blue, teal, orange, violet, and coral accents |
| 🎩 `ProfessionalNoir` | High-contrast neutrals with restrained accents |
| 🟢 `RetroGreen` | Green-centric monochrome CRT style |
| ◉ `SignalSlate` | Muted grayscale for long log streams with strong warning, error, and fatal signals |

All themes are exposed as static properties on `AnsiConsoleThemes`:

```csharp
AnsiConsoleThemes.Aurora
AnsiConsoleThemes.Bloodline
AnsiConsoleThemes.ClarionDusk
AnsiConsoleThemes.CodingNight
AnsiConsoleThemes.EigenverftDark
AnsiConsoleThemes.EigenverftHarbor
AnsiConsoleThemes.ProfessionalNoir
AnsiConsoleThemes.RetroGreen
AnsiConsoleThemes.SignalSlate
```

## 🖥️ Terminal compatibility

ANSI rendering depends on the terminal and its color capabilities.

- `EigenverftDark` and `EigenverftHarbor` use 24-bit true-color escape sequences.
- `CodingNight` and `SignalSlate` use 256-color palettes.
- `Bloodline` uses attributes such as underline, reverse video, and blink; terminal support varies.
- The remaining themes use broadly supported ANSI color sequences.

`EigenverftDark` is designed for a near-black terminal background comparable to the Eigenverft **Tarink** color (`rgb(9, 14, 15)`). It normally leaves the terminal background untouched; only fatal events use an explicit background color.

`EigenverftHarbor` targets the same dark-terminal environment, but deliberately avoids Bluecoat navy as foreground text. It keeps Icesail for readability and uses brighter blue/cyan plus orange and complementary accents for stronger semantic separation.

`SignalSlate` is optimized for scanning long-running logs: repeated message text stays deliberately muted, changing structured names and values step toward white for faster scanning, and color is reserved for warning, error, and fatal level markers.

## 🧪 Theme preview application

The repository includes a console gallery with hosting and Microsoft logging integration. Running it without arguments renders every theme in sequence for easy visual comparison:

```shell
dotnet run --project src/prj/Eigenverft.NetLib.SerilogThemes.Console/Eigenverft.NetLib.SerilogThemes.Console.csproj
```

Use `--theme` for a focused preview, or `--list` for the catalog:

```shell
dotnet run --project src/prj/Eigenverft.NetLib.SerilogThemes.Console/Eigenverft.NetLib.SerilogThemes.Console.csproj -- --theme SignalSlate
dotnet run --project src/prj/Eigenverft.NetLib.SerilogThemes.Console/Eigenverft.NetLib.SerilogThemes.Console.csproj -- --list
```

The preview writes every Serilog level, structured scalar and object values, an exception, and a message routed through `Microsoft.Extensions.Logging` for each rendered theme.

## 🎯 Target frameworks

The package ships dedicated assets for:

- `net462`
- `net6.0`
- `net8.0`
- `net10.0`

This preserves the original .NET Framework compatibility while covering the .NET LTS lines. Compatible odd-numbered .NET consumers can use the preceding LTS asset, for example .NET 7 uses `net6.0` and .NET 9 uses `net8.0`.

## 🧪 Build and test

From the repository root:

```shell
dotnet build src/Eigenverft.NetLib.SerilogThemes.slnx --configuration Release
dotnet test src/Eigenverft.NetLib.SerilogThemes.slnx --configuration Release
```

## 🚢 Releases

`main` is the production channel. Every accepted change is built, tested, documented, packed, and published by the repository CI/CD workflow.

Package versions follow the Eigenverft Drydock timestamp-based versioning scheme. Published versions and download history are available on [NuGet.org](https://www.nuget.org/packages/Eigenverft.NetLib.SerilogThemes).

## 🤝 Contributing and support

- 🐛 [Open an issue](https://github.com/eigenverft/Eigenverft.NetLib.SerilogThemes/issues)
- 🔧 [Submit a pull request](https://github.com/eigenverft/Eigenverft.NetLib.SerilogThemes/pulls)
- 📦 [View the package on NuGet.org](https://www.nuget.org/packages/Eigenverft.NetLib.SerilogThemes)

## 📄 License

Licensed under the [MIT License](LICENSE) by Eigenverft.

---

Made with ❤️ by Eigenverft
