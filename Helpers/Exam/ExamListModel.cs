using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingProgram.Helpers.Exam
{
    public class ExamListModel
    {
        public int Id{ get; set; }
        public string ClassName{ get; set; }
        public string ExamName{ get; set; }
        public DateTime ExamDate{ get; set; }
    }
}
