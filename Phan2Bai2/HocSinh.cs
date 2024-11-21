using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Phan2Bai2
{
    internal class HocSinh
    {
        private string maHocSinh;
        private string tenHocSinh;
        private double diemToan;
        private double diemVan;
        private double diemNangKhieu;
        private double diemTrungBinh;
        private string xepLoai;
        private string queQuan;
        private string gioiTinh;
        private string lop;
        private DateTime ngaySinh;


        public HocSinh(string maHocSinh, string tenHocSinh, double diemToan, double diemVan, double diemNangKhieu,string queQuan,string lop, string gioiTinh,DateTime ngaySinh)
        {
            this.maHocSinh = maHocSinh;
            this.tenHocSinh = tenHocSinh;
            this.diemToan = diemToan;
            this.diemVan = diemVan;
            this.diemNangKhieu = diemNangKhieu;
            this.queQuan = queQuan;
            this.lop = lop;
            this.gioiTinh = gioiTinh;
            this.ngaySinh = ngaySinh;
            
        }
        public HocSinh()
        {
            this.maHocSinh = "";
            this.tenHocSinh = "";
            this.diemToan = 0.0;
            this.diemVan = 0.0;
            this.diemNangKhieu = 0.0;
            this.queQuan = "";
            this.gioiTinh = "";
            this.ngaySinh = DateTime.Now;
            this.lop = "";
        }
        public string MaHocSinh 
        { 
            get { return this.maHocSinh; } 
            set { this.maHocSinh = value; } 
        }
        public string TenHocSinh
        {
            get { return this.tenHocSinh; }
            set { this.tenHocSinh = value; }
        }
        public double DiemToan
        {
            get { return this.diemToan; }
            set { this.diemToan = value; }
        }
        public double DiemVan
        {
            get { return this.diemVan; }
            set { this.diemVan = value; }
        }
        public double DiemNangKhieu
        {
            get { return this.diemNangKhieu; }
            set { this.diemNangKhieu = value; }
        }
        public string QueQuan { get => queQuan; set => queQuan = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string Lop { get => lop; set => lop = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public double DiemTrungBinh
        {
            get { return TinhTrungBinh(); }          
        }
        public double TinhTrungBinh()
        {
            return Math.Round((this.diemToan + this.diemVan + diemNangKhieu) / 3,1);
        }
        public string XepLoai
        {
            get { return Loai(); }           
        }

        

        public string Loai()
        {
            string loai="";

            if (this.DiemTrungBinh >= 5 && this.DiemToan >= 5 && this.DiemVan >= 5 && this.DiemNangKhieu >= 5)
            {
                loai = "Đạt";
            }
            else
            {
                loai = "Không đạt";
            }
                return loai;
        }
    }
}
