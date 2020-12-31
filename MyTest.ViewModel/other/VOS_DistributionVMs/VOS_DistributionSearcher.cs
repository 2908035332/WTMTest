using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.other.VOS_DistributionVMs
{
    public partial class VOS_DistributionSearcher : BaseSearcher
    {
        [Display(Name = "分销分部")]
        public String DName { get; set; }

        protected override void InitVM()
        {
        }

    }
}
