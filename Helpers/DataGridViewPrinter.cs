using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
namespace StudentGradingProgram.Helpers
{
    internal class DataGridViewPrinter
    {
        private PrintDocument _printDoc;
        private PrintPreviewDialog _previewDialog;
        private Guna2DataGridView _dataGrid; // Yazdırılacak tabloyu tutacağımız değişken
        private int _printRowIndex;
        private string _informationString;

        private string _schoolName;
        private string _className;
        private string _examName;
        private DateTime _examDate;
        private Image _leftLogo;
        private Image _rightLogo;


        // Yapıcı Metot (Constructor): Sınıf çağrıldığında tabloyu alıp ayarları yapar
        public DataGridViewPrinter(Guna2DataGridView dataGrid, string schoolName, string className, string examName, DateTime examDate, Image leftLogo, Image rightLogo, string information)
        {
            _dataGrid = dataGrid;
            _schoolName = schoolName;
            _className = className;
            _examName = examName;
            _examDate = examDate;
            _leftLogo = leftLogo;
            _rightLogo = rightLogo;
            _informationString = information;

            _printDoc = new PrintDocument();
            _previewDialog = new PrintPreviewDialog();


            _printDoc.DefaultPageSettings.Landscape = true;
            // A4 Boyutunu (210mm x 297mm) standart olarak set ediyoruz
            foreach (PaperSize size in _printDoc.PrinterSettings.PaperSizes)
            {
                if (size.Kind == PaperKind.A4)
                {
                    _printDoc.DefaultPageSettings.PaperSize = size;
                    break;
                }
            }

            _printDoc.PrintPage += PrintDoc_PrintPage;
        }


        // Form üzerinden sadece bu metodu çağıracağız
        public void ShowPrintPreview()
        {
            _printRowIndex = 0; // Baştan başla
            _previewDialog.Document = _printDoc;
            _previewDialog.Width = 1000;
            _previewDialog.Height = 800;
            _previewDialog.ShowDialog();
        }


        // Çizim işlemlerini yapan asıl motorumuz (Önceki kodun aynısı, sadece isimler düzeltildi)
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;

            Font baslikFont = new Font("Segoe UI", 16, FontStyle.Bold);
            Font bilgiFont = new Font("Segoe UI", 11, FontStyle.Bold);
            Font headerFont = new Font("Segoe UI", 7, FontStyle.Bold);
            Font cellFont = new Font("Segoe UI", 9, FontStyle.Regular);
            Font informationFont = new Font("Segoe UI", 8, FontStyle.Regular);

            Brush brush = Brushes.Black;
            Pen pen = new Pen(Color.Black, 1);

            int x = e.MarginBounds.Left - 40;
            int y = e.MarginBounds.Top - 40; // Sayfanın en üstünden başlıyoruz

            //-----------------------------------------------------------
            //Logo ve Başlık
            //-----------------------------------------------------------
            int logoSize = 90; // Logoların genişliği ve yüksekliği

            // Sol Logo (Örn: MEB)
            if (_leftLogo != null)
                g.DrawImage(_leftLogo, x, y, logoSize, logoSize);

            // Sağ Logo (Örn: Okul)
            if (_rightLogo != null)
                g.DrawImage(_rightLogo, e.MarginBounds.Right - logoSize + 50, y, logoSize, logoSize);

            // Ortaya Okul Adını Yazdırma
            StringFormat headerFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            Rectangle headerSpace = new Rectangle(x + logoSize, y, e.MarginBounds.Width - (logoSize * 2) + 50, logoSize);
            g.DrawString(_schoolName, baslikFont, brush, headerSpace, headerFormat);

            // Y eksenini logoların altına kaydırıyoruz
            y += logoSize + 15;

            //-----------------------------------------------------------
            //Sınıf, Sınav Tarihi, Yazdırma Tarihi
            //-----------------------------------------------------------
            string bilgiMetni = $"Sınav: {_examName}      |      Sınıf: {_className}      |      Sınav Tarihi: {_examDate.ToString("dd.MM.yyyy")}      |      Yazdırılma Tarihi: {DateTime.Now.ToString("dd.MM.yyyy")}";

            StringFormat bilgiFormat = new StringFormat { Alignment = StringAlignment.Center };
            Rectangle bilgiAlani = new Rectangle(x, y, e.MarginBounds.Width + 65, 30);
            g.DrawString(bilgiMetni, bilgiFont, brush, bilgiAlani, bilgiFormat);

            // Y eksenini tablonun başlayacağı yere (biraz daha aşağıya) kaydırıyoruz
            y += 40;


            int cellHeight = 30;
            int headerHeight = 70;

            //-----------------------------------------------------------
            //Paun bilgilendirme yazdırma
            //-----------------------------------------------------------
            Rectangle informationSpace = new Rectangle(57, 695, 190, 100);
            g.DrawString(_informationString, informationFont, brush, informationSpace);


            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center,
                Trimming = StringTrimming.Word
            };

            // Genişlik Hesaplama (İlk 4 sabit, son 5 dinamik)
            int[] fixedWidths = { 40, 120, 120,80,80};
            int totalFixedWidth = 40 + 120 + 120;
            int remainingWidth = e.MarginBounds.Width + 50 - totalFixedWidth;
            int dynamicColumnWidth = remainingWidth / 5;

            int[] colWidths = { fixedWidths[0], fixedWidths[1], fixedWidths[2],fixedWidths[3],fixedWidths[4],
                                dynamicColumnWidth, dynamicColumnWidth, dynamicColumnWidth, dynamicColumnWidth, dynamicColumnWidth };

            // 1. BAŞLIKLARI ÇİZ
            for (int i = 0; i < _dataGrid.Columns.Count; i++)
            {
                if (_dataGrid.Columns[i].HeaderText != "Id" && _dataGrid.Columns[i].HeaderText != "Class Name")
                {
                    Rectangle rect = new Rectangle(x, y, colWidths[i], headerHeight);
                    g.DrawRectangle(pen, rect);
                    g.DrawString(_dataGrid.Columns[i].HeaderText, headerFont, brush, rect, format);
                    x += colWidths[i];
                }
                
            }

            y += headerHeight;

            // 2. SATIRLARI ÇİZ
            while (_printRowIndex < _dataGrid.Rows.Count)
            {
                DataGridViewRow row = _dataGrid.Rows[_printRowIndex];
                if (row.IsNewRow) { _printRowIndex++; continue; }

                x = e.MarginBounds.Left - 40;

                for (int i = 0; i < _dataGrid.Columns.Count; i++)
                {
                    if (_dataGrid.Columns[i].Name != "Id" && _dataGrid.Columns[i].HeaderText != "Class Name")
                    {
                        Rectangle rect = new Rectangle(x, y, colWidths[i], cellHeight);
                        g.DrawRectangle(pen, rect);

                        string cellValue = row.Cells[i].Value != null ? row.Cells[i].Value.ToString() : "";
                        g.DrawString(cellValue, cellFont, brush, rect, format);
                        x += colWidths[i];
                    }
                }
                y += cellHeight;
                _printRowIndex++;

                if (y + cellHeight + 40 > e.MarginBounds.Bottom)
                {
                    ;
                    e.HasMorePages = true;
                    return;
                }
            }


            e.HasMorePages = false;
            _printRowIndex = 0;
        }
    }
}
