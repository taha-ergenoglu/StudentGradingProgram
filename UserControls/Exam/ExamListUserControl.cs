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

namespace StudentGradingProgram.UserControls.Exam
{
    public partial class ExamListUserControl : UserControl
    {
        public ExamListUserControl()
        {
            InitializeComponent();
        }

        ExamListDatabaseOperations dbOperations = new ExamListDatabaseOperations();
        InterfaceTools interfaceTools = new InterfaceTools();
        Main mainPanel = new Main();

        private void ExamListUserControl_Load(object sender, EventArgs e)
        {
            guna2HtmlLabel3.Visible = false;
            ExamDateDateTimePicker.Visible = false;

            ExamDateDateTimePicker.Value = DateTime.Now;
            interfaceTools.FillDataGrid(ExamListDataGrid, () => dbOperations.ExamList());
            interfaceTools.LoadComboBox(ClassComboBox, () => dbOperations.ClassList());
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            DateTime? examDate = null;
            if (DateTimePickerComboBox.Checked == true)
            {
                examDate = ExamDateDateTimePicker.Value.Date;
            }

            string examName = ExamNameTextBox.Text;
            string className = ClassComboBox.Text;
            interfaceTools.FillDataGrid(ExamListDataGrid, () => dbOperations.ExamList());
            DataTable dt = interfaceTools.CreatDataTable(ExamListDataGrid);
            interfaceTools.StudentFilter(null, null, className, examName, examDate, dt, ExamListDataGrid);
        }

        private void DateTimePickerComboBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DateTimePickerComboBox.Checked == true)
            {
                guna2HtmlLabel3.Visible = true;
                ExamDateDateTimePicker.Visible = true;
            }
            else
            {
                guna2HtmlLabel3.Visible = false;
                ExamDateDateTimePicker.Visible = false;
            }
        }

        private void FilterCancelButton_Click(object sender, EventArgs e)
        {
            interfaceTools.ClearControl(this.Controls);
            interfaceTools.FillDataGrid(ExamListDataGrid, () => dbOperations.ExamList());
            DateTimePickerComboBox.Checked = false;
            DateTimePickerComboBox_CheckedChanged(sender, e);
        }

        private void ExamListDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            int examId =Convert.ToInt32( ExamListDataGrid.SelectedCells[0]);
            mainPanel.ShowSelectedExam(examId);
        }
    }
}
