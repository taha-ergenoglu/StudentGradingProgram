using Guna.UI2.WinForms;
using StudentGradingProgram.Model;
using StudentGradingProgram.UserControls;
using StudentGradingProgram.UserControls.StudentAdd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingProgram.DataBaseOperations
{
    internal class StudentAddDatabaseOperations
    {
        public bool StudenAdd(StudentData studentData)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var newStudent = new Student
                    {
                        Name = studentData.Name,
                        Surname = studentData.Surname,
                        ClassId = studentData.SelectedClassId
                    };
                    context.Students.Add(newStudent);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }


        public List<Class> ClassList()
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var classList = context.Classes.ToList();
                    classList.Insert(0, new Class { Id = 0, ClassName = "Sınıf Seçiniz..." });
                    return classList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
        }
    }
}
