using System.Drawing.Drawing2D;
using System.Drawing;
using System.Data.SqlClient;

namespace IgnitionHacksShirleyXiao
{
    public partial class Home : Form
    {
        public Home()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //LOGIN button
        {
            btnLogin.FlatAppearance.BorderColor = Color.Gray;
            //btnLogin.BackColor = Color.MediumAquamarine;
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Register register = new Register();
            //register.ShowDialog();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            //btnLogin.BackColor = Color.BlueViolet;
            //this.Hide();
            //Login login = new Login();
            //login.ShowDialog();
        }

        private void btnLogin_Click_2(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.BlueViolet;
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.ShowDialog();
        }
    }
}