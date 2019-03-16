namespace TOOP_Optimize
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProcessStartButton = new System.Windows.Forms.Button();
            this.FunctionalComboBox = new System.Windows.Forms.ComboBox();
            this.OptimizerComboBox = new System.Windows.Forms.ComboBox();
            this.FunctionalSettings = new System.Windows.Forms.Button();
            this.OptimizerSettings = new System.Windows.Forms.Button();
            this.FunctionalLabel = new System.Windows.Forms.Label();
            this.OptimizerLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // ProcessStartButton
            // 
            this.ProcessStartButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProcessStartButton.Location = new System.Drawing.Point(222, 237);
            this.ProcessStartButton.Name = "ProcessStartButton";
            this.ProcessStartButton.Size = new System.Drawing.Size(111, 23);
            this.ProcessStartButton.TabIndex = 0;
            this.ProcessStartButton.Text = "Оптимизировать!";
            this.ProcessStartButton.UseVisualStyleBackColor = true;
            // 
            // FunctionalComboBox
            // 
            this.FunctionalComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FunctionalComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FunctionalComboBox.FormattingEnabled = true;
            this.FunctionalComboBox.Location = new System.Drawing.Point(222, 97);
            this.FunctionalComboBox.Name = "FunctionalComboBox";
            this.FunctionalComboBox.Size = new System.Drawing.Size(121, 21);
            this.FunctionalComboBox.TabIndex = 1;
            // 
            // OptimizerComboBox
            // 
            this.OptimizerComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OptimizerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OptimizerComboBox.FormattingEnabled = true;
            this.OptimizerComboBox.Location = new System.Drawing.Point(222, 156);
            this.OptimizerComboBox.Name = "OptimizerComboBox";
            this.OptimizerComboBox.Size = new System.Drawing.Size(121, 21);
            this.OptimizerComboBox.TabIndex = 2;
            // 
            // FunctionalSettings
            // 
            this.FunctionalSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FunctionalSettings.Location = new System.Drawing.Point(382, 97);
            this.FunctionalSettings.Name = "FunctionalSettings";
            this.FunctionalSettings.Size = new System.Drawing.Size(75, 23);
            this.FunctionalSettings.TabIndex = 3;
            this.FunctionalSettings.Text = "Настройка";
            this.FunctionalSettings.UseVisualStyleBackColor = true;
            this.FunctionalSettings.Click += new System.EventHandler(this.FunctionalSettings_Click);
            // 
            // OptimizerSettings
            // 
            this.OptimizerSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OptimizerSettings.Location = new System.Drawing.Point(382, 156);
            this.OptimizerSettings.Name = "OptimizerSettings";
            this.OptimizerSettings.Size = new System.Drawing.Size(75, 23);
            this.OptimizerSettings.TabIndex = 4;
            this.OptimizerSettings.Text = "Настройка";
            this.OptimizerSettings.UseVisualStyleBackColor = true;
            this.OptimizerSettings.Click += new System.EventHandler(this.OptimizerSettings_Click);
            // 
            // FunctionalLabel
            // 
            this.FunctionalLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FunctionalLabel.AutoSize = true;
            this.FunctionalLabel.Location = new System.Drawing.Point(219, 81);
            this.FunctionalLabel.Name = "FunctionalLabel";
            this.FunctionalLabel.Size = new System.Drawing.Size(71, 13);
            this.FunctionalLabel.TabIndex = 5;
            this.FunctionalLabel.Text = "Функционал";
            // 
            // OptimizerLabel
            // 
            this.OptimizerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OptimizerLabel.AutoSize = true;
            this.OptimizerLabel.Location = new System.Drawing.Point(219, 140);
            this.OptimizerLabel.Name = "OptimizerLabel";
            this.OptimizerLabel.Size = new System.Drawing.Size(75, 13);
            this.OptimizerLabel.TabIndex = 6;
            this.OptimizerLabel.Text = "Оптимизатор";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 427);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(618, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.OptimizerLabel);
            this.Controls.Add(this.FunctionalLabel);
            this.Controls.Add(this.OptimizerSettings);
            this.Controls.Add(this.FunctionalSettings);
            this.Controls.Add(this.OptimizerComboBox);
            this.Controls.Add(this.FunctionalComboBox);
            this.Controls.Add(this.ProcessStartButton);
            this.Name = "MainForm";
            this.Text = "Оптимизатор функционала";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ProcessStartButton;
        private System.Windows.Forms.ComboBox FunctionalComboBox;
        private System.Windows.Forms.ComboBox OptimizerComboBox;
        private System.Windows.Forms.Button FunctionalSettings;
        private System.Windows.Forms.Button OptimizerSettings;
        private System.Windows.Forms.Label FunctionalLabel;
        private System.Windows.Forms.Label OptimizerLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

