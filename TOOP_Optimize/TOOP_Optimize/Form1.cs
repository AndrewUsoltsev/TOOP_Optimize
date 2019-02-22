using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOOP_Optimize.Optimizers;

namespace TOOP_Optimize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tmp = new GradientDescent(new F(), new DateTime().AddMinutes(3), 1E-12);
            var tmp_df = new RandomSearch(new F(), new DateTime().AddMinutes(3), 1E-12);
            
            var  = tmp_df.Optimize(new double[] {5},
                new Progress<(double[] current, double residual, int progresslen, int progressval)>());
            var daf = tmp.Optimize(new double[] { 5 },
                new Progress<(double[] current, double residual, int progresslen, int progressval)>());
            Console.WriteLine(asd);
        }
    }
}
