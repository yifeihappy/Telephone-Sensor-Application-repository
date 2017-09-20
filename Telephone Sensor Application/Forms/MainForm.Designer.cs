namespace Telephone_Sensor_Application
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accelerateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gravityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gyroscopeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magneticToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.windowsToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.startToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1010, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(65, 21);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accelerateToolStripMenuItem,
            this.gravityToolStripMenuItem,
            this.gyroscopeToolStripMenuItem,
            this.magneticToolStripMenuItem});
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.windowsToolStripMenuItem.Text = "&Windows";
            // 
            // accelerateToolStripMenuItem
            // 
            this.accelerateToolStripMenuItem.Name = "accelerateToolStripMenuItem";
            this.accelerateToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.accelerateToolStripMenuItem.Text = "Accelerate";
            this.accelerateToolStripMenuItem.Click += new System.EventHandler(this.accelerateToolStripMenuItem_Click);
            // 
            // gravityToolStripMenuItem
            // 
            this.gravityToolStripMenuItem.Name = "gravityToolStripMenuItem";
            this.gravityToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.gravityToolStripMenuItem.Text = "Gravity";
            this.gravityToolStripMenuItem.Click += new System.EventHandler(this.gravityToolStripMenuItem_Click);
            // 
            // gyroscopeToolStripMenuItem
            // 
            this.gyroscopeToolStripMenuItem.Name = "gyroscopeToolStripMenuItem";
            this.gyroscopeToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.gyroscopeToolStripMenuItem.Text = "Gyroscope";
            this.gyroscopeToolStripMenuItem.Click += new System.EventHandler(this.gyroscopeToolStripMenuItem_Click);
            // 
            // magneticToolStripMenuItem
            // 
            this.magneticToolStripMenuItem.Name = "magneticToolStripMenuItem";
            this.magneticToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.magneticToolStripMenuItem.Text = "Magnetic";
            this.magneticToolStripMenuItem.Click += new System.EventHandler(this.magneticToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.stopToolStripMenuItem.Text = "Sto&p";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.startToolStripMenuItem.Text = "Star&t";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.Location = new System.Drawing.Point(0, 25);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.RightToLeftLayout = true;
            this.dockPanel1.Size = new System.Drawing.Size(1010, 725);
            this.dockPanel1.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 750);
            this.Controls.Add(this.dockPanel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripMenuItem accelerateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gravityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gyroscopeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem magneticToolStripMenuItem;
    }
}

