using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaAppPedidos2.Services
{
    public  class Lector
    {
        public static DateTime safeGetDate(MySqlDataReader reader, string colName)
        {
            int colIndex = reader.GetOrdinal(colName);

            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetDateTime(colIndex);
            }
            else
            {
                return new DateTime(1999, 09, 19);
            }
        }
    }
}
