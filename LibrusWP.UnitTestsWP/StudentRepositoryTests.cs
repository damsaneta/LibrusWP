using LibrusWP.DataAccess;
using LibrusWP.DataAccess.Entities;
using LibrusWP.DataAccess.Repositories;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.UnitTestsWP
{
    [TestClass]
    public class StudentRepositoryTests
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
        public void Add_new_student_test()
        {
            var repo = new StudentRepository(this.context);
            var classRepo = new ClassRepository(context);
            var clazz = new ClassEntity("GR1");
            classRepo.AddNew(clazz);
            var model = new StudentEntity("Aneta","Dams", clazz, true);
            
            repo.AddNew(model);
        }

        [TestMethod]
        public void Get_student_by_id_test()
        {
            var repo = new StudentRepository(this.context);
            var classRepo = new ClassRepository(context);
            var clazz = new ClassEntity("GR1");
            classRepo.AddNew(clazz);
            var model = new StudentEntity("Aneta", "Dams", clazz, true);
            var model2 = new StudentEntity("Mateusz", "Brzeziński", clazz, false);
            repo.AddNew(model);
            repo.AddNew(model2);

            var result = repo.GetById(model2.Id);
            
            Assert.IsNotNull(result);
            Assert.AreEqual(model2.Id, result.Id);
            Assert.AreEqual(model2.Gender, result.Gender);
            Assert.AreEqual(model2.Name, result.Name);
            Assert.AreEqual(model2.Surname, result.Surname);
            Assert.IsNotNull(result.Class);
            Assert.AreEqual(model2.Class.Id, result.Class.Id);
        }

        [TestMethod]
        public void Get_all_students_by_class_test()
        {
            var repo = new StudentRepository(this.context);
            var classRepo = new ClassRepository(context);
            var clazz = new ClassEntity("GR1");
            var clazz2 = new ClassEntity("GR2");
            classRepo.AddNew(clazz);
            classRepo.AddNew(clazz2);
            var model = new StudentEntity("Aneta", "Dams", clazz, true);
            var model2 = new StudentEntity("Mateusz", "Brzeziński", clazz, false);
            var model3 = new StudentEntity("Joanna", "Kowalska", clazz2, true);
            repo.AddNew(model);
            repo.AddNew(model2);
            repo.AddNew(model3);

            var result = repo.GetAllByClass(clazz.Id);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(clazz.Id, result[0].Class.Id);
            Assert.AreEqual(clazz.Id, result[1].Class.Id);
            Assert.AreEqual(model2.Id, result[0].Id);
            Assert.AreEqual(model.Id, result[1].Id);
        }
    }
}
