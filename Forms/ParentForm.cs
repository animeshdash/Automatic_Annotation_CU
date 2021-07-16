using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automatic_Annotation_CU.Forms;

namespace Automatic_Annotation_CU.Forms
{
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog1 = new OpenFileDialog();
        }

        private void btnTaskList_Click(object sender, EventArgs e)
        {
            loadDefaultForm();
        }

        private void ParentForm_Load(object sender, EventArgs e)
        {
            loadDefaultForm();
        }

        private void loadDefaultForm()
        {
            Login login = new Login();
            lblWelcomeMessage.Text = login.strWelcomeMessage;
            TaskList taskList = new TaskList();
            taskList.TopLevel = false;

            pnlContainer.Controls.Add(taskList);
            taskList.BringToFront();
            taskList.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ManualAnnotation manualAnnotation = new ManualAnnotation();
            manualAnnotation.TopLevel = false;

            pnlContainer.Controls.Add(manualAnnotation);
            manualAnnotation.BringToFront();
            manualAnnotation.Show();
        }

        private void btnAnnotation_Click(object sender, EventArgs e)
        {

            
                Form1 manualAnnotation = new Form1();
                manualAnnotation.TopLevel = false;

                pnlContainer.Controls.Add(manualAnnotation);
                manualAnnotation.BringToFront();
                manualAnnotation.Show();
            
        }

        private void pcbSignOut_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
