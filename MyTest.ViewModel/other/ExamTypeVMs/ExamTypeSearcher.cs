using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.other.ExamTypeVMs
{
    public partial class ExamTypeSearcher : BaseSearcher
    {
        [Display(Name = "试题类型")]
        public String TypeName { get; set; }

        protected override void InitVM()
        {
        }

    }
}
