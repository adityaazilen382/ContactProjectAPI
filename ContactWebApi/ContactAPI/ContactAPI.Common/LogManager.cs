using Microsoft.Practices.EnterpriseLibrary.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace ContactAPI.Common
{
    public class LogManager
    {
        #region Default Log
        /// <summary>
        ///  This method will log all the debug messages. To disable debug messages, change the logging setting 
        ///  for DEBUG category
        /// </summary>
        /// <param name="value"></param>
        public static void WriteDebug(object value)
        {
            WriteToDefaultLog(value, TraceEventType.Verbose);
        }

        /// <summary>
        ///  This method will log all the warning messages. To disable warning messages, change the logging setting 
        ///  for WARNING category
        /// </summary>
        /// <param name="value"></param>
        private static void WriteWarning(object value)
        {
            WriteToDefaultLog(value, TraceEventType.Warning);
        }

        private static void WriteToDefaultLog(object value, TraceEventType severity)
        {
            Logger.Write(value, "ContactAPILog", -1, 0, severity);
        }

        /// <summary>
        ///  This method will log all the error messages. It also make event log entry in MGM.CDC log source. To disable error messages, change the logging setting 
        ///  for ERROR category
        /// </summary>
        /// <param name="value"></param>
        public static void WriteError(object value)
        {
            WriteToDefaultLog(value, TraceEventType.Error);
        }

        /// <summary>
        ///  This method will log all the error messages. It also make event log entry in MGM.CDC log source. To disable error messages, change the logging setting 
        ///  for ERROR category
        /// </summary>
        /// <param name="value"></param>
        public static void WriteError(object value, Exception exp)
        {
            WriteToDefaultLog(value + " Mesg: " + exp.Message + " Stack:" + exp.StackTrace, TraceEventType.Error);
        }

        /// <summary>
        ///  This method will log all the info messages. To disable info messages, change the logging setting 
        ///  for INFO category
        /// </summary>
        /// <param name="value"></param>
        public static void WriteInfo(object value)
        {
            WriteToDefaultLog(value, TraceEventType.Information);
        }


        /// <summary>
        ///  This method will log all the info messages for object. To disable info messages, change the logging setting 
        ///  for INFO category
        /// </summary>
        /// <param name="value"></param>
        public static void WriteInfoObject(string msg, object value)
        {
            WriteToDefaultLog(msg + " " + JsonConvert.SerializeObject(value), TraceEventType.Information);
        }

        #endregion
    }
}