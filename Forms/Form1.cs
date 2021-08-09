﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace Automatic_Annotation_CU.Forms
{
    public partial class Form1 : Form
    {
        private static readonly string FolderSelectDetaultTip = "Plase select the image directory...";
        private List<string> imgPathList = new List<string>();

        private int curImageIndex = -1;
        private List<Rectangle> curBBX = new List<Rectangle>(); 
        private double curScale = 1.0; 
        private Rectangle curRect = new Rectangle(); 
        private Image curImg = null;  
        private Image curBbxImg = null;  
        private Point? leftUp = null; 

        private bool isProcessed = false;
        private Color bbxColor = Color.Red;

        private bool isTruncated = false;
        private bool isDifficult = false;

        private Matrix transform = new Matrix();
        private float m_dZoomscale = 1.0f;
        public const float s_dScrollValue = 0.1f;

        public Form1()
        {
            InitializeComponent();
            txt_folder.Text = FolderSelectDetaultTip;
            lbl_folder_desc.Text = "";
            pcb_img.Anchor = AnchorStyles.Bottom |
                AnchorStyles.Left |
                AnchorStyles.Right |
                AnchorStyles.Top;
        }

        private bool ValidImageIndex()
        {
            return imgPathList.Count > 0 && curImageIndex >= 0 && curImageIndex < imgPathList.Count;
        }

        private bool ValidImageIndex(int tmpIndex)
        {
            return imgPathList.Count > 0 && tmpIndex >= 0 && tmpIndex < imgPathList.Count;
        }

        private bool MoreImagesAfter()
        {
            return imgPathList.Count > 0 && curImageIndex >= 0 && curImageIndex < imgPathList.Count-1;
        }

        private bool MoreImagesBefore()
        {
            return imgPathList.Count > 0 && curImageIndex > 0 && curImageIndex < imgPathList.Count;
        }

        private bool ReadBoundingBox()
        {
            if (!ValidImageIndex())
            {
                return false;
            }
            string bbxFile = Path.Combine(Path.GetDirectoryName(imgPathList[curImageIndex]),
                    Path.GetFileNameWithoutExtension(imgPathList[curImageIndex]) + ".txt");
            curBBX.Clear();
            if (File.Exists(bbxFile))
            {
                using (StreamReader reader = new StreamReader(bbxFile))
                {
                    while (!reader.EndOfStream)
                    {
                        string lineStr = reader.ReadLine();
                        string[] values = lineStr.Split(',');
                        if (values != null && values.Length == 8)
                        {
                            int iLeft = Convert.ToInt32(values[0]);
                            int iTop = Convert.ToInt32(values[1]);
                            int iWidth = Convert.ToInt32(values[2]) - iLeft;
                            int iHeight = Convert.ToInt32(values[3]) - iTop;

                            curBBX.Add(new Rectangle(iLeft,
                                iTop,
                                iWidth,
                                iHeight));

                            int iTruncatedFlag = Convert.ToInt32(values[4]);
                            int iDifficultFlag = Convert.ToInt32(values[5]);
                            isTruncated = false;
                            if (1 == iTruncatedFlag)
                            {
                                isTruncated = true;
                            }
                            checkBoxTruncated.Checked = isTruncated;

                            isDifficult = false;
                            if (1 == iDifficultFlag)
                            {
                                isDifficult = true;
                            }
                            checkBoxDifficult.Checked = isDifficult;
                        }
                    }
                }
            }
            return true;
        }

        private bool SaveBoundingBox()
        {
            if (isProcessed)
            {
                if (!ValidImageIndex())
                {
                    return false;
                }

                string bbxFile = Path.Combine(Path.GetDirectoryName(imgPathList[curImageIndex]),
                    Path.GetFileNameWithoutExtension(imgPathList[curImageIndex]) + ".txt");
                using (StreamWriter writer = new StreamWriter(bbxFile, false))
                {
                    foreach (Rectangle rect in curBBX)
                    {
                        Image tmpImg = Image.FromFile(imgPathList[curImageIndex]);

                        writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", 
                            rect.Left, rect.Top, rect.Left + rect.Width, rect.Top + rect.Height,
                            Convert.ToInt32(isTruncated), Convert.ToInt32(isDifficult),
                            tmpImg.Size.Width, tmpImg.Size.Height);
                        writer.Flush();
                    }
                }
                return File.Exists(bbxFile);
            }
            

            return true;
        }

        private void DisplayBoundingBox()
        {
            if (ValidImageIndex() && curImg != null)
            {

                curBbxImg = curImg.Clone() as Image;
                Graphics g = Graphics.FromImage(curBbxImg);
                Brush brush = new SolidBrush(bbxColor);
                Pen pen = new Pen(brush, 2);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;

                foreach (Rectangle rect in curBBX)
                {
                    int projectedLeft = Convert.ToInt32(rect.Left / curScale);
                    int projectedTop = Convert.ToInt32(rect.Top / curScale);
                    int projectedWidth = Convert.ToInt32(rect.Width / curScale);
                    int projectedHeight = Convert.ToInt32(rect.Height / curScale);

                    g.DrawLine(pen, projectedLeft, projectedTop, projectedLeft, projectedTop + projectedHeight);//左
                    g.DrawLine(pen, projectedLeft + projectedWidth, projectedTop, projectedLeft + projectedWidth, projectedTop + projectedHeight);//右
                    g.DrawLine(pen, projectedLeft, projectedTop, projectedLeft + projectedWidth, projectedTop);//上
                    g.DrawLine(pen, projectedLeft, projectedTop + projectedHeight, projectedLeft + projectedWidth, projectedTop + projectedHeight);//下

                }

                g.Dispose();
                pcb_img.Image = curBbxImg;
                
                pcb_img.Update();
            }
        }

        private void load(string imageRoot)
        {
            ReadImgPathList(imageRoot);
            lbl_folder_desc.Text = string.Format("【{0}】images found", imgPathList.Count);
            curImageIndex = 0;
            pcb_img.Focus();
            DisplayNewImage();
        }

        private void ResizeImage(ref Image srcImage, ref Image destImg, double scale)
        {
            int destWidth = Convert.ToInt32(srcImage.Width / scale);
            int destHeight = Convert.ToInt32(srcImage.Height / scale);

            destImg = new Bitmap(destWidth, destHeight);

            Graphics g = Graphics.FromImage(destImg);
            g.InterpolationMode = InterpolationMode.High;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Color.Transparent);
            g.DrawImage(srcImage, new Rectangle(0, 0, destWidth, destHeight),
                    new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);

            g.Dispose();
        }

        private bool DisplayNewImage()
        {
            if (!ValidImageIndex())
            {
                return false;
            }

            leftUp = null;
            isProcessed = false;
            lbl_cur_image.Text = string.Format("Image name：{0}", Path.GetFileName(imgPathList[curImageIndex]));
            lbl_progress.Text = string.Format("Progress：{0}/{1}", curImageIndex + 1, imgPathList.Count);
            Image tmpImg = Image.FromFile(imgPathList[curImageIndex]);
            int curWidth = tmpImg.Width;
            int curHeight = tmpImg.Height;
            int ctlWidth = pcb_img.Width;
            int ctlHeight = pcb_img.Height;
            double widthScales = curWidth * 1.0 / ctlWidth;
            double heightScale = curHeight * 1.0 / ctlHeight;
            curScale = Math.Max(Math.Max(widthScales, heightScale), 1.0);
            curRect = new Rectangle(Convert.ToInt32((ctlWidth - curWidth / curScale) / 2),
                Convert.ToInt32((ctlHeight - curHeight / curScale) / 2),
                Convert.ToInt32(curWidth / curScale),
                Convert.ToInt32(curHeight / curScale));
            ResizeImage(ref tmpImg, ref curImg, curScale);

            ReadBoundingBox();
            DisplayBoundingBox();

            tmpImg.Dispose();
            pcb_img.Focus();
            return true;
        }

        private void ReadImgPathList(string folder)
        {
            if (!Directory.Exists(folder))
            {
                MessageBox.Show("The directory does not exist！Please double check it.");
                return;
            }
            string[] imgPaths = Directory.GetFiles(folder, "*.*", SearchOption.AllDirectories);
            imgPathList.Clear();
            if (imgPaths != null && imgPaths.Length > 0)  
            {
                imgPathList.Clear();
                imgPathList = imgPaths.Where(x =>
                    {
                        string imgName = x.ToLower();
                        return imgName.EndsWith(".jpg") || imgName.EndsWith(".jpeg") || imgName.EndsWith(".bmp") || imgName.EndsWith(".png");
                    }).ToList();
                
            }
        }

        private void btn_folder_select_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Please select the image directory";
        
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txt_folder.Text = dialog.SelectedPath;
                load(dialog.SelectedPath);
            }

            pcb_img.Focus();
        }

        private int NextUnLabeled()
        {
            int tmpIndex = curImageIndex + 1;
            while (ValidImageIndex(tmpIndex) && File.Exists(Path.ChangeExtension(imgPathList[tmpIndex],".txt")))
            {
                tmpIndex++;
            }
            return tmpIndex;
        }

        private int PreUnLabeled()
        {
            int tmpIndex = curImageIndex - 1;
            while (ValidImageIndex(tmpIndex) && File.Exists(Path.ChangeExtension(imgPathList[tmpIndex], ".txt")))
            {
                tmpIndex--;
            }
            return tmpIndex;
        }

        private void resetFlag()
        {
            isTruncated = false;
            isDifficult = false;
            checkBoxDifficult.Checked = false;
            checkBoxTruncated.Checked = false; 
        }

        private void pcb_img_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
            if (e.KeyCode == Keys.W)
            {
                if (ValidImageIndex())
                {
                    if (!SaveBoundingBox())
                    {
                        MessageBox.Show("Fail to save, please annotate once more");
                        return;
                    }
                }
                resetFlag();
                if (MoreImagesAfter())
                {
                    curImageIndex++;
                    DisplayNewImage();
                }
                else
                {
                    MessageBox.Show("all finished！");
                }
            }
            else if (e.KeyCode == Keys.Q)
            {
                if (ValidImageIndex())
                {
                    if (!SaveBoundingBox())
                    {
                        MessageBox.Show("Fail to save, please annotate once more");
                        return;
                    }
                }
                resetFlag();
                if (MoreImagesBefore())
                {
                    curImageIndex--;
                    DisplayNewImage();
                }
                else
                {
                    MessageBox.Show("This is the very first image！");
                }
            }
            else if (e.KeyCode == Keys.A)
            {
                if (ValidImageIndex())
                {
                    if (!SaveBoundingBox())
                    {
                        MessageBox.Show("Fail to save, please annotate once more");
                        return;
                    }
                }
                resetFlag();
                int nextUnLabeledIndex = PreUnLabeled();
                if (ValidImageIndex(nextUnLabeledIndex))
                {
                    curImageIndex = nextUnLabeledIndex;
                    DisplayNewImage();
                }
                else
                {
                    MessageBox.Show("Images prior to this one have all been annotated！");
                }
            }
            else if (e.KeyCode == Keys.S)
            {
                if (ValidImageIndex())
                {
                    if (!SaveBoundingBox())
                    {
                        MessageBox.Show("Fail to save, please annotate once more");
                        return;
                    }
                }
                resetFlag();
                int nextUnLabeledIndex = NextUnLabeled();
                if (ValidImageIndex(nextUnLabeledIndex))
                {
                    curImageIndex = nextUnLabeledIndex;
                    DisplayNewImage();
                }
                else
                {
                    MessageBox.Show("Images after this one have all been annotated！");
                }
            }
            else if (e.KeyCode == Keys.H)
            {
                if (ValidImageIndex())
                {
                    if (!SaveBoundingBox())
                    {
                        MessageBox.Show("Fail to save, please annotate once more");
                        return;
                    }
                }
                resetFlag();
                curImageIndex = 0;
                DisplayNewImage();
            }
            else if (e.KeyCode == Keys.T)
            {
                if(checkBoxTruncated.Checked)
                {
                    checkBoxTruncated.Checked = false;
                }
                else
                {
                    checkBoxTruncated.Checked = true;
                }
            }
            else if (e.KeyCode == Keys.D)
            {
                if (checkBoxDifficult.Checked)
                {
                    checkBoxDifficult.Checked = false;
                }
                else
                {
                    checkBoxDifficult.Checked = true;
                    checkBoxTruncated.Checked = false;
                }
            }


        }

        private void pcb_img_MouseDown(object sender, MouseEventArgs e)
        {
            if (curRect.Contains(e.Location))
            {
                leftUp = new Point(e.X,e.Y);
            }
            else
            {
                leftUp = null;
            }
        }

        private void pcb_img_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftUp.HasValue && curRect.Contains(e.Location))
            {
                
                int left = Math.Min(leftUp.Value.X, e.X);
                int top = Math.Min(leftUp.Value.Y, e.Y);
                int right = Math.Max(leftUp.Value.X, e.X);
                int bottom = Math.Max(leftUp.Value.Y, e.Y);
                // Minimum width and height of bounding box required for drawing a box
                if (right - left >= 10 && bottom - top >= 10)
                {
                    isProcessed = true;
                    curBBX.Add(new Rectangle(Convert.ToInt32((left - curRect.Left) * curScale),
                    Convert.ToInt32((top - curRect.Top) * curScale),
                    Convert.ToInt32((right - left) * curScale),
                    Convert.ToInt32((bottom - top) * curScale)));
                    DisplayBoundingBox();
                }
            }
            leftUp = null;
        }

        private bool inside = false;

        private void pcb_img_MouseMove(object sender, MouseEventArgs e)
        {
            if (curRect.Contains(e.Location))
            {
                if (leftUp.HasValue)
                {
                    Image tmpImg = curBbxImg.Clone() as Image;
                    Graphics g = Graphics.FromImage(tmpImg);
                    Brush brush = new SolidBrush(bbxColor);
                    Pen pen = new Pen(brush, 2);
                    pen.DashStyle = DashStyle.Custom;

                    int left = Convert.ToInt32(leftUp.Value.X - curRect.Left);
                    int top = Convert.ToInt32(leftUp.Value.Y - curRect.Top);
                    int right = Convert.ToInt32(e.X - curRect.Left);
                    int bottom = Convert.ToInt32(e.Y - curRect.Top);
                    g.DrawLine(pen, left, top, left, bottom);//左
                    g.DrawLine(pen, right, top, right, bottom);//右
                    g.DrawLine(pen, left, top, right, top);//上
                    g.DrawLine(pen, left, bottom, right, bottom);//下
                    g.Dispose();
                    pcb_img.Image = tmpImg;
                    pcb_img.Update();
                }
                else
                {
                    Image tmpImg = curBbxImg.Clone() as Image;
                    Graphics g = Graphics.FromImage(tmpImg);
                    Brush brush = new SolidBrush(bbxColor);
                    Pen pen = new Pen(brush, 2);
                    pen.DashStyle = DashStyle.DashDot;

                    g.DrawLine(pen, 0, e.Y - curRect.Top, curRect.Width, e.Y - curRect.Top);//水平
                    g.DrawLine(pen, e.X - curRect.Left, 0, e.X - curRect.Left, curRect.Height);//垂直
                    g.Dispose();
                    pcb_img.Image = tmpImg;
                    pcb_img.Update();
                }
                inside = true;
            }
            else
            {
                if (inside)
                {
                    DisplayBoundingBox();
                }
                inside = false;
                leftUp = null;
            }
        }

        private void pcb_img_MouseLeave(object sender, EventArgs e)
        {
            if (inside)
            {
                DisplayBoundingBox();
            }
            inside = false;
            leftUp = null;
        }

        private void pcb_img_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (curRect.Contains(e.Location))
            {
                for (int i = 0; i < curBBX.Count; ++i)
                {
                    int projectedLeft = Convert.ToInt32(curBBX[i].Left / curScale);
                    int projectedTop = Convert.ToInt32(curBBX[i].Top / curScale);
                    int projectedWidth = Convert.ToInt32(curBBX[i].Width / curScale);
                    int projectedHeight = Convert.ToInt32(curBBX[i].Height / curScale);
                    Rectangle tmpBBX = new Rectangle(curRect.Left + projectedLeft,
                        curRect.Top + projectedTop,
                        projectedWidth, projectedHeight);
                    if (tmpBBX.Contains(e.Location))
                    {
                        isProcessed = true;
                        curBBX.RemoveAt(i);
                        --i;
                    }
                }
                DisplayBoundingBox();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string path = txt_folder.Text;
            if (Directory.Exists(path))
            {
                load(path);
            }
            else
            {
                MessageBox.Show("Please select the directory first！");
            }
            pcb_img.Focus();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (ValidImageIndex())
            {
                File.Delete(imgPathList[curImageIndex]);
                File.Delete(Path.ChangeExtension(imgPathList[curImageIndex], ".txt"));
                imgPathList.RemoveAt(curImageIndex);
                lbl_folder_desc.Text = string.Format("【{0}】 images found", imgPathList.Count);
                DisplayNewImage();
            }
            pcb_img.Focus();
        }

        private void btn_openpath_Click(object sender, EventArgs e)
        {
            if (ValidImageIndex())
            {
                System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(imgPathList[curImageIndex])); 
            }
            pcb_img.Focus();

        }

        private void rbn_red_CheckedChanged(object sender, EventArgs e)
        {
            if (rbn_red.Checked)
            {
                bbxColor = Color.Red;
                DisplayBoundingBox();
            }
            pcb_img.Focus();
        }

        private void rbn_green_CheckedChanged(object sender, EventArgs e)
        {
            if (rbn_green.Checked)
            {
                bbxColor = Color.Green;
                DisplayBoundingBox();
            }
            pcb_img.Focus();
        }

        private void rbn_yellow_CheckedChanged(object sender, EventArgs e)
        {
            if (rbn_yellow.Checked)
            {
                bbxColor = Color.Yellow;
                DisplayBoundingBox();
            }
            pcb_img.Focus();
        }

        private void rbn_black_CheckedChanged(object sender, EventArgs e)
        {
            if (rbn_black.Checked)
            {
                bbxColor = Color.Black;
                DisplayBoundingBox();
            }
            pcb_img.Focus();
        }

        private void checkBoxTruncated_CheckedChanged(object sender, EventArgs e)
        {
            isProcessed = true;
            if (checkBoxTruncated.Checked)
            {
                isTruncated = true;
            }
            else
            {
                isTruncated = false;
            }
            pcb_img.Focus();
        }

        private void checkBoxDifficult_CheckedChanged(object sender, EventArgs e)
        {
            isProcessed = true;
            if (checkBoxDifficult.Checked)
            {
                isDifficult = true;
            }
            else
            { 
                isDifficult = false;
            }
            pcb_img.Focus();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            DisplayNewImage();
        }
        protected override void WndProc(ref Message m)
        {
            FormWindowState previousWindowState = this.WindowState;

            base.WndProc(ref m);

            FormWindowState currentWindowState = this.WindowState;

            if (previousWindowState != currentWindowState && currentWindowState == FormWindowState.Maximized)
            {
                // TODO: Do something the window has been maximized
                DisplayNewImage();
            }
            if (previousWindowState != currentWindowState && currentWindowState == FormWindowState.Normal)
            {
                // TODO: Do something the window has been maximized
                DisplayNewImage();
            }
        }

        protected override void OnMouseWheel(MouseEventArgs mea)
        {
            pcb_img.Focus();
            if (pcb_img.Focused == true && mea.Delta != 0)
            {
                if (mea.Delta <= 0)
                {
                    //set minimum size to zoom
                    if (pcb_img.Width < 500)
                        // lbl_Zoom.Text = pictureBox1.Image.Size; 
                        return;
                }
                else
                {
                    //set maximum size to zoom
                    if (pcb_img.Width > 1000)
                        return;
                }
                pcb_img.Width += Convert.ToInt32(pcb_img.Width * mea.Delta / 1000);
                pcb_img.Height += Convert.ToInt32(pcb_img.Height * mea.Delta / 1000);
                // Map the Form-centric mouse location to the PictureBox client coordinate system
                //Point pictureBoxPoint = pcb_img.PointToClient(this.PointToScreen(mea.Location));

                //ZoomScroll(pictureBoxPoint, mea.Delta > 0);
            }
        }

        private void ZoomScroll(Point location, bool zoomIn)
        {
            // Figure out what the new scale will be. Ensure the scale factor remains between
            // 1% and 1000%
            float newScale = Math.Min(Math.Max(m_dZoomscale + (zoomIn ? s_dScrollValue : -s_dScrollValue), 0.1f), 10);

            if (newScale != m_dZoomscale)
            {
                float adjust = newScale / m_dZoomscale;
                m_dZoomscale = newScale;

                // Translate mouse point to origin
                transform.Translate(-location.X, -location.Y, MatrixOrder.Append);

                // Scale view
                transform.Scale(adjust, adjust, MatrixOrder.Append);

                // Translate origin back to original mouse point.
                transform.Translate(location.X, location.Y, MatrixOrder.Append);

                pcb_img.Refresh();
            }
        }

    }
}
