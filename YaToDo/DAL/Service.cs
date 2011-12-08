using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Linq;
using System.Web;
using Massive;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;

namespace YaToDo
{


    public class Service : IService
    {
        public DynamicModel CreateTable<T>() where T : DynamicModel, new()
        {
            return new T();
        }


        public dynamic Single<T>(string where, params object[] args)
            where T : DynamicModel, new()
        {
            var table = CreateTable<T>();
            return table.Single(where, args);
        }

        public dynamic Single<T>(object key, string columns = "*")
            where T : DynamicModel, new()
        {
            var table = CreateTable<T>();
            return table.Single(key, columns);
        }

        public IEnumerable<dynamic> All<T>(string where = "", string orderBy = "", int limit = 0, string columns = "*", params object[] args)
            where T : DynamicModel, new()
        {
            var table = CreateTable<T>();
            return table.All(where, orderBy, limit, columns, args);
        }


    }
}