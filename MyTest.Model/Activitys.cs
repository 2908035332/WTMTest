using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace MyTest.Model
{
    /// <summary>
    /// 交往记录
    /// </summary>
    public class Activitys: TopBasePoco
    {
        [Display(Name = "交往ID")]
        [Required(ErrorMessage ="不可为空")]
        public Guid ActID { get; set; }

        [Display(Name = "客户编号")]
        [Required(ErrorMessage = "不可为空")]
        public Guid CusID { get; set; }

        [Display(Name = "交往时间")]
        public DateTime? ActDate { get; set; }

        [Display(Name = "交往地点")]
        [StringLength(500,ErrorMessage ="字符长度在500之内")]
        public string ActAdd { get; set; }

        [Display(Name = "概要")]
        [StringLength(500, ErrorMessage = "字符长度在500之内")]
        public string ActTitle { get; set; }

        [Display(Name = "备注")]
        [StringLength(500, ErrorMessage = "字符长度在500之内")]
        public string ActMemo { get; set; }

        [Display(Name = "详细信息")]
        [StringLength(500, ErrorMessage = "字符长度在500之内")]
        public string ActDesc { get; set; }

    }
}
