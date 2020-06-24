// Palak Depani, 000787449
// Date - 15 November 2019
// I, Palak depani, student no 000787449, cerify that all code submitted is my own work;that i have not copied from any other source .
//I also certify that i have not allowed my work to be copied by other
// purpose - it check for inserted html file tags , like all tags are closed or not and diplay the result



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4B
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
