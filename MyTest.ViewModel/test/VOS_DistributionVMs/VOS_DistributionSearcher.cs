using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.test.VOS_DistributionVMs
{
    public partial class VOS_DistributionSearcher : BaseSearcher
    {
        [Display(Name = "分销分部")]
        public String DistributionName { get; set; }
        public List<ComboSelectListItem> AllParents { get; set; }
        [Display(Name = "父级")]
        public Guid? ParentID { get; set; }

        protected override void InitVM()
        {
            AllParents = DC.Set<VOS_Distribution>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.DistributionName);
        }

    }
}
