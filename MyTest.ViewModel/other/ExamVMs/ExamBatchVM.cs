using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.other.ExamVMs
{
    public partial class ExamBatchVM : BaseBatchVM<Exam, Exam_BatchEdit>
    {
        public ExamBatchVM()
        {
            ListVM = new ExamListVM();
            LinkedVM = new Exam_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Exam_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
