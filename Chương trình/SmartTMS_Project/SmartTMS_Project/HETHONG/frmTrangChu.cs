using BusinessLayer;
using DataLayer;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon;
using static DevExpress.Xpo.DB.DataStoreLongrunnersWatch;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using SmartTMS_Project.DANHMUC;
using SmartTMS_Project.NGHIEPVU;


namespace SmartTMS_Project.HETHONG
{
    public partial class frmTrangChu : DevExpress.XtraEditors.XtraForm
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }
        public
        Bai _bai;
        PhuongTien _phuongTien;
        GalleryItem _galleryItem = null;
        private TabControl tabControl;
        private GalleryControl galleryControl;
        public void openForm(Type typeForm)
        {
            foreach (var frm in MdiChildren)
            {
                if (frm.GetType() == typeForm)
                {
                    frm.Activate();
                    return;
                }
            }
            Form f = (Form)Activator.CreateInstance(typeForm);
            f.MdiParent = this;
            f.Show();
        }
        public void showCar()
        {
            var lsBai = _bai.getAll();
            gControl.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            gControl.Gallery.ImageSize = new Size(64,64);
            gControl.Gallery.ShowItemText = true;
            gControl.Gallery.ShowGroupCaption = true;
            gControl.Gallery.FilterCaption = "TÌNH TRẠNG XE HIỆN TẠI";
            foreach (var l in lsBai)
            {
                var gallaryItem = new GalleryItemGroup();
                gallaryItem.Caption = l.TenBai;
                gallaryItem.CaptionAlignment = GalleryItemGroupCaptionAlignment.Center;
                List<PHUONGTIEN> lsCar = _phuongTien.getByBai(l.MaBai);
                foreach (var l2 in lsCar)
                {
                    var gcItem = new GalleryItem();
                    gcItem.Caption = l2.BienSo;
                    gcItem.AppearanceCaption.Hovered.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    gcItem.Value = l2.MaBai;
                    if(l2.TrangThai == "Đang vận hành")
                    {
                        gcItem.ImageOptions.Image = imageList1.Images[0];
                    }
                    else if (l2.TrangThai == "Nằm bãi")
                    {
                        gcItem.ImageOptions.Image = imageList1.Images[1];
                    }
                    else if (l2.TrangThai == "Bảo trì")
                    {
                        gcItem.ImageOptions.Image = imageList1.Images[2];
                    }
                    else if (l2.TrangThai == "Khác")
                    {
                        gcItem.ImageOptions.Image = imageList1.Images[3];
                    }
                    gallaryItem.Items.Add(gcItem);

                }
                gControl.Gallery.Groups.Add(gallaryItem);
            }
           

        }
        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            _bai = new Bai();
            _phuongTien = new PhuongTien();
            showCar();
        }

        private void grcTaiNguyen_Click(object sender, EventArgs e)
        {

        }

        private void grcConNguoi_Click(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Xử lý kết quả từ hộp thoại
            if (result == DialogResult.Yes)
            {
                // Đóng form hiện tại
                this.Hide(); // Hoặc this.Close() nếu không cần mở lại

                // Hiển thị lại frmLogin
                frm_Login loginForm = new frm_Login();
                loginForm.Show();
            }
            // Nếu chọn No thì không làm gì
        }

        private void btnKetNoiHeThong_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show(
                "Thao tác này sẽ dừng kết nối với Database hiện tại. Bạn chắc chứ?",
                "Xác nhận kết nối",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Xử lý kết quả từ hộp thoại
            if (result == DialogResult.Yes)
            {
                // Đóng form hiện tại
                this.Hide(); // Hoặc this.Close() nếu không cần mở lại

                // Hiển thị lại frmLogin
                frm_ConnectDB frm = new frm_ConnectDB();
                frm.Show();
            }
            // Nếu chọn No thì không làm gì
        }

        private void gControl_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void popupMenu1_Popup(object sender, EventArgs e)
        {
            Point point = gControl.PointToClient(Control.MousePosition);
            RibbonHitInfo hitInfo = gControl.CalcHitInfo(point);
            if (hitInfo.InGalleryItem || hitInfo.HitTest == RibbonHitTest.GalleryImage)
            {
                _galleryItem = hitInfo.GalleryItem;
               

            }
          




        }

        private void btnDieuXe_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gc_item = new GalleryItem();
            if (_galleryItem == null)
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show(
                    "Vui lòng chọn xe để thực hiện chức năng!",
                    "Thông báo!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }else
            {
                frm_ChuyenXe frm = new frm_ChuyenXe();
                string id = _galleryItem.Caption.ToString();
                string bai = _galleryItem.Value.ToString();
                frm.MainForm = this; // Truyền tham chiếu của frmTrangChu vào frm_ChuyenXe
                frm.ID_Xe = id;
                frm.ID_Bai = bai;
                frm.Show();
            }    
           
        }

        private void btnPhuongTien_Click(object sender, EventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_PhuongTien));
        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_DashBoard));
        }

        private void btnBai_Click(object sender, EventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_BaiXe));
        }

        private void btnThietBi_Click(object sender, EventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_ThietBi));
        }

        private void btnDonVi_Click(object sender, EventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_DonVi));
        }

        private void btnCongTy_Click(object sender, EventArgs e)
        {
            frm_CongTy fr = new frm_CongTy();
            fr.Show();
        }



        private void btnDonHang_Click(object sender, EventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_DonHang));
        }



        private void btnTheoDoiLoTrinh_Click(object sender, EventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_TheoDoiLoTrinh));
        }

        private void btnKeHoachVanChuyen_Click(object sender, EventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_KeHoachVanChuyen));
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_KhachHang));
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_NhanVien));
        }

        private void btnTaiXe_Click(object sender, EventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_TaiXe));
        }

        private void btnHoTro_Click(object sender, EventArgs e)
        {
            frm_HoTro fr = new frm_HoTro();
            fr.Show();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            gControl.Show();

            // Close all open tabs in the DocumentManager
            while (this.MdiChildren.Length > 0)
            {
                this.MdiChildren[0].Close();
            }
        }

        private void btnDiemTrungChuyen_Click(object sender, EventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_DiemTrungChuyen));
        }

        private void btnGanTaiXe_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gc_item = new GalleryItem();
            if (_galleryItem == null)
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show(
                    "Vui lòng chọn xe để thực hiện chức năng!",
                    "Thông báo!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                frm_GanTaiXe frm = new frm_GanTaiXe();
                string id = _galleryItem.Caption.ToString();
                string bai = _galleryItem.Value.ToString();
                frm.MainForm = this; // Truyền tham chiếu của frmTrangChu vào frm_ChuyenXe
                frm.ID_Xe = id;
                frm.ID_TaiXe = bai;
                frm.Show();
            }
        }

        private void btnThietLapKeHoachVanChuyen_Click(object sender, EventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_ThietLapKeHoachVanChuyen));
        }

        private void btnXemHanhTrinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_TheoDoiLoTrinh));
        }

        private void btnCuocPhi_Click(object sender, EventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_ThietLapCuocPhi));
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_TaiKhoan));
        }

        private void btnBaoCaoHieuSuat_Click(object sender, EventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_HieuSuatTaiXe));

        }

        private void btnBaoCaoDoanhThu_Click(object sender, EventArgs e)
        {
            gControl.Hide();
            openForm(typeof(frm_DoanhThu));
        }
    }
}
