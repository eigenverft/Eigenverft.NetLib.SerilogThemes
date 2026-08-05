using System.Collections.Generic;

using Serilog.Sinks.SystemConsole.Themes;

namespace Eigenverft.NetLib.SerilogThemes
{
    public static partial class AnsiConsoleThemes
    {
        /// <summary>
        /// Gets a Visual Studio-inspired dark coding theme using the xterm 256-color palette.
        /// </summary>
        public static AnsiConsoleTheme CodingNight { get; } = new AnsiConsoleTheme(
            new Dictionary<ConsoleThemeStyle, string>
            {
                [ConsoleThemeStyle.Text] = "\u001b[38;5;252m",
                [ConsoleThemeStyle.SecondaryText] = "\u001b[38;5;244m",
                [ConsoleThemeStyle.TertiaryText] = "\u001b[38;5;240m",
                [ConsoleThemeStyle.Invalid] = "\u001b[38;5;203m",
                [ConsoleThemeStyle.Null] = "\u001b[38;5;242m",
                [ConsoleThemeStyle.Name] = "\u001b[38;5;74m",
                [ConsoleThemeStyle.String] = "\u001b[38;5;173m",
                [ConsoleThemeStyle.Number] = "\u001b[38;5;150m",
                [ConsoleThemeStyle.Boolean] = "\u001b[38;5;72m",
                [ConsoleThemeStyle.Scalar] = "\u001b[38;5;72m",
                [ConsoleThemeStyle.LevelVerbose] = "\u001b[38;5;244m",
                [ConsoleThemeStyle.LevelDebug] = "\u001b[38;5;117m",
                [ConsoleThemeStyle.LevelInformation] = "\u001b[38;5;179m",
                [ConsoleThemeStyle.LevelWarning] = "\u001b[38;5;187m",
                [ConsoleThemeStyle.LevelError] = "\u001b[38;5;203m",
                [ConsoleThemeStyle.LevelFatal] = "\u001b[38;5;203;48;5;52m",
            });
    }
}
