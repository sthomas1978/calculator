using System;

namespace Calculator.Console
{
    public abstract class Component
    {
        public const string AddOperator = "+";
        public const string MultiplyOperator = "*";
        public const string SubtractOperator = "-";
        public const string DivideOperator = "/";
        public const string PowerOperator = "^";
        public const string LeftBracket = "(";
        public const string RightBracket = ")";

        public string Symbol { get; }

        public Component(string symbol)
        {
            Symbol = symbol;
        }

        private static bool IsNumeric(string value)
        {
            double numeric = 0;
            return double.TryParse(value, out numeric);
        }

        public static Component Parse(string value)
        {
            if (IsNumeric(value))
                return new Operand(value);

            switch (value)
            {
                case LeftBracket:
                    return new LeftParenthesis();
                case RightBracket:
                    return new RightParenthesis();
                case AddOperator:
                    return new AddOperator();
                case SubtractOperator:
                    return new SubtractOperator();
                case MultiplyOperator:
                    return new MultiplyOperator();
                case PowerOperator:
                    return new PowerOperator();
                case DivideOperator:
                    return new DivideOperator();
                default:
                    throw new ArgumentException($"Incorrect value {value}", "value");
            }
        }
    }


    public class Operand : Component
    {
        public double Value { get; }

        public Operand(string symbol) : base(symbol)
        {
            Value = double.Parse(symbol.ToString());
        }
    }

    public class LeftParenthesis : Component 
    {
        public LeftParenthesis() : base(LeftBracket) { }
    }

    public class RightParenthesis : Component
    {
        public RightParenthesis() : base (RightBracket) { }
    }


    public abstract class Operator : Component
    {
        public int Prescedence { get; }
        
        public Operator(string symbol, int prescendence) :base (symbol)
        {
            Prescedence = prescendence;
        }

        public bool IsLowerPrescendence(Operator op)
        {
            return this.Prescedence <= op.Prescedence;
        }

        public abstract double Calculate(double left, double right);
    }

    public class AddOperator : Operator
    {
        public AddOperator() : base(AddOperator, 2) { }

        public override double Calculate(double left, double right)
        {
            return left + right;
        }
    }

    public class SubtractOperator : Operator
    {
        public SubtractOperator() : base(SubtractOperator, 2) { }

        public override double Calculate(double left, double right)
        {
            return left - right;
        }
    }

    public class MultiplyOperator : Operator
    {
        public MultiplyOperator() : base(MultiplyOperator, 3) { }

        public override double Calculate(double left, double right)
        {
            return left * right;
        }
    }

    public class DivideOperator : Operator
    {
        public DivideOperator() : base(DivideOperator, 3) { }

        public override double Calculate(double left, double right)
        {
            return left / right;
        }
    }

    public class PowerOperator : Operator
    {
        public PowerOperator() : base(PowerOperator, 4) { }

        public override double Calculate(double left, double right)
        {
            return (int)Math.Pow(left, right);
        }
    }
}
