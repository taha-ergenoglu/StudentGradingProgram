using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingProgram.Helpers.StudentList
{
    internal class StudentListModel
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string Surname{ get; set; }
        public string ClassName{ get; set; }
        public int ClassId{ get; set; }
    }
}
