using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOOP_Optimize.Fabrics;
using TOOP_Optimize.Formats;
using TOOP_Optimize.Interfaces;

namespace TOOP_Optimize
{
    public partial class MainForm : Form
    {
        // View
        public List<string> Functionals = new List<string>();
        public List<string> Optimizers = new List<string>();

        FunctionalsFabric functionalsFabric = new FunctionalsFabric();
        OptimizersFabric optimizersFabric = new OptimizersFabric();

        FunctionalsFormat functionalsFormat = new FunctionalsFormat();
        OptimizersFormat optimizersFormat = new OptimizersFormat();


        public MainForm()
        {
            InitializeComponent();

            Functionals.AddRange(new List<string>(){ "Polinomial", "rozenbrok"});
            Optimizers.AddRange(new List<string>() { "GoldenRatio", "GradientDescent", "RandomSearch" });

            FunctionalComboBox.DataSource = Functionals;
            OptimizerComboBox.DataSource  = Optimizers;
        }

        private void FunctionalSettings_Click(object sender, EventArgs e)
        {
            FunctionalsSettingsForm settingsForm = new FunctionalsSettingsForm(FunctionalComboBox.SelectedItem.ToString());
            settingsForm.ShowDialog();
            if (settingsForm.DialogResult == DialogResult.OK)
            {
                functionalsFormat = settingsForm.FunctionalsFormat;
            }
        }

        private void OptimizerSettings_Click(object sender, EventArgs e)
        {
            OptimizersSettingForm settingsForm = new OptimizersSettingForm(OptimizerComboBox.SelectedItem.ToString());
            settingsForm.ShowDialog();
            if (settingsForm.DialogResult == DialogResult.OK)
            {
                optimizersFormat = settingsForm.OptimizersFormat;
            }
        }

        private void ProcessStartButton_Click(object sender, EventArgs e)
        {
            double x = 0;
            try
            {
                x = Convert.ToDouble(InitialVectorTextBox.Text.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            double[] initialVector = new double[] { x };
            IFunctional functional = null;
            IOptimizer optimizer = null;

            functional = functionalsFabric
                .GetFunctional(
                FunctionalComboBox.SelectedItem.ToString(),
                functionalsFormat);

            optimizer = optimizersFabric
                .GetOptimizer(
                OptimizerComboBox.SelectedItem.ToString(), 
                functional, 
                optimizersFormat.MaxTime,
                optimizersFormat.Eps);


            var result =  optimizer.Optimize(initialVector, null );

            MessageBox.Show(string.Join("\n", result));
        }
    }
}
