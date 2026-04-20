using StudentGradingProgram.DataBaseOperations;
using StudentGradingProgram.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentGradingProgram.UserControls.Student
{
    public partial class StudentListUserControl : UserControl
    {
        public StudentListUserControl()
        {
            InitializeComponent();
        }
        StudentListDataBaseOperations dbOperations = new StudentListDataBaseOperations();

        private void LoadComboBox()
        {
            ClassComboBox.DataSource = dbOperations.ClassList();
            ClassComboBox.DisplayMember = "ClassName";
            ClassComboBox.ValueMember = "Id";
            ClassComboBox.SelectedIndex = 0;
        }


        private void StudentList_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            FillDataGrid();
            AddDataGridButton();
        }


        public void FillDataGrid()
        {
            var studentList = dbOperations.studentList();
            StudentListDataGrid.DataSource = studentList;
            StudentListDataGrid.Columns[4].Visible = false;
        }


        private void AddDataGridButton()
        {
            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "Düzenle";
            btnEdit.Name = "EditButton";
            btnEdit.Text = "Düzenle";
            btnEdit.UseColumnTextForButtonValue = true;
            StudentListDataGrid.Columns.Add(btnEdit);

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "Sil";
            btnDelete.Name = "DeleteButton";
            btnDelete.Text = "Sil";
            btnDelete.UseColumnTextForButtonValue = true;
            StudentListDataGrid.Columns.Add(btnDelete);
        }


        private void StudentListDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            int selectedStudentId = Convert.ToInt32(StudentListDataGrid.Rows[e.RowIndex].Cells["Id"].Value);
            if (StudentListDataGrid.Columns[e.ColumnIndex].Name == "EditButton")
            {
                Main main = this.FindForm() as Main;
                main.ShowSelectedStudentData(selectedStudentId, "StudentEdit");

            }
            else if (StudentListDataGrid.Columns[e.ColumnIndex].Name == "DeleteButton")
            {
                int operatiosnConfirm = dbOperations.StudentRemove(selectedStudentId);
                if (operatiosnConfirm == 1)
                    FillDataGrid();
            }
        }


        private void FilterButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string surname = SurnameTextBox.Text;
            string className = ClassComboBox.Text;
            DataTable dt = CreateDataTable();
            StudentFilter(name, surname, className, dt);
        }


        public DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();// dt adında bir DataTable nesnesi oşuturulur
            foreach (DataGridViewColumn col in StudentListDataGrid.Columns) //DgStundet adlı nesnenin kolonları teker teker okunur ve "col" adlı ifadeye eklenir
            {
                dt.Columns.Add(col.Name);//dt adlı DataTable nesnesine yeni kolonlar eklenir ve "col" ifadesindeki kolonun adları kullanılır
            }
            foreach (DataGridViewRow row in StudentListDataGrid.Rows)
            {
                if (!row.IsNewRow)//IsnNewRow eklenen satırın yeni kayıtlar için bir satırmı yoksa doldurulmuş olup olmadığını kontrol eder. Eğer true ise bu satır yeni kayıtlar için eklenmiş boş bir satırdır. Bu kod bloğu false durumunad çalışacaktır
                {
                    DataRow dr = dt.NewRow();//dr adında bir DataRow nesnesi oluşturulur. Bu nesne dt adlı DataTable nesnesine yeni bir satır eklemek için kullanılır
                    foreach (DataGridViewColumn col in StudentListDataGrid.Columns)
                    {

                        dr[col.Name] = row.Cells[col.Index].Value?.ToString();//dr[col.Name] ile dr satırının belirtilen adlı sütununa erişilir. col.index ile o klonun indexi alınır. Kolon ve satıların kesişiminde olan hücrenin içideki değer null değilse stringe çevrilir ve dr adlı DatRow nesnesinin ilgili sütununa atanır
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }


        private void StudentFilter(string Name, string Surname, string ClassName, DataTable dt)
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
            if (!string.IsNullOrEmpty(ClassName) && ClassName != "Sınıf Seçilmedi")
            {
                filters.Add($"ClassName LIKE '%{ClassName}%'");
            }



            dv.RowFilter = string.Join(" AND ", filters);//Yukarıdaki filter koşullarına "AND" ifadesi eklenir ve .RowFilter ile sadece belirlenen koşuldaki satırlar gösterilir
            StudentListDataGrid.DataSource = dv;//Filtrelenmiş veriler DgStudent e atanır
        }
    }
}
