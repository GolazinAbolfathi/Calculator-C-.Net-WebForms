using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class Calculator
    {

        private string displayString = "";


        private bool isNewValue;
        private bool hasDecimal;

        private decimal operand1;
        private decimal operand2;
        private Operation op;
        private enum Operation { Add, Subtract, Multiply, Divide, SquareRoot, Reciprocal, None };

        public Calculator()
        {
            Clear();
        }

        public void Clear()
        {
            displayString = "";
            hasDecimal = false;
            isNewValue = true;

            operand1 = 0;
            operand2 = 0;
            op = Operation.None;
        }

        public string DisplayString =>
            string.IsNullOrEmpty(displayString) ? "0" : displayString;

        private decimal displayValue => Convert.ToDecimal(DisplayString);

        public void Append(string value)
        {
            if (isNewValue)
            {
                displayString = "";
                hasDecimal = false;
                isNewValue = false;
            }

            
            displayString += (displayString == "0" && value == "0") ? "" : value;
        }

        public void RemoveLast()
        {
            if (!isNewValue)
            {
                int newLength = displayString.Length - 1; 
                displayString = displayString.Substring(0, newLength);

                if (string.IsNullOrEmpty(displayString))
                    isNewValue = true;

                if (!displayString.Contains('.'))
                    hasDecimal = false;
            }
        }

        public void ToggleSign() => 
            displayString = (-displayValue).ToString();


        public void AddDecimalPoint()
        {
            if (!hasDecimal)
            {
                if (isNewValue)
                {
                    displayString = "";
                    hasDecimal = false;
                    isNewValue = false;
                    Append("0.");  // include a leading zero
                }
                else
                {
                    Append(".");
                }
                hasDecimal = true;
            }
        }

        public void Add()
        {
            SetValuesForOperation(Operation.Add);
        }

        public void Subtract()
        {
            SetValuesForOperation(Operation.Subtract);
        }

        public void Multiply()
        {
            SetValuesForOperation(Operation.Multiply);
        }

        public void Divide()
        {
            SetValuesForOperation(Operation.Divide);
        }

        public void Equals()
        {
            operand2 = displayValue;

            decimal calculatedValue = op switch
            {
                Operation.Add => operand1 + operand2,
                Operation.Subtract => operand1 - operand2,
                Operation.Multiply => operand1 * operand2,
                Operation.Divide => operand1 / operand2,
                _ => operand2
            };
            displayString = calculatedValue.ToString();

            op = Operation.None;
            hasDecimal = false;
            isNewValue = true;
        }

        public void SquareRoot()
        {
            SetValuesForOperation(Operation.SquareRoot);
        }

        public void Reciprocal()
        {
            SetValuesForOperation(Operation.Reciprocal);
        }

        // private helper method
        private void SetValuesForOperation(Operation newOp)
        {
            op = newOp;
            operand1 = displayValue;

            decimal calculatedValue = op switch
            {
                Operation.SquareRoot => (decimal)Math.Sqrt(Convert.ToDouble(operand1)),
                Operation.Reciprocal => 1 / operand1,
                _ => operand1
            };
            displayString = calculatedValue.ToString();

            hasDecimal = false;
            isNewValue = true;
        }

    }
}
