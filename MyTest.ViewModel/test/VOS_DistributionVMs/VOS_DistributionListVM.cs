using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MyTest.Model;


namespace MyTest.ViewModel.test.VOS_DistributionVMs
{
    public partial class VOS_DistributionListVM : BasePagedListVM<VOS_Distribution_View, VOS_DistributionSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("VOS_Distribution", GridActionStandardTypesEnum.Create, Localizer["Create"],"test", dialogWidth: 800),
                this.MakeStandardAction("VOS_Distribution", GridActionStandardTypesEnum.Edit, Localizer["Edit"], "test", dialogWidth: 800),
                this.MakeStandardAction("VOS_Distribution", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "test", dialogWidth: 800),
                this.MakeStandardAction("VOS_Distribution", GridActionStandardTypesEnum.Details, Localizer["Details"], "test", dialogWidth: 800),
                this.MakeStandardAction("VOS_Distribution", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"], "test", dialogWidth: 800),
                this.MakeStandardAction("VOS_Distribution", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"], "test", dialogWidth: 800),
                this.MakeStandardAction("VOS_Distribution", GridActionStandardTypesEnum.Import, Localizer["Import"], "test", dialogWidth: 800),
                this.MakeStandardAction("VOS_Distribution", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"], "test"),
            };
        }


        protected override IEnumerable<IGridColumn<VOS_Distribution_View>> InitGridHeader()
        {
            return new List<GridColumn<VOS_Distribution_View>>{
                this.MakeGridHeader(x => x.DistributionName),
                this.MakeGridHeader(x => x.DistributionName_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<VOS_Distribution_View> GetSearchQuery()
        {
            var query = DC.Set<VOS_Distribution>()
                .CheckContain(Searcher.DistributionName, x=>x.DistributionName)
                .CheckEqual(Searcher.ParentID, x=>x.ParentID)
                .Select(x => new VOS_Distribution_View
                {
				    ID = x.ID,
                    DistributionName = x.DistributionName,
                    DistributionName_view = x.Parent.DistributionName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class VOS_Distribution_View : VOS_Distribution{
        [Display(Name = "分销分部")]
        public String DistributionName_view { get; set; }

    }
}
