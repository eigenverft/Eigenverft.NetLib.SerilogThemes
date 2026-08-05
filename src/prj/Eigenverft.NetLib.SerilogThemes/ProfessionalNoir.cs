using System.Collections.Generic;

using Serilog.Sinks.SystemConsole.Themes;

namespace Eigenverft.NetLib.SerilogThemes
{
    public static partial class AnsiConsoleThemes
    {
        /// <summary>
        /// Gets a high-contrast noir theme with restrained neutrals and distinct level colors.
        /// </summary>
        public static AnsiConsoleTheme ProfessionalNoir { get; } = new AnsiConsoleTheme(
            new Dictionary<ConsoleThemeStyle, string>
            {
                [ConsoleThemeStyle.Text] = "\u001b[38;5;255m",
                [ConsoleThemeStyle.SecondaryText] = "\u001b[38;5;250m",
                [ConsoleThemeStyle.TertiaryText] = "\u001b[38;5;245m",
                [ConsoleThemeStyle.Invalid] = "\u001b[38;5;160m",
                [ConsoleThemeStyle.Null] = "\u001b[38;5;59m",
                [ConsoleThemeStyle.Name] = "\u001b[38;5;75m",
                [ConsoleThemeStyle.String] = "\u001b[38;5;183m",
                [ConsoleThemeStyle.Number] = "\u001b[38;5;220m",
                [ConsoleThemeStyle.Boolean] = "\u001b[38;5;82m",
                [ConsoleThemeStyle.Scalar] = "\u001b[38;5;150m",
                [ConsoleThemeStyle.LevelVerbose] = "\u001b[38;5;244m",
                [ConsoleThemeStyle.LevelDebug] = "\u001b[38;5;39m",
                [ConsoleThemeStyle.LevelInformation] = "\u001b[38;5;117m",
                [ConsoleThemeStyle.LevelWarning] = "\u001b[38;5;214m",
                [ConsoleThemeStyle.LevelError] = "\u001b[38;5;203m",
                [ConsoleThemeStyle.LevelFatal] = "\u001b[38;5;196;48;5;52m",
            });
    }
}
