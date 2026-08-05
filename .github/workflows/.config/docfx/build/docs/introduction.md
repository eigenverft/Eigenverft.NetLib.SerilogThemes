# Introduction

`Eigenverft.NetLib.SerilogThemes` provides ready-to-use `AnsiConsoleTheme` instances for `Serilog.Sinks.Console`.

The public catalog is exposed through `AnsiConsoleThemes` and currently includes:

- `Aurora`
- `Bloodline`
- `ClarionDusk`
- `CodingNight`
- `EigenverftDark`
- `ProfessionalNoir`
- `RetroGreen`

The themes use ANSI Select Graphic Rendition sequences. Rendering therefore depends on the capabilities and configuration of the target terminal.

`EigenverftDark` uses ANSI true color and is designed for a near-black terminal background. The normal background remains terminal-controlled; only fatal events use an explicit background color.
