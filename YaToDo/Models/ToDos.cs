using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Massive;

namespace YaToDo.Models
{
    public class ToDos : DynamicModel
    {
        public ToDos()
            : base("YaToDo")
        {
            PrimaryKeyField = "Id";
        }
    }
}