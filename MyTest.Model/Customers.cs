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
    /// 客户状态
    /// </summary>
    public enum CusState
    {
        正常 = 1,
        流失 = 2,
    }

    /// <summary>
    /// 客户信息
    /// </summary>
    public class Customers : TopBasePoco
    {
        [Display(Name = "客户编号")]
        public Guid CusID { get; set; }
        [Display(Name = "客户经理编号")]
        public int? UserID { get; set; }
        [Display(Name = "客户姓名")]
        [Required(ErrorMessage = "客户姓名必填")]
        public string CusName { get; set; }
        [Display(Name = "地址")]
        [StringLength(500, ErrorMessage = "填写地址过长")]
        public string CusAddress { get; set; }
        [Display(Name = "邮编")]
        public string CusZip { get; set; }
        [Display(Name = "传真")]
        public string CusFax { get; set; }
        [Display(Name = "网址")]
        [RegularExpression("[a-zA-z]+://[^\\s]*", ErrorMessage = "填写网址不正确")]
        public string CusWebsite { get; set; }
        [Display(Name = "营业执照注册号")]
        [Required(ErrorMessage = "必填")]
        public string CusLicenceNo { get; set; }

        [Display(Name = "法人")]
        [Required(ErrorMessage = "必填")]
        public string CusChieftain { get; set; }
        [Display(Name = "注册资金")]
        public int? CusBankroll { get; set; }
        [Display(Name = "年营业额")]
        public int? CusTurnover { get; set; }
        [Display(Name = "开户银行")]
        [Required(ErrorMessage = "必填")]
        public string CusBank { get; set; }
        [Display(Name = "银行账号")]
        [Required(ErrorMessage = "必填")]
        public string CusBankNo { get; set; }
        [Display(Name = "地税登记号")]
        public string CusLocalTaxNo { get; set; }
        [Display(Name = "国税登记号")]
        public string CusNationalTaxNo { get; set; }
        [Display(Name = "建立时间")]
        public DateTime? CusDate { get; set; }
        [Display(Name = "客户状态")]
        public CusState CusState { get; set; }

        [Display(Name = "交往记录")]
        public Guid ActID { get; set; }

        [Display(Name = "交往记录")]
        public Activitys Activitys { get; set; }
    }
}
