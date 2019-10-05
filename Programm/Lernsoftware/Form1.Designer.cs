namespace Lernsoftware
{
    partial class Form1
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
            this.cmdReadFile = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdSaveCard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdReadFile
            // 
            this.cmdReadFile.Location = new System.Drawing.Point(887, 66);
            this.cmdReadFile.Name = "cmdReadFile";
            this.cmdReadFile.Size = new System.Drawing.Size(152, 57);
            this.cmdReadFile.TabIndex = 9;
            this.cmdReadFile.Text = "Karten anzeigen";
            this.cmdReadFile.Click += new System.EventHandler(this.cmdReadFile_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(627, 166);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(672, 371);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(166, 165);
            this.txtQuestion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(421, 26);
            this.txtQuestion.TabIndex = 6;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(166, 205);
            this.txtAnswer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(421, 26);
            this.txtAnswer.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 209);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Antwort:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 169);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Frage:";
            // 
            // cmdSaveCard
            // 
            this.cmdSaveCard.Location = new System.Drawing.Point(299, 66);
            this.cmdSaveCard.Name = "cmdSaveCard";
            this.cmdSaveCard.Size = new System.Drawing.Size(152, 57);
            this.cmdSaveCard.TabIndex = 8;
            this.cmdSaveCard.Text = "Karte speichern";
            this.cmdSaveCard.Click += new System.EventHandler(this.cmdSaveCard_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 609);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.cmdSaveCard);
            this.Controls.Add(this.cmdReadFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdReadFile;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtQuestion;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdSaveCard;
    }
}

