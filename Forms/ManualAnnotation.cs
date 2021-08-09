using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using Automatic_Annotation_CU.Helpers;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Automatic_Annotation_CU.Forms
{
    public enum RectAction
    {
        NoAction,
        Selecting,
        Editing
    };
    public partial class ManualAnnotation : Form
    {
        //private string jsonString = "";
        //private static readonly string FolderSelectDetaultTip = "Plase select the image directory...";
        //private List<string> imgPathList = new List<string>();

        //private int curImageIndex = -1;
        //private List<Rectangle> curBBX = new List<Rectangle>(); 
        //private double curScale = 1.0;
        //private Rectangle curRect = new Rectangle(); 
        //private Image curImg = null;  
        //private Image curBbxImg = null;  
        //private Point? leftUp = null; 

        //private bool isProcessed = false;
        //private Color bbxColor = Color.Red;

        //private bool isTruncated = false;
        //private bool isDifficult = false;

        #region Private Variables

        private string _imageFolder = null;
        private int _currenIndex = -1;

        private List<string> _extentions;
        private List<string> _files;

        private AnnotationList _annList;
        private List<BRectangle> _currentRectangles;

        private Image _drawnImage;
        private Image _loadedImage;

        private float _ratio;
        private float _xoffset;
        private float _yoffset;

        private int _mouseX;
        private int _mouseY;
        private RectAction _currentAction;
        private float m_dZoomscale = 1.0f;
        private Matrix transform = new Matrix();
        private int countFiles;
        #endregion Private Variables
        public const float s_dScrollValue = 0.1f;

        private int valueBefore = 0; // to track value of trackbar

        #region Constructor
        public ManualAnnotation()
        {
            _extentions = GetImageFileExtensions();
            InitializeComponent();
            ImageFolder = "D:\\ADAS\\Code\\Annotation_ToolDemo\\Automatic_Annotation_CU\\data\\Images_for_ADAS_annotation";
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(ImageFolder);
            countFiles = dir.GetFiles().Length;
            trackBarImages.Maximum = countFiles;
            trackBarImages.Minimum = 1;
            trackBarImages.SmallChange = 1;
            
            //if (Directory.Exists(Properties.Settings.Default.ImageFolder))
            //{
            //    ImageFolder = Properties.Settings.Default.ImageFolder;
            //}
            //else
            //{
            //    ImageFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            //}
            CurrentAction = RectAction.NoAction;
            //txt_folder.Text = FolderSelectDetaultTip;
            //lbl_folder_desc.Text = "";
            //pictureBoxAnnotation.Anchor = AnchorStyles.Bottom |
            //    AnchorStyles.Left |
            //    AnchorStyles.Right |
            //    AnchorStyles.Top;
        }
       

        #endregion Constructor

        #region Form properties

        public string ImageFolder
        {
            get { return _imageFolder; }
            set
            {
                _imageFolder = value;
                if (!String.IsNullOrWhiteSpace(_imageFolder) && Directory.Exists(_imageFolder))
                {
                    LoadFileList();
                    LoadAnnotations();
                    CurrenIndex = 0;
                }
                Properties.Settings.Default.ImageFolder = _imageFolder;
                //txtImageFolder.Text = _imageFolder;
            }
        }

        public int CurrenIndex
        {
            get{ return _currenIndex;}
            set
            {
                if (value >= 0 && value != _currenIndex)
                {
                    SaveImageRectangles(_currenIndex);
                    if (_currentRectangles != null)
                        _currentRectangles.Clear();
                    _currenIndex = value;
                    LoadFile(_currenIndex);
                    LoadImageRectangles(_currenIndex);
                }
                pictureBoxAnnotation.Refresh();
            }
        }

        public int MouseX
        {
            get { return _mouseX; }
            set
            {
                _mouseX = value;
                lblMouseX.Text = _mouseX.ToString();
            }
        }

        public int MouseY
        {
            get {return _mouseY; }
            set
            {
                _mouseY = value;
                lblMouseY.Text = _mouseY.ToString();
            }
        }

        public RectAction CurrentAction
        {
            get { return _currentAction; }
            set
            {
                _currentAction = value;
            }
        }

        #endregion Form properties

        #region Save and Load

        private void LoadFileList()
        {
            if (_files == null)
                _files = new List<string>();

            _files.Clear();

            if (!string.IsNullOrWhiteSpace(ImageFolder) && System.IO.Directory.Exists(ImageFolder))
            {
                string[] f = System.IO.Directory.GetFiles(ImageFolder);

                foreach (string file in f)
                {
                    string ext = Path.GetExtension(file).ToLowerInvariant();

                    if (_extentions.Contains(ext))
                    {
                        _files.Add(Path.GetFileName(file));
                    }
                }
                _files.Sort();
            }
        }

        private void LoadAnnotations()
        {
            if (Directory.Exists(ImageFolder))
            {
                string annXml = Path.Combine(ImageFolder, "Annotations.xml");
                if (File.Exists(annXml))
                {
                    _annList = AnnotationList.FromFile(annXml);
                }
                else
                {
                    _annList = new AnnotationList();
                }
                if (_files != null)
                {
                    foreach (string file in _files)
                    {
                        if (!_annList.ContainsKey(file))
                        {
                            _annList.Add(file);
                        }
                    }
                }
            }
        }

        private void SaveAnnotations(string fileName)
        {
            SaveImageRectangles(CurrenIndex);
            if (Directory.Exists(ImageFolder))
            {
                if (_annList == null)
                    _annList = new AnnotationList();
                _annList.Save(fileName);
            }
        }

        private void SaveImageRectangles(int index)
        {
            if (_files != null && index >= 0 && index < _files.Count)
            {
                string file = _files[index];
                if (_annList != null)
                    _annList.CheckInRectangles(file, _currentRectangles, _xoffset, _yoffset, _ratio);
            }
        }

        private void LoadImageRectangles(int index)
        {
            if (_files != null && index >= 0 && index < _files.Count)
            {
                string file = _files[index];
                if (_annList != null)
                    _currentRectangles = _annList.CheckoutRectangles(file, _xoffset, _yoffset, _ratio);
            }
        }

        private void LoadFile(int index)
        {
            if (_files != null && _files.Count > 0)
            {
                string fullPath = System.IO.Path.Combine(ImageFolder, _files[index]);
                
                if (System.IO.File.Exists(fullPath))
                {
                    _loadedImage = Image.FromFile(fullPath);

                    ShowLoadedImage();
                    pictureBoxAnnotation.Refresh();
                }
            }
        }

        private static List<string> GetImageFileExtensions()
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();

            List<string> extensions = new List<string>();

            foreach (var enc in encoders)
            {
                extensions.AddRange(enc.FilenameExtension.ToLowerInvariant().Replace("*", "").Split(';'));
            }
            return extensions;
        }

        private void ShowLoadedImage()
        {
            int maxWidth = pictureBoxAnnotation.Width;
            int maxHeight = pictureBoxAnnotation.Height;

            float ratioX = ((float)maxWidth) / ((float)_loadedImage.Width);
            float ratioY = ((float)maxHeight) / ((float)_loadedImage.Height);
            _ratio = Math.Min(ratioX, ratioY);

            int newWidth = Convert.ToInt32(_loadedImage.Width * _ratio);
            int newHeight = Convert.ToInt32(_loadedImage.Height * _ratio);

            _xoffset = ((float)(maxWidth - newWidth)) / 2.0f;
            _yoffset = ((float)(maxHeight - newHeight)) / 2.0f;

            if (_drawnImage != null)
            {
                if (_drawnImage.Width != newWidth || _drawnImage.Height != newHeight)
                {
                    _drawnImage.Dispose();
                    _drawnImage = new Bitmap(newWidth, newHeight);
                }
            }
            else
            {
                _drawnImage = new Bitmap(newWidth, newHeight);
            }

            using (var graphics = Graphics.FromImage(_drawnImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(_loadedImage, 0, 0, newWidth, newHeight);
            }
        }

        private void ExportAnnotations(string fileName)
        {
            TextWriter tw = new StreamWriter(fileName);
            string format = Properties.Settings.Default.RectangleLineFormat;
            foreach (var ann in _annList)
            {
                tw.WriteLine(ann.Key);
                tw.WriteLine(ann.Value.Count);

                foreach (var rec in ann.Value)
                    tw.WriteLine(string.Format(format, rec.X, rec.Y, rec.Width, rec.Height));
            }
            tw.Close();
        }

        private void DeleteActive()
        {
            if (_currentRectangles != null && _aRect != null)
            {
                _currentRectangles.Remove(_aRect);
                SaveImageRectangles(CurrenIndex);
            }
            pictureBoxAnnotation.Refresh();
        }
        
        #endregion Save and Load

        #region Form Events

        private void ManualAnnotation_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAnnotations(Path.Combine(ImageFolder, "Annotations.xml"));
            Properties.Settings.Default.Save();
        }

        private void pictureBoxAnnotation_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (_aRect != null && e.KeyCode == Keys.Delete)
            {
                DeleteActive();
                //e. = true;
            }
            if (e.KeyCode == Keys.W)
            {
                btnNext.PerformClick();
                //if (ValidImageIndex())
                //{
                //    if (!SaveBoundingBox())
                //    {
                //        MessageBox.Show("Fail to save, please annotate once more");
                //        return;
                //    }
                //}
                ////resetFlag();
                //if (MoreImagesAfter())
                //{
                //    curImageIndex++;
                //    DisplayNewImage();
                //}
                //else
                //{
                //    MessageBox.Show("all finished！");
                //}
            }
            else if (e.KeyCode == Keys.Q)
            {
                btnPrevious.PerformClick();
                //if (ValidImageIndex())
                //{
                //    if (!SaveBoundingBox())
                //    {
                //        MessageBox.Show("Fail to save, please annotate once more");
                //        return;
                //    }
                //}
                //resetFlag();
                //if (MoreImagesBefore())
                //{
                //    curImageIndex--;
                //    DisplayNewImage();
                //}
                //else
                //{
                //    MessageBox.Show("This is the very first image！");
                //}
            }
        }
        //private bool ValidImageIndex()
        //{
        //    //return _files.Count > 0 && _currenIndex >= 0 && _currenIndex < _files.Count;
        //}
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                ImageFolder = FBD.SelectedPath;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CurrenIndex < _files.Count - 1)
                CurrenIndex++;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (CurrenIndex > 0)
                CurrenIndex--;
        }

        private void pictureBoxAnnotation_Paint(object sender, PaintEventArgs e)
        {
            if (_drawnImage != null)
            {
                e.Graphics.DrawImage(_drawnImage, new PointF(_xoffset, _yoffset));
            }
            if (_currentRectangles != null)
            {
                Color drawColor = Properties.Settings.Default.RectangleColor;

                foreach (BRectangle r in _currentRectangles)
                {
                    if (r == _aRect)
                    {
                        r.Draw(e.Graphics, drawColor, true);
                    }
                    else
                    {
                        r.Draw(e.Graphics, drawColor, false);
                    }
                }
            }
        }

        private void pictureBoxAnnotation_Resize(object sender, EventArgs e)
        {
            SaveImageRectangles(CurrenIndex);
            //ShowLoadedImage();
            LoadImageRectangles(CurrenIndex);
            pictureBoxAnnotation.Refresh();
        }
        protected override void OnMouseWheel(MouseEventArgs mea)
        {
            pictureBoxAnnotation.Focus();
            if (pictureBoxAnnotation.Focused == true && mea.Delta != 0)
            {
                if (mea.Delta <= 0)
                {
                    //set minimum size to zoom
                    if (pictureBoxAnnotation.Width < 500)
                        // lbl_Zoom.Text = pictureBox1.Image.Size; 
                        return;
                }
                else
                {
                    //set maximum size to zoom
                    if (pictureBoxAnnotation.Width > 1000)
                        return;
                }
                pictureBoxAnnotation.Width += Convert.ToInt32(pictureBoxAnnotation.Width * mea.Delta / 1000);
                pictureBoxAnnotation.Height += Convert.ToInt32(pictureBoxAnnotation.Height * mea.Delta / 1000);

                // Map the Form-centric mouse location to the PictureBox client coordinate system
                Point pictureBoxPoint = pictureBoxAnnotation.PointToClient(this.PointToScreen(mea.Location));

                ZoomScroll(pictureBoxPoint, mea.Delta > 0);
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

                pictureBoxAnnotation.Refresh();
            }
        }
        private void tsExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            SaveAnnotations(Path.Combine(ImageFolder, "Annotations.xml"));
        }

        private void tsSaveAs_Click(object sender, EventArgs e)
        {
            SFD.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            SFD.FileName = Path.Combine(ImageFolder, "Annotations.xml");
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                SaveAnnotations(SFD.FileName);
            }
        }

        private void tsExport_Click(object sender, EventArgs e)
        {
            SFD.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            SFD.InitialDirectory = ImageFolder;
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                ExportAnnotations(SFD.FileName);
            }
        }

        private void tsOptions_Click(object sender, EventArgs e)
        {
            OptionsForm ofrm = new OptionsForm();
            ofrm.Show(this);
        }

        #endregion Form Events

        #region Mouse Editing

        private int _oldx;
        private int _oldy;
        private BRectangle _aRect = null;
        private AnchorType _curAn = AnchorType.None;

        private void GetActiveRectangle(int x, int y)
        {
            if (_currentRectangles == null)
            {
                _aRect = null;
            }
            else
            {
                BRectangle act = null;
                foreach (BRectangle r in _currentRectangles)
                {
                    if (r.Contains(x, y))
                    {
                        act = r;
                        break;
                    }
                }
                _aRect = act;
            }
        }

        private void ProcessEdit()
        {
            int dx = MouseX - _oldx;
            int dy = MouseY - _oldy;

            if (_aRect != null && CurrentAction == RectAction.Editing)
            {
                switch (_curAn)
                {
                    case AnchorType.None:
                        _aRect.X += dx;
                        _aRect.Y += dy;
                        break;

                    case AnchorType.BottomCenter:
                        _aRect.Height += dy;
                        break;

                    case AnchorType.BottomLeft:
                        _aRect.Height += dy;
                        _aRect.X += dx;
                        _aRect.Width += -dx;
                        break;

                    case AnchorType.BottomRight:
                        _aRect.Width += dx;
                        _aRect.Height += dy;
                        break;

                    case AnchorType.MiddleLeft:
                        _aRect.X += dx;
                        _aRect.Width += -dx;
                        break;

                    case AnchorType.MiddleRight:
                        _aRect.Width += dx;
                        break;

                    case AnchorType.TopCenter:
                        _aRect.Y += dy;
                        _aRect.Height -= dy;
                        break;

                    case AnchorType.TopLeft:
                        _aRect.X += dx;
                        _aRect.Width += -dx;
                        _aRect.Y += dy;
                        _aRect.Height += -dy;
                        break;

                    case AnchorType.TopRight:
                        _aRect.Width += dx;
                        _aRect.Y += dy;
                        _aRect.Height += -dy;
                        break;

                    default:
                        break;
                }
            }
        }

        private void CreateNewRect()
        {
            BRectangle rec = new BRectangle(MouseX - 20, MouseY - 20, 23, 23);
            _currentRectangles.Add(rec);
            _aRect = rec;
            _curAn = AnchorType.BottomRight;
            pictureBoxAnnotation.Refresh();
        }

        private void pictureBoxAnnotation_MouseMove(object sender, MouseEventArgs e)
        {
            MouseX = e.X;
            MouseY = e.Y;
            if (_aRect == null)
            {
                pictureBoxAnnotation.Cursor = Cursors.Default;
            }
            else
            {
                AnchorType a = _aRect.GetHitAnchor(MouseX, MouseY);
                pictureBoxAnnotation.Cursor = BRectangle.GetCursor(a);
            }
            switch (CurrentAction)
            {
                case RectAction.NoAction:
                    GetActiveRectangle(e.X, e.Y);
                    if (_aRect != null)
                        CurrentAction = RectAction.Selecting;
                    break;

                case RectAction.Selecting:
                    GetActiveRectangle(e.X, e.Y);
                    if (_aRect == null)
                        CurrentAction = RectAction.NoAction;
                    break;

                case RectAction.Editing:
                    if (_aRect != null)
                        ProcessEdit();
                    break;

                default:
                    break;
            }
            _oldx = e.X;
            _oldy = e.Y;
            pictureBoxAnnotation.Refresh();
        }

        private void pictureBoxAnnotation_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (CurrentAction)
                {
                    case RectAction.NoAction:
                    case RectAction.Selecting:
                        CurrentAction = RectAction.Editing;
                        if (_aRect == null)
                        {
                            CreateNewRect();
                            _curAn = AnchorType.BottomRight;
                        }
                        else
                        {
                            _curAn = _aRect.GetHitAnchor(e.X, e.Y);
                        }
                        break;

                    case RectAction.Editing:
                        break;

                    default:
                        break;
                }
            }
        }

        private void pictureBoxAnnotation_MouseUp(object sender, MouseEventArgs e)
        {
            switch (CurrentAction)
            {
                case RectAction.NoAction:
                    break;

                case RectAction.Selecting:
                    break;

                case RectAction.Editing:
                    CurrentAction = RectAction.Selecting;
                    break;

                default:
                    break;
            }
        }

        private void pictureBoxAnnotation_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxAnnotation.Focus();
           
        }
        #endregion Mouse Editing



        private void pbSearch_Click(object sender, EventArgs e)
        {

        }

        private void tbcObjectSettings_Click(object sender, EventArgs e)
        {
            
        }

        private void tbcObjectSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcObjectSettings.SelectedTab == tbpObjectCategory) 
            {
                lblObjectProperties.Text = "Object Category";
            }
            else if (tbcObjectSettings.SelectedTab == tbpObjectLabelSummary)
            {
                lblObjectProperties.Text = "Object Label Summary";
            }
            else if (tbcObjectSettings.SelectedTab == tbpImageSettings)
            {
                lblObjectProperties.Text = "Image Settings";
            }
        }

        private void loadDataGridView(string fileName = "", string priority = "", string createdDate = "", string status = "")
        {

            //if (jsonString == "")
            //{
            //    jsonString = getObjectCategoty();
            //}
            //DataTable dataTable = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));

            //lstvObjectCategory.DataSource = dataTable;
            //BindingSource bs = new BindingSource();
            //bs.DataSource = lstvObjectCategory.DataSource;
            //string queryString = "";

            //if (fileName != "")
            //{
            //    queryString += "File_Name = '" + fileName + "' ";
            //}
            //if (priority != "")
            //{
            //    if (queryString == "")
            //    {
            //        queryString += "Priority = '" + priority + "' ";
            //    }
            //    else
            //    {
            //        queryString += " AND Priority = '" + priority + "' ";
            //    }
            //}
            //if (createdDate != "")
            //{
            //    if (queryString == "")
            //    {
            //        queryString += "Created_Date = '" + createdDate + "' ";
            //    }
            //    else
            //    {
            //        queryString += "AND  Created_Date = '" + createdDate + "' ";
            //    }
            //}
            //if (status != "")
            //{
            //    if (queryString == "")
            //    {
            //        queryString += "Status = '" + status + "' ";
            //    }
            //    else
            //    {
            //        queryString += "AND Status = '" + status + "' ";
            //    }
            //}


            //bs.Filter = queryString;
            //lstvObjectCategory.DataSource = bs;

            //lstvObjectCategory.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            //lstvObjectCategory.Columns["File_Name"].HeaderText = "File Name";
            //lstvObjectCategory.Columns["Task_level"].HeaderText = "Task Level";
            //lstvObjectCategory.Columns["Created_Date"].HeaderText = "Date of Creation";
            //lstvObjectCategory.RowsDefaultCellStyle.BackColor = Color.LightGray;
            //lstvObjectCategory.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }
        private string getObjectCategoty()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("X-Version", "1");
                var response = httpClient.GetStringAsync(new Uri("http://localhost:8000/getObjectLevel/")).Result;
                return response;
            }
        }
        private void timerTrackbar_Tick(object sender, EventArgs e)
        {
            //trackBarImages.Value = (int);
        }

        private void trackBarImages_ValueChanged(object sender, System.EventArgs e)
        {
            if (trackBarImages.Value < valueBefore) { 
                btnPrevious.PerformClick();
            }else{
                btnNext.PerformClick();
            }
                valueBefore = trackBarImages.Value;
         }

        //private void trackBarImages_Scroll(object sender, EventArgs e)
        //        {
            
        //            btnNext.PerformClick();
        //        }
    }
}
