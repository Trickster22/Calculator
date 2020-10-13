using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorProject.Manager
{
    public interface ICalcManager
    {
        double Sum(double FirstNum,double SecNum);
        double Multip(double FirstNum, double SecNum);

        double Div(double FirstNum, double SecNum);

        double Degree(double FirstNum, double SecNum);

        double Subtraction(double FirstNum, double SecNum);
        double Mod(double FirstNum, double SecNum);

        double ArrayMultip(double[] numbers);
    }
}
