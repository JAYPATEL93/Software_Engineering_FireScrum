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
    public partial class Home : Form
    {
        SqlConnection conn;// = new SqlConnection("Server = (LocalDB)\\MSSQLLocalDB; Integrated Security = true;  AttachDbFileName = C:\\Users\\TJ\\Dropbox\\CS 440 Coding and Development Projects\\Coding Project\\Glenn Turner Jr\\App_Data\\Group13Database.mdf");
        String connectionString;
        String userName;
        int userId;
        
        public Home(String connString, int userIdPass)
        {
            InitializeComponent();
            connectionString = connString;
            conn = new SqlConnection(connString);
            passwordTextBox.PasswordChar = '*';
            userId = userIdPass;
            this.FormClosed += Home_Closed;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Create_Project createproject = new Create_Project(connectionString, userId, userName);
            createproject.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select Email from Accounts where userId = @userId";
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Connection = conn;

            conn.Open();

            try
            {
                userName = (String)cmd.ExecuteScalar();
                userNameLabel.Text = userName;
            }
            catch (SqlException)
            {
                string myStringVariable = "Error with system!!";
                MessageBox.Show(myStringVariable);
            }
            conn.Close();
        }

        private void Home_Closed(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void joinProjectButton_Click(object sender, EventArgs e)
        {
            var projectName = projectNameTextBox.Text;
            var password = passwordTextBox.Text;

            int success;
            int success2;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select Count(*) from Projects where ProjectName = @projectname and Password = @password";
            cmd.Parameters.AddWithValue("@projectname", projectName);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Connection = conn;

            //Project Version
            System.Data.SqlClient.SqlCommand cmd2 = new System.Data.SqlClient.SqlCommand();
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "Select ProjectVersion from Projects where ProjectName = @projectname";
            cmd2.Parameters.AddWithValue("@projectname", projectName);
            cmd2.Parameters.AddWithValue("@password", password);
            cmd2.Connection = conn;

            //Project Description
            System.Data.SqlClient.SqlCommand cmd3 = new System.Data.SqlClient.SqlCommand();
            cmd3.CommandType = System.Data.CommandType.Text;
            cmd3.CommandText = "Select ProjectDescription from Projects where ProjectName = @projectname";
            cmd3.Parameters.AddWithValue("@projectname", projectName);
            cmd3.Parameters.AddWithValue("@password", password);
            cmd3.Connection = conn;

            //Check for accessibility
            System.Data.SqlClient.SqlCommand cmd4 = new System.Data.SqlClient.SqlCommand();
            cmd4.CommandType = System.Data.CommandType.Text;
            cmd4.CommandText = "Select COUNT(*) from MEMBERS INNER JOIN Projects on Members.ProjectId = Projects.ProjectID where ProjectName = @projectName and Password = @password and Email = @email";
            cmd4.Parameters.AddWithValue("@projectname", projectName);
            cmd4.Parameters.AddWithValue("@password", password);
            cmd4.Parameters.AddWithValue("@email", userName);

            cmd4.Connection = conn;

            conn.Open();
            try
            {
                success = (Int32)cmd.ExecuteScalar();
               // MessageBox.Show(success.ToString());
                success2 = (Int32)cmd4.ExecuteScalar();
                //MessageBox.Show(success2.ToString());
                if (success > 0)
                {
                    if (success2 < 1)
                    {
                        string myStringVariable = "This user does not have access to this project...";
                        MessageBox.Show(myStringVariable);
                    }
                    else
                    {
                        var projectVersion = (Int32)cmd2.ExecuteScalar();
                        var projectDescription = (String)cmd3.ExecuteScalar();

                        MyProject myproject = new MyProject(connectionString, userId, projectName, projectVersion, projectDescription);
                        myproject.ProjectNameTextBox.Text = projectNameTextBox.Text;
                        myproject.Show();
                    }
                }

                else
                {
                    string myStringVariable = "Error: ProjectName and/or password is incorrect. Try again!";
                    MessageBox.Show(myStringVariable);
                }
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
            /*MyProject project = new MyProject(connectionString, userId);
            project.Show();
            */
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Login login = new Login(connectionString);
            login.Show();
            this.Hide();
        }
    }
}
