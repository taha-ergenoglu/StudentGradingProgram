using StudentGradingProgram.Helpers.Exam;
using StudentGradingProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingProgram.DataBaseOperations
{
    internal class ExamListDatabaseOperations
    {
        public List<Class> ClassList()
        {
            StudentAddDatabaseOperations classList = new StudentAddDatabaseOperations();
            return classList.ClassList();
        }


        public List<ExamListModel> ExamList()
        {
			try
			{
				using (var context = new AppDbContext())
				{
					var examList = context.Exams.Select(
						exams => new ExamListModel
						{
							Id = exams.Id,
							ClassName=exams.Class.ClassName,
							ExamName=exams.ExamName,
							ExamDate=exams.ExamDate
						}).ToList();
					return examList;
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
