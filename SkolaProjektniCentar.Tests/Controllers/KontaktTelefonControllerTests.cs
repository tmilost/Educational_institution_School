using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SkolaProjektniCentar.Tests.Controllers
{
    [TestClass]
    public class KontaktTelefonControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            //Arange
            SkolaContext _context = new SkolaContext();
            KontaktTelefonControllerTests controller = new KontaktTelefonControllerTests();
            //Act
            var result = _context.KontaktTelefon;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
