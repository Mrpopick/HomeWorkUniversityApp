namespace ToDoListUniversity.Forms
{
    partial class ViewHomeworkForm
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
            this.lbOfSubject = new System.Windows.Forms.Label();
            this.lbSubject = new System.Windows.Forms.Label();
            this.lbOfDifficulty = new System.Windows.Forms.Label();
            this.lbDifficulty = new System.Windows.Forms.Label();
            this.lbOfDate = new System.Windows.Forms.Label();
            this.lbStart = new System.Windows.Forms.Label();
            this.lbEnd = new System.Windows.Forms.Label();
            this.richTbDescription = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lbOfSubject
            // 
            this.lbOfSubject.AutoSize = true;
            this.lbOfSubject.Location = new System.Drawing.Point(20, 50);
            this.lbOfSubject.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOfSubject.Name = "lbOfSubject";
            this.lbOfSubject.Size = new System.Drawing.Size(112, 13);
            this.lbOfSubject.TabIndex = 0;
            this.lbOfSubject.Text = "Название предмета:";
            // 
            // lbSubject
            // 
            this.lbSubject.AutoSize = true;
            this.lbSubject.Location = new System.Drawing.Point(136, 50);
            this.lbSubject.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSubject.Name = "lbSubject";
            this.lbSubject.Size = new System.Drawing.Size(35, 13);
            this.lbSubject.TabIndex = 1;
            this.lbSubject.Text = "label2";
            // 
            // lbOfDifficulty
            // 
            this.lbOfDifficulty.AutoSize = true;
            this.lbOfDifficulty.Location = new System.Drawing.Point(20, 93);
            this.lbOfDifficulty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOfDifficulty.Name = "lbOfDifficulty";
            this.lbOfDifficulty.Size = new System.Drawing.Size(66, 13);
            this.lbOfDifficulty.TabIndex = 2;
            this.lbOfDifficulty.Text = "Сложность:";
            // 
            // lbDifficulty
            // 
            this.lbDifficulty.AutoSize = true;
            this.lbDifficulty.Location = new System.Drawing.Point(136, 93);
            this.lbDifficulty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDifficulty.Name = "lbDifficulty";
            this.lbDifficulty.Size = new System.Drawing.Size(35, 13);
            this.lbDifficulty.TabIndex = 3;
            this.lbDifficulty.Text = "label4";
            // 
            // lbOfDate
            // 
            this.lbOfDate.AutoSize = true;
            this.lbOfDate.Location = new System.Drawing.Point(20, 146);
            this.lbOfDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbOfDate.Name = "lbOfDate";
            this.lbOfDate.Size = new System.Drawing.Size(108, 13);
            this.lbOfDate.TabIndex = 4;
            this.lbOfDate.Text = "Время выполнения:";
            // 
            // lbStart
            // 
            this.lbStart.AutoSize = true;
            this.lbStart.Location = new System.Drawing.Point(136, 146);
            this.lbStart.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStart.Name = "lbStart";
            this.lbStart.Size = new System.Drawing.Size(35, 13);
            this.lbStart.TabIndex = 5;
            this.lbStart.Text = "label6";
            // 
            // lbEnd
            // 
            this.lbEnd.AutoSize = true;
            this.lbEnd.Location = new System.Drawing.Point(249, 146);
            this.lbEnd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbEnd.Name = "lbEnd";
            this.lbEnd.Size = new System.Drawing.Size(35, 13);
            this.lbEnd.TabIndex = 6;
            this.lbEnd.Text = "label7";
            // 
            // richTbDescription
            // 
            this.richTbDescription.Location = new System.Drawing.Point(22, 193);
            this.richTbDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTbDescription.Name = "richTbDescription";
            this.richTbDescription.ReadOnly = true;
            this.richTbDescription.Size = new System.Drawing.Size(260, 144);
            this.richTbDescription.TabIndex = 7;
            this.richTbDescription.Text = "";
            // 
            // ViewHomeworkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.richTbDescription);
            this.Controls.Add(this.lbEnd);
            this.Controls.Add(this.lbStart);
            this.Controls.Add(this.lbOfDate);
            this.Controls.Add(this.lbDifficulty);
            this.Controls.Add(this.lbOfDifficulty);
            this.Controls.Add(this.lbSubject);
            this.Controls.Add(this.lbOfSubject);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ViewHomeworkForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbOfSubject;
        private System.Windows.Forms.Label lbSubject;
        private System.Windows.Forms.Label lbOfDifficulty;
        private System.Windows.Forms.Label lbDifficulty;
        private System.Windows.Forms.Label lbOfDate;
        private System.Windows.Forms.Label lbStart;
        private System.Windows.Forms.Label lbEnd;
        private System.Windows.Forms.RichTextBox richTbDescription;
    }
}