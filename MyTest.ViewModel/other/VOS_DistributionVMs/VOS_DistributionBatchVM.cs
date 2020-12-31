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
    public partial class VOS_DistributionBatchVM : BaseBatchVM<VOS_Distribution, VOS_Distribution_BatchEdit>
    {
        public VOS_DistributionBatchVM()
        {
            ListVM = new VOS_DistributionListVM();
            LinkedVM = new VOS_Distribution_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class VOS_Distribution_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
