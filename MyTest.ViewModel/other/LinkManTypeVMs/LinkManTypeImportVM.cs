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
    public partial class LinkManTypeTemplateVM : BaseTemplateVM
    {
        [Display(Name = "联系人类型名称")]
        public ExcelPropety TypeName_Excel = ExcelPropety.CreateProperty<LinkManType>(x => x.TypeName);

	    protected override void InitVM()
        {
        }

    }

    public class LinkManTypeImportVM : BaseImportVM<LinkManTypeTemplateVM, LinkManType>
    {

    }

}
