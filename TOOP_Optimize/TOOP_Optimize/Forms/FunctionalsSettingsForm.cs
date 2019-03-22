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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace TOOP_Optimize
{
    public partial class FunctionalsSettingsForm : Form
    {
        public FunctionalsSettingsForm()
        {
            InitializeComponent();
        }

        private string ObjectName { get; set; }
        private ParameterInfo[] FunctionalConstructorsParams { get; set; }
        public string JsonFile { get; private set; }

        public FunctionalsSettingsForm(string objectName)
        {
            InitializeComponent();
            ObjectName = objectName;
            var createType = ClassCollector.FunctionalsTypes.Find(x => x.Name == ObjectName);
            FunctionalConstructorsParams = createType.GetConstructors().FirstOrDefault().GetParameters();
            UpdateLabel();
        }

        private void UpdateLabel()
        {
            string textLabel = "Необходимые параметры:";
            foreach (var param in FunctionalConstructorsParams)
                textLabel = string.Concat(textLabel, $"\n{param.ParameterType.Name} {param.Name}");
            FileViewLabel.Text = textLabel;
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

        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "json files (*.json)|*.json";

            string textJson = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                textJson = System.IO.File.ReadAllText(filename);
            }

            if (!IsCheckJsonFile(textJson))
            {
                MessageBox.Show("Загружен неподходящий файл!");
                return;
            }

            FileViewLabel.Text = textJson;
            JsonFile = textJson;
            MessageBox.Show("Файл загружен!");
        }

        private bool IsCheckJsonFile(string textJson)
        {
            JObject jObject = null;
            try
            {
                jObject = JsonConvert.DeserializeObject<JObject>(textJson);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message); // нормально ли?
                return false;
            }
           
            foreach (var param in FunctionalConstructorsParams)
                if (jObject[param.Name] == null)
                    return false;
            return true;
        }

    }
}
