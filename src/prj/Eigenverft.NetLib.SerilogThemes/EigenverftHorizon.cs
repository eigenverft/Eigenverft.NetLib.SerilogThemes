using System.Collections.Generic;

using Serilog.Sinks.SystemConsole.Themes;

namespace Eigenverft.NetLib.SerilogThemes
{
    public static partial class AnsiConsoleThemes
    {
        /// <summary>
        /// Gets the background-neutral Eigenverft terminal theme based on the current
        /// <c>on_all</c> palette.
        /// </summary>
        /// <remarks>
        /// Horizon is intended for terminals where the background is unknown, user-controlled,
        /// or can switch between light and dark. Ordinary text therefore uses the terminal's
        /// default foreground and never forces a background. The current Eigenverft
        /// <c>on_all</c> colors are reserved for structured accents and information/warning
        /// signals, while error and fatal levels keep explicit high-contrast red signaling.
        /// </remarks>
        public static AnsiConsoleTheme EigenverftHorizon { get; } = new AnsiConsoleTheme(
            new Dictionary<ConsoleThemeStyle, string>
            {
                [ConsoleThemeStyle.Text] = "\u001b[39m",
                [ConsoleThemeStyle.SecondaryText] = "\u001b[2;39m",
                [ConsoleThemeStyle.TertiaryText] = "\u001b[2;39m",
                [ConsoleThemeStyle.Invalid] = "\u001b[1;38;2;251;248;243;48;2;132;37;15m",
                [ConsoleThemeStyle.Null] = "\u001b[2;39m",
                [ConsoleThemeStyle.Name] = "\u001b[1;38;2;31;167;196m",
                [ConsoleThemeStyle.String] = "\u001b[38;2;15;136;163m",
                [ConsoleThemeStyle.Number] = "\u001b[1;38;2;240;122;0m",
                [ConsoleThemeStyle.Boolean] = "\u001b[1;38;2;31;167;196m",
                [ConsoleThemeStyle.Scalar] = "\u001b[38;2;15;136;163m",
                [ConsoleThemeStyle.LevelVerbose] = "\u001b[2;39m",
                [ConsoleThemeStyle.LevelDebug] = "\u001b[1;38;2;15;136;163m",
                [ConsoleThemeStyle.LevelInformation] = "\u001b[1;38;2;31;167;196m",
                [ConsoleThemeStyle.LevelWarning] = "\u001b[1;38;2;9;14;15;48;2;240;122;0m",
                [ConsoleThemeStyle.LevelError] = "\u001b[1;38;2;251;248;243;48;2;132;37;15m",
                [ConsoleThemeStyle.LevelFatal] = "\u001b[1;4;38;2;251;248;243;48;2;160;0;0m",
            });
    }
}
