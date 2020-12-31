using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace MyTest.Model
{
    [Table("FrameworkUsers")]
    public class MyUser: FrameworkUserBase
    {
        [Display(Name = "分销分部")]
        public Guid DistrID { get; set; }

        [Display(Name = "分销分部")]
        public VOS_Distribution Distribution { get; set; }
    }
}
