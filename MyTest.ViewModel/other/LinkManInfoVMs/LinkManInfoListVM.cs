using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MyTest.Model;


namespace MyTest.ViewModel.other.LinkManInfoVMs
{
    public partial class LinkManInfoListVM : BasePagedListVM<LinkManInfo_View, LinkManInfoSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("LinkManInfo", GridActionStandardTypesEnum.Create, Localizer["Create"],"other", dialogWidth: 800),
                this.MakeStandardAction("LinkManInfo", GridActionStandardTypesEnum.Edit, Localizer["Edit"], "other", dialogWidth: 800),
                this.MakeStandardAction("LinkManInfo", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "other", dialogWidth: 800),
                this.MakeStandardAction("LinkManInfo", GridActionStandardTypesEnum.Details, Localizer["Details"], "other", dialogWidth: 800),
                this.MakeStandardAction("LinkManInfo", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"], "other", dialogWidth: 800),
                this.MakeStandardAction("LinkManInfo", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"], "other", dialogWidth: 800),
                this.MakeStandardAction("LinkManInfo", GridActionStandardTypesEnum.Import, Localizer["Import"], "other", dialogWidth: 800),
                this.MakeStandardAction("LinkManInfo", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"], "other"),
            };
        }


        protected override IEnumerable<IGridColumn<LinkManInfo_View>> InitGridHeader()
        {
            return new List<GridColumn<LinkManInfo_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Address),
                this.MakeGridHeader(x => x.Phone),
                this.MakeGridHeader(x => x.Email),
                this.MakeGridHeader(x => x.TypeName_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<LinkManInfo_View> GetSearchQuery()
        {
            var query = DC.Set<LinkManInfo>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckContain(Searcher.Address, x=>x.Address)
                .CheckContain(Searcher.Phone, x=>x.Phone)
                .CheckEqual(Searcher.ManTypeID, x=>x.ManTypeID)
                .Select(x => new LinkManInfo_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    Address = x.Address,
                    Phone = x.Phone,
                    Email = x.Email,
                    TypeName_view = x.ManType.TypeName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class LinkManInfo_View : LinkManInfo{
        [Display(Name = "联系人类型名称")]
        public String TypeName_view { get; set; }

    }
}
