namespace SweetShopView
{
    partial class FormCreateRequest
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.FCRCustomer = new System.Windows.Forms.ComboBox();
            this.FCRCake = new System.Windows.Forms.ComboBox();
            this.FCRNumber = new System.Windows.Forms.TextBox();
            this.FCRSum = new System.Windows.Forms.TextBox();
            this.FCRSave = new System.Windows.Forms.Button();
            this.FCRCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cake";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Sum";
            // 
            // FCRCustomer
            // 
            this.FCRCustomer.FormattingEnabled = true;
            this.FCRCustomer.Location = new System.Drawing.Point(155, 47);
            this.FCRCustomer.Name = "FCRCustomer";
            this.FCRCustomer.Size = new System.Drawing.Size(263, 28);
            this.FCRCustomer.TabIndex = 4;
            // 
            // FCRCake
            // 
            this.FCRCake.FormattingEnabled = true;
            this.FCRCake.Location = new System.Drawing.Point(155, 96);
            this.FCRCake.Name = "FCRCake";
            this.FCRCake.Size = new System.Drawing.Size(263, 28);
            this.FCRCake.TabIndex = 5;
            // 
            // FCRNumber
            // 
            this.FCRNumber.Location = new System.Drawing.Point(155, 154);
            this.FCRNumber.Name = "FCRNumber";
            this.FCRNumber.Size = new System.Drawing.Size(100, 26);
            this.FCRNumber.TabIndex = 6;
            this.FCRNumber.TextChanged += new System.EventHandler(this.FCRNumber_TextChanged);
            // 
            // FCRSum
            // 
            this.FCRSum.Enabled = false;
            this.FCRSum.Location = new System.Drawing.Point(155, 208);
            this.FCRSum.Name = "FCRSum";
            this.FCRSum.Size = new System.Drawing.Size(100, 26);
            this.FCRSum.TabIndex = 7;
            // 
            // FCRSave
            // 
            this.FCRSave.Location = new System.Drawing.Point(310, 289);
            this.FCRSave.Name = "FCRSave";
            this.FCRSave.Size = new System.Drawing.Size(108, 39);
            this.FCRSave.TabIndex = 8;
            this.FCRSave.Text = "Save";
            this.FCRSave.UseVisualStyleBackColor = true;
            this.FCRSave.Click += new System.EventHandler(this.FCRSave_Click);
            // 
            // FCRCancel
            // 
            this.FCRCancel.Location = new System.Drawing.Point(471, 289);
            this.FCRCancel.Name = "FCRCancel";
            this.FCRCancel.Size = new System.Drawing.Size(108, 39);
            this.FCRCancel.TabIndex = 9;
            this.FCRCancel.Text = "Cancel";
            this.FCRCancel.UseVisualStyleBackColor = true;
            this.FCRCancel.Click += new System.EventHandler(this.FCRCancel_Click);
            // 
            // FormCreateRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 358);
            this.Controls.Add(this.FCRCancel);
            this.Controls.Add(this.FCRSave);
            this.Controls.Add(this.FCRSum);
            this.Controls.Add(this.FCRNumber);
            this.Controls.Add(this.FCRCake);
            this.Controls.Add(this.FCRCustomer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormCreateRequest";
            this.Text = "CreateRequest";
            this.Load += new System.EventHandler(this.FormCreateRequest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox FCRCustomer;
        private System.Windows.Forms.ComboBox FCRCake;
        private System.Windows.Forms.TextBox FCRNumber;
        private System.Windows.Forms.TextBox FCRSum;
        private System.Windows.Forms.Button FCRSave;
        private System.Windows.Forms.Button FCRCancel;
    }
}