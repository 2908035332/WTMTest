using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.other.LinkManInfoVMs
{
    public partial class LinkManInfoVM : BaseCRUDVM<LinkManInfo>
    {
        public List<ComboSelectListItem> AllManTypes { get; set; }

        public LinkManInfoVM()
        {
            SetInclude(x => x.ManType);
        }

        protected override void InitVM()
        {
            AllManTypes = DC.Set<LinkManType>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.TypeName);
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
