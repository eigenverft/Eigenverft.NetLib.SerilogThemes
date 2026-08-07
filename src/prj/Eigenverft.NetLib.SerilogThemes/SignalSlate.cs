using System.Collections.Generic;

using Serilog.Sinks.SystemConsole.Themes;

namespace Eigenverft.NetLib.SerilogThemes
{
    public static partial class AnsiConsoleThemes
    {
        /// <summary>
        /// Gets a muted grayscale theme optimized for scanning long-running log streams.
        /// </summary>
        /// <remarks>
        /// Repeated message text stays deliberately muted while structured names and values step
        /// toward white, making changing parameters easier to scan in high-volume logs.
        /// Color is deliberately reserved for warning, error, and fatal levels: warning uses
        /// amber emphasis, error uses a dark-red signal block, and fatal escalates to a brighter
        /// red block. The terminal background remains authoritative for ordinary output.
        /// </remarks>
        public static AnsiConsoleTheme SignalSlate { get; } = new AnsiConsoleTheme(
            new Dictionary<ConsoleThemeStyle, string>
            {
                [ConsoleThemeStyle.Text] = "\u001b[38;5;248m",
                [ConsoleThemeStyle.SecondaryText] = "\u001b[38;5;244m",
                [ConsoleThemeStyle.TertiaryText] = "\u001b[38;5;240m",
                [ConsoleThemeStyle.Invalid] = "\u001b[1;38;5;255m",
                [ConsoleThemeStyle.Null] = "\u001b[38;5;246m",
                [ConsoleThemeStyle.Name] = "\u001b[38;5;252m",
                [ConsoleThemeStyle.String] = "\u001b[38;5;255m",
                [ConsoleThemeStyle.Number] = "\u001b[38;5;254m",
                [ConsoleThemeStyle.Boolean] = "\u001b[38;5;253m",
                [ConsoleThemeStyle.Scalar] = "\u001b[38;5;252m",
                [ConsoleThemeStyle.LevelVerbose] = "\u001b[2;38;5;240m",
                [ConsoleThemeStyle.LevelDebug] = "\u001b[38;5;244m",
                [ConsoleThemeStyle.LevelInformation] = "\u001b[38;5;248m",
                [ConsoleThemeStyle.LevelWarning] = "\u001b[1;4;38;5;214m",
                [ConsoleThemeStyle.LevelError] = "\u001b[1;38;5;231;48;5;88m",
                [ConsoleThemeStyle.LevelFatal] = "\u001b[1;4;38;5;231;48;5;160m",
            });
    }
}
