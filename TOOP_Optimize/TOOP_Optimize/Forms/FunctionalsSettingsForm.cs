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
using TOOP_Optimize.Interfaces;

namespace TOOP_Optimize
{
    public partial class FunctionalsSettingsForm : Form
    {
        public FunctionalsSettingsForm()
        {
            InitializeComponent();
        }


        private string ObjectName { get; set; }
        public FunctionalsFormat FunctionalsFormat { get; }

        public FunctionalsSettingsForm(string objectName)
        {
            InitializeComponent();

            ObjectName = objectName;
            FunctionalsFormat = new FunctionalsFormat();


            if (objectName == "Polinomial")
            {
                FunctionalParamsGridView.Visible = true;
                PolynomDegreeComboBox.Visible = true;

                PolynomDegreeComboBox.Visible = true;
                FunctionalParamsGridView.Visible = true;
                PolynomDegreeComboBox.SelectedIndex = 0;

                var degreeCount = int.Parse(PolynomDegreeComboBox.SelectedItem.ToString());
                FunctionalParamsGridView.DataSource = GetDataTableForSpline(degreeCount);
            }


        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ObjectName == "Polinomial")
            {
                List<double> coeffList = new List<double>();

                var dataTable = FunctionalParamsGridView.DataSource as DataTable;
                try
                {
                    foreach (var col in dataTable.Columns)
                    {
                        if (col.ToString() != "Степени")
                        {
                            var tmpCoeff = Convert.ToDouble(dataTable.Rows[0][col.ToString()]);
                            coeffList.Add(tmpCoeff);
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                coeffList.Reverse();
                FunctionalsFormat.PolinomialFunctionalFormat.Coeff = coeffList.ToArray();
            }


            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
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

        private void PolynomDegreeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (PolynomDegreeComboBox.Visible == false)
                return;

            var tmpDataTable = FunctionalParamsGridView.DataSource as DataTable;
            FunctionalParamsGridView.DataSource = null;

            var degreeCount = int.Parse(PolynomDegreeComboBox.SelectedItem.ToString());
            var dataTable = GetDataTableForSpline(degreeCount);

            // TODO исправить
            //var columns = dataTable.Columns;
            //columns.Remove("Степени");

            foreach (var col in dataTable.Columns)
                if (col.ToString() != "Степени" && tmpDataTable.Columns.Contains(col.ToString()))
                    dataTable.Rows[0][col.ToString()] = tmpDataTable.Rows[0][col.ToString()];

            FunctionalParamsGridView.DataSource = dataTable;
        }
    }
}
