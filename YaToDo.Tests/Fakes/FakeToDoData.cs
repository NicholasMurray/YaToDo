using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace YaToDo.Tests.Fakes
{
    public class FakeToDoData
    {
        private static IEnumerable<dynamic> GetToDos()
        {
            var toDos = new List<dynamic>
            {
                new { Id = 1, Title = "Get Milk", Order = 1},
                new { Id = 2, Title = "Cut Grass", Order = 3},
                new { Id = 3, Title = "Post Letter", Order = 2},
                new { Id = 4, Title = "Do Shopping", Order = 4}
            };

            return toDos;
        }


        public static dynamic GetToDo() 
        {
            dynamic toDo = new { Id = 5, Title = "Get Bread", Order = 2 };

            return toDo;
        }


        public static IEnumerable<dynamic> CreateToDosData()
        {
            var toDos = GetToDos();

            return toDos;
        }



        public static FormCollection CreateToDoFormCollection()
        {
            var form = new FormCollection();

            form.Add("Title", " Buy Bread");

            return form;
        }


    }
}
