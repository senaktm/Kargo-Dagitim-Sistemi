using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazLab11
{
    public partial class Form3 : Form
    {
        string mysqlConnection = "SERVER=35.224.209.204;DATABASE=cloudDatabase;UID=root;PWD=1234";

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {




        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {

            if (txtUsername.Text.Equals(""))
            {
                MessageBox.Show("Please enter your username");
            }
            else if (txtPassword.Text.Equals(""))
            {
                MessageBox.Show("Please enter your password");
            }
            else
            {
                using (var connection = new MySqlConnection(mysqlConnection))
                {
                    try
                    {
                        connection.Open();
                        MySqlDataReader read;
                        MySqlCommand command = new MySqlCommand("SELECT * FROM User_info WHERE username ='" + txtUsername.Text + "' AND user_password ='" + txtPassword.Text + "'", connection);
                        read = command.ExecuteReader();
                        if (read.Read())
                        {
                            MessageBox.Show("Logined succesfuly");
                            Form2 form2 = new Form2();
                            this.Hide();
                            form2.Show();





                        }
                        else
                        {
                            MessageBox.Show("INVALID USERNAME OR PASSWORD");
                        }

                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Disconnected cause of \n " + error.ToString());
                        throw;
                    }
                }
            }





        }

        private void btnSignUp_Click_1(object sender, EventArgs e)
        {
            using (var connection = new MySqlConnection(mysqlConnection))
            {
                try
                {
                    connection.Open();
                    
                        MySqlCommand command = new MySqlCommand("insert into User_info (username,user_password) values (@p1,@p2)", connection);
                    command.Parameters.AddWithValue("@p1", txtUsername.Text);
                    command.Parameters.AddWithValue("@p2", txtPassword.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("SIGNED UP SUCCESFULY");
                    
                }

                catch (Exception error)
                {
                    MessageBox.Show("Disconnected cause of \n " + error.ToString());
                    throw;
                }
            }
        }
    }
}

