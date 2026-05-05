using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingProgram.Model
{
    internal class Exam
    {
        public int Id { get; set; }
        public int ClassId{ get; set; }
        public Class Class{ get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public ICollection<ExamScore> ExamScores{ get; set; }
        public ICollection<ExamTableColumnsHeading> ExamTableColumnsHeadings { get; set; }
    }
}
