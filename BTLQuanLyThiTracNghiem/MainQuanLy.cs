using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTLQuanLyThiTracNghiem
{
    public partial class MainQuanLy : Form
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        private static string quyen = "admin";
        public MainQuanLy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new QLHS());
        }

        private void btnQLKQchung_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new QLKQChung());
        }

        private void MainQuanLy_Load(object sender, EventArgs e)
        {
            if(quyen == "admin")
            {
                btnQLHS.Enabled = true;
            }    
        }

        private void btnQlcauhoi_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new FormQuestsion());
        }
    }
}
