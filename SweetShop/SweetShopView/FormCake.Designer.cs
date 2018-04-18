namespace SweetShopView
{
    partial class FormCake
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FCList = new System.Windows.Forms.DataGridView();
            this.FCakeRel = new System.Windows.Forms.Button();
            this.FCakeDel = new System.Windows.Forms.Button();
            this.FCakeUpd = new System.Windows.Forms.Button();
            this.FCakeAdd = new System.Windows.Forms.Button();
            this.FCakeSave = new System.Windows.Forms.Button();
            this.FCakeCancel = new System.Windows.Forms.Button();
            this.FCakeName = new System.Windows.Forms.TextBox();
            this.FCakePrice = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FCList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Price";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FCList);
            this.groupBox1.Controls.Add(this.FCakeRel);
            this.groupBox1.Controls.Add(this.FCakeDel);
            this.groupBox1.Controls.Add(this.FCakeUpd);
            this.groupBox1.Controls.Add(this.FCakeAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(666, 414);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingredient";
            // 
            // FCList
            // 
            this.FCList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FCList.Location = new System.Drawing.Point(21, 36);
            this.FCList.Name = "FCList";
            this.FCList.RowTemplate.Height = 28;
            this.FCList.Size = new System.Drawing.Size(527, 342);
            this.FCList.TabIndex = 8;
            // 
            // FCakeRel
            // 
            this.FCakeRel.Location = new System.Drawing.Point(570, 157);
            this.FCakeRel.Name = "FCakeRel";
            this.FCakeRel.Size = new System.Drawing.Size(90, 38);
            this.FCakeRel.TabIndex = 7;
            this.FCakeRel.Text = "Reload";
            this.FCakeRel.UseVisualStyleBackColor = true;
            this.FCakeRel.Click += new System.EventHandler(this.FCakeRel_Click);
            // 
            // FCakeDel
            // 
            this.FCakeDel.Location = new System.Drawing.Point(570, 113);
            this.FCakeDel.Name = "FCakeDel";
            this.FCakeDel.Size = new System.Drawing.Size(90, 38);
            this.FCakeDel.TabIndex = 6;
            this.FCakeDel.Text = "Delete";
            this.FCakeDel.UseVisualStyleBackColor = true;
            this.FCakeDel.Click += new System.EventHandler(this.FCakeDel_Click);
            // 
            // FCakeUpd
            // 
            this.FCakeUpd.Location = new System.Drawing.Point(570, 69);
            this.FCakeUpd.Name = "FCakeUpd";
            this.FCakeUpd.Size = new System.Drawing.Size(90, 38);
            this.FCakeUpd.TabIndex = 5;
            this.FCakeUpd.Text = "Update";
            this.FCakeUpd.UseVisualStyleBackColor = true;
            this.FCakeUpd.Click += new System.EventHandler(this.FCakeUpd_Click);
            // 
            // FCakeAdd
            // 
            this.FCakeAdd.Location = new System.Drawing.Point(570, 25);
            this.FCakeAdd.Name = "FCakeAdd";
            this.FCakeAdd.Size = new System.Drawing.Size(90, 38);
            this.FCakeAdd.TabIndex = 4;
            this.FCakeAdd.Text = "Add";
            this.FCakeAdd.UseVisualStyleBackColor = true;
            this.FCakeAdd.Click += new System.EventHandler(this.FCakeAdd_Click);
            // 
            // FCakeSave
            // 
            this.FCakeSave.Location = new System.Drawing.Point(471, 581);
            this.FCakeSave.Name = "FCakeSave";
            this.FCakeSave.Size = new System.Drawing.Size(90, 38);
            this.FCakeSave.TabIndex = 3;
            this.FCakeSave.Text = "Save";
            this.FCakeSave.UseVisualStyleBackColor = true;
            this.FCakeSave.Click += new System.EventHandler(this.FCakeSave_Click);
            // 
            // FCakeCancel
            // 
            this.FCakeCancel.Location = new System.Drawing.Point(588, 581);
            this.FCakeCancel.Name = "FCakeCancel";
            this.FCakeCancel.Size = new System.Drawing.Size(90, 38);
            this.FCakeCancel.TabIndex = 4;
            this.FCakeCancel.Text = "Cancel";
            this.FCakeCancel.UseVisualStyleBackColor = true;
            this.FCakeCancel.Click += new System.EventHandler(this.FCakeCancel_Click);
            // 
            // FCakeName
            // 
            this.FCakeName.Location = new System.Drawing.Point(150, 43);
            this.FCakeName.Name = "FCakeName";
            this.FCakeName.Size = new System.Drawing.Size(272, 26);
            this.FCakeName.TabIndex = 5;
            // 
            // FCakePrice
            // 
            this.FCakePrice.Location = new System.Drawing.Point(150, 100);
            this.FCakePrice.Name = "FCakePrice";
            this.FCakePrice.Size = new System.Drawing.Size(106, 26);
            this.FCakePrice.TabIndex = 6;
            // 
            // FormCake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 631);
            this.Controls.Add(this.FCakePrice);
            this.Controls.Add(this.FCakeName);
            this.Controls.Add(this.FCakeCancel);
            this.Controls.Add(this.FCakeSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormCake";
            this.Text = "Cake";
            this.Load += new System.EventHandler(this.FormCake_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FCList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button FCakeRel;
        private System.Windows.Forms.Button FCakeDel;
        private System.Windows.Forms.Button FCakeUpd;
        private System.Windows.Forms.Button FCakeAdd;
        private System.Windows.Forms.Button FCakeSave;
        private System.Windows.Forms.Button FCakeCancel;
        private System.Windows.Forms.TextBox FCakeName;
        private System.Windows.Forms.TextBox FCakePrice;
        private System.Windows.Forms.DataGridView FCList;
    }
}