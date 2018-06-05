namespace SweetShopView
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.catalogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingredientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cakesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fridgesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bakersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replenishFridgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rreportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priceCakesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullnessOfFridgesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersRequestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FMList = new System.Windows.Forms.DataGridView();
            this.FMCreate = new System.Windows.Forms.Button();
            this.FMTake = new System.Windows.Forms.Button();
            this.FMFinish = new System.Windows.Forms.Button();
            this.FMPay = new System.Windows.Forms.Button();
            this.FMRel = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FMList)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.catalogsToolStripMenuItem,
            this.replenishFridgeToolStripMenuItem,
            this.rreportsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1413, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // catalogsToolStripMenuItem
            // 
            this.catalogsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customersToolStripMenuItem,
            this.ingredientsToolStripMenuItem,
            this.cakesToolStripMenuItem,
            this.fridgesToolStripMenuItem,
            this.bakersToolStripMenuItem});
            this.catalogsToolStripMenuItem.Name = "catalogsToolStripMenuItem";
            this.catalogsToolStripMenuItem.Size = new System.Drawing.Size(93, 29);
            this.catalogsToolStripMenuItem.Text = "Catalogs";
            // 
            // customersToolStripMenuItem
            // 
            this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            this.customersToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.customersToolStripMenuItem.Text = "Customers";
            this.customersToolStripMenuItem.Click += new System.EventHandler(this.customersToolStripMenuItem_Click);
            // 
            // ingredientsToolStripMenuItem
            // 
            this.ingredientsToolStripMenuItem.Name = "ingredientsToolStripMenuItem";
            this.ingredientsToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.ingredientsToolStripMenuItem.Text = "Ingredients";
            this.ingredientsToolStripMenuItem.Click += new System.EventHandler(this.ingredientsToolStripMenuItem_Click);
            // 
            // cakesToolStripMenuItem
            // 
            this.cakesToolStripMenuItem.Name = "cakesToolStripMenuItem";
            this.cakesToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.cakesToolStripMenuItem.Text = "Cakes";
            this.cakesToolStripMenuItem.Click += new System.EventHandler(this.cakesToolStripMenuItem_Click);
            // 
            // fridgesToolStripMenuItem
            // 
            this.fridgesToolStripMenuItem.Name = "fridgesToolStripMenuItem";
            this.fridgesToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.fridgesToolStripMenuItem.Text = "Fridges";
            this.fridgesToolStripMenuItem.Click += new System.EventHandler(this.fridgesToolStripMenuItem_Click);
            // 
            // bakersToolStripMenuItem
            // 
            this.bakersToolStripMenuItem.Name = "bakersToolStripMenuItem";
            this.bakersToolStripMenuItem.Size = new System.Drawing.Size(185, 30);
            this.bakersToolStripMenuItem.Text = "Bakers";
            this.bakersToolStripMenuItem.Click += new System.EventHandler(this.bakersToolStripMenuItem_Click);
            // 
            // replenishFridgeToolStripMenuItem
            // 
            this.replenishFridgeToolStripMenuItem.Name = "replenishFridgeToolStripMenuItem";
            this.replenishFridgeToolStripMenuItem.Size = new System.Drawing.Size(151, 29);
            this.replenishFridgeToolStripMenuItem.Text = "Replenish fridge";
            this.replenishFridgeToolStripMenuItem.Click += new System.EventHandler(this.replenishFridgeToolStripMenuItem_Click);
            // 
            // rreportsToolStripMenuItem
            // 
            this.rreportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.priceCakesToolStripMenuItem,
            this.fullnessOfFridgesToolStripMenuItem,
            this.customersRequestsToolStripMenuItem});
            this.rreportsToolStripMenuItem.Name = "rreportsToolStripMenuItem";
            this.rreportsToolStripMenuItem.Size = new System.Drawing.Size(92, 29);
            this.rreportsToolStripMenuItem.Text = "Rreports";
            // 
            // priceCakesToolStripMenuItem
            // 
            this.priceCakesToolStripMenuItem.Name = "priceCakesToolStripMenuItem";
            this.priceCakesToolStripMenuItem.Size = new System.Drawing.Size(258, 30);
            this.priceCakesToolStripMenuItem.Text = "Price Cakes";
            this.priceCakesToolStripMenuItem.Click += new System.EventHandler(this.priceCakesToolStripMenuItem_Click);
            // 
            // fullnessOfFridgesToolStripMenuItem
            // 
            this.fullnessOfFridgesToolStripMenuItem.Name = "fullnessOfFridgesToolStripMenuItem";
            this.fullnessOfFridgesToolStripMenuItem.Size = new System.Drawing.Size(258, 30);
            this.fullnessOfFridgesToolStripMenuItem.Text = "Fullness of Fridges";
            this.fullnessOfFridgesToolStripMenuItem.Click += new System.EventHandler(this.fullnessOfFridgesToolStripMenuItem_Click);
            // 
            // customersRequestsToolStripMenuItem
            // 
            this.customersRequestsToolStripMenuItem.Name = "customersRequestsToolStripMenuItem";
            this.customersRequestsToolStripMenuItem.Size = new System.Drawing.Size(258, 30);
            this.customersRequestsToolStripMenuItem.Text = "Customer`s requests";
            this.customersRequestsToolStripMenuItem.Click += new System.EventHandler(this.customersRequestsToolStripMenuItem_Click);
            // 
            // FMList
            // 
            this.FMList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FMList.Location = new System.Drawing.Point(12, 36);
            this.FMList.Name = "FMList";
            this.FMList.RowTemplate.Height = 28;
            this.FMList.Size = new System.Drawing.Size(993, 679);
            this.FMList.TabIndex = 1;
            // 
            // FMCreate
            // 
            this.FMCreate.Location = new System.Drawing.Point(1107, 81);
            this.FMCreate.Name = "FMCreate";
            this.FMCreate.Size = new System.Drawing.Size(183, 36);
            this.FMCreate.TabIndex = 2;
            this.FMCreate.Text = "Create Request";
            this.FMCreate.UseVisualStyleBackColor = true;
            this.FMCreate.Click += new System.EventHandler(this.FMCreate_Click);
            // 
            // FMTake
            // 
            this.FMTake.Location = new System.Drawing.Point(1107, 123);
            this.FMTake.Name = "FMTake";
            this.FMTake.Size = new System.Drawing.Size(183, 36);
            this.FMTake.TabIndex = 3;
            this.FMTake.Text = "Take Request In Work";
            this.FMTake.UseVisualStyleBackColor = true;
            this.FMTake.Click += new System.EventHandler(this.FMTake_Click);
            // 
            // FMFinish
            // 
            this.FMFinish.Location = new System.Drawing.Point(1107, 165);
            this.FMFinish.Name = "FMFinish";
            this.FMFinish.Size = new System.Drawing.Size(183, 36);
            this.FMFinish.TabIndex = 4;
            this.FMFinish.Text = "Finish Request";
            this.FMFinish.UseVisualStyleBackColor = true;
            this.FMFinish.Click += new System.EventHandler(this.FMFinish_Click);
            // 
            // FMPay
            // 
            this.FMPay.Location = new System.Drawing.Point(1107, 207);
            this.FMPay.Name = "FMPay";
            this.FMPay.Size = new System.Drawing.Size(183, 36);
            this.FMPay.TabIndex = 5;
            this.FMPay.Text = "Pay Request";
            this.FMPay.UseVisualStyleBackColor = true;
            this.FMPay.Click += new System.EventHandler(this.FMPay_Click);
            // 
            // FMRel
            // 
            this.FMRel.Location = new System.Drawing.Point(1107, 249);
            this.FMRel.Name = "FMRel";
            this.FMRel.Size = new System.Drawing.Size(183, 36);
            this.FMRel.TabIndex = 6;
            this.FMRel.Text = "Reload";
            this.FMRel.UseVisualStyleBackColor = true;
            this.FMRel.Click += new System.EventHandler(this.FMRel_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1413, 727);
            this.Controls.Add(this.FMRel);
            this.Controls.Add(this.FMPay);
            this.Controls.Add(this.FMFinish);
            this.Controls.Add(this.FMTake);
            this.Controls.Add(this.FMCreate);
            this.Controls.Add(this.FMList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "SweetShop";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FMList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem catalogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingredientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cakesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fridgesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bakersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replenishFridgeToolStripMenuItem;
        private System.Windows.Forms.DataGridView FMList;
        private System.Windows.Forms.Button FMCreate;
        private System.Windows.Forms.Button FMTake;
        private System.Windows.Forms.Button FMFinish;
        private System.Windows.Forms.Button FMPay;
        private System.Windows.Forms.Button FMRel;
        private System.Windows.Forms.ToolStripMenuItem rreportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem priceCakesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullnessOfFridgesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customersRequestsToolStripMenuItem;
    }
}

