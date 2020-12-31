using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MyTest.Model;


namespace MyTest.ViewModel.other.VOS_DistributionVMs
{
    public partial class VOS_DistributionListVM : BasePagedListVM<VOS_Distribution_View, VOS_DistributionSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("VOS_Distribution", GridActionStandardTypesEnum.Create, Localizer["Create"],"other", dialogWidth: 800),
                this.MakeStandardAction("VOS_Distribution", GridActionStandardTypesEnum.Edit, Localizer["Edit"], "other", dialogWidth: 800),
                this.MakeStandardAction("VOS_Distribution", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "other", dialogWidth: 800),
                this.MakeStandardAction("VOS_Distribution", GridActionStandardTypesEnum.Details, Localizer["Details"], "other", dialogWidth: 800),
                this.MakeStandardAction("VOS_Distribution", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"], "other", dialogWidth: 800),
                this.MakeStandardAction("VOS_Distribution", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"], "other", dialogWidth: 800),
                this.MakeStandardAction("VOS_Distribution", GridActionStandardTypesEnum.Import, Localizer["Import"], "other", dialogWidth: 800),
                this.MakeStandardAction("VOS_Distribution", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"], "other"),
            };
        }


        protected override IEnumerable<IGridColumn<VOS_Distribution_View>> InitGridHeader()
        {
            return new List<GridColumn<VOS_Distribution_View>>{
                this.MakeGridHeader(x => x.DName),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<VOS_Distribution_View> GetSearchQuery()
        {
            var query = DC.Set<VOS_Distribution>()
                .CheckContain(Searcher.DName, x=>x.DName)
                .Select(x => new VOS_Distribution_View
                {
				    ID = x.ID,
                    DName = x.DName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class VOS_Distribution_View : VOS_Distribution{

    }
}
