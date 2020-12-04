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

    public class DeserializationUtils
    {

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
