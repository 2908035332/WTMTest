using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.MyUserVMs
{
    public partial class MyUserTemplateVM : BaseTemplateVM
    {
        [Display(Name = "分销分部")]
        public ExcelPropety Distribution_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.DistributionID);
        [Display(Name = "Account")]
        public ExcelPropety ITCode_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.ITCode);
        [Display(Name = "Email")]
        public ExcelPropety Email_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.Email);
        [Display(Name = "Name")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.Name);
        [Display(Name = "Sex")]
        public ExcelPropety Sex_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.Sex);
        [Display(Name = "CellPhone")]
        public ExcelPropety CellPhone_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.CellPhone);
        [Display(Name = "HomePhone")]
        public ExcelPropety HomePhone_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.HomePhone);
        [Display(Name = "Address")]
        public ExcelPropety Address_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.Address);
        [Display(Name = "IsValid")]
        public ExcelPropety IsValid_Excel = ExcelPropety.CreateProperty<MyUser>(x => x.IsValid);

	    protected override void InitVM()
        {
            Distribution_Excel.DataType = ColumnDataType.ComboBox;
            Distribution_Excel.ListItems = DC.Set<VOS_Distribution>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.DistributionName);
        }

    }

    public class MyUserImportVM : BaseImportVM<MyUserTemplateVM, MyUser>
    {

    }

}
