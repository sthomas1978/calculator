using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Console
{
    public static class StringExtensions
    {
        public static IEnumerable<string> GetNextComponent(this string expression)
        {
            expression = expression.Trim();

            var componentChar = new List<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (Char.IsDigit(expression[i]) || expression[i] == '.')
                {
                    componentChar.Add(expression[i]);
                }
                else
                {
                    if (componentChar.Count() > 0)
                    {
                        yield return new string(componentChar.ToArray());
                        componentChar.Clear();
                    }

                    if (!(Char.IsWhiteSpace(expression[i])))
                    {
                        yield return new string(new char[] { expression[i] });
                    }
                }
            }

            if (componentChar.Count() > 0)
            {
                yield return new string(componentChar.ToArray());
            }
        }
    }
}
