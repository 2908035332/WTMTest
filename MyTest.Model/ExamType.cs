using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace MyTest.Model
{
    public class ExamType: TopBasePoco
    {
        [Display(Name ="试题类型")]
        [Required(ErrorMessage = "必填项")]
        public string TypeName { get; set; }

    }
}
