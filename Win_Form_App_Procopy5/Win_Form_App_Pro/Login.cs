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
    public partial class Login : Form
    {
        SqlConnection conn;
        String connectionString;

        public Login(String connString)
        {
            InitializeComponent();
            connectionString = connString;
            conn = new SqlConnection(connString);
            passwordTextBox.PasswordChar = '*';
            this.FormClosed += Login_Closed;
        }
        private void Login_Closed(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateAccount createAccount = new CreateAccount(connectionString);
            createAccount.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var email = emailTextBox.Text;
            var password = passwordTextBox.Text;
            int success;
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select Count(*) from Accounts where Email = @email and Password = @password";
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Connection = conn;


            System.Data.SqlClient.SqlCommand cmd2 = new System.Data.SqlClient.SqlCommand();
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "Select UserID from Accounts where Email like @email and Password like @password";
            cmd2.Parameters.AddWithValue("@email", email);
            cmd2.Parameters.AddWithValue("@password", password);
            cmd2.Connection = conn;
            int userId;
            conn.Open();

            try
            {
                success = (Int32)cmd.ExecuteScalar();
                if (success == 1)
                {
                    userId = (Int32)cmd2.ExecuteScalar();
                    this.Hide();
                    Home home = new Home(connectionString, userId);
                    home.Show();
                }
                else
                {
                    string myStringVariable = "Error: Username and/or password is incorrect. Try again!";
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

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
