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
            var classRepo = new ClassRepository(context);
            var subjectRepo = new SubjectRepository(context);
            ClassEntity clazz = new ClassEntity("GR1");
            classRepo.AddNew(clazz);
            SubjectEntity subject = new SubjectEntity("AM","Analiza");
            subjectRepo.AddNew(subject);
            TimeTableEntity model = new TimeTableEntity("poniedziałek", clazz, subject);

            repo.AddNew(model);
        }

        [TestMethod]
        public void Get_timetable_by_id_test()
        {
            var repo = new TimeTableRepository(context);
            var classRepo = new ClassRepository(context);
            var subjectRepo = new SubjectRepository(context);
            ClassEntity clazz = new ClassEntity("GR1");
            classRepo.AddNew(clazz);
            SubjectEntity subject = new SubjectEntity("AM", "Analiza");
            subjectRepo.AddNew(subject);
            TimeTableEntity model = new TimeTableEntity("poniedziałek", clazz, subject);
            TimeTableEntity model2 = new TimeTableEntity("wtorek", clazz, subject);
            repo.AddNew(model);
            repo.AddNew(model2);

            var result = repo.GetById(2);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Id);
            Assert.AreEqual(model2.Class.Id, result.Class.Id);
            Assert.AreEqual(model2.Subject.Id, result.Subject.Id);
            Assert.AreEqual(model2.Day, result.Day);
        }

        [TestMethod]
        public void Get_timetable_by_claas_and_subject_test()
        {
            var repo = new TimeTableRepository(context);
            var classRepo = new ClassRepository(context);
            var subjectRepo = new SubjectRepository(context);
            ClassEntity clazz = new ClassEntity("GR1");
            ClassEntity clazz2 = new ClassEntity("GR2");
            classRepo.AddNew(clazz);
            classRepo.AddNew(clazz2);
            SubjectEntity subject = new SubjectEntity("AM", "Analiza");
            subjectRepo.AddNew(subject);
            TimeTableEntity model = new TimeTableEntity("poniedziałek", clazz2, subject);
            TimeTableEntity model2 = new TimeTableEntity("wtorek", clazz, subject);
            repo.AddNew(model);
            repo.AddNew(model2);

            var result = repo.GetByClassAndSubject(clazz.Id, subject.Id);

            Assert.IsNotNull(result);
            Assert.AreEqual(model2.Id, result.Id);
            
        }

        [TestMethod]
        public void Get_all_timetables_by_class_test()
        {
            var repo = new TimeTableRepository(context);
            var classRepo = new ClassRepository(context);
            var subjectRepo = new SubjectRepository(context);
            ClassEntity clazz = new ClassEntity("GR1");
            ClassEntity clazz2 = new ClassEntity("GR2");
            classRepo.AddNew(clazz);
            classRepo.AddNew(clazz2);
            SubjectEntity subject = new SubjectEntity("AM", "Analiza");
            subjectRepo.AddNew(subject);
            TimeTableEntity model = new TimeTableEntity("poniedziałek", clazz2, subject);
            TimeTableEntity model2 = new TimeTableEntity("wtorek", clazz, subject);
            repo.AddNew(model);
            repo.AddNew(model2);

            var result = repo.GetAllByClass("GR1");

            Assert.IsNotNull(result);
            Assert.AreEqual("GR1", result[0].Class.Id);

        }

    }
}
