---
_layout: landing
---

# {{appName}}

Curated ANSI console themes for Serilog's console sink, including an Eigenverft-specific dark terminal palette.

## Get started

Install the package and configure a theme in a few lines of code:

```csharp
using Eigenverft.NetLib.SerilogThemes;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(theme: AnsiConsoleThemes.EigenverftDark)
    .CreateLogger();
```

Continue with the [getting started guide](docs/getting-started.md) or browse the [API reference](xref:Eigenverft.NetLib.SerilogThemes).

## Theme catalog

`Aurora`, `Bloodline`, `ClarionDusk`, `CodingNight`, `EigenverftDark`, `ProfessionalNoir`, and `RetroGreen` are available through the static `AnsiConsoleThemes` catalog.
