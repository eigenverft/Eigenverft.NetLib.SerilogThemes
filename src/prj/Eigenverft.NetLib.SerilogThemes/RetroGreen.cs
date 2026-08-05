using System.Collections.Generic;

using Serilog.Sinks.SystemConsole.Themes;

namespace Eigenverft.NetLib.SerilogThemes
{
    public static partial class AnsiConsoleThemes
    {
        /// <summary>
        /// Gets a green-centric theme inspired by monochrome CRT terminals.
        /// </summary>
        public static AnsiConsoleTheme RetroGreen { get; } = new AnsiConsoleTheme(
            new Dictionary<ConsoleThemeStyle, string>
            {
                [ConsoleThemeStyle.Text] = "\u001b[38;5;34m",
                [ConsoleThemeStyle.SecondaryText] = "\u001b[38;5;29m",
                [ConsoleThemeStyle.TertiaryText] = "\u001b[38;5;22m",
                [ConsoleThemeStyle.Invalid] = "\u001b[38;5;82;48;5;22m",
                [ConsoleThemeStyle.Null] = "\u001b[38;5;22m",
                [ConsoleThemeStyle.Name] = "\u001b[38;5;76m",
                [ConsoleThemeStyle.String] = "\u001b[38;5;70m",
                [ConsoleThemeStyle.Number] = "\u001b[38;5;34m",
                [ConsoleThemeStyle.Boolean] = "\u001b[38;5;76m",
                [ConsoleThemeStyle.Scalar] = "\u001b[38;5;70m",
                [ConsoleThemeStyle.LevelVerbose] = "\u001b[38;5;22m",
                [ConsoleThemeStyle.LevelDebug] = "\u001b[38;5;29m",
                [ConsoleThemeStyle.LevelInformation] = "\u001b[38;5;34m",
                [ConsoleThemeStyle.LevelWarning] = "\u001b[38;5;70m",
                [ConsoleThemeStyle.LevelError] = "\u001b[38;5;76;48;5;22m",
                [ConsoleThemeStyle.LevelFatal] = "\u001b[38;5;231;48;5;28m",
            });
    }
}
