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
    public class TimeTableRepositoryTests
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
        public void Add_new_timetable_test()
        {
            var repo = new TimeTableRepository(context);
            TimeTableEntity model = new TimeTableEntity("poniedzialek");
            repo.AddNew(model);
        }

        [TestMethod]
        public void Get_timetable_by_id_test()
        {
            var repo = new TimeTableRepository(context);
            TimeTableEntity model = new TimeTableEntity("poniedzialek");
            TimeTableEntity model2 = new TimeTableEntity("wtorek");
            repo.AddNew(model);
            repo.AddNew(model2);
            var result = repo.GetById(2);
            Assert.AreEqual(2, result.Id);
        }

    }
}
