
namespace Automatic_Annotation_CU.Forms
{
    partial class ParentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParentForm));
            this.menuStripParent = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.lblADAS = new System.Windows.Forms.Label();
            this.btnAnnotation = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnTaskList = new System.Windows.Forms.Button();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblWelcomeMessage = new System.Windows.Forms.Label();
            this.pcbSignOut = new System.Windows.Forms.PictureBox();
            this.menuStripParent.SuspendLayout();
            this.pnlNavigation.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSignOut)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripParent
            // 
            this.menuStripParent.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.windowToolStripMenuItem});
            this.menuStripParent.Location = new System.Drawing.Point(0, 0);
            this.menuStripParent.Name = "menuStripParent";
            this.menuStripParent.Size = new System.Drawing.Size(892, 24);
            this.menuStripParent.TabIndex = 1;
            this.menuStripParent.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.homeToolStripMenuItem.Text = "&File";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.fileToolStripMenuItem.Text = "Open";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolToolStripMenuItem
            // 
            this.aboutToolToolStripMenuItem.Name = "aboutToolToolStripMenuItem";
            this.aboutToolToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.aboutToolToolStripMenuItem.Text = "About Tool";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlNavigation.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlNavigation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlNavigation.Controls.Add(this.lblADAS);
            this.pnlNavigation.Controls.Add(this.btnAnnotation);
            this.pnlNavigation.Controls.Add(this.btnSettings);
            this.pnlNavigation.Controls.Add(this.btnTaskList);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlNavigation.Location = new System.Drawing.Point(0, 24);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(200, 375);
            this.pnlNavigation.TabIndex = 2;
            // 
            // lblADAS
            // 
            this.lblADAS.AutoSize = true;
            this.lblADAS.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblADAS.Location = new System.Drawing.Point(43, 22);
            this.lblADAS.Name = "lblADAS";
            this.lblADAS.Size = new System.Drawing.Size(79, 32);
            this.lblADAS.TabIndex = 1;
            this.lblADAS.Text = "ADAS";
            // 
            // btnAnnotation
            // 
            this.btnAnnotation.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAnnotation.FlatAppearance.BorderSize = 0;
            this.btnAnnotation.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnAnnotation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnnotation.Location = new System.Drawing.Point(0, 108);
            this.btnAnnotation.Name = "btnAnnotation";
            this.btnAnnotation.Size = new System.Drawing.Size(192, 24);
            this.btnAnnotation.TabIndex = 0;
            this.btnAnnotation.Text = "Annotation";
            this.btnAnnotation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnnotation.UseVisualStyleBackColor = true;
            this.btnAnnotation.Click += new System.EventHandler(this.btnAnnotation_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(0, 144);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(192, 24);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnTaskList
            // 
            this.btnTaskList.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTaskList.FlatAppearance.BorderSize = 0;
            this.btnTaskList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnTaskList.Location = new System.Drawing.Point(0, 72);
            this.btnTaskList.Name = "btnTaskList";
            this.btnTaskList.Size = new System.Drawing.Size(192, 24);
            this.btnTaskList.TabIndex = 0;
            this.btnTaskList.Text = "Task List";
            this.btnTaskList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTaskList.UseVisualStyleBackColor = true;
            this.btnTaskList.Click += new System.EventHandler(this.btnTaskList_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlContainer.Location = new System.Drawing.Point(195, 56);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(697, 338);
            this.pnlContainer.TabIndex = 3;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.Controls.Add(this.lblWelcomeMessage);
            this.pnlHeader.Location = new System.Drawing.Point(196, 23);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(693, 32);
            this.pnlHeader.TabIndex = 5;
            // 
            // lblWelcomeMessage
            // 
            this.lblWelcomeMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWelcomeMessage.AutoSize = true;
            this.lblWelcomeMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWelcomeMessage.Location = new System.Drawing.Point(564, 4);
            this.lblWelcomeMessage.Name = "lblWelcomeMessage";
            this.lblWelcomeMessage.Size = new System.Drawing.Size(0, 15);
            this.lblWelcomeMessage.TabIndex = 1;
            // 
            // pcbSignOut
            // 
            this.pcbSignOut.Image = ((System.Drawing.Image)(resources.GetObject("pcbSignOut.Image")));
            this.pcbSignOut.Location = new System.Drawing.Point(860, 0);
            this.pcbSignOut.Name = "pcbSignOut";
            this.pcbSignOut.Size = new System.Drawing.Size(26, 24);
            this.pcbSignOut.TabIndex = 7;
            this.pcbSignOut.TabStop = false;
            this.pcbSignOut.Click += new System.EventHandler(this.pcbSignOut_Click);
            // 
            // ParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 399);
            this.Controls.Add(this.pcbSignOut);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlNavigation);
            this.Controls.Add(this.menuStripParent);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStripParent;
            this.Name = "ParentForm";
            this.Text = "LTTS CU Automated Annotation ";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ParentForm_Load);
            this.menuStripParent.ResumeLayout(false);
            this.menuStripParent.PerformLayout();
            this.pnlNavigation.ResumeLayout(false);
            this.pnlNavigation.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbSignOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStripParent;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Button btnTaskList;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.Label lblADAS;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblWelcomeMessage;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnAnnotation;
        private System.Windows.Forms.PictureBox pcbSignOut;
    }
}