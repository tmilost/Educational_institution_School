using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkolaProjektniCentar.Controllers;

namespace SkolaProjektniCentar.Tests.Controllers
{
    [TestClass()]
    public class SkolaControllesTest
    {
        [TestMethod()]
        public void IndexTest()
        {
            //Arange
            SkolaContext _context = new SkolaContext();
            SkolaController controller = new SkolaController();
            //Act
            var result = _context.Skola;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
