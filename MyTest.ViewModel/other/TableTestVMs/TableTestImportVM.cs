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
    public partial class TableTestTemplateVM : BaseTemplateVM
    {
        [Display(Name = "姓名")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<TableTest>(x => x.Name);
        [Display(Name = "性别")]
        public ExcelPropety Sex_Excel = ExcelPropety.CreateProperty<TableTest>(x => x.Sex);
        [Display(Name = "生日")]
        public ExcelPropety Birthday_Excel = ExcelPropety.CreateProperty<TableTest>(x => x.Birthday);

	    protected override void InitVM()
        {
        }

    }

    public class TableTestImportVM : BaseImportVM<TableTestTemplateVM, TableTest>
    {

    }

}
