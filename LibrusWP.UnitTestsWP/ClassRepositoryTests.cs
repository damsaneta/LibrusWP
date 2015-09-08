using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Threading;
using LibrusWP.DataAccess;
using LibrusWP.DataAccess.Entities;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using LibrusWP.DataAccess.Repositories;

namespace LibrusWP.UnitTestsWP
{
    [TestClass]
    public class ClassRepositoryTests
    {
        private readonly string connString = @"isostore:/LibrusWP.sdf";
        private LibrusDataContext context;

        [TestInitialize]
        public void Setup()
        {
            this.context = new LibrusDataContext(this.connString);
            if (this.context.DatabaseExists())
            {
                this.context.DeleteDatabase();
            }

            this.context.CreateDatabase();
        }

        //[TestCleanup]
        //public void Clean()
        //{
        //    this.context.Dispose();
        //    this.context = null;
        //}

        [TestMethod]
        public void Add_new_class_test()
        {

            var repo = new ClassRepository(context);
            var model = new ClassEntity("GR1");
            repo.AddNew(model);

        }

        [TestMethod]
        public void Get_all_classes_test()
        {

            var repo = new ClassRepository(context);
            var model = new ClassEntity("GR2");
            var model2 = new ClassEntity("GR1");

            repo.AddNew(model);
            repo.AddNew(model2);
            var result = repo.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(model.Id, result[1].Id);
            Assert.AreEqual(model2.Id, result[0].Id);

        }

        [TestMethod]
        public void Get_class_by_id_test()
        {
           
                var repo = new ClassRepository(context);
                var model = new ClassEntity("GR2");
                var model2 = new ClassEntity("GR1");

                repo.AddNew(model);
                repo.AddNew(model2);
                var result = repo.GetById(model2.Id);

                Assert.IsNotNull(result);
                Assert.AreEqual(result.Id, model2.Id);
            
        }
    }
}
