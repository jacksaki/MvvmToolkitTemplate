using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmToolkitTemplate {
    public static class Extensions {
        public static string GetEnumText(this System.Enum value) {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attrs = fieldInfo.GetCustomAttributes(typeof(EnumTextAttribute), false) as EnumTextAttribute[];
            if (attrs != null && attrs.Length > 0) {
                return attrs[0].Text;
            } else {
                return value.ToString();
            }
        }
        public static int? ToIntN(this object value) {
            if (value == null || value == DBNull.Value) {
                return null;
            }
            return int.TryParse(value.ToString(), out int ret) ? ret : (int?)null;
        }
        public static int ToInt32(this object value) {
            return value.ToIntN() ?? default(int);
        }
        public static int ToInt32(this object value, int defaultValue) {
            return value.ToIntN() ?? defaultValue;
        }
        public static decimal? ToDecimalN(this object value) {
            if (value == null || value == DBNull.Value) {
                return null;
            }
            return decimal.TryParse(value.ToString(), out decimal ret) ? ret : (decimal?)null;
        }
        public static decimal ToDecimal(this object value) {
            return value.ToDecimalN() ?? default(decimal);
        }
        public static decimal ToDecimal(this object value, decimal defaultValue) {
            return value.ToDecimalN() ?? defaultValue;
        }
        public static double? ToDoubleN(this object value) {
            if (value == null || value == DBNull.Value) {
                return null;
            }
            return double.TryParse(value.ToString(), out double ret) ? ret : (double?)null;
        }
        public static double ToDouble(this object value) {
            return value.ToDoubleN() ?? default(double);
        }
        public static double ToDouble(this object value, double defaultValue) {
            return value.ToDoubleN() ?? defaultValue;
        }
        public static float? ToFloatN(this object value) {
            if (value == null || value == DBNull.Value) {
                return null;
            }
            return float.TryParse(value.ToString(), out float ret) ? ret : (float?)null;
        }
        public static double ToFloat(this object value) {
            return value.ToFloatN() ?? default(float);
        }
        public static double ToFloat(this object value, float defaultValue) {
            return value.ToFloatN() ?? defaultValue;
        }
        public static DateTime? ToDateTimeN(this object value, string dateFormat) {
            if (value == null || value == DBNull.Value) {
                return null;
            }
            return DateTime.TryParseExact(value.ToString(), dateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime ret) ? ret : (DateTime?)null;
        }

        public static DateTime? ToDateTime(this object value) {
            if (value == null || value == DBNull.Value) {
                return null;
            }
            if (value is DateTime) {
                return (DateTime)value;
            }
            if (value is DateTime?) {
                return (DateTime?)value;
            }
            return null;
        }

        public static DateTime ToDateTime(this object value, string dateFormat) {
            return value.ToDateTimeN(dateFormat) ?? default(DateTime);
        }
        public static DateTime ToDateTime(this object value, string dateFormat, DateTime defaultValue) {
            return value.ToDateTimeN(dateFormat) ?? defaultValue;
        }
        public static DateTime ToDateTime(this object value, DateTime defaultValue) {
            if (value == null || value == DBNull.Value) {
                return defaultValue;
            }
            return value is DateTime ? (DateTime)value : defaultValue;
        }
        public static long? ToLongN(this object value) {
            if (value == null || value == DBNull.Value) {
                return null;
            }
            long ret;
            return long.TryParse(value.ToString(), out ret) ? ret : (long?)null;
        }

        public static long ToLong(this object value, long defaultValue) {
            return value.ToLongN() ?? defaultValue;
        }
    }
}
