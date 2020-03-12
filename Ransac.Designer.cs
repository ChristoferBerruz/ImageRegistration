namespace ImageRegistration
{
    partial class Ransac
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtInitPercent = new System.Windows.Forms.TextBox();
            this.txtTotalPercent = new System.Windows.Forms.TextBox();
            this.txtIterations = new System.Windows.Forms.TextBox();
            this.txtTreshold = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "You are about to use the RANSAC algorithm.\r\nPlease fill out the blanks, then pres" +
    "s Submit\r\n";
            // 
            // txtInitPercent
            // 
            this.txtInitPercent.Location = new System.Drawing.Point(297, 123);
            this.txtInitPercent.Name = "txtInitPercent";
            this.txtInitPercent.Size = new System.Drawing.Size(167, 22);
            this.txtInitPercent.TabIndex = 1;
            // 
            // txtTotalPercent
            // 
            this.txtTotalPercent.Location = new System.Drawing.Point(297, 167);
            this.txtTotalPercent.Name = "txtTotalPercent";
            this.txtTotalPercent.Size = new System.Drawing.Size(167, 22);
            this.txtTotalPercent.TabIndex = 2;
            // 
            // txtIterations
            // 
            this.txtIterations.Location = new System.Drawing.Point(297, 217);
            this.txtIterations.Name = "txtIterations";
            this.txtIterations.Size = new System.Drawing.Size(167, 22);
            this.txtIterations.TabIndex = 3;
            // 
            // txtTreshold
            // 
            this.txtTreshold.Location = new System.Drawing.Point(297, 272);
            this.txtTreshold.Name = "txtTreshold";
            this.txtTreshold.Size = new System.Drawing.Size(167, 22);
            this.txtTreshold.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Initial size of consensus set (e.g. 0.5):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(246, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Total size of consensus set (e.g. 0.8):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Number of iterations:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Treshold value:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSubmit.Location = new System.Drawing.Point(479, 315);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(125, 42);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // Ransac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 382);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTreshold);
            this.Controls.Add(this.txtIterations);
            this.Controls.Add(this.txtTotalPercent);
            this.Controls.Add(this.txtInitPercent);
            this.Controls.Add(this.label1);
            this.Name = "Ransac";
            this.Text = "Ransac";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInitPercent;
        private System.Windows.Forms.TextBox txtTotalPercent;
        private System.Windows.Forms.TextBox txtIterations;
        private System.Windows.Forms.TextBox txtTreshold;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSubmit;

        public double InitPercent{ set { } get { return float.Parse(txtInitPercent.Text); } }
        public double TotalPercent { set { } get { return float.Parse(txtTotalPercent.Text); } }

        public double Treshold { set { } get { return float.Parse(txtTreshold.Text); } }
        public int Iterations { set { } get { return int.Parse(txtIterations.Text); } }
    }
}