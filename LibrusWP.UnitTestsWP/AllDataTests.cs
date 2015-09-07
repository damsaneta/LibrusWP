using LibrusWP.DataAccess;
using LibrusWP.DataAccess.Entities;
using LibrusWP.DataAccess.Repositories;
using LibrusWP.Logic;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.UnitTestsWP
{
    [TestClass]
    public class AllDataTests
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
        public void Test()
        {
            LibrusFactory.InsertTestData();
        }
    }
}
