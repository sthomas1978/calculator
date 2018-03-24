using System.Collections.Generic;
using System.Text;
using System.Linq;
using System;

namespace Calculator.Console
{
    public class ReversePolishService
    {
        public string ConvertFromInfix(string infixExpression)
        {
            var operatorStack = new Stack<Component>();
            var rpComponents = new List<Component>();

            infixExpression.Split(' ').ToList().ForEach(c =>
            {
                var component = Component.Parse(c);

                if (component is Operand)
                {
                    rpComponents.Add(component);
                }
                else if (component is LeftParenthesis)
                {
                    operatorStack.Push(component);
                }
                else if (component is RightParenthesis)
                {
                    var poppedcomponent = operatorStack.Pop();
                    while (!(poppedcomponent is LeftParenthesis))
                    {
                        rpComponents.Add(poppedcomponent);

                        poppedcomponent = operatorStack.Pop();
                    }
                }
                else
                {
                    while (NotEmpty(operatorStack) &&
                        (!(operatorStack.Peek() is LeftParenthesis)) &&
                        ((Operator)component).IsLowerPrescendence((Operator)operatorStack.Peek()))
                    {
                        rpComponents.Add(operatorStack.Pop());
                    };

                    operatorStack.Push(component);
                }
            });

            while (NotEmpty(operatorStack))
            {
                rpComponents.Add(operatorStack.Pop());
            }

            return String.Join(" ", rpComponents.Select(c => c.Symbol));
        }

        private bool NotEmpty(Stack<Component> operatorStack)
        {
            return operatorStack.Count > 0;
        }

        public int EvaluateExpression(string rpnExpression)
        {
            var operatorStack = new Stack<int>();

            rpnExpression.Split(' ').ToList().ForEach(c =>
            {
                var component = Component.Parse(c);

                if (component is Operand)
                {
                    operatorStack.Push(int.Parse(c));
                }
                else
                {
                    var right = operatorStack.Pop();
                    var left = operatorStack.Pop();

                    var result = ((Operator)component).Calculate(left, right);

                    operatorStack.Push(result);
                }
            });

            return operatorStack.Pop();
        }


    }
}
