using System;
using System.Linq;
using System.Collections.Generic;

namespace Calculator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var expression = "(10.1 + 20)";

            //expression.GetNextComponent()
            //    .ToList()
            //    .ForEach(x =>
            //    {
            //        System.Console.WriteLine(x);
            //    });

            var result = Evaluate(expression);

            System.Console.WriteLine(result);
        }

        public static double Evaluate (string input)
        {
            var service = new ReversePolishService();
            var rpnExpression = service.ConvertFromInfix(input);

            var result = service.EvaluateExpression(rpnExpression);

            return result;

        }
    }
}
