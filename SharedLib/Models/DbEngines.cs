using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib.Models
{
    public enum DbEngineType
    {
        Stretch,
        Sniper,
        Napalm
    }

    /// <summary>
    /// A DB engine is a method of managing the data in a Collection, all data is stored through a standard but loading a collection with a specific engine can optimize
    /// the speed at which queries are executed.
    /// 
    /// A collection can have 1 main engine type which will have Update/Delete capabilities
    /// But you can then initalize collection with other engines but they will only be able to Create/Read
    /// </summary>
    public class DbEngine
    {
        public DbEngineType EngineType { get; set; }
    }

    /// <summary>
    /// DB engine good at Create/Read ING a lot of documents in a single complex (3D) query
    /// </summary>
    public class Stretch : DbEngine
    {

    }

    /// <summary>
    /// Db engine specialized in finding/updating small batches of documents even without indexing
    /// </summary>
    public class Sniper : DbEngine
    {

    }

    /// <summary>
    /// Db engine good at updating random sections of data
    /// </summary>
    public class Napalm : DbEngine
    {

    }
}
