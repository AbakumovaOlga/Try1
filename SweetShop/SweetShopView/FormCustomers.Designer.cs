namespace SweetShopView
{
    partial class FormCustomers
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
            this.FCusSList = new System.Windows.Forms.DataGridView();
            this.FCusSAdd = new System.Windows.Forms.Button();
            this.FCusSUpd = new System.Windows.Forms.Button();
            this.FCusSDel = new System.Windows.Forms.Button();
            this.FCusSRel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FCusSList)).BeginInit();
            this.SuspendLayout();
            // 
            // FCusSList
            // 
            this.FCusSList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FCusSList.Location = new System.Drawing.Point(11, 7);
            this.FCusSList.Name = "FCusSList";
            this.FCusSList.RowTemplate.Height = 28;
            this.FCusSList.Size = new System.Drawing.Size(512, 562);
            this.FCusSList.TabIndex = 0;
            // 
            // FCusSAdd
            // 
            this.FCusSAdd.Location = new System.Drawing.Point(572, 34);
            this.FCusSAdd.Name = "FCusSAdd";
            this.FCusSAdd.Size = new System.Drawing.Size(106, 32);
            this.FCusSAdd.TabIndex = 1;
            this.FCusSAdd.Text = "Add";
            this.FCusSAdd.UseVisualStyleBackColor = true;
            this.FCusSAdd.Click += new System.EventHandler(this.FCusSAdd_Click);
            // 
            // FCusSUpd
            // 
            this.FCusSUpd.Location = new System.Drawing.Point(572, 72);
            this.FCusSUpd.Name = "FCusSUpd";
            this.FCusSUpd.Size = new System.Drawing.Size(106, 32);
            this.FCusSUpd.TabIndex = 2;
            this.FCusSUpd.Text = "Update";
            this.FCusSUpd.UseVisualStyleBackColor = true;
            this.FCusSUpd.Click += new System.EventHandler(this.FCusSUpd_Click);
            // 
            // FCusSDel
            // 
            this.FCusSDel.Location = new System.Drawing.Point(572, 110);
            this.FCusSDel.Name = "FCusSDel";
            this.FCusSDel.Size = new System.Drawing.Size(106, 32);
            this.FCusSDel.TabIndex = 3;
            this.FCusSDel.Text = "Delete";
            this.FCusSDel.UseVisualStyleBackColor = true;
            this.FCusSDel.Click += new System.EventHandler(this.FCusSDel_Click);
            // 
            // FCusSRel
            // 
            this.FCusSRel.Location = new System.Drawing.Point(572, 148);
            this.FCusSRel.Name = "FCusSRel";
            this.FCusSRel.Size = new System.Drawing.Size(106, 32);
            this.FCusSRel.TabIndex = 4;
            this.FCusSRel.Text = "Reload";
            this.FCusSRel.UseVisualStyleBackColor = true;
            this.FCusSRel.Click += new System.EventHandler(this.FCusSRel_Click);
            // 
            // FormCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 575);
            this.Controls.Add(this.FCusSRel);
            this.Controls.Add(this.FCusSDel);
            this.Controls.Add(this.FCusSUpd);
            this.Controls.Add(this.FCusSAdd);
            this.Controls.Add(this.FCusSList);
            this.Name = "FormCustomers";
            this.Text = "Customers";
            this.Load += new System.EventHandler(this.FormCustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FCusSList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView FCusSList;
        private System.Windows.Forms.Button FCusSAdd;
        private System.Windows.Forms.Button FCusSUpd;
        private System.Windows.Forms.Button FCusSDel;
        private System.Windows.Forms.Button FCusSRel;
    }
}