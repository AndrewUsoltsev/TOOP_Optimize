using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOOP_Optimize.Interfaces;

namespace TOOP_Optimize
{
    public partial class MainForm : Form
    {

        public List<string> Functionals = new List<string>();
        public List<string> Optimizers = new List<string>();

        public MainForm()
        {
            InitializeComponent();
            Functionals.AddRange(new List<string>(){ "spline", "rozenbrok"});
            Optimizers.AddRange(new List<string>() { "Golden Search", "BFGS" });

            FunctionalComboBox.DataSource = Functionals;
            OptimizerComboBox.DataSource  = Optimizers;
        }

        private void FunctionalSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(true, FunctionalComboBox.SelectedItem.ToString());
            settingsForm.ShowDialog();
            if (settingsForm.DialogResult == DialogResult.OK)
            {

            }
        }

        private void OptimizerSettings_Click(object sender, EventArgs e)
        {
            IOptimizer functional = null;
            SettingsForm settingsForm = new SettingsForm(false, OptimizerComboBox.SelectedItem.ToString());
            settingsForm.ShowDialog();
            if (settingsForm.DialogResult == DialogResult.OK)
            {

            }

        }
    }
}
