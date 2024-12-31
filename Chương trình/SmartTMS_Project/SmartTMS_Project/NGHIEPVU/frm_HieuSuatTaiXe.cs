using BusinessLayer;
using BusinessLayer.NGHIEPVU;
using DataLayer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SmartTMS_Project.REPORT;
using System.IO;
using DevExpress.XtraReports.Native.Templates;

namespace SmartTMS_Project.NGHIEPVU
{
    public partial class frm_HieuSuatTaiXe : DevExpress.XtraEditors.XtraForm
    {
        public frm_HieuSuatTaiXe()
        {
            InitializeComponent();
        }
        DonHang _donHang;
        TaiXe _taiXe;
        NhomLichSuHanhTrinh _nhomLichSuHanhTrinh;
        LichSuHanhTrinh _lichSuHanhTrinh;
        private void dtThoiGianDen_EditValueChanged(object sender, EventArgs e)
        {
            btnChotLuong.Enabled = true;
            btnNhacNho.Enabled = true;
            btnXuatBaoCao.Enabled = true;
            gcDanhSach.DataSource = CreateTemporaryDataSource();
            gvDanhSach.OptionsBehavior.Editable = false;
        }
        private double CalculateLuongDon(string maTX, DateTime ngayTu, DateTime ngayDen)
        {
            Entities db = Entities.CreateEntities();
            // Lấy danh sách lịch sử hành trình theo tài xế và thời gian
            var lichSuHanhTrinh = _lichSuHanhTrinh.getAllThoiGian(ngayTu, ngayDen).Where(x => x.MaTX == maTX);

            double luongDon = 0;

            foreach (var item in lichSuHanhTrinh)
            {
                // Lấy giá trị đơn hàng từ bảng DONHANG dựa trên MaDH
                var donHang = db.DONHANG.FirstOrDefault(dh => dh.MaDH == item.MaDH);
                if (donHang == null || donHang.TongTien == null) continue;

                // Lấy tổng số trạm từ hàm getTram_Time
                int tongSoTram = _lichSuHanhTrinh.getTram_Time(item.MaDH);
                if (tongSoTram == 0) continue;

                // Chuyển đổi TongTien sang decimal để đảm bảo tính toán chính xác
                decimal tongTien = Convert.ToDecimal(donHang.TongTien);

                // Tính lương đơn
                luongDon += (double)((tongTien / tongSoTram) * 0.05m);
            }

            return luongDon;
        }

        private DataTable CreateTemporaryDataSource()
        {
            // Tạo bảng tạm
            DataTable dataSource = new DataTable();
            // Thêm các cột cần thiết
            dataSource.Columns.Add("MaTX", typeof(string));
            dataSource.Columns.Add("HoTen", typeof(string));
            dataSource.Columns.Add("MaDonVi", typeof(string));
            dataSource.Columns.Add("TrangThai", typeof(string));
            dataSource.Columns.Add("LuongCoBan", typeof(decimal));
            dataSource.Columns.Add("SoDonGiao", typeof(int));
            dataSource.Columns.Add("SoDonTre", typeof(int));
            dataSource.Columns.Add("SoDonNhanTre", typeof(int));
            dataSource.Columns.Add("LuongDon", typeof(decimal));
            dataSource.Columns.Add("KhauTru", typeof(decimal));
            dataSource.Columns.Add("ThucNhan", typeof(decimal));
            dataSource.Columns.Add("Email", typeof(string));

            var danhSachTaiXe = _taiXe.getAll();
            DateTime thoiGianTu = DateTime.Parse(dtThoiGianTu.EditValue.ToString());
            DateTime thoiGianDen = DateTime.Parse(dtThoiGianDen.EditValue.ToString());
            var lichSuHanhTrinh = _lichSuHanhTrinh.getAllThoiGian(thoiGianTu, thoiGianDen);
            var lichSuTreDonGiao = _lichSuHanhTrinh.getAllTreDonGiao_Time(thoiGianTu, thoiGianDen);
            var lichSuNhanTre = _lichSuHanhTrinh.getAllTreDonNhan_Time(thoiGianTu, thoiGianDen);

            foreach (var taiXe in danhSachTaiXe)
            {
                int soDonGiao = lichSuHanhTrinh.Count(x => x.MaTX == taiXe.MaTX);
                int soDonTre = lichSuTreDonGiao.Count(x => x.MaTX == taiXe.MaTX);
                int soDonNhanTre = lichSuNhanTre.Count(x => x.MaTX == taiXe.MaTX);

                // Làm tròn lương đơn đến 2 chữ số thập phân
                decimal luongDon = Math.Round((decimal)CalculateLuongDon(taiXe.MaTX, thoiGianTu, thoiGianDen), 2);

                // Làm tròn tỷ lệ trễ đến 2 chữ số thập phân
                decimal tiLeTreGiao = soDonGiao > 0 ? Math.Round((decimal)soDonTre / soDonGiao, 2) : 0;
                decimal tiLeTreNhan = soDonGiao > 0 ? Math.Round((decimal)soDonNhanTre / soDonGiao, 2) : 0;

                decimal khauTruTreGiao = 0;
                if (tiLeTreGiao > 0.5m) khauTruTreGiao = 0.8m;
                else if (tiLeTreGiao > 0.4m) khauTruTreGiao = 0.6m;
                else if (tiLeTreGiao > 0.3m) khauTruTreGiao = 0.5m;
                else if (tiLeTreGiao > 0.2m) khauTruTreGiao = 0.25m;
                else if (tiLeTreGiao > 0.1m) khauTruTreGiao = 0.15m;

                decimal khauTruTreNhan = 0;
                if (tiLeTreNhan > 0.5m) khauTruTreNhan = 0.7m;
                else if (tiLeTreNhan > 0.4m) khauTruTreNhan = 0.5m;
                else if (tiLeTreNhan > 0.3m) khauTruTreNhan = 0.4m;
                else if (tiLeTreNhan > 0.2m) khauTruTreNhan = 0.15m;
                else if (tiLeTreNhan > 0.1m) khauTruTreNhan = 0.1m;

                decimal tongKhauTru = Math.Min(khauTruTreGiao + khauTruTreNhan, 0.9m);

                // Làm tròn lương cơ bản đến 2 chữ số thập phân
                decimal luongCoBan = Math.Round((decimal)(taiXe.LuongCoBan ?? 0), 2);

                // Làm tròn thực nhận đến 2 chữ số thập phân
                decimal thucNhan = Math.Round(luongCoBan + (luongDon * (1 - tongKhauTru)), 2);

                // Làm tròn số tiền khấu trừ đến 2 chữ số thập phân
                decimal khauTruValue = Math.Round(tongKhauTru * luongDon, 2);

                dataSource.Rows.Add(
                    taiXe.MaTX,
                    taiXe.HoTen,
                    taiXe.MaDV,
                    taiXe.TrangThai,
                    luongCoBan,
                    soDonGiao,
                    soDonTre,
                    soDonNhanTre,
                    luongDon,
                    khauTruValue,
                    thucNhan,
                    taiXe.Email
                );
            }
            return dataSource;
        }

        private void frm_HieuSuatTaiXe_Load(object sender, EventArgs e)
        {
            _donHang = new DonHang();
            _nhomLichSuHanhTrinh = new NhomLichSuHanhTrinh();
            _lichSuHanhTrinh = new LichSuHanhTrinh();
            _taiXe = new TaiXe();

        }

        private async void btnChotLuong_Click(object sender, EventArgs e)
        {
            // Hiển thị Panel Waiting
            panelWaiting.Visible = true;
            progressBarWaiting.Value = 0;
            lblStatus.Text = "Đang chuẩn bị gửi email...";

            

            int successCount = 0; // Đếm số email gửi thành công
            int failureCount = 0; // Đếm số email gửi thất bại

            try
            {
                DataTable dataSource = CreateTemporaryDataSource();
                int totalRows = dataSource.Rows.Count;
                progressBarWaiting.Maximum = totalRows; // Thiết lập giá trị tối đa cho ProgressBar

                int currentProgress = 0;

                await Task.Run(() =>
                {
                    foreach (DataRow row in dataSource.Rows)
                    {
                        // Tăng tiến trình
                        currentProgress++;

                        // Lấy thông tin tài xế
                        string email = row["Email"].ToString();
                        string hoTen = row["HoTen"].ToString();
                        string thucNhan = ((decimal)row["ThucNhan"]).ToString("N0") + " ₫";

                        // Tạo báo cáo cho tài xế
                        string pdfPath = GenerateReportForDriver(row);

                        if (pdfPath != null)
                        {
                            try
                            {
                                // Gửi email
                                string subject = $"Bảng lương cá nhân tháng {DateTime.Now:MM/yyyy}";
                                string body = $"<p>Kính gửi {hoTen},</p><p>Đây là bảng lương của bạn:</p><p><strong>Thực nhận: {thucNhan}</strong></p><p>Trân trọng,</p><p>Phòng Kế Toán</p>";

                                SendEmailWithAttachment(email, subject, body, pdfPath);

                                // Nếu gửi email thành công
                                successCount++;
                            }
                            catch
                            {
                                // Nếu gửi email thất bại
                                failureCount++;
                            }
                        }
                        else
                        {
                            // Nếu không tạo được báo cáo, cũng tính là thất bại
                            failureCount++;
                        }

                        // Cập nhật ProgressBar và trạng thái
                        this.Invoke(new Action(() =>
                        {
                            progressBarWaiting.Value = currentProgress;
                            lblStatus.Text = $"Đang gửi email: {currentProgress}/{totalRows}";
                        }));
                        return;
                    }
                });

                MessageBox.Show($"Chốt lương hoàn tất!\n\n- Số email gửi thành công: {successCount}\n- Số email gửi thất bại: {failureCount}",
                                "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                panelWaiting.Visible = false; // Ẩn Panel sau khi hoàn tất
                
            }
        }






        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ CreateTemporaryDataSource
            DataTable data = CreateTemporaryDataSource();

            // Kiểm tra dữ liệu
            if (data == null || data.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Mở form báo cáo
            frm_BaoCao reportForm = new frm_BaoCao(data);
            reportForm.ShowDialog();
        }
        private string GenerateReportForDriver(DataRow driverRow)
        {
            try
            {
                // Tạo báo cáo
                BangLuongCaNhan report = new BangLuongCaNhan();

                // Tạo DataTable chỉ chứa 1 dòng dữ liệu của tài xế
                DataTable driverData = driverRow.Table.Clone(); // Clone cấu trúc bảng gốc
                driverData.ImportRow(driverRow); // Nhập dữ liệu của tài xế

                // Gắn dữ liệu vào báo cáo
                report.SetDataSource(driverData);
                report.CreateDocument(); // Tạo tài liệu cho báo cáo

                // Xuất báo cáo ra file PDF
                string filePath = Path.Combine(Path.GetTempPath(), $"{driverRow["HoTen"]}_BangLuong.pdf");
                report.ExportToPdf(filePath);

                return filePath; // Trả về đường dẫn file PDF
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        private void SendEmailWithAttachment(string recipientEmail, string subject, string body, string attachmentPath)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("2121005132@sv.ufm.edu.vn.com", "Phòng quản lý nhân sự SmartTMS"); // Email của bạn
                    mail.To.Add(recipientEmail); // Email tài xế
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;

                    // Đính kèm file PDF
                    if (!string.IsNullOrEmpty(attachmentPath))
                    {
                        mail.Attachments.Add(new Attachment(attachmentPath));
                    }

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)) // SMTP server của Gmail
                    {
                        smtp.Credentials = new NetworkCredential("2121005132@sv.ufm.edu.vn", "Tvy39278"); // Thông tin đăng nhập
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi email: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SendEmail(string recipientEmail, string subject, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("2121005132@sv.ufm.edu.vn.com","Phòng quản lý vận hành SmartTMS");// Email của bạn
                mail.To.Add(recipientEmail);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)) // SMTP server của Gmail
                {
                    smtp.Credentials = new NetworkCredential("2121005132@sv.ufm.edu.vn", "Tvy39278");  // Thông tin đăng nhập
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        private async void btnNhacNho_Click(object sender, EventArgs e)
        {
            int successCount = 0; // Đếm số email gửi thành công
            int failureCount = 0; // Đếm số email gửi thất bại

            try
            {
                // Lấy dữ liệu từ CreateTemporaryDataSource
                DataTable dataSource = CreateTemporaryDataSource();

                // Lọc tài xế có số đơn trễ trên 5 (bao gồm giao trễ và nhận trễ)
                var rowsWithHighDelays = dataSource.AsEnumerable()
                                                   .Where(row => (int)row["SoDonTre"] > 5 || (int)row["SoDonNhanTre"] > 5);

                if (!rowsWithHighDelays.Any())
                {
                    MessageBox.Show("Không có tài xế nào cần nhắc nhở.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var row in rowsWithHighDelays)
                {
                    string email = row["Email"].ToString();
                    string hoTen = row["HoTen"].ToString();
                    int soDonTre = (int)row["SoDonTre"];
                    int soDonNhanTre = (int)row["SoDonNhanTre"];

                    try
                    {
                        // Soạn nội dung email
                        string subject = $"Nhắc nhở về số lượng đơn trễ";
                        string body = $"<p>Kính gửi {hoTen},</p>" +
                                      $"<p>Chúng tôi nhận thấy bạn có số lượng đơn trễ đáng kể:</p>" +
                                      $"<ul>" +
                                      $"<li>Số đơn giao trễ: {soDonTre}</li>" +
                                      $"<li>Số đơn nhận trễ: {soDonNhanTre}</li>" +
                                      $"</ul>" +
                                      $"<p>Vui lòng cải thiện hiệu suất làm việc trong thời gian tới.</p>" +
                                      $"<p>Trân trọng,</p>" +
                                      $"<p>Phòng Quản Lý Tài Xế</p>";

                        // Gửi email
                        await Task.Run(() => SendEmail(email, subject, body));

                        // Gửi thành công
                        successCount++;
                    }
                    catch
                    {
                        // Gửi thất bại
                        failureCount++;
                    }
                }

                // Hiển thị thông báo kết quả
                MessageBox.Show($"Đã gửi nhắc nhở:\n\n- Thành công: {successCount}\n- Thất bại: {failureCount}",
                                "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gcDanhSach_Click(object sender, EventArgs e)
        {
            gcDonHang.DataSource = _lichSuHanhTrinh.getAllThoiGian(DateTime.Parse(dtThoiGianTu.EditValue.ToString())
            , DateTime.Parse(dtThoiGianDen.EditValue.ToString()));
            gvDonHang.OptionsBehavior.Editable = false;
            if (gvDanhSach.RowCount > 0)
            {
                
                txtMaTX.Text = gvDanhSach.GetFocusedRowCellValue("MaTX").ToString();
                txtHoTen.Text = gvDanhSach.GetFocusedRowCellValue("HoTen").ToString();
                txtLuongCoBan.EditValue = gvDanhSach.GetFocusedRowCellValue("LuongCoBan");
                txtLuongHoaHongDon.Text = gvDanhSach.GetFocusedRowCellValue("LuongDon").ToString();
                txtMucKhauTru.Text = gvDanhSach.GetFocusedRowCellValue("KhauTru").ToString();
                txtThucNhan.Text = gvDanhSach.GetFocusedRowCellValue("ThucNhan").ToString();
                txtTongDonGiao.EditValue = gvDanhSach.GetFocusedRowCellValue("SoDonGiao");
                txtTongDonGiaoTre.Text = gvDanhSach.GetFocusedRowCellValue("SoDonTre").ToString();
                txtTongDonNhanTre.Text = gvDanhSach.GetFocusedRowCellValue("SoDonNhanTre").ToString();
            }
        }
    }
}