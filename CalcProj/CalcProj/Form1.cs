//shows what is being used at the time of operation from the systems
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcProj
{//calls for paramemters of the function
    public partial class Form1 : Form
    {//calls for suntions under parameters
        
        public Form1()
        {
            InitializeComponent(); //signal point for application to start.
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //opens the argument occurance space.
        }

        private string mathOperation = string.Empty;//let the application know it will be storing something in it short memory for the time.
        private double leftOperand = 0.0;//set the orignatl value at integer 0
        private bool beginningMathOp = false; //this tells the program when to run it starts as currently off when it is 0

        private void Equal_Click(object sender, EventArgs e)
        {//this is the execution of the math portion of the program that takes the input stored in the mathOp and showsn which case is valid.
            switch (mathOperation)
            {
                case "+":
                    Display.Text = (leftOperand + double.Parse(Display.Text)).ToString();
                    break;
                case "-":
                    Display.Text = (leftOperand - double.Parse(Display.Text)).ToString();
                    break;
                case "x":
                    Display.Text = (leftOperand * double.Parse(Display.Text)).ToString();
                    break;
                case "/":
                    Display.Text = (leftOperand / double.Parse(Display.Text)).ToString();
                    break;
                default:
                    Console.WriteLine("Error: this code should be unreachable.");
                    break;
            }
        }
        private void mathOpBtn_Click(object sender, EventArgs e)
        {//this part of the program holds functionality and the calll operand for the math porttion
            beginningMathOp = true;
            leftOperand = double.Parse(Display.Text);
            mathOperation = ((Button)sender).Text;
        }
        private void numBtn_Click(object sender, EventArgs e)
        {//tells the program that it is going to be computing if the string and value are not 0 otherwise the values is cleared.
            //the boolean tells the program if it is tracking the first of the program or not.
            if (Display.Text == "0" || beginningMathOp == true && Display.Text != ".")
            {
                Display.Clear();
            }
            beginningMathOp = false;
            Display.Text += ((Button)sender).Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {//returns the oposite value of the button even that was activated
            Display.Text = (-double.Parse(Display.Text)).ToString();
        }
        private void Clearentrybtn_Click(object sender, EventArgs e)
        { //puts current entry value to string 0 not value 0
            Display.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Display.TextLength > 0)
            {
                Display.Text = Display.Text.Substring(0, Display.TextLength - 1);// if the code is longer than 0 in value it enable you to remove one place.
            }
        }
        private void Decimal_Click(object sender, EventArgs e)
        { //if condition ? result1 : result2 ;
            //if the condition is true then meaning if it has a decimal already only display current text, if not
            //use the text and add a decimal place.
            Display.Text = Display.Text.Contains(".") ? Display.Text : Display.Text + ".";
        }
        private void Clrmem_Click(object sender, EventArgs e)
        {
            leftOperand = 0.0; //ensures that all values are nullified
            Display.Text = "0"; //returns a zero value to the display text
        }
    }
}
