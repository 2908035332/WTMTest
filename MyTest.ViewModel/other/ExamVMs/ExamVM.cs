using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.other.ExamVMs
{
    public partial class ExamVM : BaseCRUDVM<Exam>
    {
        public List<ComboSelectListItem> AllExam_Types { get; set; }

        public ExamVM()
        {
            SetInclude(x => x.Exam_Type);
        }

        protected override void InitVM()
        {
            AllExam_Types = DC.Set<ExamType>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.TypeName);
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
