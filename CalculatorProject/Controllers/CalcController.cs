
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalculatorProject.Manager;
using CalculatorProject.Classes;

namespace CalculatorProject.Controllers
{
    public class CalcController : Controller
    {
        private ICalcManager _CalcManager;
        public CalcController(ICalcManager CalcManager)
        {
            _CalcManager= CalcManager;
        }

        public ViewResult MainPage()
        {
            return View();
        }

        
        
        public ViewResult Calcpage()
        {
            return View();
        }

        public ViewResult Lab1Page()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Submit(string operations, string base_num)
        {
            operations = operations.Replace(" ", String.Empty);
            String[] stringSeparators = new string[] { "+", "-", "*", "/", "%", "^" };
            String[] numbers = operations.Split(stringSeparators, StringSplitOptions.None);
            String operation = operations.Replace(numbers[0], String.Empty);
            operation = operation.Replace(numbers[1], String.Empty);
            int basenum = 0;
            if (base_num != null)
            {
                basenum = Int32.Parse(base_num);
            }
            else { basenum = 10; }
            long[] temp_numbs = new long[2];

            temp_numbs[0] = BaseConvertation.ArbitraryToDecimalSystem(numbers[0],basenum);
            temp_numbs[1] = BaseConvertation.ArbitraryToDecimalSystem(numbers[1], basenum);
            long temp_res = 0;

            switch (operation)
            {
                case "+":
                    temp_res = long.Parse(Convert.ToString(_CalcManager.Sum(temp_numbs[0], temp_numbs[1])));
                    break;

                case"-":
                    temp_res = long.Parse(Convert.ToString(_CalcManager.Subtraction(temp_numbs[0], temp_numbs[1])));
                    break;

                case "*":
                    temp_res = long.Parse(Convert.ToString(_CalcManager.Multip(temp_numbs[0], temp_numbs[1])));
                    break;

                case "/":
                    temp_res = long.Parse(Convert.ToString(_CalcManager.Div(temp_numbs[0], temp_numbs[1])));
                    break;

                case "^":
                    temp_res = long.Parse(Convert.ToString(_CalcManager.Degree(temp_numbs[0], temp_numbs[1])));
                    break;

                case "%":
                    temp_res = long.Parse(Convert.ToString(_CalcManager.Mod(temp_numbs[0], temp_numbs[1])));
                    break;

            }
            String[] model = new String[5];
            model[0] = numbers[0];
            model[1] = operation;
            model[2] = numbers[1];
            model[3] = BaseConvertation.DecimalToArbitrarySystem(temp_res, basenum);
            model[4] = base_num;

            try
            {
                return View("Calcpage", model);
                //return RedirectToAction(nameof(Computation));
            }
            catch 
            {
                return RedirectToAction(nameof(Calcpage));
            }
        }
    }
}