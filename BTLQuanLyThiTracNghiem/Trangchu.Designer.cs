
namespace BTLQuanLyThiTracNghiem
{
    partial class Trangchu
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnDnAD = new System.Windows.Forms.Button();
            this.btnBaiThi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mời bạn chọn chức năng sử dụng";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnDnAD
            // 
            this.btnDnAD.Location = new System.Drawing.Point(122, 120);
            this.btnDnAD.Name = "btnDnAD";
            this.btnDnAD.Size = new System.Drawing.Size(120, 23);
            this.btnDnAD.TabIndex = 2;
            this.btnDnAD.Text = "Đăng nhập Admin";
            this.btnDnAD.UseVisualStyleBackColor = true;
            this.btnDnAD.Click += new System.EventHandler(this.btnDnAD_Click);
            // 
            // Trangchu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 197);
            this.Controls.Add(this.btnBaiThi);
            this.Controls.Add(this.btnDnAD);
            this.Controls.Add(this.label1);
            this.Name = "Trangchu";
            this.Text = "TaiKhoanAD";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDnAD;
        private System.Windows.Forms.Button btnBaiThi;
    }
}