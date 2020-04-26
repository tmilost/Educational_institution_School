using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SkolaProjektniCentar.Tests.Controllers
{
    [TestClass]
    public class KorisnikControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            //Arange
            SkolaContext _context = new SkolaContext();
            KorisnikControllerTests controller = new KorisnikControllerTests();
            //Act
            var result = _context.Korisnik;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
