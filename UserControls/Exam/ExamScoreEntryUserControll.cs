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
    public partial class ExamScoreEntryUserControll : UserControl
    {
        public ExamScoreEntryUserControll()
        {
            InitializeComponent();
        }


        InterfaceTools interfaceTools = new InterfaceTools();
        ExamAddDataBaseOperations dbOperations = new ExamAddDataBaseOperations();
        List<string> columnsName = new List<string>();


        private void ExamAddUserControll_Load(object sender, EventArgs e)
        {
            interfaceTools.LoadComboBox(ClassComboBox, () => dbOperations.ClassList());
        }

        private void ClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExamDataGrid.Columns.Clear();
            if (ClassComboBox.SelectedIndex != 0 && int.TryParse(ClassComboBox.SelectedValue.ToString(), out int selectedClassId))
            {
                var sinifOgrencileri = dbOperations.GetStudentsByClassId(selectedClassId);

                interfaceTools.FillDataGrid(ExamDataGrid, () => sinifOgrencileri);

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

                examScore.TotalScore = formatedTotalScore * 5;
                scoreList.Add(examScore);
            }

            if (scoreList.Count > 0)
            {
                string examName = ExamNameTextBox.Text;
                DateTime examDate = ExamDateDateTimePicker.Value;
                int examId = dbOperations.SaveClassScore(scoreList, examName, examDate, columnsName);
                bool isItSccessfull = dbOperations.SaveExamHeadings(examId, ExamDataGrid);
                if (isItSccessfull)
                {
                    MessageBox.Show("Puanlar başarılı bir şekilde kaydedildi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ChangeColumnsNameButton_Click(object sender, EventArgs e)
        {
            columnsName.Add(Evaluation1TextBox.Text);
            columnsName.Add(Evaluation2TextBox.Text);
            columnsName.Add(Evaluation3TextBox.Text);
            columnsName.Add(Evaluation4TextBox.Text);
            columnsName.Add(Evaluation5TextBox.Text);

            interfaceTools.ChangeDataGridColumnsHeader(ExamDataGrid, columnsName);
        }


        private void PrintButton_Click(object sender, EventArgs e)
        {
            Image mebLogo = Properties.Resources.mebLogo;
            Image schoolLogo = Properties.Resources.SchooLogo;
            string schoolName = "Raif Azak İmam Hatip Ortaokulu";
            string selectedClass = ClassComboBox.Text;
            string examName = ExamNameTextBox.Text;
            DateTime examDate = ExamDateDateTimePicker.Value;
            string information = "Rakamların puan karşılığı:\n1 = 20 puan\n2 = 40 puan\n3 = 60 puan\n4 = 80 puan\n5 = 100 puan";
            // 1. Sınıfımızdan bir kopya üretiyoruz ve yazdırılacak tabloyu içine gönderiyoruz
            DataGridViewPrinter print = new DataGridViewPrinter(ExamDataGrid, schoolName,selectedClass,examName,examDate,mebLogo,schoolLogo, information);

            // 2. Önizleme ekranını başlatıyoruz
            print.ShowPrintPreview();
        }
    }
}
