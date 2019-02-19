using System;
using System.Data;

namespace Trackables.Domain.Extensions
{
    public static class Extensions
    {
        public static decimal GetValue(this DataRow row, string columnName)
        {
            decimal value = 0.0m;

            if (row.IsNull(columnName))
            {
                return value;
            }
            else
            {
                Decimal.TryParse(row[columnName].ToString(), out value);
                return value;
            }
        }

        public static int? GetNullableInt(this DataRow row, string columnName)
        {
            if (row.IsNull(columnName))
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(row[columnName]);
            }
        }


        public static decimal? GetNullableDecimal(this DataRow row, string columnName)
        {
            if (row.IsNull(columnName))
            {
                return null;
            }
            else
            {
                return Convert.ToDecimal(row[columnName]);
            }
        }
    }
}
