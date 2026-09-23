using System.Collections.Generic;

using Serilog.Sinks.SystemConsole.Themes;

namespace Eigenverft.NetLib.SerilogThemes
{
    public static partial class AnsiConsoleThemes
    {
        /// <summary>
        /// Gets a deliberately dramatic red-and-white theme with strong text attributes.
        /// </summary>
        /// <remarks>
        /// This theme uses underline, reverse-video, and blink sequences. Terminal support
        /// for those attributes varies, so it is best suited to intentional visual emphasis.
        /// </remarks>
        public static AnsiConsoleTheme Bloodline { get; } = new AnsiConsoleTheme(
            new Dictionary<ConsoleThemeStyle, string>
            {
                [ConsoleThemeStyle.Text] = "\u001b[1;38;5;231m",
                [ConsoleThemeStyle.SecondaryText] = "\u001b[2;38;5;250m",
                [ConsoleThemeStyle.TertiaryText] = "\u001b[3;38;5;250m",
                [ConsoleThemeStyle.Invalid] = "\u001b[5;38;5;196m",
                [ConsoleThemeStyle.Null] = "\u001b[2;38;5;131m",
                [ConsoleThemeStyle.Name] = "\u001b[4;38;5;231m",
                [ConsoleThemeStyle.String] = "\u001b[1;38;5;196m",
                [ConsoleThemeStyle.Number] = "\u001b[7;38;5;231;48;5;196m",
                [ConsoleThemeStyle.Boolean] = "\u001b[1;38;5;196m",
                [ConsoleThemeStyle.Scalar] = "\u001b[2;38;5;231m",
                [ConsoleThemeStyle.LevelVerbose] = "\u001b[2;38;5;244m",
                [ConsoleThemeStyle.LevelDebug] = "\u001b[3;38;5;244m",
                [ConsoleThemeStyle.LevelInformation] = "\u001b[1;38;5;231m",
                [ConsoleThemeStyle.LevelWarning] = "\u001b[1;4;38;5;196m",
                [ConsoleThemeStyle.LevelError] = "\u001b[1;5;38;5;196m",
                [ConsoleThemeStyle.LevelFatal] = "\u001b[1;4;5;97;41m",
            });
    }
}
