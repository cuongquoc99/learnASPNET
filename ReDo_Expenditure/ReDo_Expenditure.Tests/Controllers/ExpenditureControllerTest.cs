using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReDo_Expenditure.Controllers;
using ReDo_Expenditure.Models;

namespace ReDo_Expenditure.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIndex()
        {
            var db = new Entities();
            var controller = new ExpendituresController();

            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as List<Expenditure>;
            Assert.IsNotNull(model);

            Assert.AreEqual(db.Expenditures.Count(), model.Count);
        }

        [TestMethod]

    public void TestDetail()
        {
            var db = new Entities();
            var controller = new ExpendituresController();

          



        }

        [TestMethod]

        public void TestCreateG()
        {
            var controller = new ExpendituresController();

            var result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);

        }

        [TestMethod]

        public void TestEditG()
        {
            var controller = new ExpendituresController();
            var result0 = controller.Edit(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));

            var db = new Entities();
            var item = db.Expenditures.First();
            var result1 = controller.Edit(item.ID) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as Expenditure;
            Assert.AreEqual(item.ID, model.ID);
        }
    }




}
