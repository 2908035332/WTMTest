using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.other.ExamVMs
{
    public partial class ExamTemplateVM : BaseTemplateVM
    {
        [Display(Name = "试题名")]
        public ExcelPropety Exam_Name_Excel = ExcelPropety.CreateProperty<Exam>(x => x.Exam_Name);
        [Display(Name = "答案A")]
        public ExcelPropety Exam_A_Excel = ExcelPropety.CreateProperty<Exam>(x => x.Exam_A);
        [Display(Name = "答案B")]
        public ExcelPropety Exam_B_Excel = ExcelPropety.CreateProperty<Exam>(x => x.Exam_B);
        [Display(Name = "答案C")]
        public ExcelPropety Exam_C_Excel = ExcelPropety.CreateProperty<Exam>(x => x.Exam_C);
        [Display(Name = "答案D")]
        public ExcelPropety Exam_D_Excel = ExcelPropety.CreateProperty<Exam>(x => x.Exam_D);
        [Display(Name = "试题类型")]
        public ExcelPropety Exam_Type_Excel = ExcelPropety.CreateProperty<Exam>(x => x.Exam_TypeId);
        [Display(Name = "正确答案")]
        public ExcelPropety TrueEnum_Excel = ExcelPropety.CreateProperty<Exam>(x => x.TrueEnum);

	    protected override void InitVM()
        {
            Exam_Type_Excel.DataType = ColumnDataType.ComboBox;
            Exam_Type_Excel.ListItems = DC.Set<ExamType>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.TypeName);
        }

    }

    public class ExamImportVM : BaseImportVM<ExamTemplateVM, Exam>
    {

    }

}
