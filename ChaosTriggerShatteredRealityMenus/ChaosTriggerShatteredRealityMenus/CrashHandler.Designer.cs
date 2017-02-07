namespace ChaosTriggerShatteredRealityMenus
{
    partial class CrashHandler
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
            this.components = new System.ComponentModel.Container();
            this.SendBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // SendBtn
            // 
            this.SendBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SendBtn.Location = new System.Drawing.Point(12, 12);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(75, 23);
            this.SendBtn.TabIndex = 0;
            this.SendBtn.Text = "Send";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(129, 12);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "Don\'t Send";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // errorLabel
            // 
            this.errorLabel.Location = new System.Drawing.Point(12, 78);
            this.errorLabel.Multiline = true;
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.errorLabel.Size = new System.Drawing.Size(493, 164);
            this.errorLabel.TabIndex = 2;
            // 
            // CrashHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 265);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.SendBtn);
            this.Name = "CrashHandler";
            this.Text = "Crash Handler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.TextBox errorLabel;
        private System.Windows.Forms.Timer timer1;
    }
}