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
using TOOP_Optimize.Forms;

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
        private JObject jObject { get; set; }

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
            FileContentTreeView.BeginUpdate();
            FileContentTreeView.Nodes.Clear();
            var root = FileContentTreeView.Nodes[FileContentTreeView.Nodes.Add(new TreeNode("Необходимые параметры"))];
            foreach (var param in FunctionalConstructorsParams)
            {

                var tmpNode = root.Nodes.Add(param.Name);
                tmpNode.Nodes.Add(param.ParameterType.Name);
            }
            FileContentTreeView.ExpandAll();
            FileContentTreeView.EndUpdate();
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
            openFileDialog.Filter = "json files (*.json)|*.json|txt files (*.txt)|*.txt|All files (*.*)|*.*";

            string textJson = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                textJson = System.IO.File.ReadAllText(filename);
            }
            else
                return;

            if (!IsCheckJsonFile(textJson))
            {
                MessageBox.Show("Загружен неподходящий файл!");
                return;
            }

            JsonFile = textJson;
            UpdateTreeView();
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
                ExceptionForm exceptionForm = new ExceptionForm(ex);
                exceptionForm.ShowDialog();
                return false;
            }
           
            foreach (var param in FunctionalConstructorsParams)
                if (jObject[param.Name] == null)
                    return false;
            this.jObject = jObject;
            return true;
        }

        private void UpdateTreeView()
        {
            FileContentTreeView.BeginUpdate();
            FileContentTreeView.Nodes.Clear();
            var root = FileContentTreeView.Nodes[FileContentTreeView.Nodes.Add(new TreeNode("Загруженные параметры"))];
            foreach (var tmpObject in FunctionalConstructorsParams)
            {
                var tmpNode = root.Nodes.Add(tmpObject.Name);
                GetChildStructure(ref tmpNode, jObject[tmpObject.Name].Parent);
            }
            FileContentTreeView.ExpandAll();
            FileContentTreeView.EndUpdate();
        }

        // TODO если будет желание, можно отрефакторить для всех форматов
        private void GetChildStructure(ref TreeNode root, JToken parameters)
        {
            if (parameters == null)
                return;
            var property = (parameters as JProperty);
            if (property != null &&
                property.Value.Type == JTokenType.Array)
            {
                var array = (JArray)property.Value;
                for (int i = 0; i < array.Count; i++)
                    root.Nodes.Add(array[i].ToString());
            }
            else
            {
                foreach (var param in parameters.Children())
                {
                    var tmpNode = root.Nodes.Add(param.ToString());
                    GetChildStructure(ref tmpNode, param);
                }
            }
        }

    }
}
