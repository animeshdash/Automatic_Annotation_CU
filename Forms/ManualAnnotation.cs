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
using Newtonsoft.Json;

namespace Automatic_Annotation_CU.Forms
{
    public partial class ManualAnnotation : Form
    {
        private string jsonString = "";
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
        public ManualAnnotation()
        {
            InitializeComponent();
            //txt_folder.Text = FolderSelectDetaultTip;
            //lbl_folder_desc.Text = "";
            //pcb_img.Anchor = AnchorStyles.Bottom |
            //    AnchorStyles.Left |
            //    AnchorStyles.Right |
            //    AnchorStyles.Top;
        }

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

        private void ManualAnnotation_Load(object sender, EventArgs e)
        {

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
    }
}
