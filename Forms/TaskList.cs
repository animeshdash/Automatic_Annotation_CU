using Automatic_Annotation_CU.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;

namespace Automatic_Annotation_CU
{
    public partial class TaskList : Form
    {
       
        public TaskList()
        {
            InitializeComponent();
        }

        private void TaskList_Load(object sender, EventArgs e)
        {
            //getTaskList(url);
            cmbPriority.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
            cmbTaskFile.SelectedIndex = 0;
            string filename = @"data\createuser_assigntaskfiles.json";
            
            string jsonString = File.ReadAllText(filename);
                       
            DataTable dataTable = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
            dgvTaskList.DataSource = dataTable;
            this.dgvTaskList.RowsDefaultCellStyle.BackColor = Color.Bisque;
            this.dgvTaskList.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
        }
                

        //private string getTaskList(url)
        //{
        //using (var httpClient = new HttpClient())
        //{
        //    httpClient.DefaultRequestHeaders.Add(RequestConstants.UserAgent, RequestConstants.UserAgentValue);
        //    var response = httpClient.GetStringAsync(new Uri(url)).Result;
        //    return response;
        //}
        //}

        private void cmbTaskFile_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpCreatedDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
