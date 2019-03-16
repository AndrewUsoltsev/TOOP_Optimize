namespace TOOP_Optimize
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ParamsGridView = new System.Windows.Forms.DataGridView();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.FunctionalParamsGridView = new System.Windows.Forms.DataGridView();
            this.PolynomDegreeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ParamsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FunctionalParamsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ParamsGridView
            // 
            this.ParamsGridView.AllowUserToAddRows = false;
            this.ParamsGridView.AllowUserToDeleteRows = false;
            this.ParamsGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ParamsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParamsGridView.Location = new System.Drawing.Point(12, 142);
            this.ParamsGridView.Name = "ParamsGridView";
            this.ParamsGridView.Size = new System.Drawing.Size(308, 196);
            this.ParamsGridView.TabIndex = 0;
            this.ParamsGridView.Visible = false;
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SaveButton.Location = new System.Drawing.Point(113, 379);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CancelButton.Location = new System.Drawing.Point(245, 415);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // FunctionalParamsGridView
            // 
            this.FunctionalParamsGridView.AllowUserToAddRows = false;
            this.FunctionalParamsGridView.AllowUserToDeleteRows = false;
            this.FunctionalParamsGridView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FunctionalParamsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.FunctionalParamsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FunctionalParamsGridView.Location = new System.Drawing.Point(12, 49);
            this.FunctionalParamsGridView.Name = "FunctionalParamsGridView";
            this.FunctionalParamsGridView.RowHeadersWidth = 20;
            this.FunctionalParamsGridView.Size = new System.Drawing.Size(308, 75);
            this.FunctionalParamsGridView.TabIndex = 3;
            this.FunctionalParamsGridView.Visible = false;
            // 
            // PolynomDegreeComboBox
            // 
            this.PolynomDegreeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PolynomDegreeComboBox.FormattingEnabled = true;
            this.PolynomDegreeComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.PolynomDegreeComboBox.Location = new System.Drawing.Point(12, 22);
            this.PolynomDegreeComboBox.Name = "PolynomDegreeComboBox";
            this.PolynomDegreeComboBox.Size = new System.Drawing.Size(46, 21);
            this.PolynomDegreeComboBox.TabIndex = 4;
            this.PolynomDegreeComboBox.Visible = false;
            this.PolynomDegreeComboBox.SelectedValueChanged += new System.EventHandler(this.PolynomDegreeComboBox_SelectedValueChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 450);
            this.Controls.Add(this.PolynomDegreeComboBox);
            this.Controls.Add(this.FunctionalParamsGridView);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ParamsGridView);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            ((System.ComponentModel.ISupportInitialize)(this.ParamsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FunctionalParamsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ParamsGridView;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.DataGridView FunctionalParamsGridView;
        private System.Windows.Forms.ComboBox PolynomDegreeComboBox;
    }
}