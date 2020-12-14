using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MyTest.Model;


namespace MyTest.ViewModel.other.LinkManTypeVMs
{
    public partial class LinkManTypeListVM : BasePagedListVM<LinkManType_View, LinkManTypeSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("LinkManType", GridActionStandardTypesEnum.Create, Localizer["Create"],"other", dialogWidth: 800),
                this.MakeStandardAction("LinkManType", GridActionStandardTypesEnum.Edit, Localizer["Edit"], "other", dialogWidth: 800),
                this.MakeStandardAction("LinkManType", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "other", dialogWidth: 800),
                this.MakeStandardAction("LinkManType", GridActionStandardTypesEnum.Details, Localizer["Details"], "other", dialogWidth: 800),
                this.MakeStandardAction("LinkManType", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"], "other", dialogWidth: 800),
                this.MakeStandardAction("LinkManType", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"], "other", dialogWidth: 800),
                this.MakeStandardAction("LinkManType", GridActionStandardTypesEnum.Import, Localizer["Import"], "other", dialogWidth: 800),
                this.MakeStandardAction("LinkManType", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"], "other"),
            };
        }


        protected override IEnumerable<IGridColumn<LinkManType_View>> InitGridHeader()
        {
            return new List<GridColumn<LinkManType_View>>{
                this.MakeGridHeader(x => x.TypeName),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<LinkManType_View> GetSearchQuery()
        {
            var query = DC.Set<LinkManType>()
                .CheckContain(Searcher.TypeName, x=>x.TypeName)
                .Select(x => new LinkManType_View
                {
				    ID = x.ID,
                    TypeName = x.TypeName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class LinkManType_View : LinkManType{

    }
}
