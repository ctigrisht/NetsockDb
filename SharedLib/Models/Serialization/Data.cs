using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLib.Models.Serialization
{

    public static class UtilsData
    {
        public static readonly Dictionary<string, SdgValue>
            BasicBlueprint = new Dictionary<string, SdgValue>();

        
        public static Type[] NumTypes = new Type[] {
                typeof(int),
                typeof(short),
                typeof(long),
                typeof(uint),
                typeof(ushort),
                typeof(ulong),
                typeof(float),
                typeof(double),
                typeof(decimal)
            };


    }

    public class SdgValue
    {
        public SdgType DataType = SdgType.dyn;
        public KeyAttribute[] Attributes = new KeyAttribute[0];
        public dynamic Value = null;

        /// <summary>
        /// For serialization
        /// </summary>
        public Type RuntimeType = null;
    }

    public class SdgMap
    {
        public Dictionary<string, SdgValue> MapDict = new Dictionary<string, SdgValue>();

    }

    [System.AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    sealed class SdgKeyAttribute : System.Attribute
    {
        readonly KeyAttribute attribute;

        public SdgKeyAttribute(KeyAttribute attribute)
        {
            this.attribute = attribute;

        }

        public KeyAttribute GetKeyAttribute
        {
            get { return attribute; }
        }
    }

    sealed class SdgTypeAttribute : System.Attribute
    {
        readonly SdgType attribute;

        public SdgTypeAttribute(SdgType type)
        {
            this.attribute = type;
        }

        public SdgType GetKeyAttribute
        {
            get { return attribute; }
        }
    }

    public enum KeyAttribute
    {
        /// <summary>
        /// Primary key, auto indexed
        /// </summary>
        pkey = 0,

        /// <summary>
        /// Geo hash Index key
        /// </summary>
        idx = 1,

        /// <summary>
        /// Stack/groud index
        /// </summary>
        sidx = 2,


    }

    public enum SdgType
    {
        /// <summary>
        /// Dynamic object of any type
        /// </summary>
        dyn = 999,

        // ID
        guid = 500,
        /// <summary>
        /// for Int64 id scheme
        /// </summary>
        lid = 501,

        // basic
        str = 1,
        num = 2,
        bol = 3,
        obj = 4,


        // lists



        // specialized

        /// <summary>
        /// DateTime
        /// </summary>
        date = 101,

        /// <summary>
        /// Timespan
        /// </summary>
        tspn = 102,

        /// <summary>
        /// Expression, TODO
        /// </summary>
        exp = 110,


        //binary

        ///// <summary>
        ///// Raw binary data
        ///// </summary>
        //bin = 151,

        /// <summary>
        /// Byte array
        /// </summary>
        bar = 167,

        // code
        cde = 30,
        js = 31,
        sql = 32,

        // operations
        oper = 40,
        numopr = 41,
        cnct = 42,
    }
}
