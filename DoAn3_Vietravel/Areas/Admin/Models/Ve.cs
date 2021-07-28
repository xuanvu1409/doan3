using DoAn3_Vietravel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DoAn3_Vietravel.Areas.Admin.Models
{
    public class Ve
    {
        public string IDVe { get; set; }
        public string TenVe { get; set; }
        public string KieuVe { get; set; }
        public string NgayKhoiHanh { get; set; }
        public string NgayKetThuc { get; set; }
        public string NoiTapTrung { get; set; }
        public int ThoiGian { get; set; }
        public string LichTrinh { get; set; }
        public int Gia { get; set; }
        public int SoCho { get; set; }
        public string TrangThai { get; set; }
        public string HinhAnh { get; set; }
        public string HinhThucVanChuyen { get; set; }
        public string IDKhachSan { get; set; }
        public string IDNhanVien { get; set; }
        public string LuuY { get; set; }
        public string GhiChu { get; set; }
        public int PhuThu { get; set; }
        public string IDLoaiVe { get; set; }
    }

    public class VeModel
    {
        // khởi tạo một đối tượng thuộc lớp dataconnection
        DataConnection db = new DataConnection();

        //lấy tất cả nhân viên trong bảng vé

        public List<Ve> LayDanhSach()
        {
            DataTable dt = db.LayDuLieu("Select * from Ve");
            List<Ve> li = new List<Ve>();
            foreach (DataRow dr in dt.Rows)
            {
                Ve ve = new Ve();
                ve.IDVe = dr[0].ToString();
                ve.TenVe = dr[1].ToString();
                ve.KieuVe = dr[2].ToString();
                ve.NgayKhoiHanh = dr[3].ToString();
                ve.NgayKetThuc = dr[4].ToString();
                ve.NoiTapTrung = dr[5].ToString();
                ve.ThoiGian = int.Parse(dr[6].ToString());
                ve.LichTrinh = dr[7].ToString();
                ve.Gia = int.Parse(dr[8].ToString());
                ve.SoCho = int.Parse(dr[9].ToString());
                ve.TrangThai = dr[10].ToString();
                ve.HinhAnh = dr[11].ToString();
                ve.HinhThucVanChuyen = dr[12].ToString();
                ve.IDKhachSan = dr[13].ToString();
                ve.IDNhanVien = dr[14].ToString();
                ve.LuuY = dr[15].ToString();
                ve.GhiChu = dr[16].ToString();
                ve.PhuThu = int.Parse(dr[17].ToString());
                ve.IDLoaiVe = dr[18].ToString();
                li.Add(ve);
            }
            return li;
        }

        public Ve Lay1Ve(string id)
        {
            DataTable dt = db.LayDuLieu("Select * from Ve where IDVe ='" + id + "'");

            {
                Ve ve = new Ve();
                ve.IDVe = dt.Rows[0][0].ToString();
                ve.TenVe = dt.Rows[0][1].ToString();
                ve.KieuVe = dt.Rows[0][2].ToString();
                ve.NgayKhoiHanh = dt.Rows[0][3].ToString();
                ve.NgayKetThuc = dt.Rows[0][4].ToString();
                ve.NoiTapTrung = dt.Rows[0][5].ToString();
                ve.ThoiGian = int.Parse(dt.Rows[0][6].ToString());
                ve.LichTrinh = dt.Rows[0][7].ToString();
                ve.Gia = int.Parse(dt.Rows[0][8].ToString());
                ve.SoCho = int.Parse(dt.Rows[0][9].ToString());
                ve.TrangThai = dt.Rows[0][10].ToString();
                ve.HinhAnh = dt.Rows[0][11].ToString();
                ve.HinhThucVanChuyen = dt.Rows[0][12].ToString();
                ve.IDKhachSan = dt.Rows[0][13].ToString();
                ve.IDNhanVien = dt.Rows[0][14].ToString();
                ve.LuuY = dt.Rows[0][15].ToString();
                ve.GhiChu = dt.Rows[0][16].ToString();
                ve.PhuThu = int.Parse(dt.Rows[0][17].ToString());
                ve.IDLoaiVe = dt.Rows[0][18].ToString();
                return ve;
            }
        }

        public void Xoa1Ve(string id)
        {
            db.GhiDuLieu("DELETE FROM Ve WHERE IDVe ='" + id + "'");
        }
        public void Them1Ve(Ve v)
        {
            string sql = "INSERT INTO Ve(TenVe,KieuVe, NgayKhoiHanh, NgayKetThuc, NoiTapTrung, ThoiGian, LichTrinh, Gia, SoCho, TrangThai, HinhAnh, HinhThucVanChuyen, IDKhachSan, IDNhanVien, LuuY, GhiChu, PhuThu, IDLoaiVe) VALUES(N'" + v.TenVe + "', N'" + v.KieuVe + "', '" + LayNgay(v.NgayKhoiHanh) + "', '" + LayNgay(v.NgayKetThuc) + "', N'" + v.NoiTapTrung + "', '" + v.ThoiGian + "', N'" + v.LichTrinh + "', '" + v.Gia + "', '" + v.SoCho + "', N'" + v.TrangThai + "', '" + v.HinhAnh + "', N'" + v.HinhThucVanChuyen + "',  '" + v.IDKhachSan + "', '" + v.IDNhanVien + "', N'" + v.LuuY + "', N'" + v.GhiChu + "', '" + v.PhuThu + "', '" + v.IDLoaiVe + "')";
            db.GhiDuLieu(sql);
        }

        public void Sua1Ve(Ve v)
        {
            string sql = "UPDATE Ve SET TenVe = N'" + v.TenVe + "', KieuVe = N'" + v.KieuVe + "', NgayKhoiHanh = '" + LayNgay(v.NgayKhoiHanh) + "', NgayKetThuc = '" + LayNgay(v.NgayKetThuc) + "', NoiTapTrung = N'" + v.NoiTapTrung + "', ThoiGian = '" + v.ThoiGian + "' , LichTrinh = N'" + v.LichTrinh + "' , Gia = '" + v.Gia + "', SoCho = '" + v.SoCho + "', TrangThai = N'" + v.TrangThai + "', HinhAnh = '" + v.HinhAnh + "', HinhThucVanChuyen = N'" + v.HinhThucVanChuyen + "', IDNhanVien = '" + v.IDNhanVien + "', LuuY = N'" + v.LuuY + "', GhiChu = N'" + v.GhiChu + "', PhuThu = '" + v.PhuThu + "', IDLoaiVe = '" + v.IDLoaiVe + "' WHERE IDVe = '" + v.IDVe + "'";

            db.GhiDuLieu(sql);
        }

        public string LayNgay(string t)
        {
            DateTime dt = Convert.ToDateTime(t);
            string kq = string.Format("{0}/{1}/{2}", dt.Year, dt.Month, dt.Day);
            return kq;
        }

        public void capNhatSoCho(string IDVe, int sc)
        {
            string sql = "UPDATE Ve SET SoCho = SoCho - " + sc + " WHERE IDVe = '" + IDVe + "'";

            db.GhiDuLieu(sql);
        }

        public List<Ve> DSVeCungLoai(string id)
        {
            DataTable dt = db.LayDuLieu("Select * from Ve where IDLoaiVe = '" + id + "' AND TrangThai = 'true'");
            List<Ve> li = new List<Ve>();
            foreach (DataRow dr in dt.Rows)
            {
                Ve ve = new Ve();
                ve.IDVe = dr[0].ToString();
                ve.TenVe = dr[1].ToString();
                ve.KieuVe = dr[2].ToString();
                ve.NgayKhoiHanh = dr[3].ToString();
                ve.NgayKetThuc = dr[4].ToString();
                ve.NoiTapTrung = dr[5].ToString();
                ve.ThoiGian = int.Parse(dr[6].ToString());
                ve.LichTrinh = dr[7].ToString();
                ve.Gia = int.Parse(dr[8].ToString());
                ve.SoCho = int.Parse(dr[9].ToString());
                ve.TrangThai = dr[10].ToString();
                ve.HinhAnh = dr[11].ToString();
                ve.HinhThucVanChuyen = dr[12].ToString();
                ve.IDKhachSan = dr[13].ToString();
                ve.IDNhanVien = dr[14].ToString();
                ve.LuuY = dr[15].ToString();
                ve.GhiChu = dr[16].ToString();
                ve.PhuThu = int.Parse(dr[17].ToString());
                ve.IDLoaiVe = dr[18].ToString();
                li.Add(ve);
            }
            return li;
        }
    }
}