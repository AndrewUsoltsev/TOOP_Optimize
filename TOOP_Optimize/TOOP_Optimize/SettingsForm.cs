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

        public SettingsForm(IFunctional functional)
        {
            InitializeComponent();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Параметры", typeof(string));
            dataTable.Columns.Add("Значения", typeof(string));

            dataTable.Rows.Add(  "Eps", "AA" );
            dataTable.Rows.Add("MaxTime", "AA" );

            ParamsGridView.DataSource = dataTable;

        }

        public SettingsForm(IOptimizer optimizer)
        {
            InitializeComponent();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Параметры");
            dataTable.Columns.Add("Значения");

            dataTable.Rows.Add("Eps", "AA");
            dataTable.Rows.Add("MaxTime", "AA");

            ParamsGridView.DataSource = dataTable;
        }

        public void SetParamsFromClasses(IFunctional functional = null, IOptimizer optimizer = null)
        {

        }
    }
}
