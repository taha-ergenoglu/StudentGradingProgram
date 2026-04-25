using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingProgram.Helpers.Exam
{
    internal class ExamDataGridCellValidating
    {
        private Guna2DataGridView _grid;

        // Sınıfın Yapıcı Metodu: Tabloyu dışarıdan alıyoruz ve denetimi başlatıyoruz
        public ExamDataGridCellValidating(Guna2DataGridView hedefTablo)
        {
            _grid = hedefTablo;

            // Kullanıcı hücrenin içine girip yazmaya başladığı anı dinliyoruz
            _grid.EditingControlShowing += Grid_EditingControlShowing;
        }

        private void Grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Hangi sütunda olduğumuzu buluyoruz
            string columnName = _grid.CurrentCell.OwningColumn.Name;

            // Arka planda açılan metin kutusunu (TextBox) yakalıyoruz
            TextBox txt = e.Control as TextBox;

            if (txt != null)
            {
                // Olası üst üste binmeleri engellemek için önce eski dinleyiciyi siliyoruz
                txt.KeyPress -= Txt_KeyPress;

                // Eğer bizim "Soru" ile başlayan kolonlardaysak, klavye denetimini aktif ediyoruz
                if (columnName.StartsWith("Exam"))
                {
                    txt.MaxLength = 1; // Sadece tek bir karaktere izin ver
                    txt.KeyPress += Txt_KeyPress; // Klavyeye basılma anını dinle
                }
            }
        }

        // Kullanıcı tuşa bastığı milisaniye içinde burası çalışır
        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 1. Silme (Backspace) tuşuna izin veriyoruz, yoksa kullanıcı yanlış yazdığını silemez
            if (e.KeyChar == (char)Keys.Back) return;

            // 2. Basılan tuş RAKAM DEĞİLSE (harf, boşluk veya sembolse) anında engelle
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Tuşu havada yut, ekrana yansıtma
                MessageBox.Show("Lütfen sadece rakam giriniz!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Basılan tuş rakamsa, 0 ile 5 arasında mı diye kontrol et
            int value = int.Parse(e.KeyChar.ToString());

            if (value < 0 || value > 5)
            {
                e.Handled = true; // Rakamı ekrana yazdırmadan engelle
                MessageBox.Show("Lütfen 0 ile 5 aralığında bir puan giriniz.", "Kural İhlali", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
