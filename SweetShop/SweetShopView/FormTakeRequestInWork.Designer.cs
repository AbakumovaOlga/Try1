namespace SweetShopView
{
    partial class FormTakeRequestInWork
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
            this.lable1 = new System.Windows.Forms.Label();
            this.FTRSave = new System.Windows.Forms.Button();
            this.FTRCancel = new System.Windows.Forms.Button();
            this.FTRBaker = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(22, 28);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(51, 20);
            this.lable1.TabIndex = 0;
            this.lable1.Text = "Baker";
            // 
            // FTRSave
            // 
            this.FTRSave.Location = new System.Drawing.Point(272, 86);
            this.FTRSave.Name = "FTRSave";
            this.FTRSave.Size = new System.Drawing.Size(108, 38);
            this.FTRSave.TabIndex = 1;
            this.FTRSave.Text = "Save";
            this.FTRSave.UseVisualStyleBackColor = true;
            this.FTRSave.Click += new System.EventHandler(this.FTRSave_Click);
            // 
            // FTRCancel
            // 
            this.FTRCancel.Location = new System.Drawing.Point(386, 86);
            this.FTRCancel.Name = "FTRCancel";
            this.FTRCancel.Size = new System.Drawing.Size(108, 38);
            this.FTRCancel.TabIndex = 2;
            this.FTRCancel.Text = "Cancel";
            this.FTRCancel.UseVisualStyleBackColor = true;
            this.FTRCancel.Click += new System.EventHandler(this.FTRCancel_Click);
            // 
            // FTRBaker
            // 
            this.FTRBaker.FormattingEnabled = true;
            this.FTRBaker.Location = new System.Drawing.Point(138, 28);
            this.FTRBaker.Name = "FTRBaker";
            this.FTRBaker.Size = new System.Drawing.Size(297, 28);
            this.FTRBaker.TabIndex = 3;
            // 
            // FormTakeRequestInWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 163);
            this.Controls.Add(this.FTRBaker);
            this.Controls.Add(this.FTRCancel);
            this.Controls.Add(this.FTRSave);
            this.Controls.Add(this.lable1);
            this.Name = "FormTakeRequestInWork";
            this.Text = "TakeRequestInWork";
            this.Load += new System.EventHandler(this.FormBaker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.Button FTRSave;
        private System.Windows.Forms.Button FTRCancel;
        private System.Windows.Forms.ComboBox FTRBaker;
    }
}