using System;

namespace ContactAPI.DAL.Utilities
{
    public class SafeDataUtil
    {
        private SafeDataUtil() { }

        public static int SafeInt(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                if (obj is string && ((string)obj).Trim().Length == 0)
                    return 0;
                try
                {
                    return (int)Convert.ToInt32(obj);
                }
                catch (Exception)
                {
                    return 0;
                }

            }
        }

        public static long SafeLong(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                if (obj is string && ((string)obj).Trim().Length == 0)
                    return 0;
                try
                {
                    return (long)Convert.ToInt64(obj);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static bool SafeBool(object obj)
        {
            if (obj is String)
            {
                string str = (string)obj;
                if (String.IsNullOrEmpty(str))
                {
                    return false;
                }
                else
                {
                    var bstr = str.Trim().ToUpper();
                    if ((bstr == "TRUE") || (bstr == "Y") || (bstr == "YES") || (bstr == "1") || (bstr == "S2S_ALL"))
                        return true;
                    else
                        return false;
                }
            }
            else
            {
                if (obj == null || obj == DBNull.Value)
                {
                    return false;
                }
                else
                {
                    try
                    {
                        return (bool)obj;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        public static DateTime SafeDateTime(string obj)
        {
            if (String.IsNullOrEmpty(obj))
            {
                return DateTime.MinValue;
            }
            else
            {
                try
                {

                    return DateTime.Parse(obj);
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
        }

        public static DateTime SafeDateTime(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return DateTime.MinValue;
            }
            else
            {
                try
                {
                    return (DateTime)obj;
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
        }

        public static DateTime? SafeNullableDateTime(object obj)
        {
            if (obj == null || obj is DBNull)
            {
                return null;
            }
            else
            {
                try
                {
                    return (DateTime)obj;
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }
        }

        public static TimeSpan SafeTime(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return TimeSpan.MinValue;
            }
            else
            {
                if (obj is DateTime)
                {
                    DateTime datetime = (DateTime)obj;
                    return datetime.TimeOfDay;
                }
                else if (obj is TimeSpan)
                {
                    return (TimeSpan)obj;
                }
                else
                {
                    //Try casting, if conversion supporte it will return.
                    try
                    {
                        return (TimeSpan)obj;
                    }
                    catch
                    {
                        return TimeSpan.MinValue;
                    }
                }
            }
        }


        public static byte SafeByte(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                try
                {

                    return Convert.ToByte(obj);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static decimal SafeDecimal(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                try
                {

                    return Convert.ToDecimal(obj);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static float SafeFloat(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                try
                {

                    return Convert.ToSingle(obj);
                }
                catch
                {
                    return 0;
                }
            }
        }


        public static double SafeDouble(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0.0;
            }
            else
            {
                try
                {

                    return Convert.ToDouble(obj);
                }
                catch
                {
                    return 0.0;
                }
            }
        }

        public static string SafeUpperStringNull(string obj)
        {
            var str = SafeStringNull(obj);
            if (str == null)
                return null;
            else
                return str.ToUpper().Trim();
        }

        public static string SafeStringNull(string obj)
        {
            if (obj == null)
                return null;
            if (obj.Trim().Length > 0)
                return obj.Trim();
            else
                return null;
        }

        public static string SafeString(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return "";
            }
            else
            {
                try
                {

                    return Convert.ToString(obj);
                }
                catch
                {
                    return "";
                }
            }
        }


        public static string GetFormattedFlightDateString(DateTime startDate, DateTime endDate)
        {
            string fmtStr = null;
            if (!startDate.Equals(null) && !endDate.Equals(null))
            {
                fmtStr = startDate.ToShortDateString() + " - " + endDate.ToShortDateString();
            }
            return fmtStr;
        }
    }
}
