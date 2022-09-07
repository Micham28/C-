//Michael McAlexander
// TInfo 200 - CS1        Due 2022-01-22
//this is a simple calulator app that will allow for minor math operations
//along with having proper clear mem, backspace and clear entry.
//should be done with a few lines of code as possible.
//////////////////////////////////////////////////////////////////////////
//Change History
//Date          Developer       Description
//2022-01-25    Michael         begin work
//2022-01-28    Michael         finishing touches
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcProj
{ //main execution point for the application
    internal class Program
    {
        //The main entry point for the application

        [STAThread]
        static void Main(string[] args)
        {//call function
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
