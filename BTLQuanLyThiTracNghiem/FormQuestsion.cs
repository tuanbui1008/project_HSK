using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLQuanLyThiTracNghiem
{
    public partial class FormQuestsion : UserControl
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        public FormQuestsion()
        {
            InitializeComponent();
        }

        public void showr()
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //string path = string.Format("{0}\\reportQLHS.rpt", Application.StartupPath);
            //rpt.Load(path);

            CrystalDecisions.Shared.TableLogOnInfo logon = new CrystalDecisions.Shared.TableLogOnInfo();
            logon.ConnectionInfo.ServerName = ".\\SQLEXPRESS";
            logon.ConnectionInfo.DatabaseName = "QLThiTracNghiem";
            logon.ConnectionInfo.UserID = "sa";
            logon.ConnectionInfo.Password = "123";

            //foreach (CrystalDecisions.CrystalReports.Engine.Table tb in rpt.Database.Tables)
            //{
            //    tb.ApplyLogOnInfo(logon);
            //}

            //rpt.SummaryInfo.ReportTitle = "Báo Cáo Học Sinh";
            //crystalReportViewer1.ReportSource = rpt;
            //crystalReportViewer1.Refresh();
        }

        private void showCbbSubject()
        {
            DataTable t = getSubject();
            DataView v = new DataView(t);
            v.Sort = "iMaMon DESC";
            cbbSubject.DisplayMember = "sTenMon"; //phần hiện trên combox;
            cbbSubject.ValueMember = "sTenMon"; // giá trj của phần đc trọn;
            cbbSubject.DataSource = v;
        }
        private DataTable getSubject()
        {
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("prc_get_subject", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable tbl = new DataTable("tblMon");
                        da.Fill(tbl);
                        return tbl;
                    }
                }
                cnn.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string codeQS = txtCode.Text;
            string QSA = txtQA.Text;
            string QSB = txtQB.Text;
            string QSC = txtQC.Text;
            string QSD = txtQD.Text;
            string resultQS = "";
            if (rbA.Checked)
            {
                resultQS += (rbA.Text);
            }
            else if (rbB.Checked)
            {
                resultQS += (rbB.Text);
            }
            else if (rbC.Checked)
            {
                resultQS += (rbC.Text);
            }
            else if (rbD.Checked)
            {
                resultQS += (rbD.Text);
            }
            string content = contentQS.Text;
            string subjectName = (string)cbbSubject.SelectedValue;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.CommandText = "proc_insert_cauhoi";
                    if (btnAdd.Tag != null)
                    {
                        cmd.CommandText = "proc_update_question";
                        cmd.Parameters.AddWithValue("iMacauhoi", btnAdd.Tag);
                    }
                    else if (btnAdd.Tag == null)
                    {
                        cmd.CommandText = "proc_insert_cauhoi";
                        cmd.Parameters.AddWithValue("iMacauhoi", codeQS);
                    }
                    /*cmd.Parameters.AddWithValue("@iMaHS", maHS);*/
                    //cmd.Parameters.AddWithValue("@iMacauhoi", codeQS);
                    cmd.Parameters.AddWithValue("@sNoidung", content);
                    cmd.Parameters.AddWithValue("@sCauA", QSA);
                    cmd.Parameters.AddWithValue("@sCauB", QSB);
                    cmd.Parameters.AddWithValue("@sCauC", QSC);
                    cmd.Parameters.AddWithValue("@sCauD", QSD);
                    cmd.Parameters.AddWithValue("@sDapan", resultQS);
                    cmd.Parameters.AddWithValue("@sTenMon", subjectName);
                    int row_afect = cmd.ExecuteNonQuery();
                    if (row_afect > 0)
                    {
                        MessageBox.Show("Thao tác thành công");
                        resetGridView();
                        //btnBoqua_Click(sender, e);
                        resetForm();
                    }

                    else
                    {
                        MessageBox.Show("Thao tác thất bại");
                    }
                }
                connection.Close();
            }
        }

        private void resetGridView()
        {
            DataTable question = getDataQuestion();
            dataQuestion.AutoGenerateColumns = false;
            DataView dataView = new DataView(question);
            dataQuestion.DataSource = dataView;
        }

        private DataTable getDataQuestion()
        {
            DataTable dataTable = new DataTable("Cauhoi");
            string procname = "pro_get_question";
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

        private void resetForm()
        {
            txtCode.Clear();
            txtQA.Clear();
            txtQB.Clear();
            txtQC.Clear();
            txtQD.Clear();
            contentQS.Clear();
        }

        private void FormQuestsion_Load(object sender, EventArgs e)
        {
            resetGridView();
            showCbbSubject();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataView dataView = (DataView)dataQuestion.DataSource;
            DataRowView dataRowView = dataView[dataQuestion.CurrentRow.Index];
            if (dataRowView["iMacauhoi"] != DBNull.Value)
            {
                txtCode.Text = (string)dataRowView["iMacauhoi"];
                txtQA.Text = (string)dataRowView["sCauA"];
                txtQB.Text = (string)dataRowView["sCauB"];
                txtQC.Text = (string)dataRowView["sCauC"];
                txtQD.Text = (string)dataRowView["sCauD"];
                contentQS.Text = (string)dataRowView["sNoidung"];
                if((string)dataRowView["sDapAn"].ToString() == "Câu A")
                {
                    rbA.Checked = true;
                }
                else if((string)dataRowView["sDapAn"].ToString() == "Câu B")
                {
                    rbB.Checked = true; 
                }
                else if((string)dataRowView["sDapAn"].ToString() == "Câu C")
                {
                    rbC.Checked = true;
                }
                else if((string)dataRowView["sDapAn"].ToString() == "Câu D")
                {
                    rbD.Checked = true;
                }
                
                btnAdd.Text = "Save";
                btnAdd.Tag = dataRowView["iMacauhoi"];
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            resetForm();
        }
    }
}
