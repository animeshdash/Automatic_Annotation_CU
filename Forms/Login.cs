using Automatic_Annotation_CU;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AAutomatic_Annotation_CU.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.Hide();
            TaskList taskList = new TaskList();
            taskList.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            TaskList taskList = new TaskList();
            taskList.ShowDialog();
        }
    }
}
