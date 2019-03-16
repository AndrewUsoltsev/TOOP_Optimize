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
    public partial class SettingsForm : Form
    {
        
        public SettingsForm()
        {
            InitializeComponent();
        }


        public DataTable GetDataTableForSpline(int degreeOfPolynom)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Степени", typeof(string));
            dataTable.Columns["Степени"].ReadOnly = true;

            var degreeCount = degreeOfPolynom;
            for (int i = 0; i < degreeCount + 1; i++)
            {
                dataTable.Columns.Add((degreeCount - i).ToString(), typeof(double));
            }
            dataTable.Rows.Add("Значения");
            return dataTable;
        }

        public SettingsForm(bool isFunctional, string objectName)
        {
            InitializeComponent();
            if (isFunctional)
            {
                if (objectName == "spline")
                {
                    PolynomDegreeComboBox.Visible = true;
                    FunctionalParamsGridView.Visible = true;
                    PolynomDegreeComboBox.SelectedIndex = 0;

                    var degreeCount = int.Parse(PolynomDegreeComboBox.SelectedItem.ToString());
                    FunctionalParamsGridView.DataSource = GetDataTableForSpline(degreeCount);




                }
            }
            else
            {
                ParamsGridView.Visible = true;

                // TODO To method
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Параметры", typeof(string));
                dataTable.Columns.Add("Значения", typeof(string));
                dataTable.Columns["Параметры"].ReadOnly = true;
                dataTable.Columns["Значения"].ReadOnly = false;

                dataTable.Rows.Add("Eps", "AA");
                dataTable.Rows.Add("MaxTime", "AA");

                ParamsGridView.DataSource = dataTable;
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void PolynomDegreeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (PolynomDegreeComboBox.Visible == false)
                return;

            var tmpDataTable = FunctionalParamsGridView.DataSource as DataTable;
            FunctionalParamsGridView.DataSource = null;

            var degreeCount = int.Parse(PolynomDegreeComboBox.SelectedItem.ToString());
            var dataTable = GetDataTableForSpline(degreeCount);

            foreach (var col in dataTable.Columns)
                if (col.ToString() != "Степени" && tmpDataTable.Columns.Contains(col.ToString()))
                    dataTable.Rows[0][col.ToString()] = tmpDataTable.Rows[0][col.ToString()];

            FunctionalParamsGridView.DataSource = dataTable;
        }
    }
}
