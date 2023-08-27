using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IgnitionHacksShirleyXiao
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();  
            Quote q = new Quote();
            q.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            InventoryAssets IA = new InventoryAssets();
            IA.Show();
        }

        private void btnVQ_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewQuotes vq = new ViewQuotes();
            vq.Show();
        }

        private void btnVIA_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewInventory vi = new ViewInventory();
            vi.Show();
        }
    }
}
