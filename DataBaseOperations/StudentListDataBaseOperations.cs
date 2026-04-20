using Guna.UI2.WinForms;
using StudentGradingProgram.Helpers.StudentList;
using StudentGradingProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingProgram.DataBaseOperations
{
    internal class StudentListDataBaseOperations
    {
        public List<StudentListModel> studentList()
        {
			try
			{
				using (var context = new AppDbContext())
				{
					var studentList = context.Students.Select(
						student => new StudentListModel
						{
							Id=student.Id,
							Name=student.Name,
							Surname=student.Surname,
							ClassName=student.Class.ClassName,
						}).ToList();
					return studentList;
				}
			}
			catch (Exception ex)
			{
                MessageBox.Show(ex.ToString());
                throw;
			}
        }


		public List<Class> ClassList()
		{
            StudentAddDatabaseOperations classList = new StudentAddDatabaseOperations();
			return classList.ClassList();
		}


		public int StudentRemove(int studentId)
		{
			try
			{
                using (var context = new AppDbContext())
                {

                    var studentToBeDeleted = context.Students.Find(studentId);
                    if (studentToBeDeleted != null)
                    {
                        DialogResult result = MessageBox.Show($"{studentId} ID numaralı öğrenci silinecektir. Onaylıyor musunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (result == DialogResult.Yes)
                        {
                            context.Students.Remove(studentToBeDeleted);
							context.SaveChanges();
                            return 1;
                        }
                        else return 0;
                    }
                    else
                    {
                        MessageBox.Show($"{studentId} ID numaralı öğrenci bulunamadı !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }
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
