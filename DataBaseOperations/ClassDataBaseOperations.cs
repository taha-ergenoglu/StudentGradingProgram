using Guna.UI2.WinForms;
using StudentGradingProgram.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingProgram.DataBaseOperations
{
    internal class ClassDataBaseOperations
    {
        public void ClassAdd(string className)
        {
            using (var context = new AppDbContext())
            {
                var newClass = new Class
                {
                    ClassName = className

                };
                context.Classes.Add(newClass);
                context.SaveChanges();
            }
        }


        public Guna2DataGridView ClassList()
        {
            using (var context = new AppDbContext())
            {
                var classList = context.Classes.ToList();
            }
            return ClassList();
        }
    }
}
