using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class MemoryCalculator: Calculator

    {
        public delegate void ChangeHandler(MemoryCalculator memoryEvent);
        public event ChangeHandler Changed;

        private decimal memoryValue=0;

        public MemoryCalculator()
        {
        }

        public MemoryCalculator(string displayString, bool isNewValue,
            bool hasDecimal, decimal operand1, decimal operand2, decimal memoryValue) : base()
        {
            this.memoryValue = memoryValue;
        }

        public decimal MemoryValue
        {
            get
            {
                return this.memoryValue;
            }
            set
            {
                this.memoryValue = value;
            }
        }
        public void memoryStore(string txtDisplay)
        {
            decimal currentValue = Convert.ToDecimal(txtDisplay);
            this.memoryValue = currentValue;
            Changed(this);
        }

        public string memoryRecall()
        {
            return this.memoryValue.ToString();
        }

        public void memoryAdd(string txtDisplay)
        {
            decimal currentValue = Convert.ToDecimal(txtDisplay);
            this.memoryValue += currentValue;
        }

        public void memoryClear()
        {
            this.memoryValue = 0;
            Changed(this);
        }
    }
}
