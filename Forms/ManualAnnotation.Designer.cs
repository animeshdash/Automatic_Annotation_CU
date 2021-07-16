
namespace Automatic_Annotation_CU.Forms
{
    partial class ManualAnnotation
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualAnnotation));
            this.pnlSubHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbcObjectSettings = new System.Windows.Forms.TabControl();
            this.tbpObjectCategory = new System.Windows.Forms.TabPage();
            this.tbpObjectLabelSummary = new System.Windows.Forms.TabPage();
            this.tbpImageSettings = new System.Windows.Forms.TabPage();
            this.pnlObjectProperties = new System.Windows.Forms.Panel();
            this.lblObjectProperties = new System.Windows.Forms.Label();
            this.txtSearchObjectCategory = new System.Windows.Forms.TextBox();
            this.pbSearch = new System.Windows.Forms.PictureBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tabSceneObject = new System.Windows.Forms.TabControl();
            this.tbpSceneLevel = new System.Windows.Forms.TabPage();
            this.tbpObectLevel = new System.Windows.Forms.TabPage();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lstvObjectCategory = new System.Windows.Forms.ListView();
            this.pnlAnnotationMain = new System.Windows.Forms.Panel();
            this.pnlPlayerNSettings = new System.Windows.Forms.Panel();
            this.tbpImageList = new System.Windows.Forms.TabPage();
            this.imgListImage = new System.Windows.Forms.ImageList(this.components);
            this.pictureBoxAnnotation = new System.Windows.Forms.PictureBox();
            this.pnlSubHeader.SuspendLayout();
            this.tbcObjectSettings.SuspendLayout();
            this.pnlObjectProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.tabSceneObject.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlAnnotationMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnnotation)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSubHeader
            // 
            this.pnlSubHeader.Controls.Add(this.label1);
            this.pnlSubHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlSubHeader.Name = "pnlSubHeader";
            this.pnlSubHeader.Size = new System.Drawing.Size(668, 30);
            this.pnlSubHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // tbcObjectSettings
            // 
            this.tbcObjectSettings.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tbcObjectSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcObjectSettings.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tbcObjectSettings.Controls.Add(this.tbpObjectCategory);
            this.tbcObjectSettings.Controls.Add(this.tbpObjectLabelSummary);
            this.tbcObjectSettings.Controls.Add(this.tbpImageSettings);
            this.tbcObjectSettings.Location = new System.Drawing.Point(668, 145);
            this.tbcObjectSettings.Name = "tbcObjectSettings";
            this.tbcObjectSettings.SelectedIndex = 0;
            this.tbcObjectSettings.Size = new System.Drawing.Size(263, 328);
            this.tbcObjectSettings.TabIndex = 1;
            this.tbcObjectSettings.SelectedIndexChanged += new System.EventHandler(this.tbcObjectSettings_SelectedIndexChanged);
            this.tbcObjectSettings.Click += new System.EventHandler(this.tbcObjectSettings_Click);
            // 
            // tbpObjectCategory
            // 
            this.tbpObjectCategory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbpObjectCategory.Location = new System.Drawing.Point(4, 4);
            this.tbpObjectCategory.Name = "tbpObjectCategory";
            this.tbpObjectCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tbpObjectCategory.Size = new System.Drawing.Size(255, 0);
            this.tbpObjectCategory.TabIndex = 0;
            this.tbpObjectCategory.Text = "Object Category";
            this.tbpObjectCategory.ToolTipText = "Object Category";
            this.tbpObjectCategory.UseVisualStyleBackColor = true;
            // 
            // tbpObjectLabelSummary
            // 
            this.tbpObjectLabelSummary.Location = new System.Drawing.Point(4, 4);
            this.tbpObjectLabelSummary.Name = "tbpObjectLabelSummary";
            this.tbpObjectLabelSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tbpObjectLabelSummary.Size = new System.Drawing.Size(255, 0);
            this.tbpObjectLabelSummary.TabIndex = 1;
            this.tbpObjectLabelSummary.Text = "Object Label Summary";
            this.tbpObjectLabelSummary.ToolTipText = "Object Label Summary";
            this.tbpObjectLabelSummary.UseVisualStyleBackColor = true;
            // 
            // tbpImageSettings
            // 
            this.tbpImageSettings.Location = new System.Drawing.Point(4, 4);
            this.tbpImageSettings.Name = "tbpImageSettings";
            this.tbpImageSettings.Size = new System.Drawing.Size(255, 0);
            this.tbpImageSettings.TabIndex = 2;
            this.tbpImageSettings.Text = "Image Settings";
            this.tbpImageSettings.ToolTipText = "Image Settings";
            this.tbpImageSettings.UseVisualStyleBackColor = true;
            // 
            // pnlObjectProperties
            // 
            this.pnlObjectProperties.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pnlObjectProperties.Controls.Add(this.lblObjectProperties);
            this.pnlObjectProperties.Location = new System.Drawing.Point(668, 29);
            this.pnlObjectProperties.Name = "pnlObjectProperties";
            this.pnlObjectProperties.Size = new System.Drawing.Size(273, 26);
            this.pnlObjectProperties.TabIndex = 2;
            // 
            // lblObjectProperties
            // 
            this.lblObjectProperties.AutoSize = true;
            this.lblObjectProperties.Location = new System.Drawing.Point(836, 7);
            this.lblObjectProperties.Name = "lblObjectProperties";
            this.lblObjectProperties.Size = new System.Drawing.Size(93, 15);
            this.lblObjectProperties.TabIndex = 0;
            this.lblObjectProperties.Text = "Object Category";
            // 
            // txtSearchObjectCategory
            // 
            this.txtSearchObjectCategory.BackColor = System.Drawing.SystemColors.Menu;
            this.txtSearchObjectCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchObjectCategory.Location = new System.Drawing.Point(668, 60);
            this.txtSearchObjectCategory.Name = "txtSearchObjectCategory";
            this.txtSearchObjectCategory.Size = new System.Drawing.Size(237, 23);
            this.txtSearchObjectCategory.TabIndex = 3;
            this.txtSearchObjectCategory.Text = "Search ...";
            // 
            // pbSearch
            // 
            this.pbSearch.Image = ((System.Drawing.Image)(resources.GetObject("pbSearch.Image")));
            this.pbSearch.Location = new System.Drawing.Point(905, 62);
            this.pbSearch.MaximumSize = new System.Drawing.Size(22, 22);
            this.pbSearch.Name = "pbSearch";
            this.pbSearch.Size = new System.Drawing.Size(22, 20);
            this.pbSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbSearch.TabIndex = 4;
            this.pbSearch.TabStop = false;
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.panel5);
            this.pnlLeft.Controls.Add(this.tabSceneObject);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 30);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(200, 445);
            this.pnlLeft.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel5.Location = new System.Drawing.Point(2, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 27);
            this.panel5.TabIndex = 1;
            // 
            // tabSceneObject
            // 
            this.tabSceneObject.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabSceneObject.Controls.Add(this.tbpSceneLevel);
            this.tabSceneObject.Controls.Add(this.tbpObectLevel);
            this.tabSceneObject.Controls.Add(this.tbpImageList);
            this.tabSceneObject.Location = new System.Drawing.Point(0, 32);
            this.tabSceneObject.Name = "tabSceneObject";
            this.tabSceneObject.SelectedIndex = 0;
            this.tabSceneObject.Size = new System.Drawing.Size(200, 410);
            this.tabSceneObject.TabIndex = 0;
            // 
            // tbpSceneLevel
            // 
            this.tbpSceneLevel.Location = new System.Drawing.Point(4, 4);
            this.tbpSceneLevel.Name = "tbpSceneLevel";
            this.tbpSceneLevel.Padding = new System.Windows.Forms.Padding(3);
            this.tbpSceneLevel.Size = new System.Drawing.Size(192, 382);
            this.tbpSceneLevel.TabIndex = 0;
            this.tbpSceneLevel.Text = "Scene Level";
            this.tbpSceneLevel.ToolTipText = "Scene Level";
            this.tbpSceneLevel.UseVisualStyleBackColor = true;
            // 
            // tbpObectLevel
            // 
            this.tbpObectLevel.Location = new System.Drawing.Point(4, 4);
            this.tbpObectLevel.Name = "tbpObectLevel";
            this.tbpObectLevel.Padding = new System.Windows.Forms.Padding(3);
            this.tbpObectLevel.Size = new System.Drawing.Size(192, 382);
            this.tbpObectLevel.TabIndex = 1;
            this.tbpObectLevel.Text = "Object Level";
            this.tbpObectLevel.ToolTipText = "Object Level";
            this.tbpObectLevel.UseVisualStyleBackColor = true;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.lstvObjectCategory);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(668, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(263, 475);
            this.pnlRight.TabIndex = 6;
            // 
            // lstvObjectCategory
            // 
            this.lstvObjectCategory.HideSelection = false;
            this.lstvObjectCategory.Location = new System.Drawing.Point(3, 89);
            this.lstvObjectCategory.Name = "lstvObjectCategory";
            this.lstvObjectCategory.Size = new System.Drawing.Size(260, 211);
            this.lstvObjectCategory.TabIndex = 0;
            this.lstvObjectCategory.UseCompatibleStateImageBehavior = false;
            // 
            // pnlAnnotationMain
            // 
            this.pnlAnnotationMain.Controls.Add(this.pictureBoxAnnotation);
            this.pnlAnnotationMain.Controls.Add(this.pnlPlayerNSettings);
            this.pnlAnnotationMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAnnotationMain.Location = new System.Drawing.Point(200, 30);
            this.pnlAnnotationMain.Name = "pnlAnnotationMain";
            this.pnlAnnotationMain.Size = new System.Drawing.Size(468, 445);
            this.pnlAnnotationMain.TabIndex = 7;
            // 
            // pnlPlayerNSettings
            // 
            this.pnlPlayerNSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPlayerNSettings.Location = new System.Drawing.Point(0, 393);
            this.pnlPlayerNSettings.Name = "pnlPlayerNSettings";
            this.pnlPlayerNSettings.Size = new System.Drawing.Size(468, 52);
            this.pnlPlayerNSettings.TabIndex = 0;
            // 
            // tbpImageList
            // 
            this.tbpImageList.Location = new System.Drawing.Point(4, 4);
            this.tbpImageList.Name = "tbpImageList";
            this.tbpImageList.Size = new System.Drawing.Size(192, 382);
            this.tbpImageList.TabIndex = 2;
            this.tbpImageList.Text = "Image List";
            this.tbpImageList.UseVisualStyleBackColor = true;
            // 
            // imgListImage
            // 
            this.imgListImage.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgListImage.ImageSize = new System.Drawing.Size(16, 16);
            this.imgListImage.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBoxAnnotation
            // 
            this.pictureBoxAnnotation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxAnnotation.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAnnotation.Image")));
            this.pictureBoxAnnotation.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxAnnotation.Name = "pictureBoxAnnotation";
            this.pictureBoxAnnotation.Size = new System.Drawing.Size(468, 393);
            this.pictureBoxAnnotation.TabIndex = 1;
            this.pictureBoxAnnotation.TabStop = false;
            // 
            // ManualAnnotation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 475);
            this.Controls.Add(this.tbcObjectSettings);
            this.Controls.Add(this.pnlAnnotationMain);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pbSearch);
            this.Controls.Add(this.txtSearchObjectCategory);
            this.Controls.Add(this.pnlObjectProperties);
            this.Controls.Add(this.pnlSubHeader);
            this.Controls.Add(this.pnlRight);
            this.Name = "ManualAnnotation";
            this.Text = "ManualAnnotation";
            this.Load += new System.EventHandler(this.ManualAnnotation_Load);
            this.pnlSubHeader.ResumeLayout(false);
            this.pnlSubHeader.PerformLayout();
            this.tbcObjectSettings.ResumeLayout(false);
            this.pnlObjectProperties.ResumeLayout(false);
            this.pnlObjectProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.tabSceneObject.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlAnnotationMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAnnotation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSubHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tbcObjectSettings;
        private System.Windows.Forms.TabPage tbpObjectCategory;
        private System.Windows.Forms.TabPage tbpObjectLabelSummary;
        private System.Windows.Forms.TabPage tbpImageSettings;
        private System.Windows.Forms.Panel pnlObjectProperties;
        private System.Windows.Forms.TextBox txtSearchObjectCategory;
        private System.Windows.Forms.PictureBox pbSearch;
        private System.Windows.Forms.Label lblObjectProperties;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TabControl tabSceneObject;
        private System.Windows.Forms.TabPage tbpSceneLevel;
        private System.Windows.Forms.TabPage tbpObectLevel;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlAnnotationMain;
        private System.Windows.Forms.Panel pnlPlayerNSettings;
        private System.Windows.Forms.ListView lstvObjectCategory;
        private System.Windows.Forms.TabPage tbpImageList;
        private System.Windows.Forms.PictureBox pictureBoxAnnotation;
        private System.Windows.Forms.ImageList imgListImage;
    }
}