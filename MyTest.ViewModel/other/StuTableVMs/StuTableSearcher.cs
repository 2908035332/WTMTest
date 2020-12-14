using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;
using static MyTest.Model.EnumClass;

namespace MyTest.ViewModel.other.StuTableVMs
{
    public partial class StuTableSearcher : BaseSearcher
    {
        [Display(Name = "学生姓名")]
        public String StuName { get; set; }
        [Display(Name = "学生性别")]
        public TableSexEnum? Sex { get; set; }

        protected override void InitVM()
        {
        }

    }
}
