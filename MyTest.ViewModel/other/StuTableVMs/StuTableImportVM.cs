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
    public partial class StuTableTemplateVM : BaseTemplateVM
    {
        [Display(Name = "学生姓名")]
        public ExcelPropety StuName_Excel = ExcelPropety.CreateProperty<StuTable>(x => x.StuName);
        [Display(Name = "学生性别")]
        public ExcelPropety Sex_Excel = ExcelPropety.CreateProperty<StuTable>(x => x.Sex);
        [Display(Name = "出生日期")]
        public ExcelPropety BirthDate_Excel = ExcelPropety.CreateProperty<StuTable>(x => x.BirthDate);

	    protected override void InitVM()
        {
        }

    }

    public class StuTableImportVM : BaseImportVM<StuTableTemplateVM, StuTable>
    {

    }

}
