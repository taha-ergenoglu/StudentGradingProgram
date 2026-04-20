using StudentGradingProgram.Helpers.StudentList;
using StudentGradingProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingProgram.DataBaseOperations
{
    internal class StudentEditDeleteDatabaseOperations()
    {
        public List<Class> ClassList()
        {
            StudentAddDatabaseOperations classList = new StudentAddDatabaseOperations();
            return classList.ClassList();
        }
        public StudentListModel StudentFind(int selectedStudentId)
        {
			try
			{
				using (var context = new AppDbContext())
				{
					var selectedStudent = context.Students
							.Where(student => student.Id == selectedStudentId)
							.Select(student => new StudentListModel
							{
								Id = student.Id,
								Name = student.Name,
								Surname = student.Surname,
								ClassId=student.ClassId,
								ClassName = student.Class.ClassName
							}).FirstOrDefault();
					return selectedStudent;
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
