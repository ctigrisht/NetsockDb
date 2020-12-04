using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib.Models
{
    public class InsertQuery
    {
        public InsertQuery(ref SockCollection collection)
        {

        }

        public string[] Directives { get; set; }
        public string Doc { get; set; }

        public static string Serialize(Dictionary<string, dynamic> doc)
        {

            return null;
        }

        public static string Serialize<OriginType>(dynamic obj)
        {


            return null;
        }
    }
}
