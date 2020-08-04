namespace ContactAPI.Common
{
    public class Constants
    {
        public static readonly string ConnectionString = "ConnectionString";
        public class DBCommands
        {
            public static readonly string USP_ContactDetails_Add = "USP_ContactDetails_Add";
            public static readonly string USP_ContactDetails_Delete = "USP_ContactDetails_Delete";
            public static readonly string USP_ContactDetails_Update = "USP_ContactDetails_Update";
            public static readonly string USP_ContactDetails_GetAll = "USP_ContactDetails_GetAll";
        }
    }
}
