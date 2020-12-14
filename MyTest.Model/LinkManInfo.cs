using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace MyTest.Model
{
    public class LinkManInfo : TopBasePoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int ID { get; set; }

        [Display(Name = "姓名")]
        [Required(ErrorMessage ="姓名必填项")]
        public string Name { get; set; }

        [Display(Name = "联系地址")]
        [Required(ErrorMessage = "联系地址必填项")]
        [StringLength(500,ErrorMessage ="最多500字符之内！！！")]
        public string Address { get; set; }

        [Display(Name = "联系号码")]
        [Required(ErrorMessage = "联系号码必填项")]
        [RegularExpression("^1([358][0-9]|4[579]|66|7[0135678]|9[89])[0-9]{8}$",ErrorMessage ="请输入正确的联系号码")]
        public string Phone { get; set; }

        [Display(Name = "电子邮件")]
        [RegularExpression("/^[a-z]([a-z0-9]*[-_]?[a-z0-9]+)*@([a-z0-9]*[-_]?[a-z0-9]+)+[\\.][a-z]{2,3}([\\.][a-z]{2})?$/i", ErrorMessage = "请输入正确的电子邮件")]
        public string Email { get; set; }


        [Display(Name = "联系人类型")]
        public LinkManType ManType { get; set; }

        [Display(Name = "联系人类型")]
        public int ManTypeID { get; set; }
    }
}
