using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YaToDo.Controllers;
using YaToDo.Tests.Fakes;
using YaToDo.Tests.Helpers;
using NUnit.Framework;
using System.Web.Mvc;

namespace YaToDo.Tests.Controllers
{
    [TestFixture]
    public class ToDoControllerTest
    {
        private static IEnumerable<dynamic> testToDos = FakeToDoData.CreateToDosData();
        private IService _session = UnitTestHelpers.MockToDoService(testToDos);

        ToDoController CreateToDoController()
        {
            var testData = testToDos;

            var session = _session;

            return new ToDoController(session);
        }

        [Test]
        public void Index_Should_Return_A_View()
        {
            // Arrange
            var controller = new ToDoController(_session);

            // Act
            var result = (ViewResult)controller.Index();

            // Assert
            Assert.IsInstanceOf(typeof(ViewResult), result);
        }


        [Test]
        public void Index_Message_Should_Be_Correct()
        {
            // Arrange
            var controller = new ToDoController(_session);

            // Act
            var result = (ViewResult)controller.Index();

            // Assert
            Assert.AreEqual(result.ViewBag.Message, "Welcome to YaToDo - A Massive Sample!");
        }

        [Test]
        public void Index_Should_Return_Four_ToDoLists()
        {
            // Arrange
            var controller = new ToDoController(_session);

            // Act
            var result = (ViewResult)controller.Index();
            dynamic resultModel = (dynamic)result.Model;

            // Assert
            Assert.AreEqual(4, resultModel.Count);
        }

        [Test]
        public void Search_Should_Return_ToDoList_With_Title_Like_Search_Term()
        {
            // Arrange
            var controller = new ToDoController(_session);

            // Act
            var result = (ViewResult)controller.Search("t");
            dynamic resultModel = (dynamic)result.Model;

            bool foundToDoWithOutSearchTerm = false;
            foreach (var item in resultModel)
            {
                bool contains = item.Title.Contains("t");
                if (!(contains)) foundToDoWithOutSearchTerm = true;
            }

            // Assert
            Assert.AreEqual(false, foundToDoWithOutSearchTerm);
        }

    }
}
