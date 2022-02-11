using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Calculator calc = new Calculator();
        private MemoryCalculator memory = new MemoryCalculator();


        private void Form1_Load(object sender, EventArgs e)
        {
            txtDisplay.Text = calc.DisplayString;

            memory.Changed += new MemoryCalculator.ChangeHandler(HandleChange);

            if (memory.MemoryValue == 0)
            {
                btn_M.Visible = false;
            }
            else
                btn_M.Visible = true;
        }

        // This method handles the 0 through 9 keys 
        private void btnNumber_Click(object sender, EventArgs e)
        {
            calc.Append( ((Button)sender).Tag.ToString() );
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            calc.RemoveLast();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            calc.Clear();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            calc.AddDecimalPoint();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            calc.ToggleSign();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            calc.Add();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            calc.Subtract();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            calc.Multiply();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            calc.Divide();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {
            calc.SquareRoot();
            txtDisplay.Text = calc.DisplayString;
        }

        private void btnReciprocal_Click(object sender, EventArgs e)
        {
            try
            {
                calc.Reciprocal();
                txtDisplay.Text = calc.DisplayString;
            }
            catch (DivideByZeroException)
            {
                calc.Clear();
                txtDisplay.Text = "Cannot divide by zero.";
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            try
            {
                calc.Equals();
                txtDisplay.Text = calc.DisplayString;
            }
            catch (DivideByZeroException)
            {
                calc.Clear();
                txtDisplay.Text = "Cannot divide by zero.";
            }
        }

        private void btn_MS_Click(object sender, EventArgs e)
        {
            memory.memoryStore(txtDisplay.Text);
        }

        private void btn_MR_Click(object sender, EventArgs e)
        {
            calc.Append(memory.memoryRecall());
            txtDisplay.Text = memory.memoryRecall();
        }

        private void btn_MC_Click(object sender, EventArgs e)
        {
            memory.memoryClear();
        }

        private void btn_MPlus_Click(object sender, EventArgs e)
        {
            memory.memoryAdd(txtDisplay.Text);
        }

        //
        private void HandleChange(MemoryCalculator memoryEvent)
        {
            if (memory.MemoryValue == 0)
            {
                btn_M.Visible = false;
            }
            else
                btn_M.Visible = true;
        }




    }
}
