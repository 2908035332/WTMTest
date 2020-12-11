using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MyTest.Model;


namespace MyTest.ViewModel.other.ExamVMs
{
    public partial class ExamListVM : BasePagedListVM<Exam_View, ExamSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Exam", GridActionStandardTypesEnum.Create, Localizer["Create"],"other", dialogWidth: 800),
                this.MakeStandardAction("Exam", GridActionStandardTypesEnum.Edit, Localizer["Edit"], "other", dialogWidth: 800),
                this.MakeStandardAction("Exam", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "other", dialogWidth: 800),
                this.MakeStandardAction("Exam", GridActionStandardTypesEnum.Details, Localizer["Details"], "other", dialogWidth: 800),
                this.MakeStandardAction("Exam", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"], "other", dialogWidth: 800),
                this.MakeStandardAction("Exam", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"], "other", dialogWidth: 800),
                this.MakeStandardAction("Exam", GridActionStandardTypesEnum.Import, Localizer["Import"], "other", dialogWidth: 800),
                this.MakeStandardAction("Exam", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"], "other"),
            };
        }


        protected override IEnumerable<IGridColumn<Exam_View>> InitGridHeader()
        {
            return new List<GridColumn<Exam_View>>{
                this.MakeGridHeader(x => x.Exam_Name),
                this.MakeGridHeader(x => x.Exam_A),
                this.MakeGridHeader(x => x.Exam_B),
                this.MakeGridHeader(x => x.Exam_C),
                this.MakeGridHeader(x => x.Exam_D),
                this.MakeGridHeader(x => x.TypeName_view),
                this.MakeGridHeader(x => x.TrueEnum),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Exam_View> GetSearchQuery()
        {
            var query = DC.Set<Exam>()
                .CheckContain(Searcher.Exam_Name, x=>x.Exam_Name)
                .CheckEqual(Searcher.Exam_TypeId, x=>x.Exam_TypeId)
                .Select(x => new Exam_View
                {
				    ID = x.ID,
                    Exam_Name = x.Exam_Name,
                    Exam_A = x.Exam_A,
                    Exam_B = x.Exam_B,
                    Exam_C = x.Exam_C,
                    Exam_D = x.Exam_D,
                    TypeName_view = x.Exam_Type.TypeName,
                    TrueEnum = x.TrueEnum,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Exam_View : Exam{
        [Display(Name = "试题类型")]
        public String TypeName_view { get; set; }

    }
}
