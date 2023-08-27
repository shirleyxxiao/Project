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
using Microsoft.VisualBasic;


namespace IgnitionHacksShirleyXiao
{
    public partial class InventoryAssets : Form
    {
        string path = @"Data Source=SHIRLEY\SHIRLEY;Initial Catalog=Inventory;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        int ID;
        System.Data.DataTable dt;
        public InventoryAssets()
        {
            InitializeComponent();
            con = new SqlConnection(path);
        }

        private void InventoryAssets_Load(object sender, EventArgs e)
        {

        }

        public void clear() //clears the textboxes after use 
        {
            txtID.Text = "";
            txtItem.Text = "";
            txtNumber.Text = "";
            
        }
        public void display()
        {
            try
            {
                dt = new System.Data.DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select * from InvTable", con);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" || txtItem.Text == "" || txtNumber.Text == "")
            {
                MessageBox.Show("Please fill in the blanks");
            }
            else
            {
                try
                {
                    dt = new System.Data.DataTable();
                    con.Open();
                    //open the connection between the server and the windows form
                    // if both of the additions are empty, then execute the non query
                    // if any of the additions are empty, then do the one by one
                    cmd = new SqlCommand("insert into InvTable (Identification, Item, Number) values ('" + txtID.Text + "','" + txtItem.Text + "', '" + txtNumber.Text + "')", con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("Your data has been saved succesfully");
                    clear();
                    display();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtID.Text == "" || txtItem.Text == "" || txtNumber.Text == "")
                {
                    MessageBox.Show("Please fill in the blanks");
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("update InvTable set  Identification='" + txtID.Text + "', Item='" + txtItem.Text + "', Number='" + txtNumber.Text + "' where ID='" + ID + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Your data has been updated succesfully");
                    clear();
                    display();//presents the most updated information 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtID.Text == "" || txtItem.Text == "" || txtNumber.Text == "")
                {
                    MessageBox.Show("Please fill in the blanks");
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("delete from InvTable where ID='" + ID + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Your record has been deleted");
                    clear();
                    display();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from InvTable where Item like '%" + txtItem.Text + "%' ", con);
            dt = new System.Data.DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtItem.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            
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
