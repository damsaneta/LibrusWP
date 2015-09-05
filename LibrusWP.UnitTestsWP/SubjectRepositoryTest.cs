using LibrusWP.DataAccess;
using LibrusWP.DataAccess.Entities;
using LibrusWP.DataAccess.Repositories;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.UnitTestsWP
{
    [TestClass]
    public class SubjectRepositoryTest
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

        [TestCleanup]
        public void Clean()
        {
            this.context.Dispose();
            this.context = null;
        }

        [TestMethod]
        public void Add_new_subject_test()
        {
            var repo = new SubjectRepository(this.context);
            var model = new SubjectEntity("AM", "Analiza matematyczna");
            repo.AddNew(model);
         }

        [TestMethod]
        public void Get_all_subjects_test()
        {

            var repo = new SubjectRepository(context);
            var model = new SubjectEntity("AM", "Analiza matematyczna");
            var model2 = new SubjectEntity("MD", "Matematyka dyskretna");

            repo.AddNew(model);
            repo.AddNew(model2);
            var result = repo.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(model.Id, result[0].Id);
            Assert.AreEqual(model2.Id, result[1].Id);

        }

        [TestMethod]
        public void Get_subject_by_id_test()
        {

            var repo = new SubjectRepository(context);
            var model = new SubjectEntity("AM", "Analiza matematyczna");
            var model2 = new SubjectEntity("MD", "Matematyka dyskretna");

            repo.AddNew(model);
            repo.AddNew(model2);
            var result = repo.GetById(model2.Id);

            Assert.IsNotNull(result);
            Assert.AreEqual(model2.Id, result.Id);

        }
    }
}
