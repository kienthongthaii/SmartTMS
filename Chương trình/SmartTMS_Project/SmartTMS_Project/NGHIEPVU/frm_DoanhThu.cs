using BusinessLayer.NGHIEPVU;
using DevExpress.XtraEditors;
using SmartTMS_Project.REPORT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartTMS_Project.NGHIEPVU
{
    public partial class frm_DoanhThu : DevExpress.XtraEditors.XtraForm
    {
        public frm_DoanhThu()
        {
            InitializeComponent();
        }
        DonHang _donHang;

        private void frm_DoanhThu_Load(object sender, EventArgs e)
        {
            _donHang = new DonHang();
        }
        public frm_DoanhThu(DataTable dataSource)
        {
            InitializeComponent();

            // Kiểm tra dữ liệu đầu vào
            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Tạo báo cáo và gắn dữ liệu
            BaoCaoDoanhThu report = new BaoCaoDoanhThu();
            report.SetDataSource(dataSource);

            // Hiển thị báo cáo trên DocumentViewer
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }
        public static DataTable ConvertToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Lấy các thuộc tính từ kiểu T
            var props = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (var prop in props)
            {
                // Tạo cột trong DataTable với tên và kiểu dữ liệu của thuộc tính
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
        public void ReloadDataSource(DataTable dataSource)
        {
            if (dataSource == null || dataSource.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Cập nhật lại dữ liệu cho báo cáo
            BaoCaoDoanhThu report = new BaoCaoDoanhThu();
            report.SetDataSource(dataSource);

            // Hiển thị lại báo cáo trên DocumentViewer
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }


        private void dtNgayDen_EditValueChanged(object sender, EventArgs e)
        {
            if (dtNgayTu.EditValue == null || dtNgayDen.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ ngày bắt đầu và ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime ngayTu = DateTime.Parse(dtNgayTu.EditValue.ToString());
            DateTime ngayDen = DateTime.Parse(dtNgayDen.EditValue.ToString());

            // Lấy danh sách đơn hàng hoàn thành
            List<DataLayer.DONHANG> listDonHang = _donHang.getAll_HoanThanh(ngayTu, ngayDen);

            if (listDonHang == null || listDonHang.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Chuyển đổi List<DONHANG> sang DataTable
            DataTable dataSource = ConvertToDataTable(listDonHang);

            // Tìm form đã mở
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is frm_DoanhThu doanhThuForm)
                {
                    doanhThuForm.ReloadDataSource(dataSource); // Cập nhật lại dữ liệu
                    return;
                }
            }

            // Nếu không tìm thấy form, mở form mới
            frm_DoanhThu frm = new frm_DoanhThu(dataSource);
            frm.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu Báo Cáo",
                FileName = "BaoCaoDoanhThu_ChiPhi.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ((BaoCaoDoanhThu)documentViewer1.DocumentSource).ExportToXlsx(saveFileDialog.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi xuất báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXuatWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Word Files|*.docx",
                Title = "Lưu Báo Cáo",
                FileName = "BaoCaoDoanhThu_ChiPhi.docx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ((BaoCaoDoanhThu)documentViewer1.DocumentSource).ExportToDocx(saveFileDialog.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi xuất báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Lưu Báo Cáo",
                FileName = "BaoCaoDoanhThu_ChiPhi.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ((BaoCaoDoanhThu)documentViewer1.DocumentSource).ExportToPdf(saveFileDialog.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi xuất báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}