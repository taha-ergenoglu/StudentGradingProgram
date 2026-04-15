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


        public void ClassRemove(int classId)
        {
            using (var context = new AppDbContext())
            {
                var classToBeDeleted = context.Classes.Find(classId);
                if (classToBeDeleted != null)
                {
                    DialogResult answer = MessageBox.Show($"{classId} ID numaralı sınıf silinecektir. Onaylıyor musunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (answer == DialogResult.Yes)
                    {
                        context.Classes.Remove(classToBeDeleted);
                        context.SaveChanges();
                        MessageBox.Show("Silme işlemi başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else
                {
                    MessageBox.Show($"{classId} ID numaralı bir kayıt bulunamadı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };
        }


        public void ClassList(Guna2DataGridView dataGrid)
        {
            using (var context = new AppDbContext())
            {
                var classList = context.Classes.ToList();
                dataGrid.DataSource = classList;
            }
        }
    }
}
