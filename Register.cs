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

namespace IgnitionHacksShirleyXiao
{
    public partial class Register : Form
    {
        string path = @"Data Source=SHIRLEY\SHIRLEY;Initial Catalog=USERDATABASE; Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        
        public Register()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            
        }

        private void Register_Load(object sender, EventArgs e)
        {
            btnRegistration.FlatAppearance.BorderColor = Color.Gray;
            linkLogin.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            linkLogin1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLogin.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            linkLogin.LinkVisited = true;
            linkLogin1.LinkVisited = true;
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void linkLogin1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLogin.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            linkLogin.LinkVisited = true;
            linkLogin1.LinkVisited = true;
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            //connect all the information

            if(txtUser.Text != String.Empty && txtPass1.Text != String.Empty && txtPass2.Text != String.Empty)
            {
                if(txtPass1.Text == txtPass2.Text)
                {
                    con.Open();
                     cmd = new SqlCommand("Select * from userTable where Username='" + txtUser.Text + "'", con);
                     dr = cmd.ExecuteReader();
                     if (dr.Read())
                     {
                         dr.Close();
                         MessageBox.Show("This username already exists, please try another one");
                     }
                     else
                     {
                         dr.Close();
                         cmd = new SqlCommand("insert into userTable values(@Username, @UPass)", con);
                         cmd.Parameters.AddWithValue("Username", txtUser.Text);
                         cmd.Parameters.AddWithValue("UPass", txtPass1.Text);
                         cmd.ExecuteNonQuery();
                         MessageBox.Show("Your account has been registered, you will be taken to the login");
                         Thread.Sleep(4000);
                         this.Hide();
                         Login login = new Login();
                         login.ShowDialog();
                     }
                     con.Close();
                }
                else
                {
                    MessageBox.Show("Passwords do not match");
                }
            }
            else
            {
                MessageBox.Show("Please enter values in all fields");
            }
            
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home form = new Home();
            form.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
