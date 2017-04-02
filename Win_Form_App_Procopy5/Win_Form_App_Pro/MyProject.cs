using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Win_Form_App_Pro
{
    public partial class MyProject : Form
    {
        //ListBox
        System.Data.DataSet myDataSet;
        System.Data.SqlClient.SqlCommand myCommand;
        System.Data.SqlClient.SqlDataAdapter myDataAdapter;

        System.Data.DataSet myDataSet1;
        System.Data.SqlClient.SqlCommand myCommand1;
        System.Data.SqlClient.SqlDataAdapter myDataAdapter1;

        SqlConnection conn;
        String connectionString;
        int userId;
        String projectName;
        int projectVersion;
        int projectId;
        String projectDescription;
        int initialSelectedIndex = 0;
        public MyProject(String connString, int userIdPass, String projectNamePass, int projectVersionPass, String projectDescriptionPass)
        {
            
            InitializeComponent();
            connectionString = connString;
            conn = new SqlConnection(connString);
            userId = userIdPass;
            projectName = projectNamePass;
            projectVersion = projectVersionPass;
            projectDescription = projectDescriptionPass;
        }

        private void MyProject_Load(object sender, EventArgs e)
        {

            System.Data.SqlClient.SqlCommand cmd0 = new System.Data.SqlClient.SqlCommand();
            cmd0.CommandType = System.Data.CommandType.Text;
            cmd0.CommandText = "Select ProjectID from Projects where ProjectName = @project and ProjectVersion = @projectver";
            cmd0.Parameters.AddWithValue("@project", projectName);
            cmd0.Parameters.AddWithValue("@projectVer", projectVersion);
            cmd0.Connection = conn;

            conn.Open();
            try
            {
                projectId = (Int32)cmd0.ExecuteScalar();
            }

            catch (SqlException)
            {
                string myStringVariable = "Error with system!!";
                MessageBox.Show(myStringVariable);
            }
            conn.Close();

            conn.Open();

            myDataSet1 = new System.Data.DataSet();
            myDataSet1.CaseSensitive = true;

            string commandString1 = "Select ProjectVersion from Projects where ProjectName = @project";
            

            myCommand1 = new System.Data.SqlClient.SqlCommand();
            myCommand1.Connection = conn;
            myCommand1.CommandText = commandString1;
            myCommand1.Parameters.AddWithValue("@project", projectName);
            myDataAdapter1 = new SqlDataAdapter();
            myDataAdapter1.SelectCommand = myCommand1;
           // myDataAdapter1.TableMappings.Add("ProjectVersion");
            myDataAdapter1.Fill(myDataSet1);


            DataTable myDataTable1 = myDataSet1.Tables[0];

            foreach (DataRow dataRow in myDataTable1.Rows)
            {
                projectVersionComboBox.Items.Add(dataRow["ProjectVersion"]);
            }
            conn.Close();
            
            ProjectNameTextBox.Text = projectName;
            //projectVersionComboBox.Items.Add(projectVersion);
            projectVersionComboBox.SelectedText = (projectVersion).ToString();
            ProjectDescriptionTextBox.Text = projectDescription;



            
            conn.Open();

            myDataSet = new System.Data.DataSet();
            myDataSet.CaseSensitive = true;

            string commandString = "Select Email, Message from MessageBox INNER JOIN ACCOUNTS ON MessageBox.UserID = Accounts.UserId INNER JOIN Projects on MessageBox.projectID = Projects.projectID where projectname = @project and projectversion = @projectVer";



            myCommand = new System.Data.SqlClient.SqlCommand();
            myCommand.Connection = conn;
            myCommand.CommandText = commandString;
            myCommand.Parameters.AddWithValue("@project", projectName);
            myCommand.Parameters.AddWithValue("@projectVer", projectVersion);
            myDataAdapter = new SqlDataAdapter();
            myDataAdapter.SelectCommand = myCommand;
            myDataAdapter.TableMappings.Add("Email", "Message");
            myDataAdapter.Fill(myDataSet);


            DataTable myDataTable = myDataSet.Tables[0];

            foreach (DataRow dataRow in myDataTable.Rows)
            {
                QuickMessageListBox.Items.Add(dataRow["Email"] + ":  " + dataRow["Message"]);
            }
            conn.Close();
        }

        //NotificationButton_Click will add the message from the bottom text box to top one
        private void NotificationButton_Click(object sender, EventArgs e)
        {
            String msg = QuickMessageSubmitTextBox.Text;
 
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert INTO MessageBox (UserID, Message, ProjectId) Values (@user, @message, @projectId)";
                cmd.Parameters.AddWithValue("@user", userId);
                cmd.Parameters.AddWithValue("@message", msg);
                cmd.Parameters.AddWithValue("@projectId", projectId);
                cmd.Connection = conn;
          
            conn.Open();
            try
            {
                cmd.ExecuteScalar();
                QuickMessageListBox.Items.Add(msg);
            }

            catch (SqlException)
            {
                string myStringVariable = "Error with system!!";
                MessageBox.Show(myStringVariable);
            }

            conn.Close();
            
        }

        private void myProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sandboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sandbox sandbox = new Sandbox(connectionString, projectId, userId);
            sandbox.Show();
        }

        private void chatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void MyProject_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void MyProject_DragDrop(object sender, DragEventArgs e)
        {
            string[] droppedfiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in droppedfiles)
            {
                string filename = getFileName(file);
                listBox1.Items.Add(filename);
            }
        }

        private string getFileName(string path)
        {
            return System.IO.Path.GetFileName(path);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SprintPlan sprint = new SprintPlan(connectionString, projectId);
            sprint.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            initialSelectedIndex++;
            if ((Int32)projectVersionComboBox.SelectedItem != projectVersion)
            {
                    projectVersion = (Int32)projectVersionComboBox.SelectedItem;
                    System.Data.SqlClient.SqlCommand cmd0 = new System.Data.SqlClient.SqlCommand();
                    cmd0.CommandType = System.Data.CommandType.Text;
                    cmd0.CommandText = "Select ProjectDescription from Projects where ProjectName = @project and ProjectVersion = @projectver";
                    cmd0.Parameters.AddWithValue("@project", projectName);
                    cmd0.Parameters.AddWithValue("@projectVer", projectVersion);
                    cmd0.Connection = conn;

                    conn.Open();
                    try
                    {
                        projectDescription = (String)cmd0.ExecuteScalar();
                    }

                    catch (SqlException)
                    {
                        string myStringVariable = "Error with system!!";
                        MessageBox.Show(myStringVariable);
                    }
                    conn.Close();
                    this.Hide();

                    MyProject myproject = new MyProject(connectionString, userId, projectName, projectVersion, projectDescription);
                    myproject.Show();
                    initialSelectedIndex = 0;
                

        }
    }

        private void productBacklogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductBacklog productBacklog = new ProductBacklog(connectionString, projectId);
            productBacklog.Show();
        }

        private void membersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Members members = new Members(connectionString, projectId, userId);
            members.Show();
        }
    }
}