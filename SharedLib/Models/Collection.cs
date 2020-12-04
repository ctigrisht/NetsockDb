using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib.Models
{
    public class SockCollection
    {
        public DbEngineType EngineType { get; set; }
        private Stretch StretchEngine { get; set; }
        public Napalm NapalmEngine { get; set; }


    }
}
