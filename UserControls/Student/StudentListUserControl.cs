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


        private void FillDataGrid()
        {
            var studentList = dbOperations.studentList();
            StudentListDataGrid.DataSource = studentList;
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
    }
}
