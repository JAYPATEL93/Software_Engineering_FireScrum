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
    public partial class connectingToDatabase : Form
    {
        String connectionString;

        public connectingToDatabase()
        {
            InitializeComponent();
            this.FormClosed += connectingToDatabase_Closed;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Database Files (*.mdf)|*.mdf";
            openFileDialog1.ShowDialog();
            connectTextBox.Text = openFileDialog1.FileName;
            connectionString = connectTextBox.Text;
        }
        private void connectingToDatabase_Closed(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            String cs = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + connectionString + "; Integrated Security = True; Connect Timeout = 30";
            try
            {
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open(); // throws if invalid
                }
            //this.Hide();
            Login login = new Login(cs);
            login.Show();
                Hide();
            }
            catch (SqlException)
            {
                MessageBox.Show("Invalid Database, Try again");
            }

        }

        private void connectingToDatabase_Load(object sender, EventArgs e)
        {

        }
    }
}
