using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.other.TableTestVMs
{
    public partial class TableTestBatchVM : BaseBatchVM<TableTest, TableTest_BatchEdit>
    {
        public TableTestBatchVM()
        {
            ListVM = new TableTestListVM();
            LinkedVM = new TableTest_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class TableTest_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
