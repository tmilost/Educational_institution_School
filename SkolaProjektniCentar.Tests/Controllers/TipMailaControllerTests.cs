using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkolaProjektniCentar.Controllers;

namespace SkolaProjektniCentar.Tests.Controllers
{
    [TestClass]
    public class TipMailaControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            //Arange
            SkolaContext _context = new SkolaContext();
            TipMailaControllerTests controller = new TipMailaControllerTests();
            //Act
            var result = _context.TipMaila;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
