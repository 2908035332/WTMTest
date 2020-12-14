using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.other.LinkManTypeVMs
{
    public partial class LinkManTypeBatchVM : BaseBatchVM<LinkManType, LinkManType_BatchEdit>
    {
        public LinkManTypeBatchVM()
        {
            ListVM = new LinkManTypeListVM();
            LinkedVM = new LinkManType_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class LinkManType_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
