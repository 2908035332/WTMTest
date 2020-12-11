using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.other.ExamTypeVMs
{
    public partial class ExamTypeBatchVM : BaseBatchVM<ExamType, ExamType_BatchEdit>
    {
        public ExamTypeBatchVM()
        {
            ListVM = new ExamTypeListVM();
            LinkedVM = new ExamType_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class ExamType_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
