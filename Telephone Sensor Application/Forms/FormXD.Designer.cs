﻿namespace Telephone_Sensor_Application.Forms
{
    partial class FormXD
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabelLineType = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxLineType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabelLineWidth = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxLineWidth = new System.Windows.Forms.ToolStripComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelLineType,
            this.toolStripComboBoxLineType,
            this.toolStripLabelLineWidth,
            this.toolStripComboBoxLineWidth});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(994, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabelLineType
            // 
            this.toolStripLabelLineType.Name = "toolStripLabelLineType";
            this.toolStripLabelLineType.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabelLineType.Text = "LineType";
            // 
            // toolStripComboBoxLineType
            // 
            this.toolStripComboBoxLineType.Name = "toolStripComboBoxLineType";
            this.toolStripComboBoxLineType.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripLabelLineWidth
            // 
            this.toolStripLabelLineWidth.Name = "toolStripLabelLineWidth";
            this.toolStripLabelLineWidth.Size = new System.Drawing.Size(65, 22);
            this.toolStripLabelLineWidth.Text = "LineWidth";
            // 
            // toolStripComboBoxLineWidth
            // 
            this.toolStripComboBoxLineWidth.Name = "toolStripComboBoxLineWidth";
            this.toolStripComboBoxLineWidth.Size = new System.Drawing.Size(121, 25);
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Location = new System.Drawing.Point(0, 28);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(994, 677);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // FormXD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 702);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.toolStrip1);
            this.HideOnClose = true;
            this.Name = "FormXD";
            this.TabText = "FormXD";
            this.Text = "FormXD";
            this.Load += new System.EventHandler(this.Form3D_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabelLineType;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxLineType;
        private System.Windows.Forms.ToolStripLabel toolStripLabelLineWidth;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxLineWidth;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}