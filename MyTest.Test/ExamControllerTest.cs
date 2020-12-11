using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using MyTest.Controllers;
using MyTest.ViewModel.other.ExamVMs;
using MyTest.Model;
using MyTest.DataAccess;

namespace MyTest.Test
{
    [TestClass]
    public class ExamControllerTest
    {
        private ExamController _controller;
        private string _seed;

        public ExamControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<ExamController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as ExamListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(ExamVM));

            ExamVM vm = rv.Model as ExamVM;
            Exam v = new Exam();
			
            v.ID = 44;
            v.Exam_Name = "74z";
            v.Exam_A = "5fM";
            v.Exam_B = "3SUvt";
            v.Exam_C = "kdFyT7";
            v.Exam_D = "kMsZ";
            v.Exam_TypeId = AddExam_Type();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Exam>().FirstOrDefault();
				
                Assert.AreEqual(data.ID, 44);
                Assert.AreEqual(data.Exam_Name, "74z");
                Assert.AreEqual(data.Exam_A, "5fM");
                Assert.AreEqual(data.Exam_B, "3SUvt");
                Assert.AreEqual(data.Exam_C, "kdFyT7");
                Assert.AreEqual(data.Exam_D, "kMsZ");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            Exam v = new Exam();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 44;
                v.Exam_Name = "74z";
                v.Exam_A = "5fM";
                v.Exam_B = "3SUvt";
                v.Exam_C = "kdFyT7";
                v.Exam_D = "kMsZ";
                v.Exam_TypeId = AddExam_Type();
                context.Set<Exam>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ExamVM));

            ExamVM vm = rv.Model as ExamVM;
            v = new Exam();
            v.ID = vm.Entity.ID;
       		
            v.Exam_Name = "sbbvQ5";
            v.Exam_A = "9fbdqCx1";
            v.Exam_B = "Uk5bw";
            v.Exam_C = "bRss17RU";
            v.Exam_D = "PgQky";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Exam_Name", "");
            vm.FC.Add("Entity.Exam_A", "");
            vm.FC.Add("Entity.Exam_B", "");
            vm.FC.Add("Entity.Exam_C", "");
            vm.FC.Add("Entity.Exam_D", "");
            vm.FC.Add("Entity.Exam_TypeId", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Exam>().FirstOrDefault();
 				
                Assert.AreEqual(data.Exam_Name, "sbbvQ5");
                Assert.AreEqual(data.Exam_A, "9fbdqCx1");
                Assert.AreEqual(data.Exam_B, "Uk5bw");
                Assert.AreEqual(data.Exam_C, "bRss17RU");
                Assert.AreEqual(data.Exam_D, "PgQky");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            Exam v = new Exam();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 44;
                v.Exam_Name = "74z";
                v.Exam_A = "5fM";
                v.Exam_B = "3SUvt";
                v.Exam_C = "kdFyT7";
                v.Exam_D = "kMsZ";
                v.Exam_TypeId = AddExam_Type();
                context.Set<Exam>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(ExamVM));

            ExamVM vm = rv.Model as ExamVM;
            v = new Exam();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<Exam>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            Exam v = new Exam();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ID = 44;
                v.Exam_Name = "74z";
                v.Exam_A = "5fM";
                v.Exam_B = "3SUvt";
                v.Exam_C = "kdFyT7";
                v.Exam_D = "kMsZ";
                v.Exam_TypeId = AddExam_Type();
                context.Set<Exam>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Exam v1 = new Exam();
            Exam v2 = new Exam();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 44;
                v1.Exam_Name = "74z";
                v1.Exam_A = "5fM";
                v1.Exam_B = "3SUvt";
                v1.Exam_C = "kdFyT7";
                v1.Exam_D = "kMsZ";
                v1.Exam_TypeId = AddExam_Type();
                v2.Exam_Name = "sbbvQ5";
                v2.Exam_A = "9fbdqCx1";
                v2.Exam_B = "Uk5bw";
                v2.Exam_C = "bRss17RU";
                v2.Exam_D = "PgQky";
                v2.Exam_TypeId = v1.Exam_TypeId; 
                context.Set<Exam>().Add(v1);
                context.Set<Exam>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(ExamBatchVM));

            ExamBatchVM vm = rv.Model as ExamBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<Exam>().Count(), 0);
            }
        }

        private Guid AddExam_Type()
        {
            ExamType v = new ExamType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.TypeName = "EryAcQEIE";
                context.Set<ExamType>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
