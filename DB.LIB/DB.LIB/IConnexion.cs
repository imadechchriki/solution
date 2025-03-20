using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DB.LIB{
    
    internal interface IConnexion : IDisposable
    {
        void Connect();
        int iud(string sql, Dictionary<string, object> parameters);
        IDataReader select(string sql, Dictionary<string, object> parameters);
    }
    }