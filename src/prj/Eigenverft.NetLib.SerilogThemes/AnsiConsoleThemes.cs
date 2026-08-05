using Serilog.Sinks.SystemConsole.Themes;

namespace Eigenverft.NetLib.SerilogThemes
{
    /// <summary>
    /// Provides curated <see cref="AnsiConsoleTheme"/> instances for Serilog's console sink.
    /// </summary>
    /// <remarks>
    /// The themes contain ANSI Select Graphic Rendition sequences and are intended for
    /// terminals that support ANSI color output. Assign one of the static properties to
    /// the <c>theme</c> argument of <c>WriteTo.Console(...)</c>.
    /// </remarks>
    public static partial class AnsiConsoleThemes
    {
    }
}
