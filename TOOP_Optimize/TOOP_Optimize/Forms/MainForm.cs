using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOOP_Optimize.Exeptions;
using TOOP_Optimize.Fabrics;
using TOOP_Optimize.Formats;
using TOOP_Optimize.Forms;
using TOOP_Optimize.Interfaces;

namespace TOOP_Optimize
{
    public partial class MainForm : Form
    {
        public List<string> Functionals = new List<string>();
        public List<string> Optimizers = new List<string>();

        string functionalsData = "";
        OptimizersFormat optimizersFormat = new OptimizersFormat();

        public Progress<(double[] current, double residual, int progresslen, int progressval)> Progress;

        public MainForm()
        {
            InitializeComponent();

            Functionals.AddRange(new List<string>(ClassCollector.FunctionalsTypes.Select(x=>x.Name)));
            Optimizers.AddRange(new List<string>(ClassCollector.OptimizersTypes.Select(x => x.Name)));

            FunctionalComboBox.DataSource = Functionals;
            OptimizerComboBox.DataSource  = Optimizers;

            Progress = new Progress<(double[] current, double residual, int progresslen, int progressval)>();
            Progress.ProgressChanged += Progress_ProgressChanged;
        }

        private void Progress_ProgressChanged(object sender, (double[] current, double residual, int progresslen, int progressval) e)
        {
            SolveProgressBar.Maximum = e.progresslen;
            SolveProgressBar.Value = e.progresslen;
            ResidualLabel.Text = $"Невязка: {e.residual}";
        }

        private void FunctionalSettings_Click(object sender, EventArgs e)
        {
            FunctionalsSettingsForm settingsForm = new FunctionalsSettingsForm(FunctionalComboBox.SelectedItem.ToString());
            settingsForm.ShowDialog();
            if (settingsForm.DialogResult == DialogResult.OK)
            {
                functionalsData = settingsForm.JsonFile;
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
            SolveProgressBar.Value = 0;
            ResidualLabel.Text = "Невязка:";
            List<double> initialVector = new List<double>();
            IFunctional functional = null;
            IOptimizer optimizer = null;

            try
            {
                var parseString = InitialVectorTextBox.Text.ToString().Split(' ');
                for (int i = 0; i < parseString.Length; i++)
                    initialVector.Add(Convert.ToDouble(parseString[i]));

                functional = FunctionalsFabric
                    .GetFunctional(
                    FunctionalComboBox.SelectedItem.ToString(),
                    functionalsData);

                optimizer = OptimizersFabric
                    .GetOptimizer(
                    OptimizerComboBox.SelectedItem.ToString(),
                    functional,
                    optimizersFormat.MaxTime,
                    optimizersFormat.Eps);
            }
            catch (Exception ex)
            {
                ExceptionForm exceptionForm = new ExceptionForm(ex);
                exceptionForm.ShowDialog();
            }

            var result = optimizer.Optimize(initialVector.ToArray(), Progress);
            MessageBox.Show(string.Join("\n", result));
        }

        private void FunctionalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            functionalsData = null;
        }
    }
}
