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

    public partial class CreateAccount : Form
    {
        SqlConnection conn;// = new SqlConnection("Server = (LocalDB)\\MSSQLLocalDB; Integrated Security = true;  AttachDbFileName = C:\\Users\\TJ\\Dropbox\\CS 440 Coding and Development Projects\\Coding Project\\Glenn Turner Jr\\App_Data\\Group13Database.mdf");
        String connectionString;


        public CreateAccount(String connString)
        {
            InitializeComponent();
            connectionString = connString;
            conn = new SqlConnection(connString);
            passwordTextBox.PasswordChar = '*';
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var firstName = firstNameTextBox.Text;
            var lastName = lastNameTextBox.Text;
            var password = passwordTextBox.Text;
            var email = emailTextBox.Text;

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO Accounts (firstname, lastname, password, email) VALUES (@firstname, @lastname, @password, @email)";
            cmd.Parameters.AddWithValue("@firstname", firstName);
            cmd.Parameters.AddWithValue("@lastname", lastName);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Connection = conn;

            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                this.Hide();
            }
            catch (SqlException)
            {
                string myStringVariable = "Error: Account already exists under email address";
                MessageBox.Show(myStringVariable);
            }
            conn.Close();
            


        }
    }
}
