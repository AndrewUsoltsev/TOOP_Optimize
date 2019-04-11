using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOOP_Optimize.Forms
{
    public partial class StackTraceExceptionForm : Form
    {
        public StackTraceExceptionForm(string stackTrace)
        {
            InitializeComponent();
            StackTraceTextBox.Text = stackTrace;
            StackTraceTextBox.SelectAll();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
