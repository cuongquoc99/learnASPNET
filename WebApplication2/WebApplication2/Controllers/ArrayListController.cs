using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ArrayListController : Controller
    {
        static object[] Buffer = new object[10];
        static int Length = 0;
        public ActionResult Index()
        {
            var model = new Tuple<object[], int>(Buffer, Length);
            return View(model);
            
        }
        public ActionResult Append(string value)
        {
            Buffer[Length] = value;
            Length++;
            return RedirectToAction("Index"); //http://localhost:2345/ArrayList/Append?value=123
        }

        public ActionResult Clear()
        {
            Length = 0;
            return RedirectToAction("Index");
        }

        public ActionResult InsertAt(int index, string value)
        {
            for (int i = Length - 1; i >= index; i--)
                Buffer[i + 1] = Buffer[i];
            Buffer[index] = value;
            Length++;

            return RedirectToAction("Index"); //http://localhost:2345/ArrayList/InsertAt?index=1&value=2
        }
    }
}