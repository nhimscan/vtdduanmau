using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;
namespace DAL_QLBanHang
{
    public interface DAL_IThongKe
    {
        List<DTO_ThongKeTonkho> ThongKeTonkho();
        List<DTO_ThongKeNhaphang> ThongKeNhaphang();
    }
}
