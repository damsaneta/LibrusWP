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
    public class PresenceRepositoryTest
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
        public void Add_new_presence_test()
        {
            var repo = new PresenceRepository(this.context);
            var model = new PresenceEntity(DateTime.Now.Date.Date, true);
            repo.AddNew(model);
        }

        [TestMethod]
        public void Get_all_presences_test()
        {
            var repo = new PresenceRepository(this.context);
            var model = new PresenceEntity(DateTime.Now.Date.Date, true);
            var model2 = new PresenceEntity(DateTime.Now.Date.Date, false);
            repo.AddNew(model);
            repo.AddNew(model2);

            var result = repo.GetAll();
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(1, model.Id);
            Assert.AreEqual(2, model2.Id);

        }

    }
}
