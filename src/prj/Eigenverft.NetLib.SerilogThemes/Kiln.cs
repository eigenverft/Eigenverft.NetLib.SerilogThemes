using System.Collections.Generic;

using Serilog.Sinks.SystemConsole.Themes;

namespace Eigenverft.NetLib.SerilogThemes
{
    public static partial class AnsiConsoleThemes
    {
        /// <summary>
        /// Gets a warm, industrial palette for dark terminals, with copper names,
        /// verdigris values, and distinct warning and error signals.
        /// </summary>
        /// <remarks>
        /// Ordinary output leaves the terminal background untouched. Only fatal level
        /// markers use an explicit brick-red background.
        /// </remarks>
        public static AnsiConsoleTheme Kiln { get; } = new AnsiConsoleTheme(
            new Dictionary<ConsoleThemeStyle, string>
            {
                [ConsoleThemeStyle.Text] = "\u001b[38;2;231;221;208m",
                [ConsoleThemeStyle.SecondaryText] = "\u001b[38;2;175;163;150m",
                [ConsoleThemeStyle.TertiaryText] = "\u001b[38;2;150;139;128m",
                [ConsoleThemeStyle.Invalid] = "\u001b[1;38;2;239;128;106m",
                [ConsoleThemeStyle.Null] = "\u001b[38;2;150;139;128m",
                [ConsoleThemeStyle.Name] = "\u001b[38;2;214;161;95m",
                [ConsoleThemeStyle.String] = "\u001b[38;2;142;201;181m",
                [ConsoleThemeStyle.Number] = "\u001b[38;2;201;175;224m",
                [ConsoleThemeStyle.Boolean] = "\u001b[38;2;214;161;95m",
                [ConsoleThemeStyle.Scalar] = "\u001b[38;2;201;175;224m",
                [ConsoleThemeStyle.LevelVerbose] = "\u001b[38;2;150;139;128m",
                [ConsoleThemeStyle.LevelDebug] = "\u001b[38;2;175;163;150m",
                [ConsoleThemeStyle.LevelInformation] = "\u001b[1;38;2;168;199;195m",
                [ConsoleThemeStyle.LevelWarning] = "\u001b[1;38;2;242;190;101m",
                [ConsoleThemeStyle.LevelError] = "\u001b[1;38;2;239;128;106m",
                [ConsoleThemeStyle.LevelFatal] = "\u001b[1;38;2;255;244;232;48;2;146;61;53m",
            });
    }
}
