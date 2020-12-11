using System;
using WalkingTec.Mvvm.Core.Attributes;

namespace MyTest.Model
{
    [MiddleTable]
    public class ExamExamType
    {
        public Exam Exam { get; set; }
        public int ExamId { get; set; }


        public ExamType ExamType { get; set; }

        public Guid ExamTypeId { get; set; }
    }
}
