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
        InterfaceTools interfaceTools = new InterfaceTools();


        private void StudentList_Load(object sender, EventArgs e)
        {
            interfaceTools.FillDataGrid(StudentListDataGrid, () => dbOperations.studentList());
            interfaceTools.LoadComboBox(ClassComboBox, () => dbOperations.ClassList());
            interfaceTools.AddDataGridButton(StudentListDataGrid);
        }



        public void FillDataGrid()
        {
            StudentListDataBaseOperations dbOperations = new StudentListDataBaseOperations();
            interfaceTools.FillDataGrid(StudentListDataGrid, () => dbOperations.studentList());
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
                    interfaceTools.FillDataGrid(StudentListDataGrid, () => dbOperations.studentList());
            }
        }


        private void FilterButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string surname = SurnameTextBox.Text;
            string className = ClassComboBox.Text;
            interfaceTools.FillDataGrid(StudentListDataGrid, () => dbOperations.studentList());
            DataTable dt = interfaceTools.CreatDataTable(StudentListDataGrid);
            interfaceTools.StudentFilter(name, surname, className,null,null, dt,StudentListDataGrid);
        }


        private void FilterCancelButton_Click(object sender, EventArgs e)
        {
            interfaceTools.ClearControl(this.Controls);
            interfaceTools.FillDataGrid(StudentListDataGrid, () => dbOperations.studentList());
        }
    }
}
