
namespace BTLQuanLyThiTracNghiem
{
    partial class MainQuanLy
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnQLHS = new System.Windows.Forms.Button();
            this.btnQLKQchung = new System.Windows.Forms.Button();
            this.btnQlcauhoi = new System.Windows.Forms.Button();
            this.btnQlthi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1096, 53);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnQLHS);
            this.flowLayoutPanel1.Controls.Add(this.btnQLKQchung);
            this.flowLayoutPanel1.Controls.Add(this.btnQlcauhoi);
            this.flowLayoutPanel1.Controls.Add(this.btnQlthi);
            this.flowLayoutPanel1.Controls.Add(this.btnThoat);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1047, 45);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnQLHS
            // 
            this.btnQLHS.Enabled = false;
            this.btnQLHS.Location = new System.Drawing.Point(4, 4);
            this.btnQLHS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQLHS.Name = "btnQLHS";
            this.btnQLHS.Size = new System.Drawing.Size(207, 42);
            this.btnQLHS.TabIndex = 0;
            this.btnQLHS.Text = "QL Học sinh";
            this.btnQLHS.UseVisualStyleBackColor = true;
            this.btnQLHS.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnQLKQchung
            // 
            this.btnQLKQchung.Location = new System.Drawing.Point(219, 4);
            this.btnQLKQchung.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQLKQchung.Name = "btnQLKQchung";
            this.btnQLKQchung.Size = new System.Drawing.Size(187, 42);
            this.btnQLKQchung.TabIndex = 1;
            this.btnQLKQchung.Text = "QL kết quả chung";
            this.btnQLKQchung.UseVisualStyleBackColor = true;
            this.btnQLKQchung.Click += new System.EventHandler(this.btnQLKQchung_Click);
            // 
            // btnQlcauhoi
            // 
            this.btnQlcauhoi.Location = new System.Drawing.Point(414, 4);
            this.btnQlcauhoi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQlcauhoi.Name = "btnQlcauhoi";
            this.btnQlcauhoi.Size = new System.Drawing.Size(201, 42);
            this.btnQlcauhoi.TabIndex = 2;
            this.btnQlcauhoi.Text = "QL câu hỏi";
            this.btnQlcauhoi.UseVisualStyleBackColor = true;
            this.btnQlcauhoi.Click += new System.EventHandler(this.btnQlcauhoi_Click);
            // 
            // btnQlthi
            // 
            this.btnQlthi.Location = new System.Drawing.Point(623, 4);
            this.btnQlthi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQlthi.Name = "btnQlthi";
            this.btnQlthi.Size = new System.Drawing.Size(199, 42);
            this.btnQlthi.TabIndex = 3;
            this.btnQlthi.Text = "QL thi";
            this.btnQlthi.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(830, 4);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(205, 42);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "Trở về";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 69);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 526);
            this.panel1.TabIndex = 1;
            // 
            // MainQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 609);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainQuanLy";
            this.Text = "MainQuanLy";
            this.Load += new System.EventHandler(this.MainQuanLy_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnQLHS;
        private System.Windows.Forms.Button btnQLKQchung;
        private System.Windows.Forms.Button btnQlcauhoi;
        private System.Windows.Forms.Button btnQlthi;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Panel panel1;
    }
}