using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace SharedLib.Models.Serialization
{
    public static class SdgParser
    {

    }

    public static class SerialisationUtils
    {
        public static T GetPropertyValue<T>(this object obj, string propName) => (T)obj.GetType().GetProperty(propName)?.GetValue(obj, null);

        public static SdgType GetSdgType(this Type type)
        {
            if (type.IsClass)
                return SdgType.obj;
            else if (type == typeof(string))
                return SdgType.str;
            else if (type == typeof(bool))
                return SdgType.bol;
            else if (type == typeof(Guid))
                return SdgType.guid;
            else if (UtilsData.NumTypes.Contains(type))
                return SdgType.num;
            else if (type == typeof(object))
                return SdgType.obj;


            else return SdgType.dyn;
        }
    }

    public static class DeserializationUtils
    {
        public static string[] GetLines(string sdgstring)
        {
            var lines = sdgstring.Split(';', StringSplitOptions.RemoveEmptyEntries);
            var nlns = new string[0];
            foreach (var line in lines)
                nlns.Append(line.Trim());
            return nlns;
        }

        public static string[] GetValueLines(string sdgdoc)
        {
            var lines = GetLines(sdgdoc);
            var nls = new string[0];
            foreach (var line in lines)
            {
                if (line.StartsWith("//")) continue;
                nls.Append(line);
            }
            return nls;
        }

        public static Dictionary<string, SdgValue> ParseSdgDoc(this string sdgdoc)
        {
            var lines = GetValueLines(sdgdoc);



        }

        public static Tuple<string, SdgValue> ParseSdgLine(string line)
        {
            var value = new SdgValue();

            var parts = line.Split('=');

            var rawElems = parts[0].Split(' ');

            var attribs = Array.FindAll(rawElems, x => x[0] is '#');
            var elements = rawElems[(attribs.Length-1)..];
            //var elements = Array.FindAll(rawElems, x => !attribs.Contains(x));
            
            var key = elements[0];
            value.DataType = Enum.Parse<SdgType>(elements[1]);

            switch (value.DataType)
            {
                case SdgType.str:
                    value.Value = ParseSTR(parts[1]);
                    break;
                case SdgType.num:

                    break;

            }
        }

        static SdgValue ParseSTR(string val)
        {

            return default;
        }

        static SdgValue ParseNUM(string val)
        {

            return default;
        }
        static SdgValue ParseLNG(string val)
        {
            var sdg = new SdgValue()
            {
                Value = long.TryParse(val, out var cval) ? cval : 0,
                DataType = SdgType.lng,
            };
        }

        static SdgValue ParseDEC(string val)
        {

        }

        static SdgValue ParseBOL(string val)
        {

            return default;
        }
        static SdgValue ParseOBJ(string val)
        {

            return default;
        }
        static SdgValue ParseGUID(string val)
        {

            return default;
        }
        static SdgValue ParseDYN(string val, bool tryCast = false)
        {

            return default;
        }

    }

    public static class SdgMapper
    {
        public static SdgMap MapType<TypeToMap>()
        {
            var objtype = typeof(TypeToMap);
            var map = new SdgMap();


            foreach (var pinfo in objtype.GetProperties())
            {
                var sdgval = new SdgValue();

                var keyname = pinfo.Name;
                var type = pinfo.PropertyType.GetSdgType();

                sdgval.DataType = type;

                map.MapDict.Add(keyname, sdgval);
                //sdgval.
            }

            return map;
        }
    }

    public static class SdgMaps
    {
        public static Dictionary<Type, SdgMap> ObjectMaps = new Dictionary<Type, SdgMap>();





    }

}
