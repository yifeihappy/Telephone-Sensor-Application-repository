namespace Telephone_Sensor_Application.Forms
{
    partial class SettingForm
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
            this.groupBoxSensorsType = new System.Windows.Forms.GroupBox();
            this.checkedListBoxSensorsType = new System.Windows.Forms.CheckedListBox();
            this.btnSensorsType = new System.Windows.Forms.Button();
            this.groupBoxRadioButton = new System.Windows.Forms.GroupBox();
            this.radioButtonFASTEST = new System.Windows.Forms.RadioButton();
            this.radioButtonGame = new System.Windows.Forms.RadioButton();
            this.radioButtonUI = new System.Windows.Forms.RadioButton();
            this.radioButtonNormal = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBoxSensorsType.SuspendLayout();
            this.groupBoxRadioButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSensorsType
            // 
            this.groupBoxSensorsType.Controls.Add(this.checkedListBoxSensorsType);
            this.groupBoxSensorsType.Location = new System.Drawing.Point(25, 61);
            this.groupBoxSensorsType.Name = "groupBoxSensorsType";
            this.groupBoxSensorsType.Size = new System.Drawing.Size(305, 245);
            this.groupBoxSensorsType.TabIndex = 0;
            this.groupBoxSensorsType.TabStop = false;
            this.groupBoxSensorsType.Text = "选择需要的传感器类型";
            // 
            // checkedListBoxSensorsType
            // 
            this.checkedListBoxSensorsType.FormattingEnabled = true;
            this.checkedListBoxSensorsType.Location = new System.Drawing.Point(22, 31);
            this.checkedListBoxSensorsType.Name = "checkedListBoxSensorsType";
            this.checkedListBoxSensorsType.Size = new System.Drawing.Size(256, 196);
            this.checkedListBoxSensorsType.TabIndex = 0;
            // 
            // btnSensorsType
            // 
            this.btnSensorsType.Location = new System.Drawing.Point(133, 12);
            this.btnSensorsType.Name = "btnSensorsType";
            this.btnSensorsType.Size = new System.Drawing.Size(75, 23);
            this.btnSensorsType.TabIndex = 1;
            this.btnSensorsType.Text = "获取传感器类型";
            this.btnSensorsType.UseVisualStyleBackColor = true;
            this.btnSensorsType.Click += new System.EventHandler(this.btnSensorsType_Click);
            // 
            // groupBoxRadioButton
            // 
            this.groupBoxRadioButton.Controls.Add(this.radioButtonFASTEST);
            this.groupBoxRadioButton.Controls.Add(this.radioButtonGame);
            this.groupBoxRadioButton.Controls.Add(this.radioButtonUI);
            this.groupBoxRadioButton.Controls.Add(this.radioButtonNormal);
            this.groupBoxRadioButton.Location = new System.Drawing.Point(25, 322);
            this.groupBoxRadioButton.Name = "groupBoxRadioButton";
            this.groupBoxRadioButton.Size = new System.Drawing.Size(305, 129);
            this.groupBoxRadioButton.TabIndex = 2;
            this.groupBoxRadioButton.TabStop = false;
            this.groupBoxRadioButton.Text = "SamplingPeriodUs";
            // 
            // radioButtonFASTEST
            // 
            this.radioButtonFASTEST.AutoSize = true;
            this.radioButtonFASTEST.Location = new System.Drawing.Point(22, 88);
            this.radioButtonFASTEST.Name = "radioButtonFASTEST";
            this.radioButtonFASTEST.Size = new System.Drawing.Size(65, 16);
            this.radioButtonFASTEST.TabIndex = 3;
            this.radioButtonFASTEST.Text = "FASTEST";
            this.radioButtonFASTEST.UseVisualStyleBackColor = true;
            // 
            // radioButtonGame
            // 
            this.radioButtonGame.AutoSize = true;
            this.radioButtonGame.Location = new System.Drawing.Point(22, 66);
            this.radioButtonGame.Name = "radioButtonGame";
            this.radioButtonGame.Size = new System.Drawing.Size(47, 16);
            this.radioButtonGame.TabIndex = 2;
            this.radioButtonGame.Text = "GAME";
            this.radioButtonGame.UseVisualStyleBackColor = true;
            // 
            // radioButtonUI
            // 
            this.radioButtonUI.AutoSize = true;
            this.radioButtonUI.Location = new System.Drawing.Point(22, 43);
            this.radioButtonUI.Name = "radioButtonUI";
            this.radioButtonUI.Size = new System.Drawing.Size(35, 16);
            this.radioButtonUI.TabIndex = 1;
            this.radioButtonUI.Text = "UI";
            this.radioButtonUI.UseVisualStyleBackColor = true;
            // 
            // radioButtonNormal
            // 
            this.radioButtonNormal.AutoSize = true;
            this.radioButtonNormal.Checked = true;
            this.radioButtonNormal.Location = new System.Drawing.Point(22, 21);
            this.radioButtonNormal.Name = "radioButtonNormal";
            this.radioButtonNormal.Size = new System.Drawing.Size(59, 16);
            this.radioButtonNormal.TabIndex = 0;
            this.radioButtonNormal.TabStop = true;
            this.radioButtonNormal.Text = "NORMAL\r\n";
            this.radioButtonNormal.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(133, 457);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 520);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxRadioButton);
            this.Controls.Add(this.btnSensorsType);
            this.Controls.Add(this.groupBoxSensorsType);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.HideOnClose = true;
            this.Name = "SettingForm";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.TabText = "SettingForm";
            this.Text = "SettingForm";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.groupBoxSensorsType.ResumeLayout(false);
            this.groupBoxRadioButton.ResumeLayout(false);
            this.groupBoxRadioButton.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSensorsType;
        private System.Windows.Forms.CheckedListBox checkedListBoxSensorsType;
        public System.Windows.Forms.Button btnSensorsType;
        private System.Windows.Forms.GroupBox groupBoxRadioButton;
        private System.Windows.Forms.RadioButton radioButtonFASTEST;
        private System.Windows.Forms.RadioButton radioButtonGame;
        private System.Windows.Forms.RadioButton radioButtonUI;
        private System.Windows.Forms.RadioButton radioButtonNormal;
        private System.Windows.Forms.Button buttonOK;
    }
}