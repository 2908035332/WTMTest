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
    public partial class LinkManInfoSearcher : BaseSearcher
    {
        [Display(Name = "姓名")]
        public String Name { get; set; }
        [Display(Name = "联系地址")]
        public String Address { get; set; }
        [Display(Name = "联系号码")]
        public String Phone { get; set; }
        public List<ComboSelectListItem> AllManTypes { get; set; }
        [Display(Name = "联系人类型")]
        public int? ManTypeID { get; set; }

        protected override void InitVM()
        {
            AllManTypes = DC.Set<LinkManType>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.TypeName);
        }

    }
}
