using BusinessLayer;
using BusinessLayer.DANHMUC;
using BusinessLayer.NGHIEPVU;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.DataProcessing.InMemoryDataProcessor.AddSurrogateOperationAlgorithm;


namespace SmartTMS_Project.NGHIEPVU
{
    public partial class frm_TheoDoiLoTrinh : DevExpress.XtraEditors.XtraForm
    {
        public frm_TheoDoiLoTrinh()
        {
            InitializeComponent();
        }
        ChiTietKeHoachVanChuyen _chiTietKeHoachVanChuyen;
        DonHang _donHang;
        LichSuHanhTrinh _LichSuHanTrinh;
        NhomLichSuHanhTrinh _NhomLichSuHanhTrinh;
        DiemTrungChuyen _diemTrungChuyen;
        NhanVien _nhanVien;
        TaiXe _taiXe;
        PhuongTien _phuongTien;
        string _maDH;
        string _maNKH;
        private void frm_TheoDoiLoTrinh_Load(object sender, EventArgs e)
        {
            _chiTietKeHoachVanChuyen = new ChiTietKeHoachVanChuyen();
            _donHang = new DonHang();
            _LichSuHanTrinh = new LichSuHanhTrinh();
            _NhomLichSuHanhTrinh = new NhomLichSuHanhTrinh();
            _diemTrungChuyen = new DiemTrungChuyen();
            _nhanVien = new NhanVien();
            _taiXe = new TaiXe();
            _phuongTien = new PhuongTien();
            LoadDonHang();
            timer1.Start();


        }
        void LoadDonHang()
        {
            // Lấy danh sách chính để hiển thị
            var danhSach = _NhomLichSuHanhTrinh.getAll();
            gcDanhSach.DataSource = danhSach;
            gvDanhSach.OptionsBehavior.Editable = false;

            // Lấy danh sách các mã đơn hàng bị trễ giao
            var maTreDonGiao = new HashSet<string>(_LichSuHanTrinh.getAllTreDonGiao().Select(x => x.MaDH).ToList());

            // Lấy danh sách các mã đơn hàng chưa nhận
            var maChuaNhanDon = new HashSet<string>(_LichSuHanTrinh.getAllTreDonNhan_Time().Select(x => x.MaDH).ToList());

            // Tô màu các dòng
            gvDanhSach.RowStyle += (sender, e) =>
            {
                var gridView = sender as DevExpress.XtraGrid.Views.Grid.GridView;
                if (gridView == null) return;

                // Lấy dữ liệu hàng hiện tại
                var currentRow = gridView.GetRow(e.RowHandle) as NHOMLICHSUHANHTRINH;
                if (currentRow == null) return;

                // Kiểm tra và tô màu
                if (maTreDonGiao.Contains(currentRow.MaDH))
                {
                    e.Appearance.BackColor = System.Drawing.Color.Red; // Tô đỏ
                    e.Appearance.ForeColor = System.Drawing.Color.White;
                }
                else if (maChuaNhanDon.Contains(currentRow.MaDH))
                {
                    e.Appearance.BackColor = System.Drawing.Color.Yellow; // Tô vàng
                    e.Appearance.ForeColor = System.Drawing.Color.Black;
                }
            };
        }


        private void CapNhatStepProgressBar(string maDH)
        {
            // Lấy danh sách kế hoạch vận chuyển
            var danhSachKeHoach = _LichSuHanTrinh.getAll(maDH);

            // Xóa các bước cũ
            spbHanhTrinh.Items.Clear();

            // Thêm các bước mới từ danh sách
            foreach (var keHoach in danhSachKeHoach)
            {
                var item = new StepProgressBarItem
                {
                    ContentBlock1 = { Caption = keHoach.DiaDiem },
                    ContentBlock2 = { Caption = $"Thời gian: {keHoach.ThoiGian}" }
                };

                

                spbHanhTrinh.Items.Add(item);
            }

            // Cập nhật trạng thái cho từng bước
            for (int i = 0; i < danhSachKeHoach.Count; i++)
            {
                var keHoach = danhSachKeHoach[i];

                if ((bool)keHoach.DaQuaTram)
                {
                    spbHanhTrinh.Items[i].State = StepProgressBarItemState.Active;
                }
                else
                {
                    spbHanhTrinh.Items[i].State = StepProgressBarItemState.Inactive;
                }
            }

            // Tăng kích thước Icon Active
            spbHanhTrinh.ItemOptions.Indicator.ActiveStateImageOptions.SvgImageSize = new System.Drawing.Size(80, 80);
            spbHanhTrinh.ItemOptions.Indicator.InactiveStateImageOptions.SvgImageSize = new System.Drawing.Size(60, 60);
        }

        


        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            _maDH = gvDanhSach.GetFocusedRowCellValue("MaDH").ToString();
            if (_LichSuHanTrinh.getAll(_maDH).Count == 0)
            {
                MessageBox.Show("Đơn hàng chưa có kế hoạch vận chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                txtMaDH.Text = gvDanhSach.GetFocusedRowCellValue("MaDH").ToString();
                txtNhanVien.Text = _nhanVien.getItem(gvDanhSach.GetFocusedRowCellValue("MaNV").ToString()).HoTen;
                txtTaiXe.Text = _taiXe.getItem(gvDanhSach.GetFocusedRowCellValue("MaTX").ToString()).HoTen;
                txtPhuongTien.Text = _phuongTien.getItem(gvDanhSach.GetFocusedRowCellValue("MaPT").ToString()).BienSo;
                CapNhatStepProgressBar(_maDH);
                txtTramHienTai.Text = _diemTrungChuyen.getItem(_LichSuHanTrinh.getItemHienTai(_maDH).DiaDiem).TenDTC;
                if (_LichSuHanTrinh.getItemKeTiep(_maDH)?.DiaDiem == null)
                {
                    txtTramKeTiep.Text = "Đã đến trạm cuối";
                }
                else
                {
                    txtTramKeTiep.Text = _diemTrungChuyen.getItem(_LichSuHanTrinh.getItemKeTiep(_maDH).DiaDiem).TenDTC;
                }
                txtThoiGianDuKien.Text = _LichSuHanTrinh.getItemHienTai(_maDH).ThoiGianHoanThanh.ToString();
                txtThoiGianDatDon.Text = _donHang.getItem(_maDH).NgayDat.ToString();
                txtThoiGianHoanThanh.Text = _donHang.getItem(_maDH).NgayHoanThanh.ToString();
                string trangThai = gvDanhSach.GetFocusedRowCellValue("TrangThai").ToString();
                // Reset trạng thái của tất cả các bước về mặc định
                foreach (StepProgressBarItem item in spbTrangThai.Items)
                {
                    item.State = StepProgressBarItemState.Inactive;
                }

                spbTrangThai.Appearances.CommonActiveColor = Color.Gray; // Màu mặc định
                switch (trangThai)
                {
                    case "Mới":
                        spMoi.State = StepProgressBarItemState.Active;
                        spbTrangThai.ItemOptions.Indicator.ActiveStateImageOptions.SvgImage = svgImageCollection2[0];
                        spbTrangThai.Appearances.CommonActiveColor = Color.Green;
                        spbTrangThai.Items[0].ContentBlock2.Caption = "Mới";
                        break;
                    case "Đang giao":
                        spDangGiao.State = StepProgressBarItemState.Active;
                        spbTrangThai.ItemOptions.Indicator.ActiveStateImageOptions.SvgImage = svgImageCollection2[0];
                        spbTrangThai.Appearances.CommonActiveColor = Color.Green;
                        spbTrangThai.Items[1].ContentBlock2.Caption = "Đang giao";
                        break;
                    case "Hoàn thành":
                        spHoanThanh.State = StepProgressBarItemState.Active;
                        spbTrangThai.ItemOptions.Indicator.ActiveStateImageOptions.SvgImage = svgImageCollection2[0];
                        spbTrangThai.Appearances.CommonActiveColor = Color.Green;
                        spbTrangThai.Items[2].ContentBlock2.Caption = "Hoàn thành";
                        break;
                    default:
                        // Xử lý khi không khớp với các giá trị trên
                        break;
                }
            }
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtThoiGianHienTai.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); // Hiển thị giờ:phút:giây
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnCanhBaoTaiXe_Click(object sender, EventArgs e)
        {
            Entities db = Entities.CreateEntities();
            int emailSuccess = 0;
            int emailFailed = 0;

            // Tạo hộp thoại chờ trực tiếp
            var waitingPanel = new Panel
            {
                Size = new Size(400, 100),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point((this.Width - 400) / 2, (this.Height - 100) / 2),
                Visible = true
            };

            var waitingLabel = new Label
            {
                Text = "Đang gửi email, vui lòng đợi...",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12, FontStyle.Regular)
            };

            waitingPanel.Controls.Add(waitingLabel);
            this.Controls.Add(waitingPanel);
            waitingPanel.BringToFront();

            try
            {
                // Chạy tiến trình gửi email trong Task
                await Task.Run(() =>
                {
                    // Lấy danh sách các đơn hàng bị trễ giao
                    var donHangTreGiao = _LichSuHanTrinh.getAllTreDonGiao();
                    var donHangChuaNhan = _LichSuHanTrinh.getAllTreDonNhan_Time();

                    // Nhóm các đơn hàng theo tài xế
                    var taiXeDonHangTreGiao = donHangTreGiao.GroupBy(x => x.MaTX);
                    var taiXeDonHangChuaNhan = donHangChuaNhan.GroupBy(x => x.MaTX);

                    // Gửi email cho tài xế có đơn hàng trễ giao
                    foreach (var group in taiXeDonHangTreGiao)
                    {
                        string maTaiXe = group.Key;
                        string email = db.TAIXE.Where(tx => tx.MaTX == maTaiXe).Select(tx => tx.Email).FirstOrDefault();
                        string hoTen = db.TAIXE.Where(tx => tx.MaTX == maTaiXe).Select(tx => tx.HoTen).FirstOrDefault();

                        if (!string.IsNullOrEmpty(email))
                        {
                            try
                            {
                                // Tạo nội dung email
                                string body = TaoNoiDungEmailTreGiao(hoTen, maTaiXe, group.ToList());
                                GuiEmailChuyenNghiep(email, "Cảnh Báo Đơn Hàng Trễ Giao", body);

                                // Tăng số lượng email thành công
                                emailSuccess++;
                            }
                            catch
                            {
                                // Tăng số lượng email thất bại
                                emailFailed++;
                            }
                        }
                    }

                    // Gửi email cho tài xế có đơn hàng chưa nhận
                    foreach (var group in taiXeDonHangChuaNhan)
                    {
                        string maTaiXe = group.Key;
                        string email = db.TAIXE.Where(tx => tx.MaTX == maTaiXe).Select(tx => tx.Email).FirstOrDefault();
                        string hoTen = db.TAIXE.Where(tx => tx.MaTX == maTaiXe).Select(tx => tx.HoTen).FirstOrDefault();

                        if (!string.IsNullOrEmpty(email))
                        {
                            try
                            {
                                // Tạo nội dung email
                                string body = TaoNoiDungEmailChuaNhan(hoTen, maTaiXe, group.ToList());
                                GuiEmailChuyenNghiep(email, "Cảnh Báo Đơn Hàng Chưa Nhận", body);

                                // Tăng số lượng email thành công
                                emailSuccess++;
                            }
                            catch
                            {
                                // Tăng số lượng email thất bại
                                emailFailed++;
                            }
                        }
                    }
                });

                // Thông báo kết quả sau khi hoàn tất
                MessageBox.Show($"Gửi email thành công: {emailSuccess}\nGửi email thất bại: {emailFailed}",
                                "Kết quả gửi email",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi gửi email: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Xóa hộp thoại chờ
                this.Controls.Remove(waitingPanel);
                waitingPanel.Dispose();
            }
        }




        private string TaoNoiDungEmailChuaNhan(string hoTen, string maTX,List<LICHSUHANHTRINH> donHangChuaNhan)
        {
            string emailHtml = $@"
        <div style='font-family: Arial, sans-serif; line-height: 1.6; background-color: #ffffff; color: #333333; border: 1px solid #dddddd; padding: 20px; border-radius: 8px;'>
            <!-- Banner -->
            <div style='background-color: #ffc107; color: #ffffff; text-align: center; padding: 20px; border-radius: 8px;'>
                <h1 style='margin: 0; font-size: 24px;'>⚠️ Cảnh Báo Đơn Hàng Chưa Nhận ⚠️</h1>
                <p style='font-size: 16px; margin: 5px 0;'>Hệ thống phát hiện một số đơn hàng chưa được nhận.</p>
            </div>
            <!-- Nội dung -->
            <div style='margin-top: 20px;'>
                <p>Kính gửi tài xế: <strong>{hoTen} [{maTX}]</strong>,</p>
                <p>Các đơn hàng sau đây chưa được nhận:</p>
                <table style='border-collapse: collapse; width: 100%; margin-top: 20px; font-size: 14px; text-align: left; border: 1px solid #dddddd;'>
                    <thead>
                        <tr style='background-color: #f9f9f9;'>
                            <th style='padding: 10px; border: 1px solid #dddddd;'>Mã Đơn Hàng</th>
                            <th style='padding: 10px; border: 1px solid #dddddd;'>Thời Gian Yêu Cầu</th>
                        </tr>
                    </thead>
                    <tbody>";

            foreach (var donHang in donHangChuaNhan)
            {
                emailHtml += $@"
                        <tr>
                            <td style='padding: 10px; border: 1px solid #dddddd;'>{donHang.MaDH}</td>
                            <td style='padding: 10px; border: 1px solid #dddddd;'>{donHang.HanNhanDon:dd/MM/yyyy HH:mm}</td>
                        </tr>";
            }

            emailHtml += @"
                    </tbody>
                </table>
            </div>
            <!-- Lời nhắc -->
            <div style='margin-top: 20px; text-align: center;'>
                <p style='color: #ffc107; font-weight: bold;'>📌 Vui lòng kiểm tra và nhận đơn hàng ngay lập tức!</p>
                <p>Trân trọng,<br>Phòng Quản lý Vận hành SmartTMS</p>
                <p style='font-size: 12px; color: #999999;'>Đây là email tự động, vui lòng không phản hồi. Xin cảm ơn!</p>
            </div>
        </div>";

            return emailHtml;
        }



        private string TaoNoiDungEmailTreGiao(string hoTen, string maTX, List<LICHSUHANHTRINH> donHangTreGiao)
        {
            string emailHtml = $@"
        <div style='font-family: Arial, sans-serif; line-height: 1.6; background-color: #ffffff; color: #333333; border: 1px solid #dddddd; padding: 20px; border-radius: 8px;'>
            <!-- Banner -->
            <div style='background-color: #dc3545; color: #ffffff; text-align: center; padding: 20px; border-radius: 8px;'>
                <h1 style='margin: 0; font-size: 24px;'>⏰ Cảnh Báo Đơn Hàng Trễ Giao ⏰</h1>
                <p style='font-size: 16px; margin: 5px 0;'>Một số đơn hàng của bạn đã bị trễ giao.</p>
            </div>
            <!-- Nội dung -->
            <div style='margin-top: 20px;'>
               <p>Kính gửi tài xế: <strong>{hoTen} [{maTX}]</strong>,</p>
                <p>Các đơn hàng sau đây đã bị trễ giao:</p>
                <table style='border-collapse: collapse; width: 100%; margin-top: 20px; font-size: 14px; text-align: left; border: 1px solid #dddddd;'>
                    <thead>
                        <tr style='background-color: #f9f9f9;'>
                            <th style='padding: 10px; border: 1px solid #dddddd;'>Mã Đơn Hàng</th>
                            <th style='padding: 10px; border: 1px solid #dddddd;'>Thời Gian Giao Dự Kiến</th>
                            <th style='padding: 10px; border: 1px solid #dddddd;'>Thời Gian Giao Thực Tế</th>
                        </tr>
                    </thead>
                    <tbody>";

            foreach (var donHang in donHangTreGiao)
            {
                emailHtml += $@"
                        <tr>
                            <td style='padding: 10px; border: 1px solid #dddddd;'>{donHang.MaDH}</td>
                            <td style='padding: 10px; border: 1px solid #dddddd;'>{donHang.ThoiGianHoanThanh:dd/MM/yyyy HH:mm}</td>
                            <td style='padding: 10px; border: 1px solid #dddddd;'>{(donHang.ThoiGian.HasValue ? donHang.ThoiGian.Value.ToString("dd/MM/yyyy HH:mm") : "Chưa giao")}</td>
                        </tr>";
            }

            emailHtml += @"
                    </tbody>
                </table>
            </div>
            <!-- Lời nhắc -->
            <div style='margin-top: 20px; text-align: center;'>
                <p style='color: #dc3545; font-weight: bold;'>📌 Vui lòng xử lý các đơn hàng này ngay lập tức!</p>
                <p>Trân trọng,<br>Phòng Quản lý Vận hành SmartTMS</p>
                <p style='font-size: 12px; color: #999999;'>Đây là email tự động, vui lòng không phản hồi. Xin cảm ơn!</p>
            </div>
        </div>";

            return emailHtml;
        }



        private void GuiEmailChuyenNghiep(string email, string subject, string bodyHtml)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("2121005132@sv.ufm.edu.vn", "Tvy39278"),
                    EnableSsl = true,
                };


                var mailMessage = new MailMessage
                {
                    From = new MailAddress("2121005132@sv.ufm.edu.vn", "Phòng Quản Lý Vận Hành - SmartTMS"),
                    Subject = subject,
                    Body = bodyHtml,
                    IsBodyHtml = true // Quan trọng để hiển thị HTML
                };

                mailMessage.To.Add(email);

                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể gửi email đến " + email + ": " + ex.Message, "Lỗi gửi email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


       

    }
}