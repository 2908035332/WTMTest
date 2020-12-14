using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using MyTest.Controllers;
using MyTest.ViewModel.other.LinkManInfoVMs;
using MyTest.Model;
using MyTest.DataAccess;

namespace MyTest.Test
{
    [TestClass]
    public class LinkManInfoControllerTest
    {
        private LinkManInfoController _controller;
        private string _seed;

        public LinkManInfoControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<LinkManInfoController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as LinkManInfoListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(LinkManInfoVM));

            LinkManInfoVM vm = rv.Model as LinkManInfoVM;
            LinkManInfo v = new LinkManInfo();
			
            v.ID = 91;
            v.Name = "jZGKgQNY";
            v.Address = "vofs";
            v.Phone = "bnyok9vaG";
            v.ManTypeID = AddManType();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<LinkManInfo>().FirstOrDefault();
				
                Assert.AreEqual(data.ID, 91);
                Assert.AreEqual(data.Name, "jZGKgQNY");
                Assert.AreEqual(data.Address, "vofs");
                Assert.AreEqual(data.Phone, "bnyok9vaG");
            }

        }

        [TestMethod]
        public void EditTest()
        {
            LinkManInfo v = new LinkManInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 91;
                v.Name = "jZGKgQNY";
                v.Address = "vofs";
                v.Phone = "bnyok9vaG";
                v.ManTypeID = AddManType();
                context.Set<LinkManInfo>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(LinkManInfoVM));

            LinkManInfoVM vm = rv.Model as LinkManInfoVM;
            v = new LinkManInfo();
            v.ID = vm.Entity.ID;
       		
            v.Name = "cyCfFwRMQ";
            v.Address = "loCO";
            v.Phone = "Wcv";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Address", "");
            vm.FC.Add("Entity.Phone", "");
            vm.FC.Add("Entity.ManTypeID", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<LinkManInfo>().FirstOrDefault();
 				
                Assert.AreEqual(data.Name, "cyCfFwRMQ");
                Assert.AreEqual(data.Address, "loCO");
                Assert.AreEqual(data.Phone, "Wcv");
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            LinkManInfo v = new LinkManInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 91;
                v.Name = "jZGKgQNY";
                v.Address = "vofs";
                v.Phone = "bnyok9vaG";
                v.ManTypeID = AddManType();
                context.Set<LinkManInfo>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(LinkManInfoVM));

            LinkManInfoVM vm = rv.Model as LinkManInfoVM;
            v = new LinkManInfo();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<LinkManInfo>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            LinkManInfo v = new LinkManInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ID = 91;
                v.Name = "jZGKgQNY";
                v.Address = "vofs";
                v.Phone = "bnyok9vaG";
                v.ManTypeID = AddManType();
                context.Set<LinkManInfo>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            LinkManInfo v1 = new LinkManInfo();
            LinkManInfo v2 = new LinkManInfo();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 91;
                v1.Name = "jZGKgQNY";
                v1.Address = "vofs";
                v1.Phone = "bnyok9vaG";
                v1.ManTypeID = AddManType();
                v2.Name = "cyCfFwRMQ";
                v2.Address = "loCO";
                v2.Phone = "Wcv";
                v2.ManTypeID = v1.ManTypeID; 
                context.Set<LinkManInfo>().Add(v1);
                context.Set<LinkManInfo>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(LinkManInfoBatchVM));

            LinkManInfoBatchVM vm = rv.Model as LinkManInfoBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<LinkManInfo>().Count(), 0);
            }
        }

        private Int32 AddManType()
        {
            LinkManType v = new LinkManType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 45;
                v.TypeName = "DFj9x";
                context.Set<LinkManType>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
