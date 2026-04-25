using StudentGradingProgram.DataBaseOperations;
using StudentGradingProgram.Helpers;
using StudentGradingProgram.Helpers.Exam;
using StudentGradingProgram.Model;
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

        private void SaveButton_Click(object sender, EventArgs e)
        {
            List<ExamScore> scoreList = new List<ExamScore>();
            foreach (DataGridViewRow row in ExamDataGrid.Rows)
            {
                int formatedTotalScore = 0;
                for (int i = 1; i <= 5; i++)
                {
                    int score = row.Cells[$"Exam{i}"].Value != null ? Convert.ToInt32(row.Cells[$"Exam{i}"].Value) : 0;
                    formatedTotalScore += score;
                }


                ExamScore examScore = new ExamScore();

                examScore.StudentID = Convert.ToInt32(row.Cells["Id"].Value);

                examScore.Score1 = row.Cells["Exam1"].Value != null ? Convert.ToInt32(row.Cells["Exam1"].Value) : 0;
                examScore.Score2 = row.Cells["Exam2"].Value != null ? Convert.ToInt32(row.Cells["Exam2"].Value) : 0;
                examScore.Score3 = row.Cells["Exam3"].Value != null ? Convert.ToInt32(row.Cells["Exam3"].Value) : 0;
                examScore.Score4 = row.Cells["Exam4"].Value != null ? Convert.ToInt32(row.Cells["Exam4"].Value) : 0;
                examScore.Score5 = row.Cells["Exam5"].Value != null ? Convert.ToInt32(row.Cells["Exam5"].Value) : 0;

                examScore.TotalScore = formatedTotalScore*5;
                scoreList.Add(examScore);
            }

            if (scoreList.Count > 0)
            {
                string examName = ExamNameTextBox.Text;
                DateTime examDate = ExamDateDateTimePicker.Value;
                bool isItSccessfull=dbOperations.SaveClassScore(scoreList,examName,examDate);
                if (isItSccessfull)
                { 
                MessageBox.Show("Puanlar başarılı bir şekilde kaydedildi","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }


            
            }
        }
    }
}
