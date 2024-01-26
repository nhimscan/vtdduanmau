using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public interface DAL_INhanVien
    {
        List<NhanVien> GetAll();
        NhanVien Get(String maNV);
        int Insert(string email, string tenNV, string diachi, byte vaiTro, byte tinhtrang, string matKhau);
        int Insert(NhanVien nhanVien);
        int Update(NhanVien nhanvien);
        int Delete(NhanVien nhanvien);
        NhanVien DangNhap(string email, string matkhau);
        NhanVien GetByEmail(string email);
        List<NhanVien> Search(string key);
        int UpdatePassword(String email, string oldPass, string newPass);
        int CreatePassword(string email, string newPass);
    }
}
