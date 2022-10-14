namespace Ebenberger_Sample
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPanel = new System.Windows.Forms.Panel();
            this.listView = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pshClose = new System.Windows.Forms.Button();
            this.pshStart = new System.Windows.Forms.Button();
            this.topPanel = new System.Windows.Forms.Panel();
            this.pshSearchFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.listView);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Controls.Add(this.topPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(399, 537);
            this.mainPanel.TabIndex = 0;
            // 
            // listView
            // 
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 41);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(399, 458);
            this.listView.TabIndex = 4;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pshClose);
            this.panel1.Controls.Add(this.pshStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 499);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(399, 38);
            this.panel1.TabIndex = 3;
            // 
            // pshClose
            // 
            this.pshClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pshClose.Location = new System.Drawing.Point(311, 3);
            this.pshClose.Name = "pshClose";
            this.pshClose.Size = new System.Drawing.Size(85, 32);
            this.pshClose.TabIndex = 4;
            this.pshClose.Text = "&Beenden";
            this.pshClose.UseVisualStyleBackColor = true;
            // 
            // pshStart
            // 
            this.pshStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.pshStart.Location = new System.Drawing.Point(3, 3);
            this.pshStart.Name = "pshStart";
            this.pshStart.Size = new System.Drawing.Size(85, 32);
            this.pshStart.TabIndex = 3;
            this.pshStart.Text = "&Starten";
            this.pshStart.UseVisualStyleBackColor = true;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.pshSearchFile);
            this.topPanel.Controls.Add(this.label1);
            this.topPanel.Controls.Add(this.txtPath);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(399, 41);
            this.topPanel.TabIndex = 2;
            // 
            // pshSearchFile
            // 
            this.pshSearchFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pshSearchFile.Location = new System.Drawing.Point(302, 9);
            this.pshSearchFile.Name = "pshSearchFile";
            this.pshSearchFile.Size = new System.Drawing.Size(85, 23);
            this.pshSearchFile.TabIndex = 2;
            this.pshSearchFile.Text = "Durchsuchen";
            this.pshSearchFile.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pfad";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(44, 11);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(252, 20);
            this.txtPath.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 537);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(415, 576);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.mainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button pshSearchFile;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button pshClose;
        private System.Windows.Forms.Button pshStart;
    }
}

