# Getting started

Install the package:

```powershell
dotnet add package Eigenverft.NetLib.SerilogThemes
```

Select a theme when configuring the Serilog console sink:

```csharp
using Eigenverft.NetLib.SerilogThemes;

using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console(theme: AnsiConsoleThemes.EigenverftDark)
    .CreateLogger();
```

Replace `EigenverftDark` with any other property from `AnsiConsoleThemes` to use a different palette.

## Terminal support

`EigenverftDark` uses 24-bit color sequences. `Bloodline` also uses text attributes such as underline, reverse video, and blink. Terminals that do not support these capabilities may render a reduced or different appearance.
