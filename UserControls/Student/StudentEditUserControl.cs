using StudentGradingProgram.DataBaseOperations;
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
    public partial class StudentEditUserControl : UserControl
    {
        public StudentEditUserControl()
        {
            InitializeComponent();
        }


        StudentEditDeleteDatabaseOperations dbOperations = new StudentEditDeleteDatabaseOperations();


        private void LoadComboBox(int classId)
        {
            ClassComboBox.DataSource = dbOperations.ClassList();
            ClassComboBox.DisplayMember = "ClassName";
            ClassComboBox.ValueMember = "Id";
            ClassComboBox.SelectedValue = classId;
        }


        public void StudentFind(int selectedStudentId)
        {
            var findedStudent = dbOperations.StudentFind(selectedStudentId);

            if (findedStudent != null)
            {
                NameTextBox.Text = findedStudent.Name;
                SurnameTextBox.Text = findedStudent.Surname;
                LoadComboBox(findedStudent.ClassId);
            }
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
