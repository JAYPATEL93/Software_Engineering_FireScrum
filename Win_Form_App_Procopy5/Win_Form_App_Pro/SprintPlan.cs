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
using System.IO;
using System.Globalization;

namespace Win_Form_App_Pro
{
    public partial class SprintPlan : Form
    {
        SqlConnection conn;
        SqlConnection conn2;
        String connectionString;
        int projectId;

        System.Data.DataSet myDataSet;
        System.Data.SqlClient.SqlCommand myCommand;
        System.Data.SqlClient.SqlDataAdapter myDataAdapter;


        System.Data.DataSet myDataSet2;
        System.Data.SqlClient.SqlCommand myCommand2;
        System.Data.SqlClient.SqlDataAdapter myDataAdapter2;

        System.Data.DataSet myDataSet3;
        System.Data.SqlClient.SqlCommand myCommand3;
        System.Data.SqlClient.SqlDataAdapter myDataAdapter3;


        System.Data.DataSet myDataSet4;
        System.Data.SqlClient.SqlCommand myCommand4;
        System.Data.SqlClient.SqlDataAdapter myDataAdapter4;

        System.Data.DataSet myDataSet5;
        System.Data.SqlClient.SqlCommand myCommand5;
        System.Data.SqlClient.SqlDataAdapter myDataAdapter5;

        System.Data.DataSet myDataSet6;
        System.Data.SqlClient.SqlCommand myCommand6;
        System.Data.SqlClient.SqlDataAdapter myDataAdapter6;

        int selectReleasePlan;
        int selectedSprint;
        String sprintStartDate;
        String sprintEndDate;
        String sprintName;
        String sprintDescription;
        String selectedStory;
        String selectedStoryInProgress;

        bool startDateCalendar = false;
        bool endDateCalendar = false;

        bool loadData = false;
        public SprintPlan(String connString, int projectIdPass)
        {
            InitializeComponent();
            connectionString = connString;
            conn = new SqlConnection(connString);
            conn2 = new SqlConnection(connString);
            projectId = projectIdPass;
            numberSprintsComboBox.SelectedIndex = 0;

        }

        private void SprintPlan_Load(object sender, EventArgs e)
        {

            conn.Open();
            myDataSet = new System.Data.DataSet();
            myDataSet.CaseSensitive = true;

            string commandString = "Select ReleaseNumber from ReleasePlan where ProjectId = @projectId";
            

            myCommand = new System.Data.SqlClient.SqlCommand();
            myCommand.Connection = conn;
            myCommand.CommandText = commandString;
            myCommand.Parameters.AddWithValue("@projectId", projectId);
            myDataAdapter = new SqlDataAdapter();
            myDataAdapter.SelectCommand = myCommand;
            myDataAdapter.Fill(myDataSet);

            
            DataTable myDataTable = myDataSet.Tables[0];

            foreach (DataRow dataRow in myDataTable.Rows)
            {
                releasePlanListBox.Items.Add(dataRow["ReleaseNumber"]);
            }
            conn.Close();

            conn.Open();
            myDataSet4 = new System.Data.DataSet();
            myDataSet4.CaseSensitive = true;

            string commandString2 = "Select Story from ProductBacklog where ProjectId = @projectId and Incomplete = @incomplete";


            myCommand4 = new System.Data.SqlClient.SqlCommand();
            myCommand4.Connection = conn;
            myCommand4.CommandText = commandString2;
            myCommand4.Parameters.AddWithValue("@projectId", projectId);
            myCommand4.Parameters.AddWithValue("@incomplete", "True");

            myDataAdapter4 = new SqlDataAdapter();
            myDataAdapter4.SelectCommand = myCommand4;
            myDataAdapter4.Fill(myDataSet4);


            DataTable myDataTable4 = myDataSet4.Tables[0];

            foreach (DataRow dataRow in myDataTable4.Rows)
            {
                toDoListBox.Items.Add(dataRow["Story"]);
            }
            conn.Close();
            
        }

        private void releasePlanTextBox_Click(object sender, EventArgs e)
        {
            sprintPanel.Hide();
            deleteReleasePlanButton.Hide();
            int i=0;
            int releasePlanNumber = 0;
            int newReleasePlanNumber = 0;
            int numberOfSprints = numberSprintsComboBox.SelectedIndex + 1;

            newReleasePlanNumber = releasePlanListBox.Items.Count;
            if (newReleasePlanNumber > 0)
            {
                releasePlanNumber = (int)releasePlanListBox.Items[newReleasePlanNumber - 1];
            }
            else
            {
               releasePlanNumber = 0;
            }
            releasePlanNumber = releasePlanNumber + 1;
            
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Insert INTO ReleasePlan(ProjectId, ReleaseNumber) Values (@projectId, @ReleaseNumber)";
            cmd.Parameters.AddWithValue("@projectId", projectId);
            cmd.Parameters.AddWithValue("@releaseNumber", releasePlanNumber);
            cmd.Connection = conn;

            conn.Open();
            try
            {
                cmd.ExecuteScalar();
                releasePlanListBox.Items.Add(releasePlanNumber);
            }

            catch (SqlException)
            {
                string myStringVariable = "Error with inserting release plans!!";
                MessageBox.Show(myStringVariable);
            }

            conn.Close();

            System.Data.SqlClient.SqlCommand cmd2 = new System.Data.SqlClient.SqlCommand();
            cmd2.CommandType = System.Data.CommandType.Text;
            conn.Open();

            cmd2.CommandText = "Insert INTO Sprints(ProjectId, ReleaseNumber, SprintNumber) Values (@projectId, @releaseNumber, @sprintNumber)";
            cmd2.Parameters.AddWithValue("@releaseNumber", releasePlanNumber);
            cmd2.Parameters.AddWithValue("@projectId", projectId);
            cmd2.Parameters.Add("@sprintNumber", SqlDbType.Int);
            cmd2.Connection = conn;
            for (i = 1; i <= numberOfSprints; i++)
            {
                cmd2.Parameters["@sprintNumber"].Value = i;


                try
                {
                cmd2.ExecuteScalar();
                }

                catch (SqlException)
                {
                    string myStringVariable = "Error with inserting sprints!!";
                    MessageBox.Show(myStringVariable);
                }
            }

            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void releasePlanListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sprintPanel.Hide();
            completeStoryButton.Hide();
            sprintsListBox.Items.Clear();
            inProgressListBox.Items.Clear();
            doneListBox.Items.Clear();
            deleteReleasePlanButton.Show();
            try
            {
                selectReleasePlan = (int)releasePlanListBox.SelectedItem;
            }
            catch
            {
                selectReleasePlan = 0;
            }
            conn.Open();
            myDataSet2 = new System.Data.DataSet();
            myDataSet2.CaseSensitive = true;

            string commandString = "Select SprintNumber from Sprints INNER JOIN ReleasePlan ON ReleasePlan.ReleaseNumber = Sprints.ReleaseNumber where Sprints.ReleaseNumber = @releaseNumber and Sprints.ProjectId = @projectId";


            myCommand2 = new System.Data.SqlClient.SqlCommand();
            myCommand2.Connection = conn;
            myCommand2.CommandText = commandString;
            myCommand2.Parameters.AddWithValue("@projectId", projectId);
            myCommand2.Parameters.AddWithValue("@releaseNumber", selectReleasePlan);

            myDataAdapter2 = new SqlDataAdapter();
            myDataAdapter2.SelectCommand = myCommand2;
            myDataAdapter2.Fill(myDataSet2);

            
            DataTable myDataTable = myDataSet2.Tables[0];

            try
            {
                foreach (DataRow dataRow in myDataTable.Rows)
                {
                    sprintsListBox.Items.Add(dataRow["SprintNumber"]);
                }
            }
            catch (SqlException)
            {

                string myStringVariable = "Error with selecting sprint number!!";
                MessageBox.Show(myStringVariable);

            }
            conn.Close();
        }

        private void sprintsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData = true;
            completeStoryButton.Hide();
            selectedSprint = (int)sprintsListBox.SelectedItem;
            sprintPanel.Show();
            inProgressListBox.Items.Clear();
            doneListBox.Items.Clear();

            conn.Open();

            myDataSet3 = new System.Data.DataSet();
            myDataSet3.CaseSensitive = true;

            string commandString = "Select SprintName, SprintDescription, StartDate, EndDate from Sprints where projectId = @projectId and SprintNumber = @sprintNumber and ReleaseNumber = @releaseNumber";

            try
            {
                
                myCommand3 = new System.Data.SqlClient.SqlCommand();
                myCommand3.Connection = conn;
                myCommand3.CommandText = commandString;
                myCommand3.Parameters.AddWithValue("@projectId", projectId);
                myCommand3.Parameters.AddWithValue("@releaseNumber", selectReleasePlan);
                myCommand3.Parameters.AddWithValue("@sprintNumber", selectedSprint);
                myDataAdapter3 = new SqlDataAdapter();
                myDataAdapter3.SelectCommand = myCommand3;
                myDataAdapter3.TableMappings.Add("SprintName", "SprintDescription");
                myDataAdapter3.TableMappings.Add("StartDate", "EndDate");

                myDataAdapter3.Fill(myDataSet3);


                DataTable myDataTable = myDataSet3.Tables[0];
                String startDateString;
                String endDateString;
                
                foreach (DataRow dataRow in myDataTable.Rows)
                {
                    startDateString = dataRow["StartDate"].ToString();
                    endDateString = dataRow["EndDate"].ToString();                   
                    sprintNameTextBox.Text = dataRow["SprintName"].ToString();
                    descriptionTextBox.Text = dataRow["SprintDescription"].ToString();
                    startDateTextBox.Text = dataRow["StartDate"].ToString();
                    endDateTextBox.Text = dataRow["EndDate"].ToString();
                   
                }
                loadData = false;
            }
            catch(SqlException)
            {
                string myStringVariable = "Error with filling out sprint information!!";
                MessageBox.Show(myStringVariable);
            }

            conn.Close();

            conn.Open();
            myDataSet5 = new System.Data.DataSet();
            myDataSet5.CaseSensitive = true;

            string commandString5 = "Select Story from ProductBacklog INNER JOIN SprintTasks ON ProductBacklog.ProductID = SprintTasks.ProductID where SprintTasks.projectId = @projectId and ReleaseNumber = @releaseNumber and SprintNumber = @sprintNumber and InProgress = @inProgress";


            myCommand5 = new System.Data.SqlClient.SqlCommand();
            myCommand5.Connection = conn;
            myCommand5.CommandText = commandString5;
            myCommand5.Parameters.AddWithValue("@projectId", projectId);
            myCommand5.Parameters.AddWithValue("@releaseNumber", selectReleasePlan);
            myCommand5.Parameters.AddWithValue("@sprintNumber", selectedSprint);
            myCommand5.Parameters.AddWithValue("@inProgress", "True");

            myDataAdapter5 = new SqlDataAdapter();
            myDataAdapter5.SelectCommand = myCommand5;
            myDataAdapter5.Fill(myDataSet5);


            DataTable myDataTable5 = myDataSet5.Tables[0];

            foreach (DataRow dataRow in myDataTable5.Rows)
            {
                inProgressListBox.Items.Add(dataRow["Story"]);
            }
            conn.Close();

            conn.Open();
            myDataSet6 = new System.Data.DataSet();
            myDataSet6.CaseSensitive = true;

            string commandString6 = "Select Story from ProductBacklog INNER JOIN SprintTasks ON ProductBacklog.ProductID = SprintTasks.ProductID where SprintTasks.projectId = @projectId and ReleaseNumber = @releaseNumber and SprintNumber = @sprintNumber and Complete = @complete";


            myCommand6 = new System.Data.SqlClient.SqlCommand();
            myCommand6.Connection = conn;
            myCommand6.CommandText = commandString6;
            myCommand6.Parameters.AddWithValue("@projectId", projectId);
            myCommand6.Parameters.AddWithValue("@releaseNumber", selectReleasePlan);
            myCommand6.Parameters.AddWithValue("@sprintNumber", selectedSprint);
            myCommand6.Parameters.AddWithValue("@complete", "True");

            myDataAdapter6 = new SqlDataAdapter();
            myDataAdapter6.SelectCommand = myCommand6;
            myDataAdapter6.Fill(myDataSet6);


            DataTable myDataTable6 = myDataSet6.Tables[0];

            foreach (DataRow dataRow in myDataTable6.Rows)
            {
                doneListBox.Items.Add(dataRow["Story"]);
            }
            conn.Close();

        }

        
        private void sprintNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (loadData != true)
            {
                sprintName = sprintNameTextBox.Text;
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE Sprints SET SprintName = @sprintName WHERE projectId = @projectId and ReleaseNumber = @releaseNumber and SprintNumber = @sprintNumber";
                cmd.Parameters.AddWithValue("@projectId", projectId);
                cmd.Parameters.AddWithValue("@releaseNumber", selectReleasePlan);
                cmd.Parameters.AddWithValue("@sprintNumber", selectedSprint);
                cmd.Parameters.AddWithValue("@sprintName", sprintName);
                cmd.Connection = conn2;

                conn2.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }

                catch (SqlException)
                {
                    string myStringVariable = "Max Characters Reached!";
                    MessageBox.Show(myStringVariable);
                }

                conn2.Close();
            }
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {

            sprintDescription = descriptionTextBox.Text;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE Sprints SET SprintDescription = @sprintDescription WHERE projectId = @projectId and ReleaseNumber = @releaseNumber and SprintNumber = @sprintNumber";
            cmd.Parameters.AddWithValue("@projectId", projectId);
            cmd.Parameters.AddWithValue("@releaseNumber", selectReleasePlan);
            cmd.Parameters.AddWithValue("@sprintNumber", selectedSprint);
            cmd.Parameters.AddWithValue("@sprintDescription", sprintDescription);
            cmd.Connection = conn2;

            conn2.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }

            catch (SqlException)
            {
                string myStringVariable = "Max Characters Reached!!";
                MessageBox.Show(myStringVariable);
            }

            conn2.Close();


        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (startDateCalendar == true)
            {
                sprintStartDate = monthCalendar.SelectionStart.ToShortDateString();
                startDateTextBox.Text = sprintStartDate;


                
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE Sprints SET StartDate = @startDate WHERE projectId = @projectId and ReleaseNumber = @releaseNumber and SprintNumber = @sprintNumber";
                cmd.Parameters.AddWithValue("@startDate", sprintStartDate);
                cmd.Parameters.AddWithValue("@projectId", projectId);
                cmd.Parameters.AddWithValue("@releaseNumber", selectReleasePlan);
                cmd.Parameters.AddWithValue("@sprintNumber", selectedSprint);
                cmd.Connection = conn2;

                conn2.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }

                catch (SqlException)
                {
                    string myStringVariable = "Error with updating sprints with date!!";
                    MessageBox.Show(myStringVariable);
                }

                conn2.Close();
                
            }
            else if (endDateCalendar == true)
            {
                sprintEndDate = monthCalendar.SelectionStart.ToShortDateString();
                endDateTextBox.Text = sprintEndDate;



                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE Sprints SET EndDate = @endDate WHERE projectId = @projectId and ReleaseNumber = @releaseNumber and SprintNumber = @sprintNumber";
                cmd.Parameters.AddWithValue("@endDate", sprintEndDate);
                cmd.Parameters.AddWithValue("@projectId", projectId);
                cmd.Parameters.AddWithValue("@releaseNumber", selectReleasePlan);
                cmd.Parameters.AddWithValue("@sprintNumber", selectedSprint);
                cmd.Connection = conn2;

                conn2.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }

                catch (SqlException)
                {
                    string myStringVariable = "Error with updating end date!!";
                    MessageBox.Show(myStringVariable);
                }

                conn2.Close();
            }
            startDateCalendar= false;
            endDateCalendar = false;
            monthCalendar.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            startDateCalendar = true;
            endDateCalendar = false;
            monthCalendar.Show();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            startDateCalendar = false;
            endDateCalendar = true;
            monthCalendar.Show();

        }

        private void toDoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            assignStoryButton.Show();
            completeStoryButton.Hide();
            int itemNumber = toDoListBox.SelectedIndex + 1;
            int itemLocation = (int)toDoListBox.SelectedIndex;
            if (itemLocation < 0)
                selectedStory = null;
            else
            {
                MessageBox.Show("Item " + itemNumber + ":\n" + toDoListBox.SelectedItem.ToString());

                selectedStory = toDoListBox.SelectedItem.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int productId = 0;
            int sprintId = 0;
            assignStoryButton.Hide();
            selectedStory = toDoListBox.SelectedItem.ToString();
            System.Data.SqlClient.SqlCommand cmd0 = new System.Data.SqlClient.SqlCommand();
            cmd0.CommandType = System.Data.CommandType.Text;
            cmd0.CommandText = "Select ProductID from ProductBacklog where Story = @story and Incomplete = @incomplete and ProjectID = @projectId";
            cmd0.Parameters.AddWithValue("@story", selectedStory);
            cmd0.Parameters.AddWithValue("@incomplete", "True");
            cmd0.Parameters.AddWithValue("@projectId", projectId);


            cmd0.Connection = conn;

            conn.Open();

            try
            {
                productId = (int)cmd0.ExecuteScalar();
            }

            catch (SqlException)
            {
                string myStringVariable = "Error with getting ProductID!!";
                MessageBox.Show(myStringVariable);
            }

            conn.Close();


            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select SprintID from Sprints where ProjectID = @projectID and ReleaseNumber = @releaseNumber and SprintNumber = @sprintNumber";
            cmd.Parameters.AddWithValue("@projectId", projectId);
            cmd.Parameters.AddWithValue("@releaseNumber", selectReleasePlan);
            cmd.Parameters.AddWithValue("@sprintNumber", selectedSprint);


            cmd.Connection = conn;

            conn.Open();

            try
            {
                sprintId = (int)cmd.ExecuteScalar();
            }

            catch (SqlException)
            {
                string myStringVariable = "Error with getting SprintId!!";
                MessageBox.Show(myStringVariable);
            }

            conn.Close();

            System.Data.SqlClient.SqlCommand cmd4 = new System.Data.SqlClient.SqlCommand();
            cmd4.CommandType = System.Data.CommandType.Text;
            cmd4.CommandText = "UPDATE ProductBacklog SET InProgress = @inProgress, Incomplete = @incomplete, Complete = @complete  WHERE projectId = @projectId and Story = @story";
            cmd4.Parameters.AddWithValue("@inProgress", "True");
            cmd4.Parameters.AddWithValue("@incomplete", "False");
            cmd4.Parameters.AddWithValue("@complete", "False");
            cmd4.Parameters.AddWithValue("@story", selectedStory);
            cmd4.Parameters.AddWithValue("@projectId", projectId);

            cmd4.Connection = conn;

            conn.Open();
            try
            {
            cmd4.ExecuteNonQuery();
            }

            catch (SqlException)
            {
                string myStringVariable = "Error with product backlog update inprogress!!";
                MessageBox.Show(myStringVariable);
            }
            
            conn.Close();



            System.Data.SqlClient.SqlCommand cmd1 = new System.Data.SqlClient.SqlCommand();
            cmd1.CommandType = System.Data.CommandType.Text;
            cmd1.CommandText = "Insert INTO SprintTasks(ProductID, ProjectId, ReleaseNumber, SprintNumber) Values (@productId, @projectId, @releaseNumber, @sprintNumber)";
            cmd1.Parameters.AddWithValue("@productId", productId);
            cmd1.Parameters.AddWithValue("@projectId", projectId);
            cmd1.Parameters.AddWithValue("@releaseNumber", selectReleasePlan);
            cmd1.Parameters.AddWithValue("@sprintNumber", selectedSprint);
            cmd1.Connection = conn;

            conn.Open();
            try
            {
                cmd1.ExecuteScalar();
                inProgressListBox.Items.Add(selectedStory);
                for (int n = toDoListBox.Items.Count - 1; n >= 0; --n)
                {
                    if (toDoListBox.Items[n].ToString().Equals(selectedStory))
                    {
                        toDoListBox.Items.RemoveAt(n);
                    }
                }
            }

            catch (SqlException)
            {
                string myStringVariable = "Error with inserting into SprintTasks!!";
                MessageBox.Show(myStringVariable);
            }

            conn.Close();

            

        }

        private void inProgressListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           // assignStoryButton.Hide();
            completeStoryButton.Show();

            int itemNumber = inProgressListBox.SelectedIndex + 1;
            int itemLocation = (int)inProgressListBox.SelectedIndex;
            if (itemLocation < 0)
                selectedStoryInProgress = null;
            else
            {
                MessageBox.Show("Item " + itemNumber + ":\n" + inProgressListBox.SelectedItem.ToString());
                selectedStoryInProgress = inProgressListBox.SelectedItem.ToString();
            }
        }

        private void doneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int itemNumber = doneListBox.SelectedIndex + 1;
            int itemLocation = (int)doneListBox.SelectedIndex;
            if (itemLocation < 0)
                selectedStoryInProgress = null;
            else
            {
                MessageBox.Show("Item " + itemNumber + ":\n" + doneListBox.SelectedItem.ToString());
            }            
        }

        private void completeStoryButton_Click(object sender, EventArgs e)
        {

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "UPDATE ProductBacklog SET Incomplete = @incomplete, Complete = @complete, InProgress = @inProgress WHERE Story = @story";
            cmd.Parameters.AddWithValue("@story", selectedStoryInProgress);
            cmd.Parameters.AddWithValue("@incomplete", "False");
            cmd.Parameters.AddWithValue("@complete", "True");
            cmd.Parameters.AddWithValue("@inProgress", "False");


            cmd.Connection = conn;

            conn.Open();
            try
            {
                cmd.ExecuteScalar();
                doneListBox.Items.Add(selectedStoryInProgress);
                for (int n = doneListBox.Items.Count - 1; n >= 0; --n)
                {
                    if (inProgressListBox.Items[n].ToString().Equals(selectedStoryInProgress))
                    {
                        inProgressListBox.Items.RemoveAt(n);
                    }
                }
            }

            catch (SqlException)
            {
                string myStringVariable = "Error with completing story!!";
                MessageBox.Show(myStringVariable);
            }

            conn.Close();
        }

        private void deleteSprintButton_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Sprints WHERE ProjectId = @projectId and ReleaseNumber = @releaseNumber and SprintNumber = @sprintNumber";
            cmd.Parameters.AddWithValue("@projectId", projectId);
            cmd.Parameters.AddWithValue("@releaseNumber", selectReleasePlan);
            cmd.Parameters.AddWithValue("@sprintNumber", selectedSprint);

            cmd.Connection = conn;

            conn.Open();
            try
            {
                cmd.ExecuteScalar();
                for (int n = sprintsListBox.Items.Count - 1; n >= 0; --n)
                {
                    if (sprintsListBox.Items[n].ToString().Equals(selectedSprint))
                    {
                        sprintsListBox.Items.RemoveAt(n);
                    }
                }
                
            }

            catch (SqlException)
            {
                string myStringVariable = "Error with system!!";
                MessageBox.Show(myStringVariable);
            }
            conn.Close();

            System.Data.SqlClient.SqlCommand cmd2 = new System.Data.SqlClient.SqlCommand();
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "DELETE FROM SprintTasks WHERE ProjectId = @projectId and ReleaseNumber = @releaseNumber and SprintNumber = @sprintNumber";
            cmd2.Parameters.AddWithValue("@projectId", projectId);
            cmd2.Parameters.AddWithValue("@releaseNumber", selectReleasePlan);
            cmd2.Parameters.AddWithValue("@sprintNumber", selectedSprint);

            cmd2.Connection = conn;

            conn.Open();
            try
            {
                cmd2.ExecuteScalar();
                
            }

            catch (SqlException)
            {
                string myStringVariable = "Error with system!!";
                MessageBox.Show(myStringVariable);
            }

            conn.Close();
            sprintPanel.Hide();
            sprintsListBox.Items.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Sprints WHERE ProjectId = @projectId and ReleaseNumber = @releaseNumber";
            cmd.Parameters.AddWithValue("@projectId", projectId);
            cmd.Parameters.AddWithValue("@releaseNumber", selectReleasePlan);

            cmd.Connection = conn;

            conn.Open();
            try
            {
                cmd.ExecuteScalar();
                for (int n = releasePlanListBox.Items.Count - 1; n >= 0; --n)
                {
                    if (releasePlanListBox.Items[n].ToString().Equals(selectReleasePlan))
                    {
                        releasePlanListBox.Items.RemoveAt(n);
                    }
                }
                deleteSprintButton.Hide();
            }

            catch (SqlException)
            {
                string myStringVariable = "Error with system!!";
                MessageBox.Show(myStringVariable);
            }
            conn.Close();

            System.Data.SqlClient.SqlCommand cmd2 = new System.Data.SqlClient.SqlCommand();
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "DELETE FROM SprintTasks WHERE ProjectId = @projectId and ReleaseNumber = @releaseNumber";
            cmd2.Parameters.AddWithValue("@projectId", projectId);
            cmd2.Parameters.AddWithValue("@releaseNumber", selectReleasePlan);

            cmd2.Connection = conn;

            conn.Open();
            try
            {
                cmd2.ExecuteScalar();

            }

            catch (SqlException)
            {
                string myStringVariable = "Error with system!!";
                MessageBox.Show(myStringVariable);
            }

            conn.Close();

            System.Data.SqlClient.SqlCommand cmd3 = new System.Data.SqlClient.SqlCommand();
            cmd3.CommandType = System.Data.CommandType.Text;
            cmd3.CommandText = "DELETE FROM ReleasePlan WHERE ProjectId = @projectId and ReleaseNumber = @releaseNumber";
            cmd3.Parameters.AddWithValue("@projectId", projectId);
            cmd3.Parameters.AddWithValue("@releaseNumber", selectReleasePlan);

            cmd3.Connection = conn;

            conn.Open();
            try
            {
                cmd3.ExecuteScalar();

            }

            catch (SqlException)
            {
                string myStringVariable = "Error with system!!";
                MessageBox.Show(myStringVariable);
            }

            conn.Close();

            sprintPanel.Hide();
            deleteReleasePlanButton.Hide();
            releasePlanListBox.Items.RemoveAt(releasePlanListBox.SelectedIndex);
            selectReleasePlan = 0 ; 
            
        }
    }
}
