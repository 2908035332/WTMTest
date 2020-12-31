using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.test.VOS_DistributionVMs
{
    public partial class VOS_DistributionTemplateVM : BaseTemplateVM
    {
        [Display(Name = "分销分部")]
        public ExcelPropety DistributionName_Excel = ExcelPropety.CreateProperty<VOS_Distribution>(x => x.DistributionName);
        [Display(Name = "父级")]
        public ExcelPropety Parent_Excel = ExcelPropety.CreateProperty<VOS_Distribution>(x => x.ParentID);

	    protected override void InitVM()
        {
            Parent_Excel.DataType = ColumnDataType.ComboBox;
            Parent_Excel.ListItems = DC.Set<VOS_Distribution>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.DistributionName);
        }

    }

    public class VOS_DistributionImportVM : BaseImportVM<VOS_DistributionTemplateVM, VOS_Distribution>
    {

    }

}
