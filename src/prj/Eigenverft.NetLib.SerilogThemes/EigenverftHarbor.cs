using System.Collections.Generic;

using Serilog.Sinks.SystemConsole.Themes;

namespace Eigenverft.NetLib.SerilogThemes
{
    public static partial class AnsiConsoleThemes
    {
        /// <summary>
        /// Gets the colorful Eigenverft harbor terminal theme for dark console backgrounds.
        /// </summary>
        /// <remarks>
        /// The theme keeps Icesail as its readable Eigenverft base and adds brighter harbor
        /// blue, teal, orange, violet, and coral accents for stronger semantic separation.
        /// Bluecoat navy is intentionally not used as foreground text because its low
        /// luminance is unsuitable for the near-black terminal backgrounds this theme targets.
        /// The terminal background remains authoritative for ordinary output.
        /// </remarks>
        public static AnsiConsoleTheme EigenverftHarbor { get; } = new AnsiConsoleTheme(
            new Dictionary<ConsoleThemeStyle, string>
            {
                [ConsoleThemeStyle.Text] = "\u001b[38;2;217;240;255m",
                [ConsoleThemeStyle.SecondaryText] = "\u001b[38;2;116;185;205m",
                [ConsoleThemeStyle.TertiaryText] = "\u001b[38;2;135;166;166m",
                [ConsoleThemeStyle.Invalid] = "\u001b[1;38;2;255;107;107m",
                [ConsoleThemeStyle.Null] = "\u001b[38;2;116;143;142m",
                [ConsoleThemeStyle.Name] = "\u001b[38;2;92;200;255m",
                [ConsoleThemeStyle.String] = "\u001b[38;2;86;224;208m",
                [ConsoleThemeStyle.Number] = "\u001b[38;2;255;138;61m",
                [ConsoleThemeStyle.Boolean] = "\u001b[38;2;154;242;197m",
                [ConsoleThemeStyle.Scalar] = "\u001b[38;2;199;160;255m",
                [ConsoleThemeStyle.LevelVerbose] = "\u001b[38;2;116;143;142m",
                [ConsoleThemeStyle.LevelDebug] = "\u001b[38;2;92;200;255m",
                [ConsoleThemeStyle.LevelInformation] = "\u001b[1;38;2;86;224;208m",
                [ConsoleThemeStyle.LevelWarning] = "\u001b[1;38;2;255;138;61m",
                [ConsoleThemeStyle.LevelError] = "\u001b[1;38;2;255;107;107m",
                [ConsoleThemeStyle.LevelFatal] = "\u001b[1;38;2;251;248;243;48;2;132;37;15m",
            });
    }
}
