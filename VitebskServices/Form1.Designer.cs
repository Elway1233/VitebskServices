namespace VitebskServices
{
    partial class Form1
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
            this.Services = new System.Windows.Forms.ToolStripMenuItem();
            this.Head = new System.Windows.Forms.ToolStripMenuItem();
            this.Products = new System.Windows.Forms.ToolStripMenuItem();
            this.Entertainment = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonMap = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Services});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Services
            // 
            this.Services.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Head,
            this.Products,
            this.Entertainment});
            this.Services.Name = "Services";
            this.Services.Size = new System.Drawing.Size(57, 20);
            this.Services.Text = "Услуги";
            // 
            // Head
            // 
            this.Head.Name = "Head";
            this.Head.Size = new System.Drawing.Size(168, 22);
            this.Head.Text = "Парикмахерские";
            this.Head.Click += new System.EventHandler(this.Head_Click);
            // 
            // Products
            // 
            this.Products.Name = "Products";
            this.Products.Size = new System.Drawing.Size(168, 22);
            this.Products.Text = "Продукты";
            this.Products.Click += new System.EventHandler(this.Products_Click);
            // 
            // Entertainment
            // 
            this.Entertainment.Name = "Entertainment";
            this.Entertainment.Size = new System.Drawing.Size(168, 22);
            this.Entertainment.Text = "Развлечения";
            this.Entertainment.Click += new System.EventHandler(this.Entertainment_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 44);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(602, 405);
            this.textBox1.TabIndex = 1;
            // 
            // buttonMap
            // 
            this.buttonMap.Location = new System.Drawing.Point(648, 1);
            this.buttonMap.Name = "buttonMap";
            this.buttonMap.Size = new System.Drawing.Size(119, 23);
            this.buttonMap.TabIndex = 3;
            this.buttonMap.Text = "Показать на карте";
            this.buttonMap.UseVisualStyleBackColor = true;
            this.buttonMap.Click += new System.EventHandler(this.buttonMap_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonMap);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "IS";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Services;
        private System.Windows.Forms.ToolStripMenuItem Head;
        private System.Windows.Forms.ToolStripMenuItem Products;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem Entertainment;
        private System.Windows.Forms.Button buttonMap;
    }
}

