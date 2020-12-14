using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.other.StuTableVMs
{
    public partial class StuTableBatchVM : BaseBatchVM<StuTable, StuTable_BatchEdit>
    {
        public StuTableBatchVM()
        {
            ListVM = new StuTableListVM();
            LinkedVM = new StuTable_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class StuTable_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
