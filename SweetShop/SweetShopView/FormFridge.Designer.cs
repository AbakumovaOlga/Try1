namespace SweetShopView
{
    partial class FormFridge
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
            this.FFrCancel = new System.Windows.Forms.Button();
            this.FFrSave = new System.Windows.Forms.Button();
            this.FFrName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // FFrCancel
            // 
            this.FFrCancel.Location = new System.Drawing.Point(629, 388);
            this.FFrCancel.Name = "FFrCancel";
            this.FFrCancel.Size = new System.Drawing.Size(122, 38);
            this.FFrCancel.TabIndex = 11;
            this.FFrCancel.Text = "Cancel";
            this.FFrCancel.UseVisualStyleBackColor = true;
            this.FFrCancel.Click += new System.EventHandler(this.FFrCancel_Click);
            // 
            // FFrSave
            // 
            this.FFrSave.Location = new System.Drawing.Point(474, 388);
            this.FFrSave.Name = "FFrSave";
            this.FFrSave.Size = new System.Drawing.Size(122, 38);
            this.FFrSave.TabIndex = 10;
            this.FFrSave.Text = "Save";
            this.FFrSave.UseVisualStyleBackColor = true;
            this.FFrSave.Click += new System.EventHandler(this.FFrSave_Click);
            // 
            // FFrName
            // 
            this.FFrName.Location = new System.Drawing.Point(103, 28);
            this.FFrName.Name = "FFrName";
            this.FFrName.Size = new System.Drawing.Size(329, 26);
            this.FFrName.TabIndex = 9;
            this.FFrName.TextChanged += new System.EventHandler(this.FFrName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(85, 102);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(452, 237);
            this.dataGridView.TabIndex = 12;
            // 
            // FormFridge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 454);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.FFrCancel);
            this.Controls.Add(this.FFrSave);
            this.Controls.Add(this.FFrName);
            this.Controls.Add(this.label1);
            this.Name = "FormFridge";
            this.Text = "Fridge";
            this.Load += new System.EventHandler(this.FormFridge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FFrCancel;
        private System.Windows.Forms.Button FFrSave;
        private System.Windows.Forms.TextBox FFrName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}