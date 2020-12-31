using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.other.VOS_DistributionVMs
{
    public partial class VOS_DistributionTemplateVM : BaseTemplateVM
    {
        [Display(Name = "分销分部")]
        public ExcelPropety DName_Excel = ExcelPropety.CreateProperty<VOS_Distribution>(x => x.DName);

	    protected override void InitVM()
        {
        }

    }

    public class VOS_DistributionImportVM : BaseImportVM<VOS_DistributionTemplateVM, VOS_Distribution>
    {

    }

}
