using Guna.UI2.WinForms;
using StudentGradingProgram.DataBaseOperations;
using System;
using System.Collections.Generic;
using System.Data;
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
                if (col.Name == "Id" || col.Name == "ClassId")
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
            int i = 5;
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
        public DataTable CreatDataTable(Guna2DataGridView dataGrid)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn col in dataGrid.Columns)
            {
                if (col.Name != "DeleteButton" && col.Name != "EditButton")
                    dt.Columns.Add(col.Name);//dt adlı DataTable nesnesine yeni kolonlar eklenir ve "col" ifadesindeki kolonun adları kullanılır
            }
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                if (!row.IsNewRow)//IsnNewRow eklenen satırın yeni kayıtlar için bir satırmı yoksa doldurulmuş olup olmadığını kontrol eder. Eğer true ise bu satır yeni kayıtlar için eklenmiş boş bir satırdır. Bu kod bloğu false durumunad çalışacaktır
                {
                    DataRow dr = dt.NewRow();//dr adında bir DataRow nesnesi oluşturulur. Bu nesne dt adlı DataTable nesnesine yeni bir satır eklemek için kullanılır
                    foreach (DataGridViewColumn col in dataGrid.Columns)
                    {
                        if (col.Name != "DeleteButton" && col.Name != "EditButton")
                            dr[col.Name] = row.Cells[col.Index].Value?.ToString();//dr[col.Name] ile dr satırının belirtilen adlı sütununa erişilir. col.index ile o klonun indexi alınır. Kolon ve satıların kesişiminde olan hücrenin içideki değer null değilse stringe çevrilir ve dr adlı DatRow nesnesinin ilgili sütununa atanır
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
        public void StudentFilter(string Name, string Surname, string ClassName, string examName, DateTime? examDate, DataTable dt, Guna2DataGridView dataGrid)
        {


            DataView dv = dt.DefaultView;//DataView ile bir tablodaki verileri değiştirmeden onlar üzerinde filtreleme işlemleri yapabilirz.
            List<string> filters = new List<string>();//Filtre koşullarını tutacak filters adında bir liste oluşturulur

            if (!string.IsNullOrEmpty(Name))
            {
                filters.Add($"Name LIKE '%{Name}%'");//Bu bir koşul ifadesinin sadece string kısmıdır. Henüz bunun bir işlevi yoktur. burada "Name" ifadesinin 2 adet % işareti arasında kullanılması, Name ifadesinin StName adlı sütunudaki verinin herhangi bir yerinde geçerli olabileceğini belirtir
            }
            if (!string.IsNullOrEmpty(Surname))
            {
                filters.Add($"Surname LIKE '%{Surname}%'");
            }
            if (!string.IsNullOrEmpty(examName))
            {
                filters.Add($"ExamName LIKE '%{examName}%'");
            }
            if (!string.IsNullOrEmpty(ClassName) && ClassName != "Sınıf Seçiniz...")
            {
                filters.Add($"ClassName LIKE '%{ClassName}%'");
            }


            dv.RowFilter = string.Join(" AND ", filters);//Yukarıdaki filter koşullarına "AND" ifadesi eklenir ve .RowFilter ile sadece belirlenen koşuldaki satırlar gösterilir
            dataGrid.DataSource = dv;//Filtrelenmiş veriler DgStudent e atanır
        }
    }
}
