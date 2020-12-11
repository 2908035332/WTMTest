using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace MyTest.Model
{
    public class T3: TopBasePoco
    {
        [Display(Name = "名称")]
        public string MyProperty { get; set; }
    }
}
