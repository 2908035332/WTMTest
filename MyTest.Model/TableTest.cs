using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace MyTest.Model
{
    public enum TableTestSexEnum
    {
        女 = 0, 男 = 1
    }
    public class TableTest : TopBasePoco
    {
        [Key]
        [Display(Name = "编号")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名不能为空")]
        [StringLength(20, ErrorMessage = "姓名字符不能超过20")]
        public string Name { get; set; }

        [Display(Name = "性别")]
        public TableTestSexEnum Sex { get; set; }

        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }

        [NotMapped]
        [Display(Name = "年龄")]
        public int Age => DateTime.Now.Year - Birthday.Year;
    }
}
