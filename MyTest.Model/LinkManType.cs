using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace MyTest.Model
{
    public class LinkManType : TopBasePoco
    {
        public LinkManType() {
            LinkManInfos = new List<LinkManInfo>();
        }
        [Display(Name = "联系人类型编号")]
        public new int ID { get; set; }

        [Display(Name = "联系人类型名称")]
        [Required(ErrorMessage ="必填项")]
        [StringLength(20,ErrorMessage ="最多20个字符")]
        public string TypeName { get; set; }

        [Display(Name ="联系")]
        public List<LinkManInfo> LinkManInfos { get; set; }
    }
}
