namespace SweetShopView
{
    partial class FormCakeIngredient
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
            this.FCINumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FCISave = new System.Windows.Forms.Button();
            this.FCICancel = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // FCINumber
            // 
            this.FCINumber.Location = new System.Drawing.Point(188, 73);
            this.FCINumber.Name = "FCINumber";
            this.FCINumber.Size = new System.Drawing.Size(330, 26);
            this.FCINumber.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ingredient";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number";
            // 
            // FCISave
            // 
            this.FCISave.Location = new System.Drawing.Point(288, 120);
            this.FCISave.Name = "FCISave";
            this.FCISave.Size = new System.Drawing.Size(102, 30);
            this.FCISave.TabIndex = 4;
            this.FCISave.Text = "Save";
            this.FCISave.UseVisualStyleBackColor = true;
            this.FCISave.Click += new System.EventHandler(this.FCISave_Click);
            // 
            // FCICancel
            // 
            this.FCICancel.Location = new System.Drawing.Point(416, 120);
            this.FCICancel.Name = "FCICancel";
            this.FCICancel.Size = new System.Drawing.Size(102, 30);
            this.FCICancel.TabIndex = 5;
            this.FCICancel.Text = "Cancel";
            this.FCICancel.UseVisualStyleBackColor = true;
            this.FCICancel.Click += new System.EventHandler(this.FCICancel_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(188, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(329, 28);
            this.comboBox1.TabIndex = 6;
            // 
            // FormCakeIngredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 180);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.FCICancel);
            this.Controls.Add(this.FCISave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FCINumber);
            this.Name = "FormCakeIngredient";
            this.Text = "CakeIngregient";
            this.Load += new System.EventHandler(this.FormCakeIngredient_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox FCINumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button FCISave;
        private System.Windows.Forms.Button FCICancel;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}