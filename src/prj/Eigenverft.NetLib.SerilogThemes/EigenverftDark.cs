using System.Collections.Generic;

using Serilog.Sinks.SystemConsole.Themes;

namespace Eigenverft.NetLib.SerilogThemes
{
    public static partial class AnsiConsoleThemes
    {
        /// <summary>
        /// Gets the Eigenverft dark terminal theme using the current Tarink, Icesail,
        /// Creammap, and Bluecoat palette values as ANSI true-color sequences.
        /// </summary>
        /// <remarks>
        /// This theme is designed for a near-black terminal background comparable to
        /// Tarink (<c>rgb(9, 14, 15)</c>). It does not force a background for ordinary
        /// text, so the terminal's configured background remains authoritative.
        /// </remarks>
        public static AnsiConsoleTheme EigenverftDark { get; } = new AnsiConsoleTheme(
            new Dictionary<ConsoleThemeStyle, string>
            {
                [ConsoleThemeStyle.Text] = "\u001b[38;2;217;240;255m",
                [ConsoleThemeStyle.SecondaryText] = "\u001b[38;2;175;208;210m",
                [ConsoleThemeStyle.TertiaryText] = "\u001b[38;2;116;143;142m",
                [ConsoleThemeStyle.Invalid] = "\u001b[1;38;2;255;204;208m",
                [ConsoleThemeStyle.Null] = "\u001b[38;2;97;121;116m",
                [ConsoleThemeStyle.Name] = "\u001b[38;2;217;240;255m",
                [ConsoleThemeStyle.String] = "\u001b[38;2;214;255;238m",
                [ConsoleThemeStyle.Number] = "\u001b[38;2;255;254;208m",
                [ConsoleThemeStyle.Boolean] = "\u001b[38;2;227;255;211m",
                [ConsoleThemeStyle.Scalar] = "\u001b[38;2;215;198;255m",
                [ConsoleThemeStyle.LevelVerbose] = "\u001b[38;2;97;121;116m",
                [ConsoleThemeStyle.LevelDebug] = "\u001b[38;2;175;208;210m",
                [ConsoleThemeStyle.LevelInformation] = "\u001b[1;38;2;217;240;255m",
                [ConsoleThemeStyle.LevelWarning] = "\u001b[1;38;2;255;254;208m",
                [ConsoleThemeStyle.LevelError] = "\u001b[1;38;2;255;204;208m",
                [ConsoleThemeStyle.LevelFatal] = "\u001b[1;38;2;251;248;243;48;2;75;0;0m",
            });
    }
}
