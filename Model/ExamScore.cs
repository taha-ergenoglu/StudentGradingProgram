using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingProgram.Model
{
    internal class ExamScore
    {
        public int Id{ get; set; }
        public int StudentID{ get; set; }
        public Student? Student { get; set; }

        public int ExamId{ get; set; }
        public Exam Exam{ get; set; }
        public decimal? Score1{ get; set; }
        public decimal? Score2{ get; set; }
        public decimal? Score3{ get; set; }
        public decimal? Score4{ get; set; }
        public decimal? Score5 { get; set; }
        public decimal? TotalScore { get; set; }
    }
}
