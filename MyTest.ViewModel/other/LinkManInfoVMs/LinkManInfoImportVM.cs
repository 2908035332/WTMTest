using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.other.LinkManInfoVMs
{
    public partial class LinkManInfoTemplateVM : BaseTemplateVM
    {
        [Display(Name = "姓名")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<LinkManInfo>(x => x.Name);
        [Display(Name = "联系地址")]
        public ExcelPropety Address_Excel = ExcelPropety.CreateProperty<LinkManInfo>(x => x.Address);
        [Display(Name = "联系号码")]
        public ExcelPropety Phone_Excel = ExcelPropety.CreateProperty<LinkManInfo>(x => x.Phone);
        [Display(Name = "电子邮件")]
        public ExcelPropety Email_Excel = ExcelPropety.CreateProperty<LinkManInfo>(x => x.Email);
        [Display(Name = "联系人类型")]
        public ExcelPropety ManType_Excel = ExcelPropety.CreateProperty<LinkManInfo>(x => x.ManTypeID);

	    protected override void InitVM()
        {
            ManType_Excel.DataType = ColumnDataType.ComboBox;
            ManType_Excel.ListItems = DC.Set<LinkManType>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.TypeName);
        }

    }

    public class LinkManInfoImportVM : BaseImportVM<LinkManInfoTemplateVM, LinkManInfo>
    {

    }

}
