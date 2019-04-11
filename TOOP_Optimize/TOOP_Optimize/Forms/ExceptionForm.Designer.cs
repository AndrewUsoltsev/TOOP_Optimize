namespace TOOP_Optimize.Forms
{
    partial class ExceptionForm
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
            this.CloseButton = new System.Windows.Forms.Button();
            this.AdditionalButton = new System.Windows.Forms.Button();
            this.ExceptionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(118, 149);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "ОК";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AdditionalButton
            // 
            this.AdditionalButton.Location = new System.Drawing.Point(219, 115);
            this.AdditionalButton.Name = "AdditionalButton";
            this.AdditionalButton.Size = new System.Drawing.Size(95, 23);
            this.AdditionalButton.TabIndex = 1;
            this.AdditionalButton.Text = "Дополнительно";
            this.AdditionalButton.UseVisualStyleBackColor = true;
            this.AdditionalButton.Click += new System.EventHandler(this.AdditionalButton_Click);
            // 
            // ExceptionTextBox
            // 
            this.ExceptionTextBox.Location = new System.Drawing.Point(12, 12);
            this.ExceptionTextBox.Multiline = true;
            this.ExceptionTextBox.Name = "ExceptionTextBox";
            this.ExceptionTextBox.ReadOnly = true;
            this.ExceptionTextBox.Size = new System.Drawing.Size(302, 97);
            this.ExceptionTextBox.TabIndex = 2;
            // 
            // ExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 184);
            this.Controls.Add(this.ExceptionTextBox);
            this.Controls.Add(this.AdditionalButton);
            this.Controls.Add(this.CloseButton);
            this.MaximizeBox = false;
            this.Name = "ExceptionForm";
            this.Text = "Ошибка!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button AdditionalButton;
        private System.Windows.Forms.TextBox ExceptionTextBox;
    }
}