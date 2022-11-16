using System;
using System.Threading.Tasks;
using System.Threading;
using System.Data;
using System.Collections.Generic;
using IntegrationTest.Interfaces;
using Microsoft.AspNetCore.Mvc;
using IntegrationTest.Controllers;
using Xunit;
using Moq;


namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public  void  ItExists()
        {

            DemoController dmc = GetStdController();
            var result = dmc.get("hola");

            var isok = result as ContentResult;
            Assert.NotNull(isok);

            var retval = isok.Content as string;

            Assert.Equal("Exists", retval);
        }
        [Fact]
        public void NotExsts()
        {
            DemoController dmc = GetStdController();
            var result = dmc.get("Perón");
            var cnt = result as ContentResult;
            var nfr = result as NotFoundResult;

            Assert.Null(cnt);
            Assert.NotNull(nfr);

            var stdcode = nfr.StatusCode;

            Assert.Equal(404, stdcode);

          

        }

        private DemoController GetStdController()
        {
            var mockBDG = new Mock<IBDG>();
            mockBDG.Setup(M => M.GetList()).Returns(new List<string> { "hola", "mundo", "goat" });

            DemoController dmc = new DemoController(mockBDG.Object);

            return dmc;
        }
    }
}
