using System;
using System.IO;
using System.Linq;
using System.Reflection;

using Serilog.Sinks.SystemConsole.Themes;

namespace Eigenverft.NetLib.SerilogThemes.Tests
{
    [TestClass]
    public sealed class AnsiConsoleThemesTests
    {
        private static readonly string[] ExpectedThemeNames =
        {
            nameof(AnsiConsoleThemes.Aurora),
            nameof(AnsiConsoleThemes.Bloodline),
            nameof(AnsiConsoleThemes.ClarionDusk),
            nameof(AnsiConsoleThemes.CodingNight),
            nameof(AnsiConsoleThemes.EigenverftDark),
            nameof(AnsiConsoleThemes.ProfessionalNoir),
            nameof(AnsiConsoleThemes.RetroGreen),
        };

        [TestMethod]
        public void Catalog_ExposesTheExpectedThemes()
        {
            PropertyInfo[] themeProperties = GetThemeProperties();
            string[] actualNames = themeProperties.Select(property => property.Name).ToArray();

            CollectionAssert.AreEquivalent(ExpectedThemeNames, actualNames);

            foreach (PropertyInfo property in themeProperties)
            {
                Assert.IsInstanceOfType<AnsiConsoleTheme>(
                    property.GetValue(null),
                    $"Theme property {property.Name} did not return an AnsiConsoleTheme.");
            }
        }

        [TestMethod]
        public void EveryTheme_DefinesEveryConsoleThemeStyle()
        {
            foreach (PropertyInfo property in GetThemeProperties())
            {
                AnsiConsoleTheme theme = (AnsiConsoleTheme)property.GetValue(null)!;

                foreach (ConsoleThemeStyle style in Enum.GetValues<ConsoleThemeStyle>())
                {
                    using var writer = new StringWriter();
                    int writtenCharacterCount = theme.Set(writer, style);
                    theme.Reset(writer);

                    string output = writer.ToString();
                    Assert.IsGreaterThan(
                        0,
                        writtenCharacterCount,
                        $"Theme {property.Name} did not define style {style}.");
                    StringAssert.StartsWith(
                        output,
                        "\u001b[",
                        $"Theme {property.Name} style {style} did not emit an ANSI sequence.");
                }
            }
        }

        [TestMethod]
        public void EigenverftDark_UsesTheCurrentEigenverftPalette()
        {
            AssertStyle(
                AnsiConsoleThemes.EigenverftDark,
                ConsoleThemeStyle.Text,
                "\u001b[38;2;217;240;255m");
            AssertStyle(
                AnsiConsoleThemes.EigenverftDark,
                ConsoleThemeStyle.String,
                "\u001b[38;2;214;255;238m");
            AssertStyle(
                AnsiConsoleThemes.EigenverftDark,
                ConsoleThemeStyle.LevelWarning,
                "\u001b[1;38;2;255;254;208m");
            AssertStyle(
                AnsiConsoleThemes.EigenverftDark,
                ConsoleThemeStyle.LevelError,
                "\u001b[1;38;2;255;204;208m");
            AssertStyle(
                AnsiConsoleThemes.EigenverftDark,
                ConsoleThemeStyle.LevelFatal,
                "\u001b[1;38;2;251;248;243;48;2;75;0;0m");
        }

        private static PropertyInfo[] GetThemeProperties()
        {
            return typeof(AnsiConsoleThemes)
                .GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(property => property.PropertyType == typeof(AnsiConsoleTheme))
                .OrderBy(property => property.Name, StringComparer.Ordinal)
                .ToArray();
        }

        private static void AssertStyle(
            AnsiConsoleTheme theme,
            ConsoleThemeStyle style,
            string expectedSequence)
        {
            using var writer = new StringWriter();
            int writtenCharacterCount = theme.Set(writer, style);

            Assert.AreEqual(expectedSequence.Length, writtenCharacterCount);
            Assert.AreEqual(expectedSequence, writer.ToString());
        }
    }
}
