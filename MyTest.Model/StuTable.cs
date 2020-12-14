using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;
using static MyTest.Model.EnumClass;

namespace MyTest.Model
{
    public class StuTable : TopBasePoco
    {
        [Display(Name = "学生编号")]
        public int ID { get; set; }

        [Display(Name = "学生姓名")]
        [Required(ErrorMessage = "学生姓名必填项")]
        [StringLength(50, ErrorMessage = "最长50字符")]
        public string StuName { get; set; }

        [Display(Name = "学生性别")]
        [Required(ErrorMessage = "性别必填项")]
        public TableSexEnum? Sex { get; set; }

        [Display(Name ="出生日期")]
        [Required(ErrorMessage = "出生日期必填项")]
        public DateTime? BirthDate { get; set; }

        public FileAttachment Photo { get; set; }
        [Display(Name = "学生照片")]
        public Guid? PhotoId { get; set; }

        [NotMapped]
        [Display(Name = "学生年龄")]
        public int Age => DateTime.Now.Year - BirthDate.Value.Year;
    }
}
