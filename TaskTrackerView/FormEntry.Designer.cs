
namespace TaskTrackerView
{
    partial class FormEntry
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
            this.buttonSingOut = new System.Windows.Forms.Button();
            this.buttonSingIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSingOut
            // 
            this.buttonSingOut.Location = new System.Drawing.Point(152, 32);
            this.buttonSingOut.Name = "buttonSingOut";
            this.buttonSingOut.Size = new System.Drawing.Size(127, 23);
            this.buttonSingOut.TabIndex = 7;
            this.buttonSingOut.Text = "Зарегистрироваться";
            this.buttonSingOut.UseVisualStyleBackColor = true;
            this.buttonSingOut.Click += new System.EventHandler(this.buttonSingOut_Click);
            // 
            // buttonSingIn
            // 
            this.buttonSingIn.Location = new System.Drawing.Point(48, 32);
            this.buttonSingIn.Name = "buttonSingIn";
            this.buttonSingIn.Size = new System.Drawing.Size(75, 23);
            this.buttonSingIn.TabIndex = 6;
            this.buttonSingIn.Text = "Войти";
            this.buttonSingIn.UseVisualStyleBackColor = true;
            this.buttonSingIn.Click += new System.EventHandler(this.buttonSingIn_Click);
            // 
            // FormEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 90);
            this.Controls.Add(this.buttonSingOut);
            this.Controls.Add(this.buttonSingIn);
            this.Name = "FormEntry";
            this.Text = "FormEntry";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSingOut;
        private System.Windows.Forms.Button buttonSingIn;
    }
}