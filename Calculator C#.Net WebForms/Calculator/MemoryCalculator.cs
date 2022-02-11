using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    public class MemoryCalculator: Calculator

    {
        public delegate void ChangeHandler(MemoryCalculator memoryEvent);
        public event ChangeHandler Changed;

        //A decimal that stores the current memory value.
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
        //Stores the calculator’s current value in memory.
        public void memoryStore(string txtDisplay)
        {
            decimal currentValue = Convert.ToDecimal(txtDisplay);
            this.memoryValue = currentValue;
            Changed(this);
        }
        //Sets the calculator’s current value to the value stored in memory.
        public string memoryRecall()
        {
            return this.memoryValue.ToString();
        }
        //Adds the calculator’s current value to the value currently stored in memory.
        public void memoryAdd(string txtDisplay)
        {
            decimal currentValue = Convert.ToDecimal(txtDisplay);
            this.memoryValue += currentValue;
        }
        //Clears the current memory value.
        public void memoryClear()
        {
            this.memoryValue = 0;
            Changed(this);
        }
    }
}
