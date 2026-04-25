using StudentGradingProgram.DataBaseOperations;
using StudentGradingProgram.UserControls.StudentAdd;
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

namespace StudentGradingProgram.UserControls
{
    

    public partial class StundetAddUserControl : UserControl
    {
        public StundetAddUserControl()
        {
            InitializeComponent();
        }

        InterfaceTools interfaceTools = new InterfaceTools();
        StudentAddDatabaseOperations StudentAddDb = new StudentAddDatabaseOperations();

        public StudentData AllValue()
        {
            var student = new StudentData();
            student.Name = NameTextBox.Text;
            student.Surname = SurnameTextBox.Text;
            student.SelectedClassId = Convert.ToInt16(ClassComboBox.SelectedValue);
            if (!string.IsNullOrEmpty(student.Name) && !string.IsNullOrEmpty(student.Surname) && student.SelectedClassId != 0)
            {
                return student;
            }
            else
            {
                MessageBox.Show("Lütfen tüm verileri eksiksiz girdiğinize emin olun", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }


        private void StundetAddUserControl_Load(object sender, EventArgs e)
        {
            interfaceTools.LoadComboBox(ClassComboBox, () => StudentAddDb.ClassList());
        }


        private void StudentAddButton_Click(object sender, EventArgs e)
        {
            if (AllValue() != null)
            {
                StudentAddDb.StudenAdd(AllValue());
                interfaceTools.ClearControl(this.Controls);
            }
        }
    }
}
