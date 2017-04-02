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
    public partial class Members : Form
    {
        SqlConnection conn;
        String connectionString;
        int projectId;
        int userId;
        String email;
        String position;
        String member;

        System.Data.DataSet myDataSet;
        System.Data.SqlClient.SqlCommand myCommand;
        System.Data.SqlClient.SqlDataAdapter myDataAdapter;

        System.Data.DataSet myDataSet2;
        System.Data.SqlClient.SqlCommand myCommand2;
        System.Data.SqlClient.SqlDataAdapter myDataAdapter2;

        public Members(String connString, int projectIdPass, int userIdPass)
        {
            InitializeComponent();
            connectionString = connString;
            conn = new SqlConnection(connString);
            projectId = projectIdPass;
            userId = userIdPass;
        }

        private void Members_Load(object sender, EventArgs e)
        {
            conn.Open();
            
            myDataSet = new System.Data.DataSet();
            myDataSet.CaseSensitive = true;

            string commandString = "Select Email from Accounts where UserId != @userId";
           
                myCommand = new System.Data.SqlClient.SqlCommand();
                myCommand.Connection = conn;
                myCommand.CommandText = commandString;
                myCommand.Parameters.AddWithValue("@userId", userId);


                myDataAdapter = new SqlDataAdapter();
                myDataAdapter.SelectCommand = myCommand;
                myDataAdapter.Fill(myDataSet);


                DataTable myDataTable = myDataSet.Tables[0];

                foreach (DataRow dataRow in myDataTable.Rows)
                {
                    usersComboBox.Items.Add(dataRow["Email"]);
                }


            conn.Close();

            conn.Open();

            myDataSet2 = new System.Data.DataSet();
            myDataSet2.CaseSensitive = true;

            string commandString2 = "Select Email, Position from Members where ProjectId = @projectId";

            myCommand2 = new System.Data.SqlClient.SqlCommand();
            myCommand2.Connection = conn;
            myCommand2.CommandText = commandString2;
            myCommand2.Parameters.AddWithValue("@projectId", projectId);


            myDataAdapter2 = new SqlDataAdapter();
            myDataAdapter2.SelectCommand = myCommand2;
            myDataAdapter2.TableMappings.Add("Email", "Position");
            myDataAdapter2.Fill(myDataSet2);


            DataTable myDataTable2 = myDataSet2.Tables[0];

            foreach (DataRow dataRow in myDataTable2.Rows)
            {
                membersListBox.Items.Add(dataRow["Email"] + ": " + dataRow["Position"]);
            }


            conn.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            System.Data.SqlClient.SqlCommand cmd0 = new System.Data.SqlClient.SqlCommand();
            cmd0.CommandType = System.Data.CommandType.Text;
            cmd0.CommandText = "INSERT INTO Members(Email, ProjectId, Position) Values (@email, @projectId, @position)";
            cmd0.Parameters.AddWithValue("@email", email);
            cmd0.Parameters.AddWithValue("@position", position);
            cmd0.Parameters.AddWithValue("@projectId", projectId);


            cmd0.Connection = conn;

            conn.Open();

            try
            {
                cmd0.ExecuteNonQuery();
                membersListBox.Items.Add(email + ": " + position);
            }

            catch (SqlException)
            {
                string myStringVariable = "Duplicate Member!!";
                MessageBox.Show(myStringVariable);
            }

            conn.Close();


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            position = positionComboBox.SelectedItem.ToString();
        }

        private void usersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            email = usersComboBox.SelectedItem.ToString();
        }

        private void removeMemberButton_Click(object sender, EventArgs e)
        {
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Members WHERE ProjectId = @projectId and Email = @email and Position = @position";
            cmd.Parameters.AddWithValue("@projectId", projectId);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@position", position);

            cmd.Connection = conn;

            conn.Open();
            try
            {
                cmd.ExecuteScalar();
                for (int n = membersListBox.Items.Count - 1; n >= 0; --n)
                {
                    if (membersListBox.Items[n].ToString().Equals(member))
                    {
                        membersListBox.Items.RemoveAt(n);
                    }
                }

            }

            catch (SqlException)
            {
                string myStringVariable = "Error with system!!";
                MessageBox.Show(myStringVariable);
            }
            conn.Close();
        }

        private void membersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int memberNumber = membersListBox.SelectedIndex;
            if (memberNumber < 0)
                member = null;
            else
            {
                member = membersListBox.SelectedItem.ToString();
            }
        }
    }
}
