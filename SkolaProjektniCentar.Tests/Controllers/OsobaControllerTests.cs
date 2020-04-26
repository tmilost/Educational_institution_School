using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkolaProjektniCentar.Controllers;

namespace SkolaProjektniCentar.Tests.Controllers
{
    [TestClass]
    public class OsobaControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            //Arange
            SkolaContext _context = new SkolaContext();
            OsobaControllerTests controller = new OsobaControllerTests();
            //Act
            var result = _context.Osoba;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
