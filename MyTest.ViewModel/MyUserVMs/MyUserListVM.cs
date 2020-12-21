using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MyTest.Model;


namespace MyTest.ViewModel.MyUserVMs
{
    public partial class MyUserListVM : BasePagedListVM<MyUser_View, MyUserSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("MyUser", GridActionStandardTypesEnum.Create, Localizer["Create"],"", dialogWidth: 800),
                this.MakeStandardAction("MyUser", GridActionStandardTypesEnum.Edit, Localizer["Edit"], "", dialogWidth: 800),
                this.MakeStandardAction("MyUser", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "", dialogWidth: 800),
                this.MakeStandardAction("MyUser", GridActionStandardTypesEnum.Details, Localizer["Details"], "", dialogWidth: 800),
                this.MakeStandardAction("MyUser", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"], "", dialogWidth: 800),
                this.MakeStandardAction("MyUser", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"], "", dialogWidth: 800),
                this.MakeStandardAction("MyUser", GridActionStandardTypesEnum.Import, Localizer["Import"], "", dialogWidth: 800),
                this.MakeStandardAction("MyUser", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"], ""),
            };
        }

        protected override IEnumerable<IGridColumn<MyUser_View>> InitGridHeader()
        {
            return new List<GridColumn<MyUser_View>>{
                this.MakeGridHeader(x => x.ITCode),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Sex),
                this.MakeGridHeader(x => x.CellPhone),
                this.MakeGridHeader(x => x.PhotoId).SetFormat(PhotoIdFormat),
                this.MakeGridHeader(x => x.IsValid),
                this.MakeGridHeader(x => x.RoleName_view),
                this.MakeGridHeader(x => x.GroupName_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> PhotoIdFormat(MyUser_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.PhotoId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.PhotoId,640,480),
            };
        }


        public override IOrderedQueryable<MyUser_View> GetSearchQuery()
        {
            var query = DC.Set<MyUser>()
                .CheckContain(Searcher.ITCode, x=>x.ITCode)
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckEqual(Searcher.Sex, x=>x.Sex)
                .CheckContain(Searcher.CellPhone, x=>x.CellPhone)
                .CheckWhere(Searcher.SelectedUserRolesIDs,x=>DC.Set<FrameworkUserRole>().Where(y=>Searcher.SelectedUserRolesIDs.Contains(y.RoleId)).Select(z=>z.UserId).Contains(x.ID))
                .Select(x => new MyUser_View
                {
				    ID = x.ID,
                    ITCode = x.ITCode,
                    Name = x.Name,
                    Sex = x.Sex,
                    CellPhone = x.CellPhone,
                    PhotoId = x.PhotoId,
                    IsValid = x.IsValid,
                    RoleName_view = x.UserRoles.Select(y=>y.Role.RoleName).ToSpratedString(null,","), 
                    GroupName_view = x.UserGroups.Select(y=>y.Group.GroupName).ToSpratedString(null,","), 
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class MyUser_View : MyUser{
        [Display(Name = "RoleName")]
        public String RoleName_view { get; set; }
        [Display(Name = "GroupName")]
        public String GroupName_view { get; set; }

    }
}
