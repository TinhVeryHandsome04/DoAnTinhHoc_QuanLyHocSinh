using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan2Bai2
{
    public partial class Form1 : Form
    {

        private DanhSachHocSinh dsHocSinh = new DanhSachHocSinh();
        
        private Stack<HocSinh> stack = new Stack<HocSinh>();
        private int index = -1;
        HocSinh hocSinh;
        string data;
        int i;
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
            dgvDanhSachHocSinh.CellFormatting += dgvDanhSachHocSinh_CellFormatting;
        }
        
        public bool checkControl()
        {
            try
            {
                if (txtMaHocSinh.Text == "")
                {
                    MessageBox.Show("Chưa nhập mã học sinh !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (txtTenHocSinh.Text == "")
                {
                    MessageBox.Show("Chưa nhập tên học sinh !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (txtDiemToan.Text == "")
                {
                    MessageBox.Show("Chưa nhập điểm toán !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (txtDiemVan.Text == "")
                {
                    MessageBox.Show("Chưa nhập điểm văn !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (txtDiemNangKhieu.Text == "")
                {
                    MessageBox.Show("Chưa nhập điểm năng khiếu !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (txtLop.Text == "") {
                    MessageBox.Show("Chưa nhập lớp !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (cbbQueQuan.Text == "") {
                    MessageBox.Show("Chưa chọn quê quán !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                
                
            }catch (Exception ex) {
                MessageBox.Show(ex.Message);}
            return true;
        }
        public bool checkPoint(double diemToan,double diemVan, double diemNangKhieu)
        {
            
                if (diemToan < 0 || diemToan > 10)
                {                   
                    return false;
                }
                if (diemVan < 0 || diemVan > 10)
                {                   
                    return false;
                }

                if (diemNangKhieu < 0 || diemNangKhieu > 10)
                {                   
                    return false;
                }
            return true;
        }
        private void DocTapTin()
        {
            try
            {
                using (StreamReader fR = new StreamReader("QuanLyHocSinh.txt"))
                {
                    string line;
                    while ((line = fR.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        DateTime ngaySinh;
                        bool validDate = DateTime.TryParseExact(
                            parts[2], "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh
                        );
                        if (!validDate)
                        {
                            MessageBox.Show("Định dạng ngày không hợp lệ: " + parts[2], "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue; 
                        }

                        HocSinh hs = new HocSinh
                        {
                            MaHocSinh = parts[0],
                            TenHocSinh = parts[1],
                            NgaySinh = ngaySinh,
                            Lop = parts[3],
                            GioiTinh = parts[4],
                            QueQuan = parts[5],
                            DiemToan = Convert.ToDouble(parts[6], CultureInfo.InvariantCulture),
                            DiemVan = Convert.ToDouble(parts[7], CultureInfo.InvariantCulture),
                            DiemNangKhieu = Convert.ToDouble(parts[8], CultureInfo.InvariantCulture)
                        };
                        dsHocSinh.Them(hs);
                    }
                }
                HienThiHocSinh(dgvDanhSachHocSinh, dsHocSinh.DSHocSinh);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void WriteAllToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("QuanLyHocSinh.txt"))
                {
                    foreach (HocSinh hs in dsHocSinh.DSHocSinh)
                    {

                        string line = string.Format(CultureInfo.InvariantCulture,
                            "{0},{1},{2:yyyy-MM-dd},{3},{4},{5},{6:0.0},{7:0.0},{8:0.0}",
                            hs.MaHocSinh,
                            hs.TenHocSinh,
                            hs.NgaySinh,
                            hs.Lop,
                            hs.GioiTinh,
                            hs.QueQuan,
                            hs.DiemToan,
                            hs.DiemVan,
                            hs.DiemNangKhieu);

                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi ghi vào tệp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AppendToFile(HocSinh hs)
        {
            try
            {
                
                using (StreamWriter writer = new StreamWriter("QuanLyHocSinh.txt", true))
                {
                    string line = string.Format(CultureInfo.InvariantCulture, "{0},{1},{2:yyyy-MM-dd},{3},{4},{5},{6:0.0},{7:0.0},{8:0.0}",
                        hs.MaHocSinh, hs.TenHocSinh, hs.NgaySinh, hs.Lop, hs.GioiTinh, hs.QueQuan, hs.DiemToan, hs.DiemVan, hs.DiemNangKhieu);

                    writer.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi ghi vào tệp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string maHocSinh, tenHocSinh, queQuan, lop, gioiTinh;
            double diemToan, diemVan,diemNangKhieu;
            DateTime ngaySinh;
            try
            {
                maHocSinh = txtMaHocSinh.Text;
                tenHocSinh = txtTenHocSinh.Text;
                diemToan = double.Parse(txtDiemToan.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
                diemVan = double.Parse(txtDiemVan.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
                diemNangKhieu = double.Parse(txtDiemNangKhieu.Text.Replace(',', '.'), CultureInfo.InvariantCulture);

                queQuan = cbbQueQuan.SelectedItem.ToString();
                lop = txtLop.Text;
                ngaySinh = dtpNgaySinh.Value;
                gioiTinh = "";
                if (radNam.Checked)
                    gioiTinh = "Nam";
                else 
                    gioiTinh = "Nữ"; 
            
                if (checkPoint(diemToan, diemVan, diemNangKhieu) == false)
                {
                    MessageBox.Show("Điểm phải lớn hơn 0 và bé hơn 10","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                HocSinh hs = new HocSinh(maHocSinh, tenHocSinh, diemToan, diemVan, diemNangKhieu,queQuan,lop,gioiTinh,ngaySinh);
                bool check=checkControl();
                if (check)
                {
                    if (dsHocSinh.Them(hs))
                    {
                        dsHocSinh.Them(hs);
                        AppendToFile(hs);
                        MessageBox.Show("Thêm thành công !", "Thông báo !", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Mã bị trùng !", "Warning !", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
                
                HienThiHocSinh(dgvDanhSachHocSinh, dsHocSinh.DSHocSinh);                
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);            
            }    
        }

       

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            if (index < 0 || index >= dsHocSinh.DSHocSinh.Count)
            {
                MessageBox.Show("Chọn vị trí cần xóa", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult ketQua = MessageBox.Show("Bạn chắc chắn xóa không ? ", "Thông báo !", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (ketQua == DialogResult.Yes)
            {
                stack.Push(dsHocSinh.DSHocSinh[index]);
                dsHocSinh.Xoa(index);
                             
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK);
                
            }
            HienThiHocSinh(dgvDanhSachHocSinh, dsHocSinh.DSHocSinh);
            WriteAllToFile();
        }
        
        private void btnSua_Click(object sender, EventArgs e)
        {

            string maHocSinh, tenHocSinh, queQuan,lop,gioiTinh ;
            double diemToan, diemVan, diemNangKhieu;
            DateTime ngaySinh;
            if (index < 0 || index >= dsHocSinh.DSHocSinh.Count)
            {
                MessageBox.Show("Chọn vị trí cần sửa","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            try
            {          
                
                maHocSinh = txtMaHocSinh.Text;               
                tenHocSinh = txtTenHocSinh.Text;              
                diemToan = double.Parse(txtDiemToan.Text);                              
                diemVan = Convert.ToDouble(txtDiemVan.Text);                             
                diemNangKhieu = Convert.ToDouble(txtDiemNangKhieu.Text);
                queQuan = cbbQueQuan.SelectedItem.ToString();
                lop = txtLop.Text;
                ngaySinh = dtpNgaySinh.Value;
                gioiTinh = "";
                if (radNam.Checked)
                    gioiTinh = "Nam";
                else { gioiTinh = "Nữ"; }
                if (checkPoint(diemToan, diemVan, diemNangKhieu) == false)
                {
                    MessageBox.Show("Điểm phải lớn hơn 0 và bé hơn 10", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                HocSinh hs = new HocSinh(maHocSinh, tenHocSinh, diemToan, diemVan, diemNangKhieu, queQuan, lop, gioiTinh, ngaySinh);
                if (checkControl())
                {
                    //stack.Push(dsHocSinh.DSHocSinh[index]);
                    if (dsHocSinh.Sua(hs, index))
                    {
                        AppendToFile(hs);
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    else MessageBox.Show("Không sửa được !", "Thông báo !", MessageBoxButtons.OK);

                }
                HienThiHocSinh(dgvDanhSachHocSinh, dsHocSinh.DSHocSinh);
                WriteAllToFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvDanhSachHocSinh.AutoGenerateColumns = false;
            dgvDanhSachHocSinh.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);
            dgvDanhSachHocSinh.DefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            //dgvDanhSachHocSinh.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvDanhSachHocSinh_CellFormatting);
            //dgvDanhSachHocSinh.CellFormatting += new DataGridViewCellFormattingEventHandler(dgvDanhSachHocSinh_CellFormatting);
            

            DocTapTin();
            HienThiHocSinh(dgvDanhSachHocSinh, dsHocSinh.DSHocSinh);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<HocSinh> hs = new List<HocSinh>();
            if (radDiemCaoNhat.Checked)
            {
                hs = dsHocSinh.HocSinhDiemCaoNhat();
            }
            else if (radDiemThapNhat.Checked)
            {
                hs = dsHocSinh.HocSinhDiemThapNhat();
            }
            else if (rdbHocSinhDat.Checked)
            {
                hs = dsHocSinh.HocSinhDatYeuCau();
            }
            else if (rdbHocSinhKhongDat.Checked)
            {
                hs = dsHocSinh.HocSinhKhongDat();
            }
            else if (rdbSearchClass.Checked)
            {                             
                    hs = dsHocSinh.SearchStudentByClass(cbbClass.SelectedItem.ToString());
                
            }
            else if (rdbTimKiemTheoMa.Checked)
            {
                if (txtNhapMa.Text == "")
                {
                    MessageBox.Show("Chưa nhập mã !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dsHocSinh.TimKiemTheoMa(txtNhapMa.Text) == null)
                {
                    MessageBox.Show("Không tìm thấy học sinh !!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                hs.Add(dsHocSinh.TimKiemTheoMa(txtNhapMa.Text));
            }               
            HienThiHocSinh(dgvDanhSachHocSinh, hs);
        }

        private void btnDanhSachDayDu_Click(object sender, EventArgs e)
        {
            HienThiHocSinh(dgvDanhSachHocSinh, dsHocSinh.DSHocSinh);
        }

        private void HienThiHocSinh(DataGridView dgv, List<HocSinh> ds)
        {
            dgv.DataSource = null;

            dgv.DataSource = ds.ToList();

        }


        private void dgvDanhSachHocSinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            try
            {
                if (index >= 0)
                {
                    HocSinh hs = dsHocSinh.DSHocSinh[index];
                    txtMaHocSinh.Text = hs.MaHocSinh;
                    txtTenHocSinh.Text = hs.TenHocSinh;
                    txtLop.Text = hs.Lop;
                    dtpNgaySinh.Value = hs.NgaySinh;
                    cbbQueQuan.Text = hs.QueQuan;
                    if (hs.GioiTinh == "Nam")
                        radNam.Checked = true;
                    else if (hs.GioiTinh == "Nữ")
                        radNu.Checked = true;
                    txtDiemToan.Text = hs.DiemToan.ToString();
                    txtDiemVan.Text = hs.DiemVan.ToString();
                    txtDiemNangKhieu.Text = hs.DiemNangKhieu.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgvDanhSachHocSinh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDanhSachHocSinh.Columns[e.ColumnIndex].Name == "KetQua" && e.Value != null)
            {
                string ketQua = e.Value.ToString();
                if (ketQua == "Đạt")
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else
                    e.CellStyle.ForeColor = Color.Red;
            }          
        }

        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            if (stack.Count() == 0) 
                return;
            else
            {
                dsHocSinh.HoanTac(stack);
                AppendToFile(stack.Pop());
                HienThiHocSinh(dgvDanhSachHocSinh, dsHocSinh.DSHocSinh);
                WriteAllToFile();
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = MessageBox.Show("Bạn chắc chắc muốn thoát ?", "Thông báo !", MessageBoxButtons.OKCancel);
            if (DialogResult != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
