using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorProject.Manager
{
    public class CalcManager : ICalcManager
    {
        public CalcManager()
        {

        }

        public double Sum(double FirstNum,double SecondNum)
        {
            return (FirstNum+SecondNum);
        }

        public double Subtraction(double FirstNum, double SecondNum)
        {
            return (FirstNum - SecondNum);
        }

        public double Div(double FirstNum, double SecondNum)
        {
            return (FirstNum / SecondNum);
        }

        public double Degree(double FirstNum, double SecondNum)
        {
            double res=1;
            double FN = FirstNum;
            for (int i = 1; i < SecondNum; i++)
            {
                FirstNum = FirstNum * FN;
            }
            return FirstNum;
        }

        public double Multip(double FirstNum, double SecondNum)
        {
            return (FirstNum * SecondNum);
        }

        public double Mod(double FirstNum, double SecondNum)
        {
            return FirstNum % SecondNum;
        }

        public double ArrayMultip(double[] numbers)
        {
            double proizv = 1;
            bool Exist = false;
            if (numbers.Length < 15)
                throw new ArgumentException(
                    "Должно быть минимум 15 элементов.",
                    "numbers");
            foreach (double num in numbers)
            {
                if ((num < 54) && (num > 0))
                {
                    proizv *= num;
                    Exist = true;
                }
            }
            if (!Exist)
                throw new ArgumentException( "Не найдено подходящих чисел.","numbers");
            return proizv;
        }
       
    }
}
