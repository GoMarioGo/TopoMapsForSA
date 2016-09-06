namespace GIS2LKMAP
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
            this.buttonASC2LK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLK2ASC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonASC2LK
            // 
            this.buttonASC2LK.Location = new System.Drawing.Point(109, 150);
            this.buttonASC2LK.Margin = new System.Windows.Forms.Padding(2);
            this.buttonASC2LK.Name = "buttonASC2LK";
            this.buttonASC2LK.Size = new System.Drawing.Size(107, 55);
            this.buttonASC2LK.TabIndex = 1;
            this.buttonASC2LK.Text = "ASC to KMAP ";
            this.buttonASC2LK.UseVisualStyleBackColor = true;
            this.buttonASC2LK.Click += new System.EventHandler(this.buttonASC2LK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonLK2ASC
            // 
            this.buttonLK2ASC.Location = new System.Drawing.Point(109, 53);
            this.buttonLK2ASC.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLK2ASC.Name = "buttonLK2ASC";
            this.buttonLK2ASC.Size = new System.Drawing.Size(107, 50);
            this.buttonLK2ASC.TabIndex = 0;
            this.buttonLK2ASC.Text = "LKMAP to ASC";
            this.buttonLK2ASC.UseVisualStyleBackColor = true;
            this.buttonLK2ASC.Click += new System.EventHandler(this.buttonLK2ASC_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 277);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonASC2LK);
            this.Controls.Add(this.buttonLK2ASC);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "GIS2LKMAP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonASC2LK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLK2ASC;
    }
}

