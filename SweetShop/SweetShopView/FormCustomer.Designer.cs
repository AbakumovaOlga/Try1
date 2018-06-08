namespace SweetShopView
{
    partial class FormCustomer
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
            this.FCusFIO = new System.Windows.Forms.TextBox();
            this.FCusSave = new System.Windows.Forms.Button();
            this.FCusCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "FIO";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // FCusFIO
            // 
            this.FCusFIO.Location = new System.Drawing.Point(125, 56);
            this.FCusFIO.Name = "FCusFIO";
            this.FCusFIO.Size = new System.Drawing.Size(329, 26);
            this.FCusFIO.TabIndex = 1;
            this.FCusFIO.TextChanged += new System.EventHandler(this.FCusFIO_TextChanged);
            // 
            // FCusSave
            // 
            this.FCusSave.Location = new System.Drawing.Point(177, 131);
            this.FCusSave.Name = "FCusSave";
            this.FCusSave.Size = new System.Drawing.Size(122, 38);
            this.FCusSave.TabIndex = 2;
            this.FCusSave.Text = "Save";
            this.FCusSave.UseVisualStyleBackColor = true;
            this.FCusSave.Click += new System.EventHandler(this.FCusSave_Click);
            // 
            // FCusCancel
            // 
            this.FCusCancel.Location = new System.Drawing.Point(332, 131);
            this.FCusCancel.Name = "FCusCancel";
            this.FCusCancel.Size = new System.Drawing.Size(122, 38);
            this.FCusCancel.TabIndex = 3;
            this.FCusCancel.Text = "Cancel";
            this.FCusCancel.UseVisualStyleBackColor = true;
            this.FCusCancel.Click += new System.EventHandler(this.FCusCancel_Click);
            // 
            // FormCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 199);
            this.Controls.Add(this.FCusCancel);
            this.Controls.Add(this.FCusSave);
            this.Controls.Add(this.FCusFIO);
            this.Controls.Add(this.label1);
            this.Name = "FormCustomer";
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.FormCustomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FCusFIO;
        private System.Windows.Forms.Button FCusSave;
        private System.Windows.Forms.Button FCusCancel;
    }
}