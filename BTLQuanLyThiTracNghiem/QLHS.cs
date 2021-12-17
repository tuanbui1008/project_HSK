using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTLQuanLyThiTracNghiem
{
    public partial class QLHS : UserControl
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        public QLHS()
        {
            InitializeComponent();
        }

        //đổ dữ liệu vào form
        private DataTable getHocsinh()
        {
            DataTable dataTable = new DataTable("Hocsinh");
            string procname = "sp_getAllHS";
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
            DataTable hocsinh = getHocsinh();
            dataGridView1.AutoGenerateColumns = false;
            DataView dataView = new DataView(hocsinh);
            dataGridView1.DataSource = dataView;
        }

        private void hienmalop()
        {
            DataTable t = getLop();
            DataView v = new DataView(t);
            v.Sort = "sTenlop DESC";
            cbomalop.DisplayMember = "sTenlop"; //phần hiện trên combox;
            cbomalop.ValueMember = "iMalop"; // giá trj của phần đc trọn;
            cbomalop.DataSource = v;
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
                        DataTable tbl = new DataTable("tblLop");
                        da.Fill(tbl);
                        return tbl;
                    }
                }
                cnn.Close();
            }
        }

        private void QLHS_Load(object sender, EventArgs e)
        {
            resetGridView();
            hienmalop();
        }


        private void txtDiem_TextChanged(object sender, EventArgs e)
        {

        }
        //sửa DL trong form
        private void btnSua_Click(object sender, EventArgs e)
        {
            DataView dataView = (DataView)dataGridView1.DataSource;
            DataRowView dataRowView = dataView[dataGridView1.CurrentRow.Index];
            if (dataRowView["iMaHS"] != DBNull.Value)
            {
                txtMaHS.Text = (string)dataRowView["iMaHS"];
                txtHoten.Text = (string)dataRowView["sHoten"];
                mtxtNgaysinh.Text = ((DateTime)dataRowView["tNgaysinh"]).ToString("dd/MM/yyyy");
                txtDiemcaonhat.Text = dataRowView["sDiemcaonhat"].ToString();
                txtDiachi.Text = (string)dataRowView["sDiachi"];
                rbtnNam.Checked = false;
                rbtnNu.Checked = false;
                if ((bool)dataRowView["sGioitinh"] == false)
                {
                    rbtnNam.Checked = true;
                }
                else if ((bool)dataRowView["sGioitinh"] == true)
                {
                    rbtnNu.Checked = true;
                }
                dataGridView1.Enabled = btnXoa.Enabled = btnTimkiem.Enabled = false;
                btnThem.Text = "Nhận";
                btnThem.Tag = dataRowView["iMaHS"];
            }
        }

        //thêm dữ liệu vào form
        private void btnThem_Click(object sender, EventArgs e)
        {
            string hoten = txtHoten.Text;
            string maHS = txtMaHS.Text;
            string ngaysinh = mtxtNgaysinh.Text;
            string malop = (string)cbomalop.SelectedValue; // giá trị (valueMember) đc chọn
            string diachi = txtDiachi.Text;
            float diem = (float)Convert.ToDouble(txtDiemcaonhat.Text);
            int gioitinh = 0;
            DateTime ns = DateTime.ParseExact(ngaysinh, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            if (rbtnNam.Checked)
            {
                gioitinh = 1;
            }
            else if(rbtnNu.Checked)
            {
                gioitinh = 0;
            }    

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (btnThem.Tag != null)
                    {
                        cmd.CommandText = "proc_update_info_student";
                        cmd.Parameters.AddWithValue("iMaHS", btnThem.Tag);
                    }
                    else if (btnThem.Tag == null)
                    {
                        cmd.CommandText = "proc_insert_HS";
                        cmd.Parameters.AddWithValue("iMaHS", maHS);
                    }
                    /*cmd.Parameters.AddWithValue("@iMaHS", maHS);*/
                    cmd.Parameters.AddWithValue("@sHoten", hoten);
                    cmd.Parameters.AddWithValue("@tNgaysinh", ngaysinh);
                    cmd.Parameters.AddWithValue("@iMalop", malop);
                    cmd.Parameters.AddWithValue("@sGioitinh", gioitinh);
                    cmd.Parameters.AddWithValue("@sDiachi", diachi);
                    cmd.Parameters.AddWithValue("@sDiemcaonhat", diem);
                    int row_afect = cmd.ExecuteNonQuery();
                    if (row_afect > 0)
                    {
                        MessageBox.Show("Thao tác thành công");
                        resetGridView();
                        btnBoqua_Click(sender, e);
                    }

                    else
                    {
                        MessageBox.Show("Thao tác thất bại");
                    }
                }
                connection.Close();
            }
        }

        //chức năng bỏ qua
        private void resetInput()
        {
            txtHoten.Text = "";
            mtxtNgaysinh.Text = "";
            txtMaHS.Text = "";
            txtDiachi.Text = "";
            txtDiemcaonhat.Text = "";

        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            resetInput();
            btnThem.Tag = null;
            dataGridView1.Enabled = btnXoa.Enabled = btnTimkiem.Enabled = true;
            btnThem.Text = "Thêm";
        }

        //Chức năng xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataView dataView = (DataView)dataGridView1.DataSource;
            DataRowView row = dataView[dataGridView1.CurrentRow.Index];
            String id = (string)row["iMaHS"];
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc muốn xóa?" + row["iMaHS"], "Xóa học sinh", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string procname = "proc_xoaHStheoma";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(procname, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaHS", row["iMaHS"]);
                        int row_xoa = 0;
                        try
                        {
                            row_xoa = cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi không thể xóa");
                        }
                        if (row_xoa > 0)
                        {
                            MessageBox.Show("Xóa thành công");
                            resetGridView();
                            resetInput();
                        }
                    }
                    conn.Close();
                }
            }
        }

        //chức năng tìm kiếm
        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string DKloc = "iMaHS <>''";
            if (!String.IsNullOrEmpty(txtHoten.Text))
            {
                DKloc += String.Format("AND sHoten LIKE '%{0}%'", txtHoten.Text);
            }
            if (!String.IsNullOrEmpty(txtDiachi.Text))
            {
                DKloc += String.Format("AND sDiachi LIKE '%{0}%'", txtDiachi.Text);
            }
            DialogResult dialog = MessageBox.Show("Có tìm theo giới tính hay không?", "Tìm kiếm", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                DKloc += String.Format("AND sGioitinh = {0}", !rbtnNam.Checked);
            }
            DataView data = (DataView)dataGridView1.DataSource;
            data.RowFilter = DKloc;
            dataGridView1.DataSource = data;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnBaocao_Click(object sender, EventArgs e)
        {
            FormReportQLHS fm = new FormReportQLHS();
            fm.showr();
            fm.Show();
        }
    }
}
