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
    public partial class StudentEditUserControl : UserControl
    {
        public StudentEditUserControl()
        {
            InitializeComponent();
        }
        public event EventHandler IslemBitti;

        StudentEditDatabaseOperations dbOperations = new StudentEditDatabaseOperations();
        StudentListUserControl studentListUser = new StudentListUserControl();

        public int StudentID { get; set; }

        private void LoadComboBox(int classId)
        {
            ClassComboBox.DataSource = dbOperations.ClassList();
            ClassComboBox.DisplayMember = "ClassName";
            ClassComboBox.ValueMember = "Id";
            ClassComboBox.SelectedValue = classId;
        }


        public void StudentFind()
        {
            var findedStudent = dbOperations.StudentFind(StudentID);

            if (findedStudent != null)
            {
                NameTextBox.Text = findedStudent.Name;
                SurnameTextBox.Text = findedStudent.Surname;
                LoadComboBox(findedStudent.ClassId);
            }
        }


        private void SaveButton_Click(object sender, EventArgs e)
        {
            string newName = NameTextBox.Text;
            string newSurname = SurnameTextBox.Text;
            int newClassId = Convert.ToInt16(ClassComboBox.SelectedValue);

            bool operationResult = dbOperations.StudentUpdate(StudentID, newName, newSurname, newClassId);
            if (operationResult)
            {
                MessageBox.Show("İşlem başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IslemBitti?.Invoke(this, EventArgs.Empty);
            }
            else
                MessageBox.Show("İşlem başarısız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            IslemBitti?.Invoke(this, EventArgs.Empty);
        }
    }
}
