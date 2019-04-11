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
    public partial class ExceptionForm : Form
    {
        string stackTrace = "";
        public ExceptionForm(Exception exception)
        {
            InitializeComponent();
            stackTrace = exception.StackTrace;
            string exceptionText = $"Произошла следующая ошибка:\r\n ";
            if (exception.InnerException != null)
                exceptionText += exception.InnerException.Message;
            else
                exceptionText += exception.Message;
            ExceptionTextBox.Text = exceptionText;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AdditionalButton_Click(object sender, EventArgs e)
        {
            StackTraceExceptionForm stackTraceForm = new StackTraceExceptionForm(stackTrace);
            stackTraceForm.Show();
        }


        //if (exception.InnerException != null)
        //    MessageBox.Show($"{exception.InnerException.Message}\n\n{exception.InnerException.StackTrace}");
        //else
        //    MessageBox.Show($"{exception.Message}\n\n{exception.StackTrace}");

        //        }
    }
}
