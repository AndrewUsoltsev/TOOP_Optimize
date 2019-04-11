using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TOOP_Optimize.Formats;

namespace TOOP_Optimize
{
    public partial class OptimizersSettingForm : Form
    {
        public OptimizersSettingForm()
        {
            InitializeComponent();
        }

        private string ObjectName { get; set; }
        public OptimizersFormat OptimizersFormat { get; }

        public OptimizersSettingForm(string objectName)
        {
            InitializeComponent();

            ObjectName = objectName;
            OptimizersFormat = new OptimizersFormat();

            TableFormation();
        }

        private void TableFormation()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Параметры", typeof(string));
            dataTable.Columns.Add("Значения", typeof(double));
            dataTable.Columns["Параметры"].ReadOnly = true;
            dataTable.Columns["Значения"].ReadOnly = false;

            dataTable.Rows.Add("Eps", 1E-6);
            dataTable.Rows.Add("MaxTime", 120);

            ParamsGridView.DataSource = dataTable;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            var dataTable = ParamsGridView.DataSource as DataTable;

            double eps = 1E-6;
            double seconds = 120;
            try
            {
                eps = Convert.ToDouble(dataTable.Rows[0]["Значения"]);
                seconds = Convert.ToDouble(dataTable.Rows[1]["Значения"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            CheckAndAssigmentParams(eps, seconds);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CheckAndAssigmentParams(double eps, double seconds)
        {
            DateTime maxTime = new DateTime(); 
            if (eps > 0 && eps < 1)
                OptimizersFormat.Eps = eps;
            if (seconds > 0)
            {
                maxTime = maxTime.AddSeconds(seconds);
                OptimizersFormat.MaxTime = maxTime;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }



    }
}
