using System;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Automatic_Annotation_CU
{
    public partial class TaskList : Form
    {
        string jsonString = "";
        public TaskList()
        {
            InitializeComponent();
        }

        private void TaskList_Load(object sender, EventArgs e)
        {
            //cmbPriority.SelectedIndex = 0;
            //cmbStatus.SelectedIndex = 0;
            //cmbTaskFile.SelectedIndex = 0;
            //string filename = @"data\createuser_assigntaskfiles.json";
            //string jsonString = File.ReadAllText(filename);
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            loadDataGridView();
            loadFilesCombo();
        }

        private void loadDataGridView(string fileName = "", string priority ="",string createdDate = "", string status ="")
        {

            if (jsonString == "")
            {
                jsonString = getTaskList();
            }
            DataTable dataTable = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));

            dgvTaskList.DataSource = dataTable;
            BindingSource bs = new BindingSource();
            bs.DataSource = dgvTaskList.DataSource;
            string queryString = "";

            if (fileName != "")
            {
                queryString += "File_Name = '"+ fileName +"' ";
            }
            if (priority != "")
            {
                if (queryString == "")
                {
                    queryString += "Priority = '" + priority + "' ";
                }
                else
                {
                    queryString += " AND Priority = '" + priority + "' ";
                }
            }
            if (createdDate != "")
            {
                if (queryString == "")
                {
                    queryString += "Created_Date = '" + createdDate + "' ";
                }
                else
                {
                    queryString += "AND  Created_Date = '" + createdDate + "' ";
                }
            }
            if (status != "")
            {
                if (queryString == "")
                {
                    queryString += "Status = '" + status + "' ";
                }
                else
                {
                    queryString += "AND Status = '" + status + "' ";
                }
            }

          
            bs.Filter = queryString;
            dgvTaskList.DataSource = bs;

            dgvTaskList.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);
            dgvTaskList.Columns["File_Name"].HeaderText = "File Name";
            dgvTaskList.Columns["project_name"].Visible = false;
            dgvTaskList.Columns["Task_level"].HeaderText = "Task Level";
            dgvTaskList.Columns["Created_Date"].HeaderText = "Date of Creation";
            
            dgvTaskList.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvTaskList.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
        }

        private string getTaskList()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("X-Version", "1");
                var response = httpClient.GetStringAsync(new Uri("http://localhost:8000/getTaskFilesList/")).Result;
                return response;
            }
        }

        private void cmbTaskFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDataGridView( cmbTaskFile.Text, "","", "");
        }

        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDataGridView("",cmbPriority.Text,"","");
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDataGridView("", "", "", cmbStatus.Text);
        }

        //private void dtpCreatedDate_ValueChanged(object sender, EventArgs e)
        //{
        //    loadDataGridView("", "" ,dtpCreatedDate.Text,  "");
        //}
        private void dtpCreatedDate_CloseUp(object sender, EventArgs e)
        {
            loadDataGridView("", "", dtpCreatedDate.Text, "");
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            resetFilter();
        }

        private void resetFilter()
        {
            cmbPriority.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            cmbTaskFile.SelectedIndex = -1;
            dtpCreatedDate.Value = DateTime.Today;
            loadDataGridView();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            getTaskList();
            loadDataGridView();
        }

        private void loadFilesCombo()
        { 
            
        }
    }
}
