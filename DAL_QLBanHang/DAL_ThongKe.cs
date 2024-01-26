using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public class DAL_ThongKe : DAL_IThongKe
    {
        public List<DTO_ThongKeNhaphang> ThongKeNhaphang()
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                var list = (from n in db.NhanViens
                            select new DTO_ThongKeNhaphang
                            {
                                MaNV = n.MaNV,
                                TenNV = n.TenNV,
                                SoLuonHang = n.Hangs.Count
                            }).ToList();
                return list;
            }
        }

        public List<DTO_ThongKeTonkho> ThongKeTonkho()
        {
            using (QLBanHangEntities db = new QLBanHangEntities())
            {
                var list = (from h in db.Hangs
                            group h by h.TenHang into g
                            select new DTO_ThongKeTonkho
                            {
                                TenHang = g.Key,
                                SoLuongTon = g.Sum(h => h.SoLuong)
                            }).ToList();
                return list;
            }
        }
    }
}
