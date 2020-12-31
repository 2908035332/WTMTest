using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using MyTest.Model;


namespace MyTest.ViewModel.MyUserVMs
{
    public partial class MyUserBatchVM : BaseBatchVM<MyUser, MyUser_BatchEdit>
    {
        public MyUserBatchVM()
        {
            ListVM = new MyUserListVM();
            LinkedVM = new MyUser_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class MyUser_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
