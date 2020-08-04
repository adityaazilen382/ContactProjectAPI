namespace ContactAPI.DAL
{
    using Common;
    using System.Data.SqlClient;

    /// <summary>
    /// Defines the <see cref="DBConnection" />
    /// </summary>
    public abstract class DBConnection
    {

        /// <summary>
        /// Defines the _sqlConnection
        /// </summary>
        private SqlConnection _sqlConnection;

        /// <summary>
        /// Gets the SQLConnection
        /// </summary>
        public SqlConnection SQLConnection
        {
            get
            {
                return _sqlConnection;
            }

            private set
            {
                _sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString());
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DBConnection"/> class.
        /// </summary>
        public DBConnection()
        {
            SQLConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[Constants.ConnectionString].ToString());
        }
    }
}
