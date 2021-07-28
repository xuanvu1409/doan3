using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn3_Vietravel.Models
{
    public class DatVe
    {
        public string IDKhachHang { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string LoaiKhach { get; set; }
        public string NgaySinh { get; set; }
        public int SoLuong { get; set; }
        public int PhuThu { get; set; }
        public int DonGia { get; set; }
        public int tinhTien()
        {
            return SoLuong * DonGia;
        }

    }
}