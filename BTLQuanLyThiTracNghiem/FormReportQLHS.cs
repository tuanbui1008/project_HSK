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
    public partial class FormReportQLHS : Form
    {
        public FormReportQLHS()
        {
            InitializeComponent();
        }
        public void showr()
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string path = string.Format("{0}\\reportQLHS.rpt", Application.StartupPath);
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

            rpt.SummaryInfo.ReportTitle = "Báo Cáo Học Sinh";
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
        }

        public void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            showr();
        }
    }
}
