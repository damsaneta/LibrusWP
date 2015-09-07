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
            var studrepo = new StudentRepository(this.context);
            var timerepo = new TimeTableRepository(this.context);
            var classrepo = new ClassRepository(this.context);
            var subrepo = new SubjectRepository(this.context);
            ClassEntity clazz = new ClassEntity("GR1");
            classrepo.AddNew(clazz);
            StudentEntity model = new StudentEntity("Aneta", "Dams", clazz,true);
            studrepo.AddNew(model);
            SubjectEntity subject = new SubjectEntity("AM", "Analiza Matematyczna");
            subrepo.AddNew(subject);
            TimeTableEntity timeTable = new TimeTableEntity("poniedziałek",clazz, subject);
            var model1 = new PresenceEntity(model, subject, DateTime.Now.Date, true);
            repo.AddNew(model1);
        }

        [TestMethod]
        public void Get_presences_by_student_and_subject_test()
        {
            var repo = new PresenceRepository(this.context);
            var studrepo = new StudentRepository(this.context);
            var timerepo = new TimeTableRepository(this.context);
            var classrepo = new ClassRepository(this.context);
            var subrepo = new SubjectRepository(this.context);
            ClassEntity clazz = new ClassEntity("GR1");
            classrepo.AddNew(clazz);
            StudentEntity model = new StudentEntity("Aneta", "Dams", clazz, true);
            studrepo.AddNew(model);
            SubjectEntity subject = new SubjectEntity("AM", "Analiza Matematyczna");
            subrepo.AddNew(subject);
            TimeTableEntity timeTable = new TimeTableEntity("poniedziałek", clazz, subject);
            var model1 = new PresenceEntity(model, subject, DateTime.Now.Date, true);
            var model2 = new PresenceEntity(model, subject, DateTime.Now.Date.AddDays(2), true);
            repo.AddNew(model1);
            repo.AddNew(model2);

            var result= repo.GetAllByStudentAndSubject(model.Id, subject.Id);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(model1.Id, result[0].Id);
            Assert.AreEqual(model2.Id, result[1].Id);

        }

    }
}
