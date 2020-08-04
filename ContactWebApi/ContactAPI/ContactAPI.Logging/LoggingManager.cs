using log4net;
using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace ContactAPI.Logging
{
    public sealed class LoggingManager : ILoggingManager
    {
        #region Variable Declarations
        private readonly ILog _logger;
        #endregion

        static LoggingManager()
        {

            // Gets directory path of the calling application
            // RelativeSearchPath is null if the executing assembly i.e. calling assembly is a
            // stand alone exe file (Console, WinForm, etc). 
            // RelativeSearchPath is not null if the calling assembly is a web hosted application i.e. a web site

            var log4NetConfigDirectory = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;

            var log4NetConfigFilePath = Path.Combine(log4NetConfigDirectory, "log4net.config");
            GlobalContext.Properties["LogFileName"] = Path.Combine(ConfigurationManager.AppSettings["LogFilePath"] + "ContactAPILog" + ".log");
        }
        readonly string messageFormat = "Message Format: message: {0}, exception: {1}";
        public LoggingManager(Type logClass)
        {
            _logger = log4net.LogManager.GetLogger(logClass);
        }

        /// <summary>
        /// Info Message Import.
        /// </summary>
        /// <param name="Direction">Request/Response</param>
        /// <param name="MessageID">Reference MessageId/AppLogId</param>
        /// <param name="ManagerName">Restaurant/User/Loyalty/Hotel/ServiceDiscovery/Transaction</param>
        /// <param name="MessageType">GET/POST [Api URL]</param>
        /// <param name="MessageBody">Request/Response Body</param> 
        public long AddInfoLogSync(string Direction, long MessageID, string ManagerName, string MessageType, string MessageBody, string RestID, string PlayerID)
        {
            long MessageId = 0;
            if (_logger.IsDebugEnabled)
            {
                _logger.DebugFormat(messageFormat, MessageType, MessageBody);
            }
            else if (_logger.IsInfoEnabled)
            {
                _logger.InfoFormat(messageFormat, MessageType, MessageBody);
            }

            return MessageId;
        }

        public long AddInfoLog(string Direction, long MessageID, string ManagerName, string MessageType, string MessageBody, string RestID, string PlayerID = null)
        {
            long MessageId = 0;
            if (MessageID > 0)
                Task.Run(() =>
                {
                    MessageId = AddInfoLogSync(Direction, MessageID, ManagerName, MessageType, MessageBody, RestID, PlayerID);
                });
            else
                MessageId = AddInfoLogSync(Direction, MessageID, ManagerName, MessageType, MessageBody, RestID, PlayerID);
            return MessageId;
        }
    }
}
