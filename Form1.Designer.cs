namespace ImageRegistration
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
            this.btnCreateShapes = new System.Windows.Forms.Button();
            this.btnApplyTransform = new System.Windows.Forms.Button();
            this.panOriginal = new System.Windows.Forms.Panel();
            this.panAfterT = new System.Windows.Forms.Panel();
            this.panRemoval = new System.Windows.Forms.Panel();
            this.btnOutlierRem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateShapes
            // 
            this.btnCreateShapes.Location = new System.Drawing.Point(134, 563);
            this.btnCreateShapes.Name = "btnCreateShapes";
            this.btnCreateShapes.Size = new System.Drawing.Size(155, 60);
            this.btnCreateShapes.TabIndex = 0;
            this.btnCreateShapes.Text = "Create Shapes";
            this.btnCreateShapes.UseVisualStyleBackColor = true;
            this.btnCreateShapes.Click += new System.EventHandler(this.btnCreateShapes_Click);
            // 
            // btnApplyTransform
            // 
            this.btnApplyTransform.Location = new System.Drawing.Point(538, 563);
            this.btnApplyTransform.Name = "btnApplyTransform";
            this.btnApplyTransform.Size = new System.Drawing.Size(155, 59);
            this.btnApplyTransform.TabIndex = 1;
            this.btnApplyTransform.Text = "Apply Transformation";
            this.btnApplyTransform.UseVisualStyleBackColor = true;
            this.btnApplyTransform.Click += new System.EventHandler(this.btnApplyTransform_Click);
            // 
            // panOriginal
            // 
            this.panOriginal.Location = new System.Drawing.Point(36, 29);
            this.panOriginal.Name = "panOriginal";
            this.panOriginal.Size = new System.Drawing.Size(356, 496);
            this.panOriginal.TabIndex = 2;
            // 
            // panAfterT
            // 
            this.panAfterT.Location = new System.Drawing.Point(440, 29);
            this.panAfterT.Name = "panAfterT";
            this.panAfterT.Size = new System.Drawing.Size(363, 496);
            this.panAfterT.TabIndex = 4;
            // 
            // panRemoval
            // 
            this.panRemoval.Location = new System.Drawing.Point(840, 29);
            this.panRemoval.Name = "panRemoval";
            this.panRemoval.Size = new System.Drawing.Size(339, 496);
            this.panRemoval.TabIndex = 5;
            // 
            // btnOutlierRem
            // 
            this.btnOutlierRem.Location = new System.Drawing.Point(920, 554);
            this.btnOutlierRem.Name = "btnOutlierRem";
            this.btnOutlierRem.Size = new System.Drawing.Size(155, 59);
            this.btnOutlierRem.TabIndex = 6;
            this.btnOutlierRem.Text = "Outlier Removal";
            this.btnOutlierRem.UseVisualStyleBackColor = true;
            this.btnOutlierRem.Click += new System.EventHandler(this.btnOutlierRem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 676);
            this.Controls.Add(this.btnOutlierRem);
            this.Controls.Add(this.panRemoval);
            this.Controls.Add(this.panAfterT);
            this.Controls.Add(this.panOriginal);
            this.Controls.Add(this.btnApplyTransform);
            this.Controls.Add(this.btnCreateShapes);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateShapes;
        private System.Windows.Forms.Button btnApplyTransform;
        private System.Windows.Forms.Panel panOriginal;
        private System.Windows.Forms.Panel panAfterT;
        private System.Windows.Forms.Panel panRemoval;
        private System.Windows.Forms.Button btnOutlierRem;
    }
}

