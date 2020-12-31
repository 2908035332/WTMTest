using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using MyTest.Controllers;
using MyTest.ViewModel.MyUserVMs;
using MyTest.Model;
using MyTest.DataAccess;

namespace MyTest.Test
{
    [TestClass]
    public class MyUserControllerTest
    {
        private MyUserController _controller;
        private string _seed;

        public MyUserControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<MyUserController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as MyUserListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(MyUserVM));

            MyUserVM vm = rv.Model as MyUserVM;
            MyUser v = new MyUser();
			
            v.DistributionID = AddDistribution();
            v.ITCode = "pz5gQi8";
            v.Password = "YIGkKK";
            v.Name = "FptmSv3O";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<MyUser>().FirstOrDefault();
				
                Assert.AreEqual(data.ITCode, "pz5gQi8");
                Assert.AreEqual(data.Password, "YIGkKK");
                Assert.AreEqual(data.Name, "FptmSv3O");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            MyUser v = new MyUser();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.DistributionID = AddDistribution();
                v.ITCode = "pz5gQi8";
                v.Password = "YIGkKK";
                v.Name = "FptmSv3O";
                context.Set<MyUser>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(MyUserVM));

            MyUserVM vm = rv.Model as MyUserVM;
            v = new MyUser();
            v.ID = vm.Entity.ID;
       		
            v.ITCode = "c0w34jx";
            v.Password = "uonqtO";
            v.Name = "KFGzg";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.DistributionID", "");
            vm.FC.Add("Entity.ITCode", "");
            vm.FC.Add("Entity.Password", "");
            vm.FC.Add("Entity.Name", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<MyUser>().FirstOrDefault();
 				
                Assert.AreEqual(data.ITCode, "c0w34jx");
                Assert.AreEqual(data.Password, "uonqtO");
                Assert.AreEqual(data.Name, "KFGzg");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            MyUser v = new MyUser();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.DistributionID = AddDistribution();
                v.ITCode = "pz5gQi8";
                v.Password = "YIGkKK";
                v.Name = "FptmSv3O";
                context.Set<MyUser>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(MyUserVM));

            MyUserVM vm = rv.Model as MyUserVM;
            v = new MyUser();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<MyUser>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            MyUser v = new MyUser();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.DistributionID = AddDistribution();
                v.ITCode = "pz5gQi8";
                v.Password = "YIGkKK";
                v.Name = "FptmSv3O";
                context.Set<MyUser>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            MyUser v1 = new MyUser();
            MyUser v2 = new MyUser();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.DistributionID = AddDistribution();
                v1.ITCode = "pz5gQi8";
                v1.Password = "YIGkKK";
                v1.Name = "FptmSv3O";
                v2.DistributionID = v1.DistributionID; 
                v2.ITCode = "c0w34jx";
                v2.Password = "uonqtO";
                v2.Name = "KFGzg";
                context.Set<MyUser>().Add(v1);
                context.Set<MyUser>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(MyUserBatchVM));

            MyUserBatchVM vm = rv.Model as MyUserBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<MyUser>().Count(), 0);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as MyUserListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Guid AddDistribution()
        {
            VOS_Distribution v = new VOS_Distribution();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.DName = "c5LDQ8";
                context.Set<VOS_Distribution>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
