namespace Telephone_Sensor_Application.Forms
{
    partial class AccelerateForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsplLineType = new System.Windows.Forms.ToolStripLabel();
            this.LineTypeTSCB = new System.Windows.Forms.ToolStripComboBox();
            this.LineWidthtoolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.LineWidthTSCB = new System.Windows.Forms.ToolStripComboBox();
            this.charAccelerate = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.charAccelerate)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsplLineType,
            this.LineTypeTSCB,
            this.LineWidthtoolStripLabel,
            this.LineWidthTSCB});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(994, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsplLineType
            // 
            this.tsplLineType.Name = "tsplLineType";
            this.tsplLineType.Size = new System.Drawing.Size(59, 22);
            this.tsplLineType.Text = "LineType";
            // 
            // LineTypeTSCB
            // 
            this.LineTypeTSCB.Name = "LineTypeTSCB";
            this.LineTypeTSCB.Size = new System.Drawing.Size(121, 25);
            // 
            // LineWidthtoolStripLabel
            // 
            this.LineWidthtoolStripLabel.Name = "LineWidthtoolStripLabel";
            this.LineWidthtoolStripLabel.Size = new System.Drawing.Size(65, 22);
            this.LineWidthtoolStripLabel.Text = "LineWidth";
            // 
            // LineWidthTSCB
            // 
            this.LineWidthTSCB.Name = "LineWidthTSCB";
            this.LineWidthTSCB.Size = new System.Drawing.Size(121, 25);
            // 
            // charAccelerate
            // 
            chartArea1.Name = "ChartAreaAccelerate";
            this.charAccelerate.ChartAreas.Add(chartArea1);
            this.charAccelerate.Location = new System.Drawing.Point(0, 28);
            this.charAccelerate.Name = "charAccelerate";
            this.charAccelerate.Size = new System.Drawing.Size(994, 677);
            this.charAccelerate.TabIndex = 3;
            this.charAccelerate.Text = "chart1";
            // 
            // AccelerateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 702);
            this.Controls.Add(this.charAccelerate);
            this.Controls.Add(this.toolStrip1);
            this.HideOnClose = true;
            this.Name = "AccelerateForm";
            this.TabText = "AccelerateForm";
            this.Text = "AccelerateForm";
            this.Load += new System.EventHandler(this.AccelerateForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.charAccelerate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tsplLineType;
        private System.Windows.Forms.ToolStripComboBox LineTypeTSCB;
        private System.Windows.Forms.DataVisualization.Charting.Chart charAccelerate;
        private System.Windows.Forms.ToolStripLabel LineWidthtoolStripLabel;
        private System.Windows.Forms.ToolStripComboBox LineWidthTSCB;
    }
}