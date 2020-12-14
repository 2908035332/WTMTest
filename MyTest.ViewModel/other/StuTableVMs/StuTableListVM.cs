using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MyTest.Model;


namespace MyTest.ViewModel.other.StuTableVMs
{
    public partial class StuTableListVM : BasePagedListVM<StuTable_View, StuTableSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("StuTable", GridActionStandardTypesEnum.Create, Localizer["Create"],"other", dialogWidth: 800),
                this.MakeStandardAction("StuTable", GridActionStandardTypesEnum.Edit, Localizer["Edit"], "other", dialogWidth: 800),
                this.MakeStandardAction("StuTable", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "other", dialogWidth: 800),
                this.MakeStandardAction("StuTable", GridActionStandardTypesEnum.Details, Localizer["Details"], "other", dialogWidth: 800),
                this.MakeStandardAction("StuTable", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"], "other", dialogWidth: 800),
                this.MakeStandardAction("StuTable", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"], "other", dialogWidth: 800),
                this.MakeStandardAction("StuTable", GridActionStandardTypesEnum.Import, Localizer["Import"], "other", dialogWidth: 800),
                this.MakeStandardAction("StuTable", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"], "other"),
            };
        }


        protected override IEnumerable<IGridColumn<StuTable_View>> InitGridHeader()
        {
            return new List<GridColumn<StuTable_View>>{
                this.MakeGridHeader(x => x.StuName),
                this.MakeGridHeader(x => x.Sex),
                this.MakeGridHeader(x => x.BirthDate),
                this.MakeGridHeader(x => x.PhotoId).SetFormat(PhotoIdFormat),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> PhotoIdFormat(StuTable_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.PhotoId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.PhotoId,640,480),
            };
        }


        public override IOrderedQueryable<StuTable_View> GetSearchQuery()
        {
            var query = DC.Set<StuTable>()
                .CheckContain(Searcher.StuName, x=>x.StuName)
                .CheckEqual(Searcher.Sex, x=>x.Sex)
                .Select(x => new StuTable_View
                {
				    ID = x.ID,
                    StuName = x.StuName,
                    Sex = x.Sex,
                    BirthDate = x.BirthDate,
                    PhotoId = x.PhotoId,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class StuTable_View : StuTable{

    }
}
