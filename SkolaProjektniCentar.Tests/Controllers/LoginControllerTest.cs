using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SkolaProjektniCentar.Tests.Controllers
{
    [TestClass]
    public class LoginControllerTest
    {
        [TestMethod()]
        public void IndexTest()
        {
            //Arange
            SkolaContext _context = new SkolaContext();
            LoginControllerTest controller = new LoginControllerTest();
            //Act
            var result = _context.Skola;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
