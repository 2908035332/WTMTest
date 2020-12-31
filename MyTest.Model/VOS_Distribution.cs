using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace MyTest.Model
{
    public class VOS_Distribution : PersistPoco
    {
        [Display(Name = "分销分部")]
        [Required(ErrorMessage = "不可为空")]
        [StringLength(50, ErrorMessage = "字符在50以内")]
        public string DistributionName { get; set; }

        public List<VOS_Distribution> Children { get; set; }
        [Display(Name = "父级")]
        public VOS_Distribution Parent { get; set; }
        [Display(Name = "父级")]
        public Guid? ParentID { get; set; }
    }
}
