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
    public partial class MyUserSearcher : BaseSearcher
    {
        [Display(Name = "Account")]
        public String ITCode { get; set; }
        [Display(Name = "Name")]
        public String Name { get; set; }
        [Display(Name = "Sex")]
        public SexEnum? Sex { get; set; }
        [Display(Name = "CellPhone")]
        public String CellPhone { get; set; }
        public List<ComboSelectListItem> AllUserRoless { get; set; }
        [Display(Name = "Role")]
        public List<Guid> SelectedUserRolesIDs { get; set; }

        protected override void InitVM()
        {
            AllUserRoless = DC.Set<FrameworkRole>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.RoleName);
        }

    }
}
