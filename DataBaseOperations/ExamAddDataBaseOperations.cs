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

        public bool SaveClassScore(List<ExamScore> allScores,string examName,DateTime examDate)
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
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
                throw;
            }
            
        }
        
    }
}
