namespace SweetShopView
{
    partial class FormIngredient
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
            this.FIngrCancel = new System.Windows.Forms.Button();
            this.FIngrSave = new System.Windows.Forms.Button();
            this.FIngrName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FIngrCancel
            // 
            this.FIngrCancel.Location = new System.Drawing.Point(321, 104);
            this.FIngrCancel.Name = "FIngrCancel";
            this.FIngrCancel.Size = new System.Drawing.Size(122, 38);
            this.FIngrCancel.TabIndex = 7;
            this.FIngrCancel.Text = "Cancel";
            this.FIngrCancel.UseVisualStyleBackColor = true;
            this.FIngrCancel.Click += new System.EventHandler(this.FIngrCancel_Click);
            // 
            // FIngrSave
            // 
            this.FIngrSave.Location = new System.Drawing.Point(166, 104);
            this.FIngrSave.Name = "FIngrSave";
            this.FIngrSave.Size = new System.Drawing.Size(122, 38);
            this.FIngrSave.TabIndex = 6;
            this.FIngrSave.Text = "Save";
            this.FIngrSave.UseVisualStyleBackColor = true;
            this.FIngrSave.Click += new System.EventHandler(this.FIngrSave_Click);
            // 
            // FIngrName
            // 
            this.FIngrName.Location = new System.Drawing.Point(114, 29);
            this.FIngrName.Name = "FIngrName";
            this.FIngrName.Size = new System.Drawing.Size(329, 26);
            this.FIngrName.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // FormIngredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 176);
            this.Controls.Add(this.FIngrCancel);
            this.Controls.Add(this.FIngrSave);
            this.Controls.Add(this.FIngrName);
            this.Controls.Add(this.label1);
            this.Name = "FormIngredient";
            this.Text = "Ingredient";
            this.Load += new System.EventHandler(this.FormIngredient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FIngrCancel;
        private System.Windows.Forms.Button FIngrSave;
        private System.Windows.Forms.TextBox FIngrName;
        private System.Windows.Forms.Label label1;
    }
}