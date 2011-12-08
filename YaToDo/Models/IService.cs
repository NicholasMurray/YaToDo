using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Massive;

namespace YaToDo
{
    public interface IService
    {
        DynamicModel CreateTable<T>() where T : DynamicModel, new();

        dynamic Single<T>(string where, params object[] args)
            where T : DynamicModel, new();

        dynamic Single<T>(object key, string columns = "*")
            where T : DynamicModel, new();

        IEnumerable<dynamic> All<T>(string where, string orderBy, int limit, string columns, params object[] args)
            where T : DynamicModel, new();

    }
}
