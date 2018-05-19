namespace SweetShopView
{
    partial class FormBaker
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
            this.FBakCancel = new System.Windows.Forms.Button();
            this.FBakSave = new System.Windows.Forms.Button();
            this.FBakFIO = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FBakCancel
            // 
            this.FBakCancel.Location = new System.Drawing.Point(312, 95);
            this.FBakCancel.Name = "FBakCancel";
            this.FBakCancel.Size = new System.Drawing.Size(122, 38);
            this.FBakCancel.TabIndex = 7;
            this.FBakCancel.Text = "Cancel";
            this.FBakCancel.UseVisualStyleBackColor = true;
            this.FBakCancel.Click += new System.EventHandler(this.FBakCancel_Click);
            // 
            // FBakSave
            // 
            this.FBakSave.Location = new System.Drawing.Point(157, 95);
            this.FBakSave.Name = "FBakSave";
            this.FBakSave.Size = new System.Drawing.Size(122, 38);
            this.FBakSave.TabIndex = 6;
            this.FBakSave.Text = "Save";
            this.FBakSave.UseVisualStyleBackColor = true;
            this.FBakSave.Click += new System.EventHandler(this.FBakSave_Click);
            // 
            // FBakFIO
            // 
            this.FBakFIO.Location = new System.Drawing.Point(105, 20);
            this.FBakFIO.Name = "FBakFIO";
            this.FBakFIO.Size = new System.Drawing.Size(329, 26);
            this.FBakFIO.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "FIO";
            // 
            // FormBaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 161);
            this.Controls.Add(this.FBakCancel);
            this.Controls.Add(this.FBakSave);
            this.Controls.Add(this.FBakFIO);
            this.Controls.Add(this.label1);
            this.Name = "FormBaker";
            this.Text = "Baker";
            this.Load += new System.EventHandler(this.FormBaker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FBakCancel;
        private System.Windows.Forms.Button FBakSave;
        private System.Windows.Forms.TextBox FBakFIO;
        private System.Windows.Forms.Label label1;
    }
}