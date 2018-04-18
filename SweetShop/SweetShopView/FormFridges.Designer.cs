namespace SweetShopView
{
    partial class FormFridges
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
            this.FFrSRel = new System.Windows.Forms.Button();
            this.FFrSDel = new System.Windows.Forms.Button();
            this.FFrSUpd = new System.Windows.Forms.Button();
            this.FFrSAdd = new System.Windows.Forms.Button();
            this.FFrSList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.FFrSList)).BeginInit();
            this.SuspendLayout();
            // 
            // FFrSRel
            // 
            this.FFrSRel.Location = new System.Drawing.Point(573, 153);
            this.FFrSRel.Name = "FFrSRel";
            this.FFrSRel.Size = new System.Drawing.Size(106, 32);
            this.FFrSRel.TabIndex = 14;
            this.FFrSRel.Text = "Reload";
            this.FFrSRel.UseVisualStyleBackColor = true;
            this.FFrSRel.Click += new System.EventHandler(this.FFrSRel_Click);
            // 
            // FFrSDel
            // 
            this.FFrSDel.Location = new System.Drawing.Point(573, 115);
            this.FFrSDel.Name = "FFrSDel";
            this.FFrSDel.Size = new System.Drawing.Size(106, 32);
            this.FFrSDel.TabIndex = 13;
            this.FFrSDel.Text = "Delete";
            this.FFrSDel.UseVisualStyleBackColor = true;
            this.FFrSDel.Click += new System.EventHandler(this.FFrSDel_Click);
            // 
            // FFrSUpd
            // 
            this.FFrSUpd.Location = new System.Drawing.Point(573, 77);
            this.FFrSUpd.Name = "FFrSUpd";
            this.FFrSUpd.Size = new System.Drawing.Size(106, 32);
            this.FFrSUpd.TabIndex = 12;
            this.FFrSUpd.Text = "Update";
            this.FFrSUpd.UseVisualStyleBackColor = true;
            this.FFrSUpd.Click += new System.EventHandler(this.FFrSUpd_Click);
            // 
            // FFrSAdd
            // 
            this.FFrSAdd.Location = new System.Drawing.Point(573, 39);
            this.FFrSAdd.Name = "FFrSAdd";
            this.FFrSAdd.Size = new System.Drawing.Size(106, 32);
            this.FFrSAdd.TabIndex = 11;
            this.FFrSAdd.Text = "Add";
            this.FFrSAdd.UseVisualStyleBackColor = true;
            this.FFrSAdd.Click += new System.EventHandler(this.FFrSAdd_Click);
            // 
            // FFrSList
            // 
            this.FFrSList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FFrSList.Location = new System.Drawing.Point(12, 12);
            this.FFrSList.Name = "FFrSList";
            this.FFrSList.RowTemplate.Height = 28;
            this.FFrSList.Size = new System.Drawing.Size(512, 562);
            this.FFrSList.TabIndex = 10;
            // 
            // FormFridges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 599);
            this.Controls.Add(this.FFrSRel);
            this.Controls.Add(this.FFrSDel);
            this.Controls.Add(this.FFrSUpd);
            this.Controls.Add(this.FFrSAdd);
            this.Controls.Add(this.FFrSList);
            this.Name = "FormFridges";
            this.Text = "Fridges";
            this.Load += new System.EventHandler(this.FormFridges_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FFrSList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FFrSRel;
        private System.Windows.Forms.Button FFrSDel;
        private System.Windows.Forms.Button FFrSUpd;
        private System.Windows.Forms.Button FFrSAdd;
        private System.Windows.Forms.DataGridView FFrSList;
    }
}