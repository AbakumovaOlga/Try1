namespace SweetShopView
{
    partial class FormBakers
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
            this.FBakSRel = new System.Windows.Forms.Button();
            this.FBakSDel = new System.Windows.Forms.Button();
            this.FBakSUpd = new System.Windows.Forms.Button();
            this.FBakSAdd = new System.Windows.Forms.Button();
            this.FBakSList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.FBakSList)).BeginInit();
            this.SuspendLayout();
            // 
            // FBakSRel
            // 
            this.FBakSRel.Location = new System.Drawing.Point(573, 153);
            this.FBakSRel.Name = "FBakSRel";
            this.FBakSRel.Size = new System.Drawing.Size(106, 32);
            this.FBakSRel.TabIndex = 9;
            this.FBakSRel.Text = "Reload";
            this.FBakSRel.UseVisualStyleBackColor = true;
            this.FBakSRel.Click += new System.EventHandler(this.FBakSRel_Click);
            // 
            // FBakSDel
            // 
            this.FBakSDel.Location = new System.Drawing.Point(573, 115);
            this.FBakSDel.Name = "FBakSDel";
            this.FBakSDel.Size = new System.Drawing.Size(106, 32);
            this.FBakSDel.TabIndex = 8;
            this.FBakSDel.Text = "Delete";
            this.FBakSDel.UseVisualStyleBackColor = true;
            this.FBakSDel.Click += new System.EventHandler(this.FBakSDel_Click);
            // 
            // FBakSUpd
            // 
            this.FBakSUpd.Location = new System.Drawing.Point(573, 77);
            this.FBakSUpd.Name = "FBakSUpd";
            this.FBakSUpd.Size = new System.Drawing.Size(106, 32);
            this.FBakSUpd.TabIndex = 7;
            this.FBakSUpd.Text = "Update";
            this.FBakSUpd.UseVisualStyleBackColor = true;
            this.FBakSUpd.Click += new System.EventHandler(this.FBakSUpd_Click);
            // 
            // FBakSAdd
            // 
            this.FBakSAdd.Location = new System.Drawing.Point(573, 39);
            this.FBakSAdd.Name = "FBakSAdd";
            this.FBakSAdd.Size = new System.Drawing.Size(106, 32);
            this.FBakSAdd.TabIndex = 6;
            this.FBakSAdd.Text = "Add";
            this.FBakSAdd.UseVisualStyleBackColor = true;
            this.FBakSAdd.Click += new System.EventHandler(this.FBakSAdd_Click);
            // 
            // FBakSList
            // 
            this.FBakSList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FBakSList.Location = new System.Drawing.Point(12, 12);
            this.FBakSList.Name = "FBakSList";
            this.FBakSList.RowTemplate.Height = 28;
            this.FBakSList.Size = new System.Drawing.Size(512, 562);
            this.FBakSList.TabIndex = 5;
            // 
            // FormBakers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 596);
            this.Controls.Add(this.FBakSRel);
            this.Controls.Add(this.FBakSDel);
            this.Controls.Add(this.FBakSUpd);
            this.Controls.Add(this.FBakSAdd);
            this.Controls.Add(this.FBakSList);
            this.Name = "FormBakers";
            this.Text = "Bakers";
            this.Load += new System.EventHandler(this.FormBakers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FBakSList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FBakSRel;
        private System.Windows.Forms.Button FBakSDel;
        private System.Windows.Forms.Button FBakSUpd;
        private System.Windows.Forms.Button FBakSAdd;
        private System.Windows.Forms.DataGridView FBakSList;
    }
}