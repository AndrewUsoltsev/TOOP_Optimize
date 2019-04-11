namespace TOOP_Optimize.Forms
{
    partial class StackTraceExceptionForm
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
            this.StackTraceTextBox = new System.Windows.Forms.TextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StackTraceTextBox
            // 
            this.StackTraceTextBox.Location = new System.Drawing.Point(10, 12);
            this.StackTraceTextBox.Multiline = true;
            this.StackTraceTextBox.Name = "StackTraceTextBox";
            this.StackTraceTextBox.ReadOnly = true;
            this.StackTraceTextBox.Size = new System.Drawing.Size(380, 268);
            this.StackTraceTextBox.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(311, 302);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // StackTraceExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 337);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.StackTraceTextBox);
            this.MaximizeBox = false;
            this.Name = "StackTraceExceptionForm";
            this.Text = "Дополнительный текст ошибки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox StackTraceTextBox;
        private System.Windows.Forms.Button CloseButton;
    }
}