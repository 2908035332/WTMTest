using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using MyTest.Controllers;
using MyTest.ViewModel.other.StuTableVMs;
using MyTest.Model;
using MyTest.DataAccess;

namespace MyTest.Test
{
    [TestClass]
    public class StuTableControllerTest
    {
        private StuTableController _controller;
        private string _seed;

        public StuTableControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<StuTableController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as StuTableListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(StuTableVM));

            StuTableVM vm = rv.Model as StuTableVM;
            StuTable v = new StuTable();
			
            v.ID = 80;
            v.StuName = "sbOgORLa";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<StuTable>().FirstOrDefault();
				
                Assert.AreEqual(data.ID, 80);
                Assert.AreEqual(data.StuName, "sbOgORLa");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            StuTable v = new StuTable();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 80;
                v.StuName = "sbOgORLa";
                context.Set<StuTable>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(StuTableVM));

            StuTableVM vm = rv.Model as StuTableVM;
            v = new StuTable();
            v.ID = vm.Entity.ID;
       		
            v.StuName = "JMY2EM";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.StuName", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<StuTable>().FirstOrDefault();
 				
                Assert.AreEqual(data.StuName, "JMY2EM");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            StuTable v = new StuTable();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 80;
                v.StuName = "sbOgORLa";
                context.Set<StuTable>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(StuTableVM));

            StuTableVM vm = rv.Model as StuTableVM;
            v = new StuTable();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<StuTable>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            StuTable v = new StuTable();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ID = 80;
                v.StuName = "sbOgORLa";
                context.Set<StuTable>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            StuTable v1 = new StuTable();
            StuTable v2 = new StuTable();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 80;
                v1.StuName = "sbOgORLa";
                v2.StuName = "JMY2EM";
                context.Set<StuTable>().Add(v1);
                context.Set<StuTable>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(StuTableBatchVM));

            StuTableBatchVM vm = rv.Model as StuTableBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<StuTable>().Count(), 0);
            }
        }


    }
}
