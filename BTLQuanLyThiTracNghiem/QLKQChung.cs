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
    public partial class QLKQChung : UserControl
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        public QLKQChung()
        {
            InitializeComponent();
        }

        //đổ DL vào form
        private DataTable getKetquachung()
        {
            DataTable dataTable = new DataTable("KQchung");
            string procname = "get_kqchung";
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


        private void hienMon()
        {
            DataTable table = getMon();
            DataView view = new DataView(table);
            view.Sort = "sTenMon DESC";
            cmMon.DisplayMember = "sTenMon";
            cmMon.ValueMember = "iMaMon";
            cmMon.DataSource = view;
        }

        private DataTable getMon()
        {
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("getMon", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tblmon = new DataTable("tblMon");
                        da.Fill(tblmon);
                        return tblmon;
                    }
                }
                cn.Close();
            }
        }
        private void hienmalop()
        {
            DataTable t = getLop();
            DataView v = new DataView(t);
            v.Sort = "sTenlop DESC";
            cmLop.DisplayMember = "sTenlop"; //phần hiện trên combox;
            cmLop.ValueMember = "iMalop"; // giá trj của phần đc trọn;
            cmLop.DataSource = v;
        }

        private DataTable getLop()
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("getLop", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tbllop = new DataTable("tblLop");
                        da.Fill(tbllop);
                        return tbllop;
                    }
                }
                cnn.Close();
            }
        }
        private void resetGridView()
        {
            DataTable ketquachung = getKetquachung();
            dataGridView1.AutoGenerateColumns = false;
            DataView dataView = new DataView(ketquachung);
            dataGridView1.DataSource = dataView;
        }


        private void QLKQChung_Load(object sender, EventArgs e)
        {
            resetGridView();
            hienmalop();
        }

        //tim kiem trong form
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string DKloc = "iMaHS <>''";
            if (!String.IsNullOrEmpty(txtHoten.Text))
            {
                DKloc += String.Format("AND sHoten LIKE '%{0}%'", txtHoten.Text);
            }
            if (!String.IsNullOrEmpty(cmMon.Text))
            {
                DKloc += String.Format("AND sTenMon LIKE '%{0}%'", cmMon.Text);
            }
            if(!String.IsNullOrEmpty(cmLop.Text))
            {
                DKloc += String.Format("AND iMalop LIKE '%{0}%'", cmLop.Text);
            }
            DataView data = (DataView)dataGridView1.DataSource;
            data.RowFilter = DKloc;
            dataGridView1.DataSource = data;
        }

        //Sua DL trong form
        private void button1_Click(object sender, EventArgs e)
        {
            DataView dataView = (DataView)dataGridView1.DataSource;
            DataRowView dataRowView = dataView[dataGridView1.CurrentRow.Index];
            if (dataRowView["iMaHS"] != DBNull.Value)
            {
                txtMaHS.Text = (string)dataRowView["iMaHS"];
                txtHoten.Text = (string)dataRowView["sHoten"];
                txtDiem.Text = dataRowView["iDiem"].ToString();
                cmMon.Text = (string)dataRowView["sTenMon"];
                cmLop.Text = (string)dataRowView["iMalop"];
                dataGridView1.Enabled = btnTimkiem.Enabled = false;
                btnNhan.Tag = dataRowView["iMaHS"];
                btnNhan.Text = "Nhận";
            }
        }

        //Chuc nang bo qua trong form

        private void resetInput()
        {
            txtHoten.Text = "";
            txtMaHS.Text = "";
            txtDiem.Text = "";
            cmMon.Text = "";
            cmLop.Text = "";

        }
        private void btnBoqua_Click(object sender, EventArgs e)
        {
            resetInput();
            btnNhan.Tag = null;
            dataGridView1.Enabled = btnTimkiem.Enabled = true;
        }

        private void btnInKQ_Click(object sender, EventArgs e)
        {
            FormReportQLKQC fm = new FormReportQLKQC();
            fm.showKQC();
            fm.Show();
        }
    }
}
