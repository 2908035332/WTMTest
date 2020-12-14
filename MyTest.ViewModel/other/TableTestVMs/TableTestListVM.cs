using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MyTest.Model;


namespace MyTest.ViewModel.other.TableTestVMs
{
    public partial class TableTestListVM : BasePagedListVM<TableTest_View, TableTestSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("TableTest", GridActionStandardTypesEnum.Create, Localizer["Create"],"other", dialogWidth: 800),
                this.MakeStandardAction("TableTest", GridActionStandardTypesEnum.Edit, Localizer["Edit"], "other", dialogWidth: 800),
                this.MakeStandardAction("TableTest", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "other", dialogWidth: 800),
                this.MakeStandardAction("TableTest", GridActionStandardTypesEnum.Details, Localizer["Details"], "other", dialogWidth: 800),
                this.MakeStandardAction("TableTest", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"], "other", dialogWidth: 800),
                this.MakeStandardAction("TableTest", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"], "other", dialogWidth: 800),
                this.MakeStandardAction("TableTest", GridActionStandardTypesEnum.Import, Localizer["Import"], "other", dialogWidth: 800),
                this.MakeStandardAction("TableTest", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"], "other"),
            };
        }


        protected override IEnumerable<IGridColumn<TableTest_View>> InitGridHeader()
        {
            return new List<GridColumn<TableTest_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Sex),
                this.MakeGridHeader(x => x.Birthday),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<TableTest_View> GetSearchQuery()
        {
            var query = DC.Set<TableTest>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckEqual(Searcher.Sex, x=>x.Sex)
                .Select(x => new TableTest_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    Sex = x.Sex,
                    Birthday = x.Birthday,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class TableTest_View : TableTest{

    }
}
