using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BTLQuanLyThiTracNghiem
{
    public partial class FormReportQLKQC : Form
    {
        public FormReportQLKQC()
        {
            InitializeComponent();
        }

        public void showKQC()
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string path = string.Format("{0}\\reportQLKQchung.rpt", Application.StartupPath);
            rpt.Load(path);

            CrystalDecisions.Shared.TableLogOnInfo logon = new CrystalDecisions.Shared.TableLogOnInfo();
            logon.ConnectionInfo.ServerName = ".\\SQLEXPRESS";
            logon.ConnectionInfo.DatabaseName = "QLThiTracNghiem";
            logon.ConnectionInfo.UserID = "sa";
            logon.ConnectionInfo.Password = "123";

            foreach (CrystalDecisions.CrystalReports.Engine.Table tb in rpt.Database.Tables)
            {
                tb.ApplyLogOnInfo(logon);
            }

            rpt.SummaryInfo.ReportTitle = "Báo cáo kết quả chung";
            crystalReportViewer2.ReportSource = rpt;
            crystalReportViewer2.Refresh();
        }

        public void FormReportQLKQC_Load(object sender, EventArgs e)
        {
            showKQC();
        }
    }
}
