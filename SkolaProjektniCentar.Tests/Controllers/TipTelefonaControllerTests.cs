using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkolaProjektniCentar.Controllers;

namespace SkolaProjektniCentar.Tests.Controllers
{
    [TestClass]
    public class TipTelefonaControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            //Arange
            SkolaContext _context = new SkolaContext();
            TipTelefonaControllerTests controller = new TipTelefonaControllerTests();
            //Act
            var result = _context.TipTelefona;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
