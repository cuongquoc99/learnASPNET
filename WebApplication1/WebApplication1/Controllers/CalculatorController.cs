using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }

        public string ShowAuthor()
        {
            return "Nguyen Dinh Anh Quoc";
        }

        
        public int Factorial(int n)
        {
           
            int f = 1;
            for (int i = 2; i <= n; i++)
            
                f = f * i;
            return f;
            //http://localhost:11963/Calculator/Factorial/100 chay tren web danh cho public double Factorial(int id) && int n = id
            //http://localhost:11963/Calculator/Factorial/?n=100 public double Factorial(int n)
       
        }
        
        public int Sum(int a, int b)        
        {
            int result = 0;
            return result = a + b;

            //http://localhost:11963/Calculator/Sum/?a=10&b=20
        }


    }
}