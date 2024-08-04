namespace MyProject3
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCodeUser = new System.Windows.Forms.Button();
            this.maskedTextBoxCodeUser = new System.Windows.Forms.MaskedTextBox();
            this.labelNode1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(588, 80);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(145, 32);
            this.label1.TabIndex = 80;
            this.label1.Text = "היומן שלי:";
            // 
            // buttonCodeUser
            // 
            this.buttonCodeUser.Location = new System.Drawing.Point(312, 315);
            this.buttonCodeUser.Name = "buttonCodeUser";
            this.buttonCodeUser.Size = new System.Drawing.Size(204, 42);
            this.buttonCodeUser.TabIndex = 79;
            this.buttonCodeUser.Text = "אישור";
            this.buttonCodeUser.UseVisualStyleBackColor = true;
            this.buttonCodeUser.Click += new System.EventHandler(this.button1_Click);
            // 
            // maskedTextBoxCodeUser
            // 
            this.maskedTextBoxCodeUser.Location = new System.Drawing.Point(286, 228);
            this.maskedTextBoxCodeUser.Name = "maskedTextBoxCodeUser";
            this.maskedTextBoxCodeUser.Size = new System.Drawing.Size(254, 22);
            this.maskedTextBoxCodeUser.TabIndex = 81;
            this.maskedTextBoxCodeUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelNode1
            // 
            this.labelNode1.AutoSize = true;
            this.labelNode1.Location = new System.Drawing.Point(303, 360);
            this.labelNode1.Name = "labelNode1";
            this.labelNode1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelNode1.Size = new System.Drawing.Size(187, 17);
            this.labelNode1.TabIndex = 82;
            this.labelNode1.Text = "הסיסמא שהוקשה שגויה,נסו שוב.";
            this.labelNode1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(355, 205);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 83;
            this.label2.Text = "הקישי קוד כניסה";
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelNode1);
            this.Controls.Add(this.maskedTextBoxCodeUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCodeUser);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HomePage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCodeUser;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCodeUser;
        private System.Windows.Forms.Label labelNode1;
        private System.Windows.Forms.Label label2;
    }
}

