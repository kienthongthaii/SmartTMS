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
    public partial class frm_BaoCao : DevExpress.XtraEditors.XtraForm
    {
        public frm_BaoCao()
        {
            InitializeComponent();
        }

        private void frm_BaoCao_Load(object sender, EventArgs e)
        {

        }
        public frm_BaoCao (DataTable dataSource)
        {
            InitializeComponent();

            // Tạo báo cáo và gắn dữ liệu
            HieuSuatTaiXe report = new HieuSuatTaiXe();
            report.SetDataSource(dataSource);

            // Hiển thị báo cáo trên DocumentViewer
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "Lưu Báo Cáo",
                FileName = "BaoCaoTaiXe.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ((HieuSuatTaiXe)documentViewer1.DocumentSource).ExportToPdf(saveFileDialog.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi xuất báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuatWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Word Files|*.docx",
                Title = "Lưu Báo Cáo",
                FileName = "BaoCaoTaiXe.docx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ((HieuSuatTaiXe)documentViewer1.DocumentSource).ExportToDocx(saveFileDialog.FileName);
                    MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra khi xuất báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Lưu Báo Cáo",
                FileName = "BaoCaoTaiXe.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ((HieuSuatTaiXe)documentViewer1.DocumentSource).ExportToXlsx(saveFileDialog.FileName);
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