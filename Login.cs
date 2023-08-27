using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IgnitionHacksShirleyXiao
{
    public partial class Login : Form
    {
        string path = @"Data Source = SHIRLEY\SHIRLEY;Initial Catalog=USERDATABASE; Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        int count = 0;
        public Login()
        {
            InitializeComponent();
            con = new SqlConnection(path);
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkRegister.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            linkRegister.VisitedLinkColor = Color.BlueViolet;
            linkRegister1.VisitedLinkColor = Color.BlueViolet;
            this.Hide();
            Register reg = new Register();
            reg.ShowDialog();
        }

        private void linkLogin1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkRegister.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            linkRegister.VisitedLinkColor = Color.BlueViolet;
            linkRegister1.VisitedLinkColor = Color.BlueViolet;
            this.Hide();
            Register reg = new Register();
            reg.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            linkRegister.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            linkRegister1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home form = new Home();
            form.ShowDialog();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUser.Text != String.Empty && txtPass.Text != String.Empty)
                {
                    count++;

                    if(count <= 3)
                    {
                        con.Open();
                        cmd = new SqlCommand("select * from userTable where Username = '" + txtUser.Text + "' and UPass = '" + txtPass.Text + "' ", con);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            dr.Close();
                            MessageBox.Show("You have successfully logged in", "Success", MessageBoxButtons.OK);
                            Thread.Sleep(1000);
                            this.Hide();
                            Menu menu = new Menu();
                            menu.ShowDialog();
                        }
                        else
                        {
                            dr.Close();
                            MessageBox.Show("Username and password do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You have exceeded the maximum alloted logins. Please try again later. You will be logged off in 3 seconds.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Thread.Sleep(3000);
                        Environment.Exit(0);
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Please enter values in all fields");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
