using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using MyTest.Controllers;
using MyTest.ViewModel.other.LinkManTypeVMs;
using MyTest.Model;
using MyTest.DataAccess;

namespace MyTest.Test
{
    [TestClass]
    public class LinkManTypeControllerTest
    {
        private LinkManTypeController _controller;
        private string _seed;

        public LinkManTypeControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<LinkManTypeController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as LinkManTypeListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(LinkManTypeVM));

            LinkManTypeVM vm = rv.Model as LinkManTypeVM;
            LinkManType v = new LinkManType();
			
            v.ID = 86;
            v.TypeName = "ACNL";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<LinkManType>().FirstOrDefault();
				
                Assert.AreEqual(data.ID, 86);
                Assert.AreEqual(data.TypeName, "ACNL");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            LinkManType v = new LinkManType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 86;
                v.TypeName = "ACNL";
                context.Set<LinkManType>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(LinkManTypeVM));

            LinkManTypeVM vm = rv.Model as LinkManTypeVM;
            v = new LinkManType();
            v.ID = vm.Entity.ID;
       		
            v.TypeName = "ho5kHGd";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.TypeName", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<LinkManType>().FirstOrDefault();
 				
                Assert.AreEqual(data.TypeName, "ho5kHGd");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            LinkManType v = new LinkManType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 86;
                v.TypeName = "ACNL";
                context.Set<LinkManType>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(LinkManTypeVM));

            LinkManTypeVM vm = rv.Model as LinkManTypeVM;
            v = new LinkManType();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<LinkManType>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            LinkManType v = new LinkManType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ID = 86;
                v.TypeName = "ACNL";
                context.Set<LinkManType>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            LinkManType v1 = new LinkManType();
            LinkManType v2 = new LinkManType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 86;
                v1.TypeName = "ACNL";
                v2.TypeName = "ho5kHGd";
                context.Set<LinkManType>().Add(v1);
                context.Set<LinkManType>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(LinkManTypeBatchVM));

            LinkManTypeBatchVM vm = rv.Model as LinkManTypeBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<LinkManType>().Count(), 0);
            }
        }


    }
}
