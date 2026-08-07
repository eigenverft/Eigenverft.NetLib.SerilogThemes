using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Eigenverft.NetLib.SerilogThemes;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace Eigenverft.NetLib.SerilogThemes.Console
{
    internal class Program
    {
        private static readonly IReadOnlyDictionary<string, AnsiConsoleTheme> Themes =
            new Dictionary<string, AnsiConsoleTheme>(StringComparer.OrdinalIgnoreCase)
            {
                [nameof(AnsiConsoleThemes.EigenverftDark)] = AnsiConsoleThemes.EigenverftDark,
                [nameof(AnsiConsoleThemes.EigenverftHarbor)] = AnsiConsoleThemes.EigenverftHarbor,
                [nameof(AnsiConsoleThemes.Aurora)] = AnsiConsoleThemes.Aurora,
                [nameof(AnsiConsoleThemes.Bloodline)] = AnsiConsoleThemes.Bloodline,
                [nameof(AnsiConsoleThemes.ClarionDusk)] = AnsiConsoleThemes.ClarionDusk,
                [nameof(AnsiConsoleThemes.CodingNight)] = AnsiConsoleThemes.CodingNight,
                [nameof(AnsiConsoleThemes.ProfessionalNoir)] = AnsiConsoleThemes.ProfessionalNoir,
                [nameof(AnsiConsoleThemes.RetroGreen)] = AnsiConsoleThemes.RetroGreen,
                [nameof(AnsiConsoleThemes.SignalSlate)] = AnsiConsoleThemes.SignalSlate
            };

        private static async Task<int> Main(string[] args)
        {
            if (HasSwitch(args, "--list"))
            {
                PrintAvailableThemes();
                return 0;
            }

            string? requestedTheme = GetRequestedTheme(args);
            bool showAllThemes = requestedTheme is null || HasSwitch(args, "--all");

            if (showAllThemes)
            {
                global::System.Console.WriteLine("Eigenverft Serilog theme gallery");
                global::System.Console.WriteLine("Every available theme is rendered below using the same preview data.");

                foreach (KeyValuePair<string, AnsiConsoleTheme> entry in Themes)
                {
                    int exitCode = await RunThemePreviewAsync(entry.Key, entry.Value).ConfigureAwait(false);
                    if (exitCode != 0)
                    {
                        return exitCode;
                    }
                }

                PauseForExit();
                return 0;
            }

            string requestedThemeName = requestedTheme
                ?? throw new InvalidOperationException("A single-theme preview requires a theme name.");

            if (!Themes.TryGetValue(requestedThemeName, out AnsiConsoleTheme? theme))
            {
                global::System.Console.Error.WriteLine($"Unknown theme '{requestedThemeName}'.");
                PrintAvailableThemes();
                return 2;
            }

            int result = await RunThemePreviewAsync(requestedThemeName, theme).ConfigureAwait(false);
            if (result == 0)
            {
                PauseForExit();
            }

            return result;
        }

        private static async Task<int> RunThemePreviewAsync(string themeName, AnsiConsoleTheme theme)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Verbose()
                .MinimumLevel.Override("Microsoft.Hosting", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.Extensions.Hosting", LogEventLevel.Warning)
                .WriteTo.Console(
                    restrictedToMinimumLevel: LogEventLevel.Verbose,
                    theme: theme,
                    outputTemplate:
                        "[{Timestamp:HH:mm:ss.fff} {Level:u3}] " +
                        "{Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            try
            {
                using IHost host = Host.CreateDefaultBuilder(Array.Empty<string>())
                    .ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                        logging.AddSerilog(Log.Logger, dispose: false);
                        // The host is intentionally real so the demo proves that
                        // Microsoft.Extensions.Logging is routed through Serilog. Host lifecycle
                        // noise is suppressed by the Serilog SourceContext overrides above.
                        logging.SetMinimumLevel(LogLevel.Trace);
                    })
                    .Build();

                WriteThemeBlockHeader(themeName, theme);

                await host.StartAsync().ConfigureAwait(false);

                WriteThemePreview(themeName);

                ILogger<Program> microsoftLogger =
                    host.Services.GetRequiredService<ILogger<Program>>();

                microsoftLogger.LogInformation(
                    "Microsoft.Extensions.Logging is routed through the same Serilog logger and theme.");

                await host.StopAsync().ConfigureAwait(false);

                WriteThemeBlockFooter(theme);
                return 0;
            }
            catch (Exception exception)
            {
                Log.Fatal(exception, "The theme preview terminated unexpectedly.");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void WriteThemeBlockHeader(string themeName, AnsiConsoleTheme theme)
        {
            global::System.Console.WriteLine();
            WriteThemedLine(theme, ConsoleThemeStyle.SecondaryText, new string('=', 72));

            theme.Set(global::System.Console.Out, ConsoleThemeStyle.SecondaryText);
            global::System.Console.Write("THEME: ");
            theme.Set(global::System.Console.Out, ConsoleThemeStyle.Name);
            global::System.Console.WriteLine(themeName);
            theme.Reset(global::System.Console.Out);

            WriteThemedLine(theme, ConsoleThemeStyle.SecondaryText, new string('=', 72));
        }

        private static void WriteThemeBlockFooter(AnsiConsoleTheme theme)
        {
            WriteThemedLine(theme, ConsoleThemeStyle.SecondaryText, new string('=', 72));
        }

        private static void WriteThemedLine(
            AnsiConsoleTheme theme,
            ConsoleThemeStyle style,
            string text)
        {
            theme.Set(global::System.Console.Out, style);
            global::System.Console.WriteLine(text);
            theme.Reset(global::System.Console.Out);
        }

        private static void WriteThemePreview(string themeName)
        {
            Log.Verbose(
                "Verbose message: Starting operation with parameters {@Parameters}",
                new { Param1 = "Value1", Param2 = 123 });

            Log.Debug("Debug message: Processing step {StepNumber}", 1);

            Log.Information(
                "Information: Hello, Serilog! User {UserId} logged in at {LoginTime}",
                "user123",
                DateTimeOffset.Now);

            Log.Warning(
                "Warning: Disk space is low. Available: {AvailableSpace} MB",
                512);

            Log.Error(
                new InvalidOperationException("Simulated exception"),
                "Error: An exception occurred while processing request for user {UserId}",
                "user456");

            Log.Fatal(
                "Fatal: System crash imminent. System details: {@SystemDetails}",
                new { System = "MainSystem", Status = "Critical" });

            Log.Information(
                "Scalar values: Text={Text}, Number={Number}, Boolean={Boolean}, Null={NullValue}",
                "Eigenverft",
                42,
                true,
                null);

            Log.Information(
                "Structured application data: {@Application}",
                new
                {
                    Name = "Eigenverft.NetLib.SerilogThemes.Console",
                    Theme = themeName,
                    Environment = "Preview",
                    StartedAt = DateTimeOffset.Now
                });
        }

        private static bool HasSwitch(string[] args, string switchName)
        {
            return args.Any(argument => string.Equals(argument, switchName, StringComparison.OrdinalIgnoreCase));
        }

        private static string? GetRequestedTheme(string[] args)
        {
            for (int index = 0; index < args.Length; index++)
            {
                string argument = args[index];

                if (argument.StartsWith("--theme=", StringComparison.OrdinalIgnoreCase))
                {
                    return argument.Substring("--theme=".Length);
                }

                if (string.Equals(argument, "--theme", StringComparison.OrdinalIgnoreCase) &&
                    index + 1 < args.Length)
                {
                    return args[index + 1];
                }
            }

            return args.FirstOrDefault(argument => !argument.StartsWith("-", StringComparison.Ordinal));
        }

        private static void PrintAvailableThemes()
        {
            global::System.Console.WriteLine("Available themes:");

            foreach (string themeName in Themes.Keys)
            {
                string defaultMarker = string.Equals(
                    themeName,
                    nameof(AnsiConsoleThemes.EigenverftDark),
                    StringComparison.Ordinal)
                    ? " (Eigenverft default)"
                    : string.Empty;

                global::System.Console.WriteLine($"  {themeName}{defaultMarker}");
            }
        }

        private static void PauseForExit()
        {
            if (global::System.Console.IsInputRedirected)
            {
                return;
            }

            global::System.Console.WriteLine();
            global::System.Console.Write("Press any key to exit ...");
            global::System.Console.ReadKey(intercept: true);
            global::System.Console.WriteLine();
        }
    }
}
