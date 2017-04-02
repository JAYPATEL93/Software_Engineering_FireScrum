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
    public partial class Create_Project : Form
    {
        SqlConnection conn;
        String connectionString;
        int userId;
        String email;
        int projectId;


        public Create_Project(String connString, int userIdPass, String emailPass)
        {
            InitializeComponent();
            connectionString = connString;
            conn = new SqlConnection(connString);
            passwordTextBox.PasswordChar = '*';
            userId = userIdPass;
            email = emailPass;
        }

        private void Create_Project_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int duplicate=0;
            String projectName = projectNameTextBox.Text;
            int projectVersion = projectVersionListBox.SelectedIndex + 1;
            String projectDescription = projectDescriptionTextBox.Text;
            String password = passwordTextBox.Text;
            var owner = managementCheckedListBox.GetItemCheckState(managementCheckedListBox.Items.IndexOf("Product Owner")).ToString();
            var scrum = managementCheckedListBox.GetItemCheckState(managementCheckedListBox.Items.IndexOf("Scrum Master")).ToString();
            String productOwner;
            String scrumMaster;

            if (owner == "Checked")
                productOwner = "True";
            else
                productOwner = "False";
            if (scrum == "Checked")
                scrumMaster = "True";
            else
                scrumMaster = "False";

            System.Data.SqlClient.SqlCommand cmd5 = new System.Data.SqlClient.SqlCommand();
            cmd5.CommandType = System.Data.CommandType.Text;
            cmd5.CommandText = "Select Count(*) from Projects where ProjectName = @projectName and ProjectVersion = @projectVersion";
            cmd5.Parameters.AddWithValue("@projectname", projectName);
            cmd5.Parameters.AddWithValue("@projectversion", projectVersion);
            cmd5.Connection = conn;

            conn.Open();

            try
            {
                duplicate = (int)cmd5.ExecuteScalar();
            }
            catch (SqlException)
            {
                string myStringVariable = "Error with system!!";
                MessageBox.Show(myStringVariable);
            }
            conn.Close();
            
            if (duplicate == 0)
            {
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT INTO Projects (ProjectName, ProjectVersion, ProductOwner, ScrumMaster, ProjectDescription, Password) VALUES (@projectname, @projectversion, @productowner, @scrummaster, @projectdescription, @password)";
                cmd.Parameters.AddWithValue("@projectname", projectName);
                cmd.Parameters.AddWithValue("@projectversion", projectVersion);
                cmd.Parameters.AddWithValue("@productowner", productOwner);
                cmd.Parameters.AddWithValue("@scrummaster", scrumMaster);
                cmd.Parameters.AddWithValue("@projectdescription", projectDescription);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Connection = conn;

                conn.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    this.Hide();
                    // add info to MyProject boxes on myProject
                    MyProject myproject = new MyProject(connectionString, userId, projectName, projectVersion, projectDescription);
                    myproject.Show();
                }
                catch (SqlException)
                {
                    string myStringVariable = "Error: Duplicate Project";
                    MessageBox.Show(myStringVariable);
                }
                conn.Close();


                System.Data.SqlClient.SqlCommand cmd0 = new System.Data.SqlClient.SqlCommand();
                cmd0.CommandType = System.Data.CommandType.Text;
                cmd0.CommandText = "Select ProjectID from Projects where ProjectName = @projectName and ProjectVersion = @projectVersion";
                cmd0.Parameters.AddWithValue("@projectname", projectName);
                cmd0.Parameters.AddWithValue("@projectversion", projectVersion);
                cmd0.Connection = conn;

                conn.Open();

                try
                {
                    projectId = (int)cmd0.ExecuteScalar();
                }
                catch (SqlException)
                {
                    string myStringVariable = "Error with system!!";
                    MessageBox.Show(myStringVariable);
                }
                conn.Close();


                System.Data.SqlClient.SqlCommand cmd1 = new System.Data.SqlClient.SqlCommand();
                cmd1.CommandType = System.Data.CommandType.Text;
                cmd1.CommandText = "Insert INTO Members(Email, ProjectId, Position) Values (@email, @projectId, @position)";
                cmd1.Parameters.AddWithValue("@email", email);
                cmd1.Parameters.AddWithValue("@projectId", projectId);
                cmd1.Parameters.AddWithValue("@position", "Product Owner");


                cmd1.Connection = conn;

                conn.Open();

                try
                {
                    cmd1.ExecuteScalar();
                }
                catch (SqlException)
                {
                    string myStringVariable = "Error with system!!";
                    MessageBox.Show(myStringVariable);
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Error: This project already exists!!");
            }
        }

        private void projectNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void projectVersionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
