using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;
using static MyTest.Model.EnumClass;

namespace MyTest.ViewModel.other.TableTestVMs
{
    public partial class TableTestSearcher : BaseSearcher
    {
        [Display(Name = "姓名")]
        public String Name { get; set; }
        [Display(Name = "性别")]
        public TableSexEnum? Sex { get; set; }

        protected override void InitVM()
        {
        }

    }
}
