using DAL_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QLBanHang
{
    public static class BUS_NhanVien
    {
        private static DAL_INhanVien dalNhanVien;
        static BUS_NhanVien()
        {
            dalNhanVien = new DAL_NhanVien();
        }
        public static List<NhanVien> GetAll()
        {
            return dalNhanVien.GetAll();
        }
        public static NhanVien Get(string maNV)
        {
            return dalNhanVien.Get(maNV);
        }
        public static int Insert(string email, string tenNV, string diaChi, byte vaiTro, byte tinhTrang, string matKhau)
        {
            return dalNhanVien.Insert(email,tenNV, diaChi, vaiTro, tinhTrang, matKhau);
        }

        public static int Update (NhanVien nhanVien)
        {
            return dalNhanVien.Update(nhanVien);
        }
        public static int Delete(NhanVien nhanVien)
        {
            return dalNhanVien.Delete(nhanVien);
        }
        public static NhanVien DangNhap(string email, string password)
        {
            return dalNhanVien.DangNhap(email, password);
        }


        public static bool DaTonTaiEmail (string email)
        {
            email = email.ToLower().Trim();
            NhanVien nv = dalNhanVien.GetByEmail(email);
            return nv != null;
        }
        public static List<NhanVien> Search (string key)
        {
            return dalNhanVien.Search(key);
        }  
        public static int UpdataPassword(string email, string oldPass, string newPass)
        {
            return dalNhanVien.UpdatePassword(email, oldPass, newPass);
        }
        public static int CreatePassword(string email, string newPass)
        {
            return dalNhanVien.CreatePassword(email, newPass);
        }
    }
}
