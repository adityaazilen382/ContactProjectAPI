namespace ContactAPI.Common.Helper
{
    using System;

    /// <summary>
    /// Defines the <see cref="Util" />
    /// </summary>
    public class Util
    {
        /// <summary>
        /// The CheckForCredentials
        /// </summary>
        /// <param name="authorizationParameter">The authorizationParameter<see cref="string"/></param>
        /// <param name="userName">The userName<see cref="string"/></param>
        /// <param name="password">The password<see cref="string"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool CheckForCredentials(string authorizationParameter, out string userName, out string password)
        {
            userName = null;
            password = null;
            byte[] credentialBytes;
            try
            {
                credentialBytes = Convert.FromBase64String(authorizationParameter);
            }
            catch (FormatException)
            {
                return false;
            }

            var encoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            var decodedCredentials = encoding.GetString(credentialBytes);
            if (string.IsNullOrEmpty(decodedCredentials))
            {
                return false;
            }

            int colonIndex = decodedCredentials.IndexOf(':');
            if (colonIndex == -1)
            {
                return false;
            }

            userName = decodedCredentials.Substring(0, colonIndex);
            password = decodedCredentials.Substring(colonIndex + 1);
            return !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password);
        }
    }
}
