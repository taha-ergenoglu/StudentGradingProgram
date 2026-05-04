using Guna.UI2.WinForms;
using StudentGradingProgram.DataBaseOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingProgram.Helpers
{
    internal class InterfaceTools
    {

        public void FillDataGrid(Guna2DataGridView dataGrid, Func<object> dataPull)
        {
            var dataList = dataPull();
            dataGrid.DataSource = dataList;
            foreach (DataGridViewColumn col in dataGrid.Columns)
            {
                if (col.Name == "Id"||col.Name=="ClassId")
                    dataGrid.Columns[col.Name].Visible = false;
                else if (col.Name == "ClassName")
                    dataGrid.Columns["ClassName"].HeaderText = "Class Name";
            }
        }


        public void LoadComboBox(Guna2ComboBox comboBox, Func<object> dataPull)
        {
            var dataList = dataPull();
            comboBox.DataSource = dataList;
            comboBox.DisplayMember = "ClassName";
            comboBox.ValueMember = "Id";
            comboBox.SelectedIndex = 0;
        }


        public void AddDataGridButton(Guna2DataGridView dataGridView)
        {
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Düzenle";
            btnEdit.Name = "EditButton";
            btnEdit.Text = "Düzenle";
            btnEdit.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(btnEdit);

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "Sil";
            btnDelete.Name = "DeleteButton";
            btnDelete.Text = "Sil";
            btnDelete.UseColumnTextForButtonValue = true;
            dataGridView.Columns.Add(btnDelete);
        }


        public void AddSoccerColumns(DataGridView grid)
        {
            // 1. DİKKAT: Izgara çizgilerini (Border) her yönden ve belirgin renkte çiz!
            grid.CellBorderStyle = DataGridViewCellBorderStyle.Single; // Sadece yatay değil, dikey çizgiler de gelsin
            grid.GridColor = Color.Silver; // Çizgiler çok belirgin bir gri olsun
            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.ReadOnly = true;
                col.DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240); // Standart pasif gri
                col.DefaultCellStyle.ForeColor = Color.DimGray; // Yazılar soluk siyah
            }

            // 2. Eğer daha önce puan kolonları eklendiyse, tekrar eklememek için kontrol et
            if (!grid.Columns.Contains("Exam 1"))
            {
                // 5 adet kolon oluşturmak için döngü kuruyoruz
                for (int i = 1; i <= 5; i++)
                {
                    DataGridViewTextBoxColumn soccerColumn = new DataGridViewTextBoxColumn();
                    soccerColumn.Name = "Exam" + i;
                    soccerColumn.HeaderText = "Exam " + i;
                    soccerColumn.Width = 60;
                    soccerColumn.ReadOnly = false;
                    soccerColumn.DefaultCellStyle.BackColor = Color.FromArgb(230, 242, 255);

                    // b) Kullanıcı o hücreye tıkladığında rengi değişsin ama içindeki yazı okunabilsin
                    soccerColumn.DefaultCellStyle.BackColor = Color.White;

                    // b) Yazı rengi net siyah
                    soccerColumn.DefaultCellStyle.ForeColor = Color.Black;

                    // c) Seçili hücre ayarları (Tıklandığında çok açık bir sarı/mavi olabilir)
                    soccerColumn.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
                    soccerColumn.DefaultCellStyle.SelectionForeColor = Color.Black;

                    // d) Rakamları ortala ve kalınlaştır
                    soccerColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    soccerColumn.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    grid.Columns.Add(soccerColumn);
                }
            }
        }


        public void ClearControl(Control.ControlCollection allControls)
        {
            foreach (Control control in allControls)
            {
                if (control.HasChildren)
                {
                    ClearControl(control.Controls);
                }

                switch (control)
                {
                    case Guna2TextBox txt:
                        txt.Clear();
                        break;
                    case Guna2ComboBox combo:
                        if (combo.Items.Count > 0)
                            combo.SelectedIndex = 0;
                        break;
                    case Guna2RadioButton radio:
                        radio.Checked = false;
                        break;
                    case Guna2DateTimePicker dtp:
                        dtp.Value = DateTime.Now;
                        break;
                }
            }
        }


        public void ChangeDataGridColumnsHeader(Guna2DataGridView dataGrid, List<string> headNames)
        {
            int i = 4;
            foreach (string headerName in headNames)
            {

                if (i < dataGrid.Columns.Count)
                {
                    dataGrid.Columns[i].HeaderText = headerName;
                    i++;
                }
                else if (dataGrid.Columns.Count == 0)
                {
                    MessageBox.Show("Lütfen önce sınıf seçimi yapınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
