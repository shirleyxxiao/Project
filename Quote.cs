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
using ClosedXML.Excel;

namespace IgnitionHacksShirleyXiao
{
    public partial class Quote : Form
    {
        string path = @"Data Source=SHIRLEY\SHIRLEY;Initial Catalog=Quotes;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        int ID;
        System.Data.DataTable dt;

        public Quote()
        {
            InitializeComponent();
            con = new SqlConnection(path);
        }

        private void Quote_Load(object sender, EventArgs e)
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

        private void btnExport_Click(object sender, EventArgs e) //in progress, potentially 
        {
            foreach(DataGridViewColumn column in dataGridView1.Columns)
            {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                dt.Rows.Add();
                foreach(DataGridViewCell cell in row.Cells)
                {
                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                }
            }

            string folderPath = "C:\\C# Projects\\IgnitionHacksShirleyXiao";
            if (!Directory.Exists(folderPath))
            {

            }
            using(XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Quotes");

                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    string cellRange = string.Format("A{0}:C{0}", i + 1);
                    if (i % 2 != 0)
                    {
                        wb.Worksheet(1).Cells(cellRange).Style.Fill.BackgroundColor = XLColor.Amethyst;
                    }
                    else
                    {
                        wb.Worksheet(1).Cell(cellRange).Style.Fill.BackgroundColor = XLColor.Auburn;
                    }
                }

                wb.Worksheet(1).Columns().AdjustToContents();
                wb.SaveAs(folderPath + "QuotesExport.xlsx");
            }
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
                    cmd = new SqlCommand("insert into QuotesTable (Name_, Email, Contact, AddCurb, AddSide, DOE) values ('" + txtName.Text + "','" + txtEmail.Text + "', '" + txtNumber.Text + "', '" + txtCurb.Text + "', '" + txtSide.Text + "', '" + doeDate.Text + "')", con);
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
                    cmd = new SqlCommand("update QuotesTable set  Name_='" + txtName.Text + "', Email='" + txtEmail.Text + "', Contact='" + txtNumber.Text + "',  AddCurb='" + txtCurb.Text + "', AddSide='" + txtSide.Text + "', DOE='" + doeDate.Text + "' where ID='" + ID + "' ", con);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from QuotesTable where Name_ like '%" + txtSearch.Text + "%' ", con);
            dt = new System.Data.DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtCurb.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSide.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            doeDate.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

        }
    }
}
