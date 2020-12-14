using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using MyTest.Controllers;
using MyTest.ViewModel.other.TableTestVMs;
using MyTest.Model;
using MyTest.DataAccess;

namespace MyTest.Test
{
    [TestClass]
    public class TableTestControllerTest
    {
        private TableTestController _controller;
        private string _seed;

        public TableTestControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<TableTestController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as TableTestListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(TableTestVM));

            TableTestVM vm = rv.Model as TableTestVM;
            TableTest v = new TableTest();
			
            v.ID = 7;
            v.Name = "QSW";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<TableTest>().FirstOrDefault();
				
                Assert.AreEqual(data.ID, 7);
                Assert.AreEqual(data.Name, "QSW");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            TableTest v = new TableTest();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 7;
                v.Name = "QSW";
                context.Set<TableTest>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(TableTestVM));

            TableTestVM vm = rv.Model as TableTestVM;
            v = new TableTest();
            v.ID = vm.Entity.ID;
       		
            v.Name = "pn6";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Name", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<TableTest>().FirstOrDefault();
 				
                Assert.AreEqual(data.Name, "pn6");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            TableTest v = new TableTest();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 7;
                v.Name = "QSW";
                context.Set<TableTest>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(TableTestVM));

            TableTestVM vm = rv.Model as TableTestVM;
            v = new TableTest();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<TableTest>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            TableTest v = new TableTest();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ID = 7;
                v.Name = "QSW";
                context.Set<TableTest>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            TableTest v1 = new TableTest();
            TableTest v2 = new TableTest();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 7;
                v1.Name = "QSW";
                v2.Name = "pn6";
                context.Set<TableTest>().Add(v1);
                context.Set<TableTest>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(TableTestBatchVM));

            TableTestBatchVM vm = rv.Model as TableTestBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<TableTest>().Count(), 0);
            }
        }


    }
}
