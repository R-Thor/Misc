using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Logging
{
    class Program
    {
        //public static U EnterpriseLibraryContainer 
        //public static UnityContainer UC { get; private set; }
        //public static LogWriter defaultWriter;
        static void Main(string[] args)
        {
            //UC = new UnityContainer();
            // Formatter
            //TextFormatter briefFormatter = new TextFormatter();

            //// Trace Listener
            //var flatFileTraceListener = new FlatFileTraceListener(
            //  @"C:\Temp\FlatFile.log",
            //  "----------------------------------------",
            //  "----------------------------------------",
            //  briefFormatter);

            //// Build Configuration
            //var config = new LoggingConfiguration();

            //config.AddLogSource("DiskFiles", new TraceListener[] { flatFileTraceListener });
            //var x = config.AllTraceListeners;
            ////.AddTraceListener(flatFileTraceListener);

            //LogWriter defaultwriter = new LogWriter(config);
            //UC.RegisterInstance(defaultwriter);
            //defaultWriter = UC.Resolve<LogWriter>();
            //// Check if logging is enabled before creating log entries.
            //LogWriter defaultWriter = new LogWriter()
            LoggingConfiguration loggingConfiguration = BuildProgrammaticConfig();
            LogWriter defaultWriter = new LogWriter(loggingConfiguration);
            if (defaultWriter.IsLoggingEnabled())
            {
                defaultWriter.Write("Log entry created using the simplest overload.");
                defaultWriter.Write("Log entry with a single category.", "General");
                defaultWriter.Write("Log entry with a category, priority, and event ID.",
                                    "General", 6, 9001);
                defaultWriter.Write("Log entry with a category, priority, event ID, "
                                    + "and severity.", "General", 5, 9002,
                                    TraceEventType.Warning);
                defaultWriter.Write("Log entry with a category, priority, event ID, "
                                    + "severity, and title.", "General", 8, 9003,
                                    TraceEventType.Warning, "Logging Block Examples");

            }
            else
            {
                Console.WriteLine("Logging is disabled in the configuration.");
            }
            //// Check if logging is enabled before creating log entries.
            //if (defaultWriter.IsLoggingEnabled())
            //{
            //    // Create a string array (or List<>) containing the categories.
            //    string[] logCategories = new string[] { "DiskFiles", "Important" };

            //    // Write the log entries using these categories.
            //    defaultWriter.Write("Log entry with multiple categories.", logCategories);
            //    defaultWriter.Write("Log entry with multiple categories, a priority, "
            //                        + "and an event ID.", logCategories, 7, 9004);
            //    defaultWriter.Write("Log entry with multiple categories, a priority, "
            //                        + "event ID, severity, and title.", logCategories, 10,
            //                        9005, TraceEventType.Critical, "Logging Block Examples");
            //}
            //else
            //{
            //    Console.WriteLine("Logging is disabled in the configuration.");
            //}
            //// Check if logging is enabled before creating log entries.
            //if (defaultWriter.IsLoggingEnabled())
            //{
            //    // Create a Dictionary of extended properties
            //    Dictionary<string, object> exProperties = new Dictionary<string, object>();
            //    exProperties.Add("Extra Information", "Some Special Value");

            //    // Create a LogEntry using the constructor parameters. 
            //    LogEntry entry1 = new LogEntry("LogEntry with category, priority, event ID, "
            //                                   + "severity, and title.", "General", 8, 9006,
            //                                   TraceEventType.Error, "Logging Block Examples",
            //                                   exProperties);
            //    defaultWriter.Write(entry1);

            //    // Create a LogEntry and populate the individual properties.
            //    LogEntry entry2 = new LogEntry();
            //    entry2.Categories = new string[] { "General" };
            //    entry2.EventId = 9007;
            //    entry2.Message = "LogEntry with individual properties specified.";
            //    entry2.Priority = 9;
            //    entry2.Severity = TraceEventType.Warning;
            //    entry2.Title = "Logging Block Examples";
            //    entry2.ExtendedProperties = exProperties;
            //    defaultWriter.Write(entry2);
            //}
            //else
            //{
            //    Console.WriteLine("Logging is disabled in the configuration.");
            //}
            //// Check if logging is enabled before creating log entries.
            //if (defaultWriter.IsLoggingEnabled())
            //{
            //    // Create log entry to be processed by the "Unprocessed" special source.
            //    defaultWriter.Write("Entry with category not defined in configuration.",
            //                        "InvalidCategory");

            //    // Create log entry to be processed by the "Errors & Warnings" special source.
            //    defaultWriter.Write("Entry that causes a logging error.", "CauseLoggingError");
            //}
            //else
            //{
            //    Console.WriteLine("Logging is disabled in the configuration.");
            //}
            //// Check if logging is enabled before creating log entries.
            //if (defaultWriter.IsLoggingEnabled())
            //{
            //    // Create a Dictionary of extended properties
            //    Dictionary<string, object> exProperties = new Dictionary<string, object>();
            //    exProperties.Add("Extra Information", "Some Special Value");

            //    // Create a LogEntry using the constructor parameters.
            //    defaultWriter.Write("Log entry with category, priority, event ID, severity, "
            //                        + "title, and extended properties.", "Database",
            //                        5, 9008, TraceEventType.Warning,
            //                        "Logging Block Examples", exProperties);

            //    // Create a LogEntry using the constructor parameters. 
            //    LogEntry entry = new LogEntry("LogEntry with category, priority, event ID, "
            //                                  + "severity, title, and extended properties.",
            //                                  "Database", 8, 9009, TraceEventType.Error,
            //                                  "Logging Block Examples", exProperties);
            //    defaultWriter.Write(entry);
            //}
            //else
            //{
            //    Console.WriteLine("Logging is disabled in the configuration.");
            //}
            //// Check if logging is enabled before creating log entries.
            ////if (defaultWriter.IsLoggingEnabled())
            ////{
            ////    // Create a new LogEntry with two categories and priority 3.
            ////    string[] logCategories = new string[] { "General", "DiskFiles" };
            ////    LogEntry entry1 = new LogEntry("LogEntry with categories 'General' and "
            ////                                   + "'DiskFiles' and Priority 3.", logCategories,
            ////                                   3, 9009, TraceEventType.Error,
            ////                                   "Logging Block Examples", null);
            ////    ShowDetailsAndAddExtraInfo(entry1);

            ////    // Create a new LogEntry with one category and priority 1.
            ////    logCategories = new string[] { "BlockedByFilter" };
            ////    LogEntry entry2 = new LogEntry("LogEntry with category 'BlockedByFilter' and "
            ////                                   + "Priority 1.", logCategories, 1, 9010,
            ////                                   TraceEventType.Information,
            ////                                   "Logging Block Examples", null);
            ////    ShowDetailsAndAddExtraInfo(entry2);
            ////}
            ////else
            ////{
            ////    Console.WriteLine("Logging is disabled in the configuration.");
            ////}

        }

        private static LoggingConfiguration BuildProgrammaticConfig()
        {
            // Formatter
            var formatter = new TextFormatter();

            // Trace Listeners
            var eventLog = new EventLog("Application", ".", "StackOverflow #24309323");
            var eventLogTraceListener = new FormattedEventLogTraceListener(eventLog, formatter);

            // Build Configuration
            var config = new LoggingConfiguration();
            config.AddLogSource("General", SourceLevels.All, true)
                  .AddTraceListener(eventLogTraceListener);

            config.IsTracingEnabled = true;
            return config;
        }
        //void ShowDetailsAndAddExtraInfo(LogEntry entry)
        //{
        //    // Display information about the Trace Sources and Listeners for this LogEntry. 
        //    IEnumerable<LogSource> sources = defaultWriter.GetMatchingTraceSources(entry);
        //    foreach (LogSource source in sources)
        //    {
        //        Console.WriteLine("Log Source name: '{0}'", source.Name);
        //        foreach (TraceListener listener in source.Listeners)
        //        {
        //            Console.WriteLine(" - Listener name: '{0}'", listener.Name);
        //        }
        //    }
        //}
    }
}
