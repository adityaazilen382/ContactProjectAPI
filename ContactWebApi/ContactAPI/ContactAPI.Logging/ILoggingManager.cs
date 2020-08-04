namespace ContactAPI.Logging
{
    public interface ILoggingManager
    {
        /// <summary>
        /// Info Message Import.
        /// </summary>
        /// <param name="Direction">Request/Response</param>
        /// <param name="MessageID">Reference MessageId/AppLogId</param>
        /// <param name="ManagerName">Restaurant/User/Loyalty/Hotel/ServiceDiscovery/Transaction</param>
        /// <param name="MessageType">GET/POST [Api URL]</param>
        /// <param name="MessageBody">Request/Response Body</param> 
        long AddInfoLog(string Direction, long MessageID, string ManagerName, string MessageType, string MessageBody, string RestID, string PlayerID);
    }
}
