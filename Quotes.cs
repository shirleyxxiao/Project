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
using System.Runtime.InteropServices;
using System.IO;
using ClosedXML.Excel;

namespace IgnitionHacksShirleyXiao
{
    public partial class Quotes : Form
    {
        string path = @"Data Source=SHIRLEY\SHIRLEY;Initial Catalog=Quotes;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        int ID;
        System.Data.DataTable dt;

        //Excel.Application xlap = new Excel.Application();
        public Quotes()
        {
            InitializeComponent();
            con = new SqlConnection(path);
            display();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        public void clear() //clears the textboxes after use 
        {
            txtName.Text = "";
            txtNumber.Text = "";
            txtEmail.Text = "";
            txtCurb.Text = "";
            txtSide.Text = "";
        }
        public void display()
        {
            try
            {
                dt = new System.Data.DataTable();
                con.Open();
                adpt = new SqlDataAdapter("select * from QuotesTable", con);
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Quotes_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (doeDate.Text == "" || txtName.Text == "" || txtEmail.Text == "" || txtNumber.Text == "")
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
                    cmd = new SqlCommand("insert into QuotesTable (Name_, Email, Contact, AddCurb, AddSide, DOE) values ('" + txtName.Text + "','" + txtEmail.Text + "', '" + txtNumber.Text + "', '" + txtCurb.Text + "', '" + txtSide.Text + "', '"+doeDate.Text+"')", con);
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

                if (doeDate.Text == "" || txtName.Text == "" || txtEmail.Text == "" || txtNumber.Text == "")
                {
                    MessageBox.Show("No data selected");
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("update QuotesTable set  Name_='" + txtName.Text + "', Email='" + txtEmail.Text + "', Contact='" + txtNumber.Text + "',  AddCurb='" + txtCurb.Text + "', AddSide='" + txtSide.Text + "', DOE='"+doeDate.Text+"' where ID='" + ID + "' ", con);
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

                if (doeDate.Text == "" || txtName.Text == "" || txtEmail.Text == "" || txtNumber.Text == "")
                {
                    MessageBox.Show("No data selected");
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("delete from QuotesTable where ID='" + ID + "' ", con);
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (doeDate.Text == "" || txtName.Text == "" || txtEmail.Text == "" || txtNumber.Text == "")
            {
                MessageBox.Show("No data selected");
            }
            else
            {
                try
                {
                //    Excel.Workbook xlWorkBook;
                //    Excel.Worksheet xlWorkSheet;
                //    object misValue = System.Reflection.Missing.Value;
                //    xlWorkBook = xlap.Workbooks.Add(misValue);
                //    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from QuotesTable where Name_ like '%" + txtSearch.Text + "%' ", con);
            dt = new System.Data.DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
