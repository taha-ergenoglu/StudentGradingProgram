using Guna.UI2.WinForms;
using StudentGradingProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingProgram.DataBaseOperations
{
    internal class ExamAddDataBaseOperations
    {
        public List<Class> ClassList()
        {
            StudentAddDatabaseOperations classList = new StudentAddDatabaseOperations();
            return classList.ClassList();
        }
        public object GetStudentsByClassId(int selectedClassId)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var classStudents = context.Students
                            .Where(student => student.ClassId == selectedClassId)
                            .Select(student => new
                            {
                                Id = student.Id,
                                Name = student.Name,
                                Surname = student.Surname,
                                ClassName = student.Class.ClassName

                            }).ToList();
                    return classStudents;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        public int SaveClassScore(List<ExamScore> allScores,string examName,DateTime examDate,List<string>examHeadNames)//Buradaki examHeadNames kullanıcının "Değerlendirme1,...,5" kısımlarına girdiği ifadeleri belirtir
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var newExam = new Exam
                    {
                        ExamName = examName,
                        ExamDate = examDate.Date
                    };
                    context.Exams.Add(newExam);
                    context.SaveChanges();

                    foreach (var score in allScores)
                    {
                        score.ExamId = newExam.Id;
                    }

                    context.ExamScores.AddRange(allScores);
                    context.SaveChanges();

                    int examId = newExam.Id;

                    return examId;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
                throw;
            }
            
        }


        public bool SaveExamHeadings(int examId, Guna2DataGridView dataGrid)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var newHeadings = new ExamTableColumnsHeading
                    {
                        ExamId = examId, // Sınav tablosundan gelen gerçek ID
                        Header1Name = dataGrid.Columns[4].HeaderText,
                        Header2Name = dataGrid.Columns[5].HeaderText,
                        Header3Name = dataGrid.Columns[6].HeaderText,
                        Header4Name = dataGrid.Columns[7].HeaderText,
                        Header5Name = dataGrid.Columns[8].HeaderText
                    };

                    context.ExamTableColumnsHeadings.Add(newHeadings);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Başlıklar kaydedilirken hata oluştu: " + ex.Message);
                return false;
            }
        }

    }
}
