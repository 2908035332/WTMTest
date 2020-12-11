using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;


namespace MyTest.Model
{
    public class Exam : TopBasePoco
    {
        [Display(Name = "试题名编号")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new  int ID { get; set; }

        [Display(Name ="试题名")]
        [Required(ErrorMessage ="必填项")]
        public string Exam_Name { get; set; }

        [Display(Name ="答案A")]
        [Required(ErrorMessage = "必填项")]
        public string Exam_A { get; set; }

        [Display(Name = "答案B")]
        [Required(ErrorMessage = "必填项")]
        public string Exam_B { get; set; }

        [Display(Name = "答案C")]
        [Required(ErrorMessage = "必填项")]
        public string Exam_C { get; set; }

        [Display(Name = "答案D")]
        [Required(ErrorMessage = "必填项")]
        public string Exam_D { get; set; }

        [Display(Name = "试题类型")]
        public ExamType Exam_Type { get; set; }

        [Display(Name = "试题类型")]
        public Guid Exam_TypeId { get; set; }

        [Display(Name = "正确答案")]
        [Required(ErrorMessage = "必填项")]
        public string Exam_True { get; set; }
    }
}
