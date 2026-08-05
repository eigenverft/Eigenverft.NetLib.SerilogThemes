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
                [nameof(AnsiConsoleThemes.Aurora)] = AnsiConsoleThemes.Aurora,
                [nameof(AnsiConsoleThemes.Bloodline)] = AnsiConsoleThemes.Bloodline,
                [nameof(AnsiConsoleThemes.ClarionDusk)] = AnsiConsoleThemes.ClarionDusk,
                [nameof(AnsiConsoleThemes.CodingNight)] = AnsiConsoleThemes.CodingNight,
                [nameof(AnsiConsoleThemes.ProfessionalNoir)] = AnsiConsoleThemes.ProfessionalNoir,
                [nameof(AnsiConsoleThemes.RetroGreen)] = AnsiConsoleThemes.RetroGreen
            };

        private static async Task<int> Main(string[] args)
        {
            if (args.Any(argument => string.Equals(argument, "--list", StringComparison.OrdinalIgnoreCase)))
            {
                PrintAvailableThemes();
                return 0;
            }

            string requestedTheme = GetRequestedTheme(args) ?? nameof(AnsiConsoleThemes.EigenverftDark);

            if (!Themes.TryGetValue(requestedTheme, out AnsiConsoleTheme? theme))
            {
                global::System.Console.Error.WriteLine($"Unknown theme '{requestedTheme}'.");
                PrintAvailableThemes();
                return 2;
            }

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Verbose()
                .WriteTo.Console(
                    restrictedToMinimumLevel: LogEventLevel.Verbose,
                    theme: theme,
                    outputTemplate:
                        "[{Timestamp:HH:mm:ss.fff} {Level:u3}] " +
                        "{Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            try
            {
                using IHost host = Host.CreateDefaultBuilder(args)
                    .ConfigureLogging(logging =>
                    {
                        logging.ClearProviders();
                        logging.AddSerilog(Log.Logger, dispose: false);
                        logging.SetMinimumLevel(LogLevel.Trace);
                    })
                    .Build();

                await host.StartAsync().ConfigureAwait(false);

                WriteThemePreview(requestedTheme);

                ILogger<Program> microsoftLogger =
                    host.Services.GetRequiredService<ILogger<Program>>();

                microsoftLogger.LogInformation(
                    "Microsoft.Extensions.Logging is routed through the same Serilog logger and theme.");

                if (!global::System.Console.IsInputRedirected)
                {
                    global::System.Console.WriteLine();
                    global::System.Console.Write("Press any key to exit ...");
                    global::System.Console.ReadKey(intercept: true);
                    global::System.Console.WriteLine();
                }

                await host.StopAsync().ConfigureAwait(false);
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

        private static void WriteThemePreview(string themeName)
        {
            global::System.Console.WriteLine();
            global::System.Console.WriteLine($"Eigenverft Serilog theme preview: {themeName}");
            global::System.Console.WriteLine(new string('-', 56));

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
                    ? " (default)"
                    : string.Empty;

                global::System.Console.WriteLine($"  {themeName}{defaultMarker}");
            }
        }
    }
}
