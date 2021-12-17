using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTLQuanLyThiTracNghiem
{
   
    public partial class Login : Form
    {

        private static string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        public Login()
        {
            InitializeComponent();
        }

        //đổ dữ liệu vào form
        private DataTable getLogin()
        {
            DataTable dataTable = new DataTable("login");
            string procname = "get_login";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(procname, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            return dataTable;
        }

        private void resetGridView()
        {
            DataTable login = getLogin();
            dataGridView1.AutoGenerateColumns = false;
            DataView dataView = new DataView(login);
            dataGridView1.DataSource = dataView;
        }

    }
}
