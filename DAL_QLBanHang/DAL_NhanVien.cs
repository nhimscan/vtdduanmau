using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public class DAL_NhanVien : DAL_INhanVien
    {
        public int CreatePassword(string email, string newPass)
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                NhanVien nv = db.NhanViens.FirstOrDefault(n => n.Email == email);
                if (nv == null) return 0;
                nv.MatKhau = newPass;
                return db.SaveChanges();
            }
        }

        public NhanVien DangNhap(string email, string matKhau)
        {
            if (email == "" || matKhau == "") return null;
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                return db.NhanViens.FirstOrDefault(n => n.Email == email && n.MatKhau == matKhau && n.TinhTrang == 1);
            }
        }

        public int Delete(NhanVien nhanvien)
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                db.NhanViens.Attach(nhanvien);
                if (nhanvien.Hangs.Any() || nhanvien.Khaches.Any())
                    return 0;// nếu nhân viên đã có hàng hoắc có khách hàng thì không cho xoá
                db.NhanViens.Remove(nhanvien);
                return db.SaveChanges();
            }
        }

        public NhanVien Get(string maNV)
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                return db.NhanViens.Find(maNV);
            }
        }

        public List<NhanVien> GetAll()
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                return db.NhanViens.ToList();
            }
        }

        public NhanVien GetByEmail(string email)
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                return db.NhanViens.FirstOrDefault(n => n.Email == email);
            }
        }

        public int Insert(string email, string tenNV, string diaChi, byte vaiTro, byte tinhTrang, string matKhau)
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                try
                {
                    db.sp_InsertNhanVien(email, tenNV, diaChi, vaiTro, tinhTrang, matKhau);
                    return 1;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public int Insert(NhanVien nhanVien)
        {
            throw new NotImplementedException();
        }


        public List<NhanVien> Search(string key)
        {
            if (String.IsNullOrEmpty(key))
                return GetAll();
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                return db.NhanViens.Where(n => n.MaNV == key || n.TenNV.Contains(key)).ToList();
            }
        }

        public int Update(NhanVien nhanvien)
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                db.NhanViens.Attach(nhanvien);
                db.Entry(nhanvien).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public int UpdatePassword(string email, string oldPass, string newPass)
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                NhanVien nv = db.NhanViens.FirstOrDefault(n => n.Email == email);
                if (nv == null) return 0;
                nv.MatKhau = newPass;
                return db.SaveChanges();
            }
        }
    }
}
