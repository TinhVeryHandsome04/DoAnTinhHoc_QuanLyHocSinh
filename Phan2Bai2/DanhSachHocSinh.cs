using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan2Bai2
{
    internal class DanhSachHocSinh
    {
        private List<HocSinh> dsHocSinh;
        
        
        public DanhSachHocSinh()
        {
            this.dsHocSinh = new List<HocSinh>();
        }
        public DanhSachHocSinh(List<HocSinh> dsHocSinh)
        {
            this.dsHocSinh = dsHocSinh;
        }
        public List<HocSinh> DSHocSinh
        {
            get { return this.dsHocSinh; }
            set { this.dsHocSinh = value; }
        }
        public bool Them(HocSinh hs)
        {
            if (KiemTraTrung(hs.MaHocSinh))
                return false;
            else 
            {
                dsHocSinh.Add(hs);
                return true;
            }
        }
        public bool Xoa(int viTri)
        {

            dsHocSinh.RemoveAt(viTri);

            return true;
        }
        public bool Sua(HocSinh hs, int viTri)
        {
            for (int i = 0; i < DSHocSinh.Count; i++)
            {
                if (i != viTri && DSHocSinh[i].MaHocSinh == hs.MaHocSinh)
                {
                    return false;
                }
            }
            dsHocSinh[viTri] = hs;
                return true;
            
        }
        public bool HoanTac(Stack<HocSinh> stackDeleteHocSinh)
        {
            if (stackDeleteHocSinh == null) 
                return false;
            foreach (HocSinh h in stackDeleteHocSinh)
            {

                dsHocSinh.Add(h);
            }
            return true;
            
        }
        public bool KiemTraTrung(string ma)
        {
            foreach (HocSinh hs in dsHocSinh)
            {
                if (hs.MaHocSinh.Equals(ma)==true)
                    return true;
            }
            return false;
        }
        //public void SapXep()
        //{
        //    dsHocSinh.Sort(DSHocSinh);
        //}
        public List<HocSinh> HocSinhDiemCaoNhat()
        {
            List<HocSinh> highScoreStudents = new List<HocSinh>();
            if (dsHocSinh.Count == 0)
                return highScoreStudents;

            double maxScore = dsHocSinh.Max(hs => hs.DiemTrungBinh);

            foreach (HocSinh hs in dsHocSinh)
            {
                if (hs.DiemTrungBinh == maxScore)
                {
                    highScoreStudents.Add(hs);
                }
            }
            return highScoreStudents;
        }

        public HocSinh TimKiemTheoMa(string ma)
        {
            HocSinh hocSinhDangtim = new HocSinh();
            hocSinhDangtim = null;
            foreach(HocSinh hs in DSHocSinh)
            {
                if (hs.MaHocSinh.Equals(ma))
                    hocSinhDangtim = hs;
                
            }
            return hocSinhDangtim;
        }
        public List<HocSinh> HocSinhDiemThapNhat()
        {
            List<HocSinh> lowScoreStudents = new List<HocSinh>();
            if (dsHocSinh.Count == 0)
                return lowScoreStudents;
            
            double minScore = dsHocSinh.Min(hs => hs.DiemTrungBinh);

            foreach (HocSinh hs in dsHocSinh)
            {
                if (hs.DiemTrungBinh == minScore)
                {
                    lowScoreStudents.Add(hs);
                }
            }
            return lowScoreStudents;
        }
        public List<HocSinh> HocSinhKhongDat() {
            List<HocSinh> failedStudet = new List<HocSinh>();
            if(dsHocSinh.Count==0)return failedStudet;
            foreach (HocSinh hs in dsHocSinh)
            {
                if(hs.XepLoai.Equals("Không đạt"))
                    failedStudet.Add(hs);
            }
            return failedStudet;
        }
        public List<HocSinh> HocSinhDatYeuCau()
        {
            List<HocSinh> failedStudet = new List<HocSinh>();
            if (dsHocSinh.Count == 0) return failedStudet;
            foreach (HocSinh hs in dsHocSinh)
            {
                if (hs.XepLoai.Equals("Đạt"))
                    failedStudet.Add(hs);
            }
            return failedStudet;
        }
        public List<HocSinh> SearchStudentByClass(string className) { 
            List<HocSinh> classStudent= new List<HocSinh>();
            if(dsHocSinh.Count==0)return classStudent;
            foreach(HocSinh student in dsHocSinh)
            {
                if (student.Lop.Equals(className)) 
                    classStudent.Add(student);  
            }
        
            return classStudent;
        }
    }
}