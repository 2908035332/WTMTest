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
    public partial class ExamTypeTemplateVM : BaseTemplateVM
    {
        [Display(Name = "试题类型")]
        public ExcelPropety TypeName_Excel = ExcelPropety.CreateProperty<ExamType>(x => x.TypeName);

	    protected override void InitVM()
        {
        }

    }

    public class ExamTypeImportVM : BaseImportVM<ExamTypeTemplateVM, ExamType>
    {

    }

}
