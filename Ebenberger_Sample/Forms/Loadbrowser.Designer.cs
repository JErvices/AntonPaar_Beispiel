namespace Ebenberger_Sample.Forms
{
    partial class Loadbrowser
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pshCancel = new System.Windows.Forms.Button();
            this.spinnerBox = new System.Windows.Forms.PictureBox();
            this.lblMaxCount = new System.Windows.Forms.Label();
            this.lblTopText = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainPanel.Controls.Add(this.lblMaxCount);
            this.mainPanel.Controls.Add(this.progressBar);
            this.mainPanel.Controls.Add(this.pshCancel);
            this.mainPanel.Controls.Add(this.spinnerBox);
            this.mainPanel.Controls.Add(this.lblTopText);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(6);
            this.mainPanel.Size = new System.Drawing.Size(291, 87);
            this.mainPanel.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(76, 32);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(204, 18);
            this.progressBar.TabIndex = 5;
            // 
            // pshCancel
            // 
            this.pshCancel.Location = new System.Drawing.Point(205, 56);
            this.pshCancel.Name = "pshCancel";
            this.pshCancel.Size = new System.Drawing.Size(75, 23);
            this.pshCancel.TabIndex = 4;
            this.pshCancel.Text = "&Abbrechen";
            this.pshCancel.UseVisualStyleBackColor = true;
            // 
            // spinnerBox
            // 
            this.spinnerBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.spinnerBox.Image = global::Ebenberger_Sample.Properties.Resources.Settings;
            this.spinnerBox.Location = new System.Drawing.Point(6, 15);
            this.spinnerBox.Name = "spinnerBox";
            this.spinnerBox.Size = new System.Drawing.Size(64, 64);
            this.spinnerBox.TabIndex = 2;
            this.spinnerBox.TabStop = false;
            // 
            // lblMaxCount
            // 
            this.lblMaxCount.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxCount.Location = new System.Drawing.Point(76, 56);
            this.lblMaxCount.Name = "lblMaxCount";
            this.lblMaxCount.Size = new System.Drawing.Size(123, 23);
            this.lblMaxCount.TabIndex = 6;
            this.lblMaxCount.Text = "label1";
            this.lblMaxCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTopText
            // 
            this.lblTopText.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopText.Location = new System.Drawing.Point(79, 6);
            this.lblTopText.Name = "lblTopText";
            this.lblTopText.Size = new System.Drawing.Size(204, 23);
            this.lblTopText.TabIndex = 0;
            this.lblTopText.Text = "label1";
            this.lblTopText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Loadbrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 87);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loadbrowser";
            this.Text = "Loadbrowser";
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinnerBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.PictureBox spinnerBox;
        private System.Windows.Forms.Button pshCancel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblMaxCount;
        private System.Windows.Forms.Label lblTopText;
    }
}