using System.Collections.Generic;

using Serilog.Sinks.SystemConsole.Themes;

namespace Eigenverft.NetLib.SerilogThemes
{
    public static partial class AnsiConsoleThemes
    {
        /// <summary>
        /// Gets a balanced low-glare theme with aqua, mint, gold, and coral accents.
        /// </summary>
        public static AnsiConsoleTheme Aurora { get; } = new AnsiConsoleTheme(
            new Dictionary<ConsoleThemeStyle, string>
            {
                [ConsoleThemeStyle.Text] = "\u001b[38;5;251m",
                [ConsoleThemeStyle.SecondaryText] = "\u001b[38;5;244m",
                [ConsoleThemeStyle.TertiaryText] = "\u001b[38;5;240m",
                [ConsoleThemeStyle.Invalid] = "\u001b[38;5;203m",
                [ConsoleThemeStyle.Null] = "\u001b[38;5;245m",
                [ConsoleThemeStyle.Name] = "\u001b[38;5;109m",
                [ConsoleThemeStyle.String] = "\u001b[38;5;108m",
                [ConsoleThemeStyle.Number] = "\u001b[38;5;220m",
                [ConsoleThemeStyle.Boolean] = "\u001b[38;5;150m",
                [ConsoleThemeStyle.Scalar] = "\u001b[38;5;104m",
                [ConsoleThemeStyle.LevelVerbose] = "\u001b[38;5;245m",
                [ConsoleThemeStyle.LevelDebug] = "\u001b[38;5;37m",
                [ConsoleThemeStyle.LevelInformation] = "\u001b[38;5;75m",
                [ConsoleThemeStyle.LevelWarning] = "\u001b[38;5;178m",
                [ConsoleThemeStyle.LevelError] = "\u001b[38;5;203m",
                [ConsoleThemeStyle.LevelFatal] = "\u001b[1;38;5;231;48;5;52m",
            });
    }
}
