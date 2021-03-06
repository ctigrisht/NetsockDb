﻿using System;
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

    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    sealed class SdgParamsAttribute : Attribute
    {
        readonly KeyAttribute[] attributes;

        public SdgParamsAttribute(KeyAttribute[] attributes)
        {
            this.attributes = attributes;

        }

        public KeyAttribute[] GetKeyAttribute
        {
            get { return attributes; }
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

        /// <summary>
        /// When deserializing, tries to find type and cast to the type
        /// </summary>
        cast = 20,
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

        /// <summary>
        /// string
        /// </summary>
        str = 1,

        /// <summary>
        /// general purpose numeric value, can be unsafe if used in typed languages, so do proper data validation
        /// </summary>
        num = 2,

        /// <summary>
        /// int16
        /// </summary>
        srt = 24,
        /// <summary>
        /// int32
        /// </summary>
        igr = 25,
        /// <summary>
        /// int64
        /// </summary>
        lng = 26,

        /// <summary>
        /// float
        /// </summary>
        flt = 27,

        /// <summary>
        /// double
        /// </summary>
        dbl = 28,

        /// <summary>
        /// decimal128
        /// </summary>
        dec = 31,

        /// <summary>
        /// boolean
        /// </summary>
        bol = 3,

        /// <summary>
        /// object
        /// </summary>
        obj = 4,


        // lists
        lst = 10,


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
