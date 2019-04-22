using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Controllers;


namespace UnitTestProject1
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result); 
        }
           
        [TestMethod]
        public void TestAbout()
        {
            var controller = new HomeController();
            ViewResult result = controller.About() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestContact()
        {
            var controller = new HomeController();
            ViewResult result = controller.Contact() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestTemplate()
        {
            var controller = new HomeController();
            ViewResult result = controller.Template() as ViewResult;
            Assert.IsNotNull(result);
        }


    }
}
