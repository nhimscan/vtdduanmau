using BUS_QLBanHang;
using DTO_QLBanHang;
using GUI_QLBanHang.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLBanHang
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }
        public static NhanVien nhanVien;

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtemail.Text.Trim().Length == 0 || txtmatkhau.Text.Trim().Length == 0)
            {
                DialogHelper.Alert(" Bạn cân f nhập đầy đủ thông tin đăng nhập");
                return;
            }
            string matkhau = StringHelper.MD5Hash(txtmatkhau.Text);
            frmmain.nhanVien = BUS_NhanVien.DangNhap(txtemail.Text, matkhau);
            if (frmmain.nhanVien != null)
            {
                DialogHelper.Alert(" Đăng nhập thành công");
                this.Close();
            }
            else
            {
                DialogHelper.Alert("Sai thông tin đăng nhập");
            }
        }

        private void btnquenmk_Click(object sender, EventArgs e)
        {

        }

        private void btnquenmk_Click_1(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {

        }
    }
}
