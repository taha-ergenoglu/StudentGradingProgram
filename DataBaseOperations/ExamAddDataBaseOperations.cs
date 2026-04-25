using StudentGradingProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
