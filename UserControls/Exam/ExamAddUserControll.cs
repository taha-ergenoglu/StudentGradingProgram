using StudentGradingProgram.DataBaseOperations;
using StudentGradingProgram.Helpers;
using StudentGradingProgram.Helpers.Exam;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentGradingProgram.UserControls.Exam
{
    public partial class ExamAddUserControll : UserControl
    {
        public ExamAddUserControll()
        {
            InitializeComponent();
        }
        InterfaceTools interfaceTools = new InterfaceTools();
        ExamAddDataBaseOperations dbOperations = new ExamAddDataBaseOperations();
        private void ExamAddUserControll_Load(object sender, EventArgs e)
        {
            interfaceTools.LoadComboBox(ClassComboBox, () => dbOperations.ClassList());
        }

        private void ClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ClassComboBox.SelectedIndex != 0 && int.TryParse(ClassComboBox.SelectedValue.ToString(), out int selectedClassId))
            {
                var sinifOgrencileri = dbOperations.GetStudentsByClassId(selectedClassId);

                // 2. Bir önceki mesajda kurduğumuz InterfaceTools ile tabloyu doldurun
                interfaceTools.FillDataGrid(ExamDataGrid, () => sinifOgrencileri);

                // 3. Puan giriş kolonlarını tabloya ekleyin
                interfaceTools.AddSoccerColumns(ExamDataGrid);
                ExamDataGridCellValidating validating = new ExamDataGridCellValidating(ExamDataGrid);
            }
        }

    }
}
