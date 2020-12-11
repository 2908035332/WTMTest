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
    public partial class ExamSearcher : BaseSearcher
    {
        [Display(Name = "试题名")]
        public String Exam_Name { get; set; }
        public List<ComboSelectListItem> AllExam_Types { get; set; }
        [Display(Name = "试题类型")]
        public Guid? Exam_TypeId { get; set; }

        protected override void InitVM()
        {
            AllExam_Types = DC.Set<ExamType>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.TypeName);
        }

    }
}
