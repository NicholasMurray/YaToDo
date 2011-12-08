using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Massive;
using YaToDo.Models;

namespace YaToDo.Tests.Helpers
{
    public static class UnitTestHelpers
    {
        public static void ShouldEqual<T>(this T actualValue, T expectedValue)
        {
            Assert.AreEqual(expectedValue, actualValue);
        }


        public static IService MockToDoService(IEnumerable<dynamic> ToDos)
        {
            var mockService = new Mock<IService>();

            mockService.Setup(x => x.All<ToDos>(It.IsAny<string>(), It.IsAny<string>(),
                                                It.IsAny<int>(), It.IsAny<string>(),
                                                It.IsAny<object>())).Returns(ToDos.AsEnumerable());

            mockService.Setup(x => x.All<ToDos>(It.IsAny<string>(), It.IsAny<string>(),
                                                It.IsAny<int>(), It.IsAny<string>(),
                                                "Get Milk")).Returns(ToDos.AsEnumerable()
                                                .Where(x => x.Title == "Get Milk"));


            mockService.Setup(x => x.All<ToDos>("WHERE Title like @0", It.IsAny<string>(),
                                                It.IsAny<int>(), It.IsAny<string>(),
                                                "t")).Returns(ToDos.AsEnumerable()
                                                .Where(x => x.Title.Contains("t")));

            return mockService.Object;
        }


    }
}
