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
using System.Data.SqlClient;



namespace IgnitionHacksShirleyXiao
{
    public partial class ViewQuotes : Form
    {
        string path = @"Data Source=SHIRLEY\SHIRLEY;Initial Catalog=Quotes;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        int ID;
        System.Data.DataTable dt;
        public ViewQuotes()
        {
            InitializeComponent();
            con = new SqlConnection(path);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from QuotesTable where Name_ like '%" + txtSearch.Text + "%' ", con);
            dt = new System.Data.DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearchE_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from QuotesTable where Email like '%" + txtSearchE.Text + "%' ", con);
            dt = new System.Data.DataTable();
            adpt.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
