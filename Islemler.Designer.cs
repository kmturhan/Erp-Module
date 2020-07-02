namespace WindowsFormsApplication15
{
    partial class Islemler
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.raporlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aktifBakımlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toplamArızaSayılarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bakımcıÇalışmaSüreleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Orange;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.button1.Location = new System.Drawing.Point(98, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "Arıza Kaydı";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.button2.Location = new System.Drawing.Point(98, 164);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(189, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "Tezgahlar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Orange;
            this.button4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.button4.Location = new System.Drawing.Point(98, 110);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(189, 48);
            this.button4.TabIndex = 3;
            this.button4.Text = "Ceza Ücretleri";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.raporlarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(391, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // raporlarToolStripMenuItem
            // 
            this.raporlarToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.raporlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aktifBakımlarToolStripMenuItem,
            this.toplamArızaSayılarıToolStripMenuItem,
            this.bakımcıÇalışmaSüreleriToolStripMenuItem});
            this.raporlarToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.raporlarToolStripMenuItem.Name = "raporlarToolStripMenuItem";
            this.raporlarToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.raporlarToolStripMenuItem.Text = "Raporlar";
            // 
            // aktifBakımlarToolStripMenuItem
            // 
            this.aktifBakımlarToolStripMenuItem.BackColor = System.Drawing.Color.CornflowerBlue;
            this.aktifBakımlarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.aktifBakımlarToolStripMenuItem.Name = "aktifBakımlarToolStripMenuItem";
            this.aktifBakımlarToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.aktifBakımlarToolStripMenuItem.Text = "Aktif Bakımlar";
            this.aktifBakımlarToolStripMenuItem.Click += new System.EventHandler(this.aktifBakımlarToolStripMenuItem_Click);
            // 
            // toplamArızaSayılarıToolStripMenuItem
            // 
            this.toplamArızaSayılarıToolStripMenuItem.BackColor = System.Drawing.Color.CornflowerBlue;
            this.toplamArızaSayılarıToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toplamArızaSayılarıToolStripMenuItem.Name = "toplamArızaSayılarıToolStripMenuItem";
            this.toplamArızaSayılarıToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.toplamArızaSayılarıToolStripMenuItem.Text = "Toplam Arıza Sayıları";
            this.toplamArızaSayılarıToolStripMenuItem.Click += new System.EventHandler(this.toplamArızaSayılarıToolStripMenuItem_Click);
            // 
            // bakımcıÇalışmaSüreleriToolStripMenuItem
            // 
            this.bakımcıÇalışmaSüreleriToolStripMenuItem.BackColor = System.Drawing.Color.CornflowerBlue;
            this.bakımcıÇalışmaSüreleriToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bakımcıÇalışmaSüreleriToolStripMenuItem.Name = "bakımcıÇalışmaSüreleriToolStripMenuItem";
            this.bakımcıÇalışmaSüreleriToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.bakımcıÇalışmaSüreleriToolStripMenuItem.Text = "Bakımcı Çalışma Süreleri";
            this.bakımcıÇalışmaSüreleriToolStripMenuItem.Click += new System.EventHandler(this.bakımcıÇalışmaSüreleriToolStripMenuItem_Click);
            // 
            // Islemler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication15.Properties.Resources.logo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(391, 273);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Islemler";
            this.Text = "Islemler";
            this.Load += new System.EventHandler(this.Islemler_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem raporlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aktifBakımlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toplamArızaSayılarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bakımcıÇalışmaSüreleriToolStripMenuItem;
    }
}