﻿namespace Automatic_Annotation_CU.Forms
{
    partial class Form1
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
            this.pcb_img = new System.Windows.Forms.PictureBox();
            this.btn_folder_select = new System.Windows.Forms.Button();
            this.txt_folder = new System.Windows.Forms.TextBox();
            this.lbl_folder_desc = new System.Windows.Forms.Label();
            this.lbl_cur_image = new System.Windows.Forms.Label();
            this.lbl_progress = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_openpath = new System.Windows.Forms.Button();
            this.rbn_red = new System.Windows.Forms.RadioButton();
            this.rbn_green = new System.Windows.Forms.RadioButton();
            this.rbn_yellow = new System.Windows.Forms.RadioButton();
            this.rbn_black = new System.Windows.Forms.RadioButton();
            this.checkBoxTruncated = new System.Windows.Forms.CheckBox();
            this.checkBoxDifficult = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcb_img)).BeginInit();
            this.SuspendLayout();
            // 
            // pcb_img
            // 
            this.pcb_img.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pcb_img.Location = new System.Drawing.Point(41, 140);
            this.pcb_img.Margin = new System.Windows.Forms.Padding(4);
            this.pcb_img.Name = "pcb_img";
            this.pcb_img.Size = new System.Drawing.Size(845, 608);
            this.pcb_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcb_img.TabIndex = 0;
            this.pcb_img.TabStop = false;
            
            this.pcb_img.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pcb_img_MouseDoubleClick);
            this.pcb_img.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pcb_img_MouseDown);
            this.pcb_img.MouseLeave += new System.EventHandler(this.pcb_img_MouseLeave);
            this.pcb_img.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pcb_img_MouseMove);
            this.pcb_img.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pcb_img_MouseUp);
            this.pcb_img.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pcb_img_PreviewKeyDown);
            // 
            // btn_folder_select
            // 
            this.btn_folder_select.Location = new System.Drawing.Point(646, 15);
            this.btn_folder_select.Margin = new System.Windows.Forms.Padding(4);
            this.btn_folder_select.Name = "btn_folder_select";
            this.btn_folder_select.Size = new System.Drawing.Size(72, 29);
            this.btn_folder_select.TabIndex = 1;
            this.btn_folder_select.Text = "Browse";
            this.btn_folder_select.UseVisualStyleBackColor = true;
            this.btn_folder_select.Click += new System.EventHandler(this.btn_folder_select_Click);
            // 
            // txt_folder
            // 
            this.txt_folder.Enabled = false;
            this.txt_folder.Location = new System.Drawing.Point(41, 15);
            this.txt_folder.Margin = new System.Windows.Forms.Padding(4);
            this.txt_folder.Name = "txt_folder";
            this.txt_folder.Size = new System.Drawing.Size(598, 23);
            this.txt_folder.TabIndex = 2;
            // 
            // lbl_folder_desc
            // 
            this.lbl_folder_desc.AutoSize = true;
            this.lbl_folder_desc.Location = new System.Drawing.Point(37, 84);
            this.lbl_folder_desc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_folder_desc.Name = "lbl_folder_desc";
            this.lbl_folder_desc.Size = new System.Drawing.Size(65, 15);
            this.lbl_folder_desc.TabIndex = 3;
            this.lbl_folder_desc.Text = "[N] Images";
            // 
            // lbl_cur_image
            // 
            this.lbl_cur_image.AutoSize = true;
            this.lbl_cur_image.Location = new System.Drawing.Point(38, 120);
            this.lbl_cur_image.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cur_image.Name = "lbl_cur_image";
            this.lbl_cur_image.Size = new System.Drawing.Size(57, 15);
            this.lbl_cur_image.TabIndex = 4;
            this.lbl_cur_image.Text = "FileName";
            // 
            // lbl_progress
            // 
            this.lbl_progress.AutoSize = true;
            this.lbl_progress.Location = new System.Drawing.Point(38, 102);
            this.lbl_progress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_progress.Name = "lbl_progress";
            this.lbl_progress.Size = new System.Drawing.Size(55, 15);
            this.lbl_progress.TabIndex = 5;
            this.lbl_progress.Text = "Progress:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Manual：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(483, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "1. Keys intro：【Q】Last，【W】Next，【A】Last non-labeled，【S】Next non-labeled，【H】First on" +
    "e";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(104, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(710, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "2. Operation intro：【add annotation】hold the left mouse button and draw. 【remove a" +
    "nnotation】double-click inside the bounding box";
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(726, 15);
            this.btn_update.Margin = new System.Windows.Forms.Padding(4);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(88, 29);
            this.btn_update.TabIndex = 9;
            this.btn_update.Text = "Reload";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(532, 99);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(4);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(88, 29);
            this.btn_delete.TabIndex = 10;
            this.btn_delete.Text = "delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_openpath
            // 
            this.btn_openpath.Location = new System.Drawing.Point(404, 99);
            this.btn_openpath.Margin = new System.Windows.Forms.Padding(4);
            this.btn_openpath.Name = "btn_openpath";
            this.btn_openpath.Size = new System.Drawing.Size(121, 29);
            this.btn_openpath.TabIndex = 11;
            this.btn_openpath.Text = "open folder";
            this.btn_openpath.UseVisualStyleBackColor = true;
            this.btn_openpath.Click += new System.EventHandler(this.btn_openpath_Click);
            // 
            // rbn_red
            // 
            this.rbn_red.AutoSize = true;
            this.rbn_red.Checked = true;
            this.rbn_red.ForeColor = System.Drawing.Color.Red;
            this.rbn_red.Location = new System.Drawing.Point(636, 108);
            this.rbn_red.Margin = new System.Windows.Forms.Padding(4);
            this.rbn_red.Name = "rbn_red";
            this.rbn_red.Size = new System.Drawing.Size(45, 19);
            this.rbn_red.TabIndex = 12;
            this.rbn_red.TabStop = true;
            this.rbn_red.Text = "Red";
            this.rbn_red.UseVisualStyleBackColor = true;
            this.rbn_red.CheckedChanged += new System.EventHandler(this.rbn_red_CheckedChanged);
            // 
            // rbn_green
            // 
            this.rbn_green.AutoSize = true;
            this.rbn_green.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.rbn_green.Location = new System.Drawing.Point(692, 108);
            this.rbn_green.Margin = new System.Windows.Forms.Padding(4);
            this.rbn_green.Name = "rbn_green";
            this.rbn_green.Size = new System.Drawing.Size(56, 19);
            this.rbn_green.TabIndex = 13;
            this.rbn_green.Text = "Green";
            this.rbn_green.UseVisualStyleBackColor = true;
            this.rbn_green.CheckedChanged += new System.EventHandler(this.rbn_green_CheckedChanged);
            // 
            // rbn_yellow
            // 
            this.rbn_yellow.AutoSize = true;
            this.rbn_yellow.ForeColor = System.Drawing.Color.Gold;
            this.rbn_yellow.Location = new System.Drawing.Point(758, 108);
            this.rbn_yellow.Margin = new System.Windows.Forms.Padding(4);
            this.rbn_yellow.Name = "rbn_yellow";
            this.rbn_yellow.Size = new System.Drawing.Size(59, 19);
            this.rbn_yellow.TabIndex = 14;
            this.rbn_yellow.Text = "Yellow";
            this.rbn_yellow.UseVisualStyleBackColor = true;
            this.rbn_yellow.CheckedChanged += new System.EventHandler(this.rbn_yellow_CheckedChanged);
            // 
            // rbn_black
            // 
            this.rbn_black.AutoSize = true;
            this.rbn_black.Location = new System.Drawing.Point(831, 108);
            this.rbn_black.Margin = new System.Windows.Forms.Padding(4);
            this.rbn_black.Name = "rbn_black";
            this.rbn_black.Size = new System.Drawing.Size(53, 19);
            this.rbn_black.TabIndex = 15;
            this.rbn_black.TabStop = true;
            this.rbn_black.Text = "Black";
            this.rbn_black.UseVisualStyleBackColor = true;
            this.rbn_black.CheckedChanged += new System.EventHandler(this.rbn_black_CheckedChanged);
            // 
            // checkBoxTruncated
            // 
            this.checkBoxTruncated.AutoSize = true;
            this.checkBoxTruncated.Location = new System.Drawing.Point(268, 98);
            this.checkBoxTruncated.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxTruncated.Name = "checkBoxTruncated";
            this.checkBoxTruncated.Size = new System.Drawing.Size(99, 19);
            this.checkBoxTruncated.TabIndex = 16;
            this.checkBoxTruncated.Text = "Truncated 【T】";
            this.checkBoxTruncated.UseVisualStyleBackColor = true;
            this.checkBoxTruncated.CheckedChanged += new System.EventHandler(this.checkBoxTruncated_CheckedChanged);
            // 
            // checkBoxDifficult
            // 
            this.checkBoxDifficult.AutoSize = true;
            this.checkBoxDifficult.Location = new System.Drawing.Point(268, 119);
            this.checkBoxDifficult.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxDifficult.Name = "checkBoxDifficult";
            this.checkBoxDifficult.Size = new System.Drawing.Size(91, 19);
            this.checkBoxDifficult.TabIndex = 17;
            this.checkBoxDifficult.Text = "Difficult 【D】";
            this.checkBoxDifficult.UseVisualStyleBackColor = true;
            this.checkBoxDifficult.CheckedChanged += new System.EventHandler(this.checkBoxDifficult_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 749);
            this.Controls.Add(this.checkBoxDifficult);
            this.Controls.Add(this.checkBoxTruncated);
            this.Controls.Add(this.rbn_black);
            this.Controls.Add(this.rbn_yellow);
            this.Controls.Add(this.rbn_green);
            this.Controls.Add(this.rbn_red);
            this.Controls.Add(this.btn_openpath);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_progress);
            this.Controls.Add(this.lbl_cur_image);
            this.Controls.Add(this.lbl_folder_desc);
            this.Controls.Add(this.txt_folder);
            this.Controls.Add(this.btn_folder_select);
            this.Controls.Add(this.pcb_img);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manual Annotation ";
            
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.pcb_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcb_img;
        private System.Windows.Forms.Button btn_folder_select;
        private System.Windows.Forms.TextBox txt_folder;
        private System.Windows.Forms.Label lbl_folder_desc;
        private System.Windows.Forms.Label lbl_cur_image;
        private System.Windows.Forms.Label lbl_progress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_openpath;
        private System.Windows.Forms.RadioButton rbn_red;
        private System.Windows.Forms.RadioButton rbn_green;
        private System.Windows.Forms.RadioButton rbn_yellow;
        private System.Windows.Forms.RadioButton rbn_black;
        private System.Windows.Forms.CheckBox checkBoxTruncated;
        private System.Windows.Forms.CheckBox checkBoxDifficult;
    }
}

