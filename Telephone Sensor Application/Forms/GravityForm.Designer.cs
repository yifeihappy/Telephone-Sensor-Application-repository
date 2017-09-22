namespace Telephone_Sensor_Application.Forms
{
    partial class GravityForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxLineType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxLineWidth = new System.Windows.Forms.ToolStripComboBox();
            this.chartGravity = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGravity)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripComboBoxLineType,
            this.toolStripLabel2,
            this.toolStripComboBoxLineWidth});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(747, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel1.Text = "LineType";
            // 
            // toolStripComboBoxLineType
            // 
            this.toolStripComboBoxLineType.Name = "toolStripComboBoxLineType";
            this.toolStripComboBoxLineType.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(65, 22);
            this.toolStripLabel2.Text = "LineWidth";
            // 
            // toolStripComboBoxLineWidth
            // 
            this.toolStripComboBoxLineWidth.Name = "toolStripComboBoxLineWidth";
            this.toolStripComboBoxLineWidth.Size = new System.Drawing.Size(121, 25);
            // 
            // chartGravity
            // 
            chartArea2.Name = "ChartAreaGravity";
            this.chartGravity.ChartAreas.Add(chartArea2);
            this.chartGravity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartGravity.Location = new System.Drawing.Point(0, 25);
            this.chartGravity.Name = "chartGravity";
            this.chartGravity.Size = new System.Drawing.Size(747, 448);
            this.chartGravity.TabIndex = 1;
            this.chartGravity.Text = "chart1";
            // 
            // GravityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 473);
            this.Controls.Add(this.chartGravity);
            this.Controls.Add(this.toolStrip1);
            this.HideOnClose = true;
            this.Name = "GravityForm";
            this.TabText = "GravityForm";
            this.Text = "GravityForm";
            this.Load += new System.EventHandler(this.GravityForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartGravity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxLineType;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxLineWidth;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGravity;
    }
}