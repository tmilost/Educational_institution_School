using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkolaProjektniCentar.Controllers;

namespace SkolaProjektniCentar.Tests.Controllers
{
    [TestClass]
    public class MailListeControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            //Arange
            SkolaContext _context = new SkolaContext();
            MailListeControllerTests controller = new MailListeControllerTests();
            //Act
            var result = _context.MailListe;
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
