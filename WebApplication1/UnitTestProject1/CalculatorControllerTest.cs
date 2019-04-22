using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Controllers;
using System.Web.Mvc;
namespace UnitTestProject1
{
    [TestClass]
    public class CalculatorControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            CalculatorController controller = new CalculatorController();

            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);

        }


        [TestMethod]
        public void TestAuthor()
        {
            var controller = new CalculatorController();
            var result = controller.ShowAuthor();

            Assert.AreEqual("Nguyen Dinh Anh Quoc", result);
        }

        [TestMethod]

        public void TestFactorial()
        {
            
            var controller = new CalculatorController();
            Object result = controller.Factorial(3);
            
            
            Assert.AreEqual(6,result);
        }

        [TestMethod]

        public void TestSum()
        {
            var controller = new CalculatorController();
            object result = controller.Sum(3,6);
            Assert.AreEqual(9, result);

            
        }  



    }    
    
}
