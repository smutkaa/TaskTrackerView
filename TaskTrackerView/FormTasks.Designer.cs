
namespace TaskTrackerView
{
    partial class FormTasks
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
            this.buttonComment = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonComment
            // 
            this.buttonComment.Location = new System.Drawing.Point(538, 117);
            this.buttonComment.Name = "buttonComment";
            this.buttonComment.Size = new System.Drawing.Size(92, 27);
            this.buttonComment.TabIndex = 5;
            this.buttonComment.Text = "Оценить";
            this.buttonComment.UseVisualStyleBackColor = true;
            this.buttonComment.Click += new System.EventHandler(this.buttonComment_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(21, 33);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(497, 263);
            this.dataGridView.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(538, 150);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 27);
            this.button1.TabIndex = 6;
            this.button1.Text = "Выполнять";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 323);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonComment);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormTasks";
            this.Text = "FormTasks";
            this.Load += new System.EventHandler(this.FormTasks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonComment;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button button1;
    }
}