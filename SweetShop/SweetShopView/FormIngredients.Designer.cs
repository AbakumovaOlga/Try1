namespace SweetShopView
{
    partial class FormIngredients
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
            this.FIngrSRel = new System.Windows.Forms.Button();
            this.FIngrSDel = new System.Windows.Forms.Button();
            this.FIngrSUpd = new System.Windows.Forms.Button();
            this.FIngrSAdd = new System.Windows.Forms.Button();
            this.FIngrSList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.FIngrSList)).BeginInit();
            this.SuspendLayout();
            // 
            // FIngrSRel
            // 
            this.FIngrSRel.Location = new System.Drawing.Point(573, 146);
            this.FIngrSRel.Name = "FIngrSRel";
            this.FIngrSRel.Size = new System.Drawing.Size(106, 32);
            this.FIngrSRel.TabIndex = 9;
            this.FIngrSRel.Text = "Reload";
            this.FIngrSRel.UseVisualStyleBackColor = true;
            this.FIngrSRel.Click += new System.EventHandler(this.FIngrSRel_Click);
            // 
            // FIngrSDel
            // 
            this.FIngrSDel.Location = new System.Drawing.Point(573, 108);
            this.FIngrSDel.Name = "FIngrSDel";
            this.FIngrSDel.Size = new System.Drawing.Size(106, 32);
            this.FIngrSDel.TabIndex = 8;
            this.FIngrSDel.Text = "Delete";
            this.FIngrSDel.UseVisualStyleBackColor = true;
            this.FIngrSDel.Click += new System.EventHandler(this.FIngrSDel_Click);
            // 
            // FIngrSUpd
            // 
            this.FIngrSUpd.Location = new System.Drawing.Point(573, 70);
            this.FIngrSUpd.Name = "FIngrSUpd";
            this.FIngrSUpd.Size = new System.Drawing.Size(106, 32);
            this.FIngrSUpd.TabIndex = 7;
            this.FIngrSUpd.Text = "Update";
            this.FIngrSUpd.UseVisualStyleBackColor = true;
            this.FIngrSUpd.Click += new System.EventHandler(this.FIngrSUpd_Click);
            // 
            // FIngrSAdd
            // 
            this.FIngrSAdd.Location = new System.Drawing.Point(573, 32);
            this.FIngrSAdd.Name = "FIngrSAdd";
            this.FIngrSAdd.Size = new System.Drawing.Size(106, 32);
            this.FIngrSAdd.TabIndex = 6;
            this.FIngrSAdd.Text = "Add";
            this.FIngrSAdd.UseVisualStyleBackColor = true;
            this.FIngrSAdd.Click += new System.EventHandler(this.FIngrSAdd_Click);
            // 
            // FIngrSList
            // 
            this.FIngrSList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FIngrSList.Location = new System.Drawing.Point(12, 5);
            this.FIngrSList.Name = "FIngrSList";
            this.FIngrSList.RowTemplate.Height = 28;
            this.FIngrSList.Size = new System.Drawing.Size(512, 562);
            this.FIngrSList.TabIndex = 5;
            // 
            // FormIngredients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 579);
            this.Controls.Add(this.FIngrSRel);
            this.Controls.Add(this.FIngrSDel);
            this.Controls.Add(this.FIngrSUpd);
            this.Controls.Add(this.FIngrSAdd);
            this.Controls.Add(this.FIngrSList);
            this.Name = "FormIngredients";
            this.Text = "Ingredients";
            this.Load += new System.EventHandler(this.FormIngredients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FIngrSList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FIngrSRel;
        private System.Windows.Forms.Button FIngrSDel;
        private System.Windows.Forms.Button FIngrSUpd;
        private System.Windows.Forms.Button FIngrSAdd;
        private System.Windows.Forms.DataGridView FIngrSList;
    }
}