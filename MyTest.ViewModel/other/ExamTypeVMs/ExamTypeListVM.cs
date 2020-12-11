using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MyTest.Model;


namespace MyTest.ViewModel.other.ExamTypeVMs
{
    public partial class ExamTypeListVM : BasePagedListVM<ExamType_View, ExamTypeSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("ExamType", GridActionStandardTypesEnum.Create, Localizer["Create"],"other", dialogWidth: 800),
                this.MakeStandardAction("ExamType", GridActionStandardTypesEnum.Edit, Localizer["Edit"], "other", dialogWidth: 800),
                this.MakeStandardAction("ExamType", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "other", dialogWidth: 800),
                this.MakeStandardAction("ExamType", GridActionStandardTypesEnum.Details, Localizer["Details"], "other", dialogWidth: 800),
                this.MakeStandardAction("ExamType", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"], "other", dialogWidth: 800),
                this.MakeStandardAction("ExamType", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"], "other", dialogWidth: 800),
                this.MakeStandardAction("ExamType", GridActionStandardTypesEnum.Import, Localizer["Import"], "other", dialogWidth: 800),
                this.MakeStandardAction("ExamType", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"], "other"),
            };
        }


        protected override IEnumerable<IGridColumn<ExamType_View>> InitGridHeader()
        {
            return new List<GridColumn<ExamType_View>>{
                this.MakeGridHeader(x => x.TypeName),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ExamType_View> GetSearchQuery()
        {
            var query = DC.Set<ExamType>()
                .CheckContain(Searcher.TypeName, x=>x.TypeName)
                .Select(x => new ExamType_View
                {
				    ID = x.ID,
                    TypeName = x.TypeName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class ExamType_View : ExamType{

    }
}
