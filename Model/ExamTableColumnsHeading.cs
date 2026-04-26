using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradingProgram.Model
{
    internal class ExamTableColumnsHeading
    {
        public int Id { get; set; }
        public int ExamId { get; set; }

        public string Header1Name { get; set; }
        public string Header2Name { get; set; }
        public string Header3Name { get; set; }
        public string Header4Name { get; set; }
        public string Header5Name { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
