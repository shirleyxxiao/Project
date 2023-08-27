namespace IgnitionHacksShirleyXiao
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btnLogin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnEstimates = new System.Windows.Forms.Panel();
            this.btnVQ = new System.Windows.Forms.Button();
            this.btnVIA = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(35, 80);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(146, 57);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Customer Quotes";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(35, 191);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 57);
            this.button1.TabIndex = 5;
            this.button1.Text = "Inventory Assets";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEstimates
            // 
            this.btnEstimates.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEstimates.BackgroundImage")));
            this.btnEstimates.Location = new System.Drawing.Point(238, 111);
            this.btnEstimates.Name = "btnEstimates";
            this.btnEstimates.Size = new System.Drawing.Size(479, 338);
            this.btnEstimates.TabIndex = 6;
            // 
            // btnVQ
            // 
            this.btnVQ.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnVQ.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVQ.Location = new System.Drawing.Point(35, 283);
            this.btnVQ.Name = "btnVQ";
            this.btnVQ.Size = new System.Drawing.Size(146, 57);
            this.btnVQ.TabIndex = 7;
            this.btnVQ.Text = "View Quotes";
            this.btnVQ.UseVisualStyleBackColor = false;
            this.btnVQ.Click += new System.EventHandler(this.btnVQ_Click);
            // 
            // btnVIA
            // 
            this.btnVIA.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnVIA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVIA.Location = new System.Drawing.Point(35, 382);
            this.btnVIA.Name = "btnVIA";
            this.btnVIA.Size = new System.Drawing.Size(146, 57);
            this.btnVIA.TabIndex = 8;
            this.btnVIA.Text = "View Inventory Assets";
            this.btnVIA.UseVisualStyleBackColor = false;
            this.btnVIA.Click += new System.EventHandler(this.btnVIA_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnHome.Location = new System.Drawing.Point(12, 12);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(124, 26);
            this.btnHome.TabIndex = 11;
            this.btnHome.Text = "Logout";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Tomato;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExit.Location = new System.Drawing.Point(697, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(20, 26);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "x";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 500);
            this.Controls.Add(this.btnVQ);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnVIA);
            this.Controls.Add(this.btnEstimates);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnLogin;
        private Button button1;
        private Panel btnEstimates;
        private Button btnVQ;
        private Button btnVIA;
        private Button btnHome;
        private Button btnExit;
    }
}