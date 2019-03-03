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

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Степени", typeof(string));
                    dataTable.Columns["Степени"].ReadOnly = true;

                    var degreeCount = int.Parse(PolynomDegreeComboBox.SelectedItem.ToString());
                    for (int i=0;i < degreeCount + 1;i++)
                    {
                        dataTable.Columns.Add((degreeCount-i).ToString(), typeof(double));
                    }
                    dataTable.Rows.Add("Значения");

                    FunctionalParamsGridView.DataSource = dataTable;




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

    }
}
