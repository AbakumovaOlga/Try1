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
            System.Windows.Forms.Label label2;
            this.label1 = new System.Windows.Forms.Label();
            this.FCusFIO = new System.Windows.Forms.TextBox();
            this.FCusSave = new System.Windows.Forms.Button();
            this.FCusCancel = new System.Windows.Forms.Button();
            this.FCusMail = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(554, 56);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(37, 20);
            label2.TabIndex = 4;
            label2.Text = "Mail";
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
            this.FCusSave.Location = new System.Drawing.Point(644, 610);
            this.FCusSave.Name = "FCusSave";
            this.FCusSave.Size = new System.Drawing.Size(122, 38);
            this.FCusSave.TabIndex = 2;
            this.FCusSave.Text = "Save";
            this.FCusSave.UseVisualStyleBackColor = true;
            this.FCusSave.Click += new System.EventHandler(this.FCusSave_Click);
            // 
            // FCusCancel
            // 
            this.FCusCancel.Location = new System.Drawing.Point(799, 610);
            this.FCusCancel.Name = "FCusCancel";
            this.FCusCancel.Size = new System.Drawing.Size(122, 38);
            this.FCusCancel.TabIndex = 3;
            this.FCusCancel.Text = "Cancel";
            this.FCusCancel.UseVisualStyleBackColor = true;
            this.FCusCancel.Click += new System.EventHandler(this.FCusCancel_Click);
            // 
            // FCusMail
            // 
            this.FCusMail.Location = new System.Drawing.Point(647, 56);
            this.FCusMail.Name = "FCusMail";
            this.FCusMail.Size = new System.Drawing.Size(329, 26);
            this.FCusMail.TabIndex = 5;
            this.FCusMail.TextChanged += new System.EventHandler(this.FCusMail_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(96, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(972, 474);
            this.dataGridView1.TabIndex = 6;
            // 
            // FormCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1567, 660);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.FCusMail);
            this.Controls.Add(label2);
            this.Controls.Add(this.FCusCancel);
            this.Controls.Add(this.FCusSave);
            this.Controls.Add(this.FCusFIO);
            this.Controls.Add(this.label1);
            this.Name = "FormCustomer";
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.FormCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FCusFIO;
        private System.Windows.Forms.Button FCusSave;
        private System.Windows.Forms.Button FCusCancel;
        private System.Windows.Forms.TextBox FCusMail;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}