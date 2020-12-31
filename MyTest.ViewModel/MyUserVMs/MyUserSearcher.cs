using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.MyUserVMs
{
    public partial class MyUserSearcher : BaseSearcher
    {
        public List<ComboSelectListItem> AllDistributions { get; set; }
        [Display(Name = "分销分部")]
        public Guid? DistributionID { get; set; }
        [Display(Name = "Account")]
        public String ITCode { get; set; }
        [Display(Name = "Name")]
        public String Name { get; set; }
        [Display(Name = "IsValid")]
        public Boolean? IsValid { get; set; }

        protected override void InitVM()
        {
            AllDistributions = DC.Set<VOS_Distribution>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.DistributionName);
        }

    }
}
