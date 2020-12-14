using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.other.LinkManInfoVMs
{
    public partial class LinkManInfoBatchVM : BaseBatchVM<LinkManInfo, LinkManInfo_BatchEdit>
    {
        public LinkManInfoBatchVM()
        {
            ListVM = new LinkManInfoListVM();
            LinkedVM = new LinkManInfo_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class LinkManInfo_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
