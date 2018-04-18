namespace SweetShopView
{
    partial class FormCakes
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
            this.FCakeSRel = new System.Windows.Forms.Button();
            this.FCakeSDel = new System.Windows.Forms.Button();
            this.FCakeSUpd = new System.Windows.Forms.Button();
            this.FCakeSAdd = new System.Windows.Forms.Button();
            this.FCakeSList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.FCakeSList)).BeginInit();
            this.SuspendLayout();
            // 
            // FCakeSRel
            // 
            this.FCakeSRel.Location = new System.Drawing.Point(586, 144);
            this.FCakeSRel.Name = "FCakeSRel";
            this.FCakeSRel.Size = new System.Drawing.Size(106, 32);
            this.FCakeSRel.TabIndex = 9;
            this.FCakeSRel.Text = "Reload";
            this.FCakeSRel.UseVisualStyleBackColor = true;
            this.FCakeSRel.Click += new System.EventHandler(this.FCakeSRel_Click);
            // 
            // FCakeSDel
            // 
            this.FCakeSDel.Location = new System.Drawing.Point(586, 106);
            this.FCakeSDel.Name = "FCakeSDel";
            this.FCakeSDel.Size = new System.Drawing.Size(106, 32);
            this.FCakeSDel.TabIndex = 8;
            this.FCakeSDel.Text = "Delete";
            this.FCakeSDel.UseVisualStyleBackColor = true;
            this.FCakeSDel.Click += new System.EventHandler(this.FCakeSDel_Click);
            // 
            // FCakeSUpd
            // 
            this.FCakeSUpd.Location = new System.Drawing.Point(586, 68);
            this.FCakeSUpd.Name = "FCakeSUpd";
            this.FCakeSUpd.Size = new System.Drawing.Size(106, 32);
            this.FCakeSUpd.TabIndex = 7;
            this.FCakeSUpd.Text = "Update";
            this.FCakeSUpd.UseVisualStyleBackColor = true;
            this.FCakeSUpd.Click += new System.EventHandler(this.FCakeSUpd_Click);
            // 
            // FCakeSAdd
            // 
            this.FCakeSAdd.Location = new System.Drawing.Point(586, 30);
            this.FCakeSAdd.Name = "FCakeSAdd";
            this.FCakeSAdd.Size = new System.Drawing.Size(106, 32);
            this.FCakeSAdd.TabIndex = 6;
            this.FCakeSAdd.Text = "Add";
            this.FCakeSAdd.UseVisualStyleBackColor = true;
            this.FCakeSAdd.Click += new System.EventHandler(this.FCakeSAdd_Click);
            // 
            // FCakeSList
            // 
            this.FCakeSList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FCakeSList.Location = new System.Drawing.Point(25, 3);
            this.FCakeSList.Name = "FCakeSList";
            this.FCakeSList.RowTemplate.Height = 28;
            this.FCakeSList.Size = new System.Drawing.Size(512, 562);
            this.FCakeSList.TabIndex = 5;
            // 
            // FormCakes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 568);
            this.Controls.Add(this.FCakeSRel);
            this.Controls.Add(this.FCakeSDel);
            this.Controls.Add(this.FCakeSUpd);
            this.Controls.Add(this.FCakeSAdd);
            this.Controls.Add(this.FCakeSList);
            this.Name = "FormCakes";
            this.Text = "Cakes";
            this.Load += new System.EventHandler(this.FormCakes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FCakeSList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FCakeSRel;
        private System.Windows.Forms.Button FCakeSDel;
        private System.Windows.Forms.Button FCakeSUpd;
        private System.Windows.Forms.Button FCakeSAdd;
        private System.Windows.Forms.DataGridView FCakeSList;
    }
}