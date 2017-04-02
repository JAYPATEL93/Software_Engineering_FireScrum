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
    public partial class ProductBacklog : Form
    {
        SqlConnection conn;
        String connectionString;
        int projectId;

        System.Data.DataSet myDataSet;
        System.Data.SqlClient.SqlCommand myCommand;
        System.Data.SqlClient.SqlDataAdapter myDataAdapter;

        System.Data.DataSet myDataSet2;
        System.Data.SqlClient.SqlCommand myCommand2;
        System.Data.SqlClient.SqlDataAdapter myDataAdapter2;
        String incompleteStoryItem;
        int incompleteStoryItemLocation;

        public ProductBacklog(String connString, int projectIdPass)
        {
            InitializeComponent();
            connectionString = connString;
            conn = new SqlConnection(connString);
            projectId = projectIdPass;
        }

        private void ProductBacklog_Load(object sender, EventArgs e)
        {
            completeStoryButton.Hide();
            deleteButton.Hide();
            conn.Open();

            myDataSet = new System.Data.DataSet();
            myDataSet.CaseSensitive = true;

            string commandString = "Select Story from ProductBacklog where projectId = @projectId and incomplete = @incomplete";

            myCommand = new System.Data.SqlClient.SqlCommand();
            myCommand.Connection = conn;
            myCommand.CommandText = commandString;
            myCommand.Parameters.AddWithValue("@projectId", projectId);
            myCommand.Parameters.AddWithValue("@incomplete", "True");
            myDataAdapter = new SqlDataAdapter();
            myDataAdapter.SelectCommand = myCommand;
            //myDataAdapter.TableMappings.Add("Story");
            myDataAdapter.Fill(myDataSet);


            DataTable myDataTable = myDataSet.Tables[0];

            foreach (DataRow dataRow in myDataTable.Rows)
            {
                incompleteStoryListBox.Items.Add(dataRow["Story"]);
            }
            conn.Close();

            conn.Open();

            myDataSet2 = new System.Data.DataSet();
            myDataSet2.CaseSensitive = true;

            string commandString2 = "Select Story from ProductBacklog where projectId = @projectId and complete = @complete";

            myCommand2 = new System.Data.SqlClient.SqlCommand();
            myCommand2.Connection = conn;
            myCommand2.CommandText = commandString2;
            myCommand2.Parameters.AddWithValue("@projectId", projectId);
            myCommand2.Parameters.AddWithValue("@complete", "True");
            myDataAdapter2 = new SqlDataAdapter();
            myDataAdapter2.SelectCommand = myCommand2;
            //myDataAdapter.TableMappings.Add("Story");
            myDataAdapter2.Fill(myDataSet2);


            DataTable myDataTable2 = myDataSet2.Tables[0];

            foreach (DataRow dataRow in myDataTable2.Rows)
            {
                completeStoryListBox.Items.Add(dataRow["Story"]);
            }
            conn.Close();
        }

        private void incompleteStoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            completeStoryButton.Show();
            deleteButton.Show();
            incompleteStoryItemLocation = (int)incompleteStoryListBox.SelectedIndex;
            if (incompleteStoryItemLocation < 0)
                incompleteStoryItem = null;
            else
                incompleteStoryItem = incompleteStoryListBox.SelectedItem.ToString();
        }

        private void completeStoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            completeStoryButton.Hide();
            deleteButton.Hide();
        }

        private void completeStoryButton_Click(object sender, EventArgs e)
        {

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE ProductBacklog SET Incomplete = @incomplete, Complete = @complete, InProgress = @inProgress WHERE Story = @story";
            cmd.Parameters.AddWithValue("@story", incompleteStoryItem);
            cmd.Parameters.AddWithValue("@incomplete", "False");
            cmd.Parameters.AddWithValue("@complete", "True");
            cmd.Parameters.AddWithValue("@inProgress", "False");


            cmd.Connection = conn;

            conn.Open();
            try
            {
                cmd.ExecuteScalar();
                completeStoryListBox.Items.Add(incompleteStoryItem);
                for (int n = incompleteStoryListBox.Items.Count - 1; n >= 0; --n)
                {
                    if (incompleteStoryListBox.Items[n].ToString().Equals(incompleteStoryItem))
                    {
                        incompleteStoryListBox.Items.RemoveAt(n);
                    }
                }

                MessageBox.Show("Story Completed!!");
                
            }

            catch (SqlException)
            {
                string myStringVariable = "Error with system!!";
                MessageBox.Show(myStringVariable);
            }

            conn.Close();




            completeStoryButton.Hide();
            deleteButton.Hide();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM ProductBacklog WHERE story = @story and incomplete = @incomplete and complete = @complete";
            cmd.Parameters.AddWithValue("@story", incompleteStoryItem);
            cmd.Parameters.AddWithValue("@incomplete", "True");
            cmd.Parameters.AddWithValue("@complete", "False");

            cmd.Connection = conn;

            conn.Open();
            try
            {
                cmd.ExecuteScalar();
                for (int n = incompleteStoryListBox.Items.Count - 1; n >= 0; --n)
                {
                    if (incompleteStoryListBox.Items[n].ToString().Equals(incompleteStoryItem))
                    {
                        incompleteStoryListBox.Items.RemoveAt(n);
                    }
                }

                MessageBox.Show("Story Deleted!!");


            }

            catch (SqlException)
            {
                string myStringVariable = "Error with system!!";
                MessageBox.Show(myStringVariable);
            }

            conn.Close();
            completeStoryButton.Hide();
            deleteButton.Hide();

        }
    }
}
