using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using MyTest.Controllers;
using MyTest.ViewModel.other.ExamTypeVMs;
using MyTest.Model;
using MyTest.DataAccess;

namespace MyTest.Test
{
    [TestClass]
    public class ExamTypeControllerTest
    {
        private ExamTypeController _controller;
        private string _seed;

        public ExamTypeControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<ExamTypeController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as ExamTypeListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(ExamTypeVM));

            ExamTypeVM vm = rv.Model as ExamTypeVM;
            ExamType v = new ExamType();
			
            v.TypeName = "3olErTmcu";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ExamType>().FirstOrDefault();
				
                Assert.AreEqual(data.TypeName, "3olErTmcu");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            ExamType v = new ExamType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.TypeName = "3olErTmcu";
                context.Set<ExamType>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ExamTypeVM));

            ExamTypeVM vm = rv.Model as ExamTypeVM;
            v = new ExamType();
            v.ID = vm.Entity.ID;
       		
            v.TypeName = "G4w";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.TypeName", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<ExamType>().FirstOrDefault();
 				
                Assert.AreEqual(data.TypeName, "G4w");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            ExamType v = new ExamType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.TypeName = "3olErTmcu";
                context.Set<ExamType>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ExamTypeVM));

            ExamTypeVM vm = rv.Model as ExamTypeVM;
            v = new ExamType();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ExamType>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            ExamType v = new ExamType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.TypeName = "3olErTmcu";
                context.Set<ExamType>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            ExamType v1 = new ExamType();
            ExamType v2 = new ExamType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.TypeName = "3olErTmcu";
                v2.TypeName = "G4w";
                context.Set<ExamType>().Add(v1);
                context.Set<ExamType>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(ExamTypeBatchVM));

            ExamTypeBatchVM vm = rv.Model as ExamTypeBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<ExamType>().Count(), 0);
            }
        }


    }
}
