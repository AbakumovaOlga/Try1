namespace SweetShopView
{
    partial class FormReplenishFridge
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
            this.FRFFridge = new System.Windows.Forms.ComboBox();
            this.FRFIngredient = new System.Windows.Forms.ComboBox();
            this.FRFNumber = new System.Windows.Forms.TextBox();
            this.FRFSave = new System.Windows.Forms.Button();
            this.FRFCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fridge";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ingredient";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number";
            // 
            // FRFFridge
            // 
            this.FRFFridge.FormattingEnabled = true;
            this.FRFFridge.Location = new System.Drawing.Point(148, 34);
            this.FRFFridge.Name = "FRFFridge";
            this.FRFFridge.Size = new System.Drawing.Size(244, 28);
            this.FRFFridge.TabIndex = 3;
            // 
            // FRFIngredient
            // 
            this.FRFIngredient.FormattingEnabled = true;
            this.FRFIngredient.Location = new System.Drawing.Point(148, 75);
            this.FRFIngredient.Name = "FRFIngredient";
            this.FRFIngredient.Size = new System.Drawing.Size(244, 28);
            this.FRFIngredient.TabIndex = 4;
            // 
            // FRFNumber
            // 
            this.FRFNumber.Location = new System.Drawing.Point(148, 118);
            this.FRFNumber.Name = "FRFNumber";
            this.FRFNumber.Size = new System.Drawing.Size(100, 26);
            this.FRFNumber.TabIndex = 5;
            // 
            // FRFSave
            // 
            this.FRFSave.Location = new System.Drawing.Point(351, 212);
            this.FRFSave.Name = "FRFSave";
            this.FRFSave.Size = new System.Drawing.Size(97, 37);
            this.FRFSave.TabIndex = 6;
            this.FRFSave.Text = "Save";
            this.FRFSave.UseVisualStyleBackColor = true;
            this.FRFSave.Click += new System.EventHandler(this.FRFSave_Click);
            // 
            // FRFCancel
            // 
            this.FRFCancel.Location = new System.Drawing.Point(454, 212);
            this.FRFCancel.Name = "FRFCancel";
            this.FRFCancel.Size = new System.Drawing.Size(97, 37);
            this.FRFCancel.TabIndex = 7;
            this.FRFCancel.Text = "Cancel";
            this.FRFCancel.UseVisualStyleBackColor = true;
            this.FRFCancel.Click += new System.EventHandler(this.FRFCancel_Click);
            // 
            // FormReplenishFridge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 261);
            this.Controls.Add(this.FRFCancel);
            this.Controls.Add(this.FRFSave);
            this.Controls.Add(this.FRFNumber);
            this.Controls.Add(this.FRFIngredient);
            this.Controls.Add(this.FRFFridge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormReplenishFridge";
            this.Text = "ReplenishFridge";
            this.Load += new System.EventHandler(this.FormReplenishFridge_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox FRFFridge;
        private System.Windows.Forms.ComboBox FRFIngredient;
        private System.Windows.Forms.TextBox FRFNumber;
        private System.Windows.Forms.Button FRFSave;
        private System.Windows.Forms.Button FRFCancel;
    }
}