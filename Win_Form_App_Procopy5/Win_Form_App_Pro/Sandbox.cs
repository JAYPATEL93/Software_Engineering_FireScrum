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
    public partial class Sandbox : Form
    {
        System.Data.DataSet myDataSet;
        System.Data.SqlClient.SqlCommand myCommand;
        System.Data.SqlClient.SqlDataAdapter myDataAdapter;

        SqlConnection conn;
        String connectionString;
        int projectId;
        int userId;
        int leftClick = 0;
        int rightClick = 0;

        public Sandbox(String connString, int project, int user)
        {
            InitializeComponent();
            connectionString = connString;
            conn = new SqlConnection(connString);
            projectId = project;
            userId = user;

            conn.Open();

            myDataSet = new System.Data.DataSet();
            myDataSet.CaseSensitive = true;

            string commandString = "Select Email, SandBoxEntry from Sandbox INNER JOIN ACCOUNTS ON Sandbox.UserID = Accounts.UserId where projectId = @projectId";

            myCommand = new System.Data.SqlClient.SqlCommand();
            myCommand.Connection = conn;
            myCommand.CommandText = commandString;
            myCommand.Parameters.AddWithValue("@projectId", projectId);
            myDataAdapter = new SqlDataAdapter();
            myDataAdapter.SelectCommand = myCommand;
            myDataAdapter.TableMappings.Add("Email", "SandBoxEntry");
            myDataAdapter.Fill(myDataSet);


            DataTable myDataTable = myDataSet.Tables[0];

            foreach (DataRow dataRow in myDataTable.Rows)
            {
                sandboxListBox.Items.Add(dataRow["Email"] + ":  " + dataRow["SandBoxEntry"]);
            }
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName;

            System.Data.SqlClient.SqlCommand cmd0 = new System.Data.SqlClient.SqlCommand();
            cmd0.CommandType = System.Data.CommandType.Text;
            cmd0.CommandText = "Select Email from Accounts where UserID = @user";
            cmd0.Parameters.AddWithValue("@user", userId);
            cmd0.Connection = conn;

            conn.Open();
            try
            {
                userName = (string)cmd0.ExecuteScalar(); 
            }

            catch (SqlException)
            {
                string myStringVariable = "Error!!";
                MessageBox.Show(myStringVariable);
            }

            conn.Close();

            string msg = sandboxEntryTextBox.Text;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO Sandbox (ProjectId, UserID, SandboxEntry) values (@projectId, @userId, @entry)";
            cmd.Parameters.AddWithValue("@projectId", projectId);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@entry", msg);
            cmd.Connection = conn;

            conn.Open();
            try
            {
                cmd.ExecuteScalar();
            sandboxListBox.Items.Add(msg);
             sandboxListBox.Items.Add("");
            }

            catch (SqlException)
            {
                string myStringVariable = "Error with system!!";
                MessageBox.Show(myStringVariable);
            }
            
            conn.Close();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            leftClick = 0;
            rightClick = 0;
            this.sandboxListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouse_Click);

        }

        private void mouse_Click(object sender, MouseEventArgs e)
        {
            string listBoxItem;
            
            {
                if (leftClick < 1)
                {
                    if (e.Button == MouseButtons.Left)
                    {

                        listBoxItem = sandboxListBox.SelectedItem.ToString();
                        MessageBox.Show("Item Selected" + "\n" + "Right-Click to submit as Story");
                        leftClick++;
                    }
                }

                if (rightClick < 1)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        listBoxItem = sandboxListBox.SelectedItem.ToString();


                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "INSERT INTO ProductBacklog (ProjectId, Story, Incomplete, InProgress, Complete) values (@projectId, @story, @incomplete, @inProgress, @complete)";
                        cmd.Parameters.AddWithValue("@projectId", projectId);
                        cmd.Parameters.AddWithValue("@story", listBoxItem);
                        cmd.Parameters.AddWithValue("@incomplete", "True");
                        cmd.Parameters.AddWithValue("@inProgress", "False");
                        cmd.Parameters.AddWithValue("@complete", "False");

                        cmd.Connection = conn;

                        conn.Open();
                        try
                        {
                            cmd.ExecuteScalar();
                            MessageBox.Show("Submitted as a Story to Product Backlog");
                        }

                        catch (SqlException)
                        {
                            string myStringVariable = "Error with system!!";
                            MessageBox.Show(myStringVariable);
                        }

                        conn.Close();
                        rightClick++;
                    }
                    
                }
                
            }
        }

        private void Sandbox_Load(object sender, EventArgs e)
        {

        }
    }//form
}//namespace
