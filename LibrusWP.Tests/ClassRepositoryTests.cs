using LibrusWP.DataAccess;
using LibrusWP.DataAccess.Entities;
using LibrusWP.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.Tests
{
    [TestClass]
    public class ClassRepositoryTests
    {
        private readonly string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\aneta\Documents\LibrusWP.mdf;Integrated Security=True;Connect Timeout=30";

        [TestMethod]
        public void Add_new_class_test()
        {
           // this.SetupAll();
            
            var repo = new ClassRepository(connString);
            var model = new ClassEntity("GR1");

            repo.AddNew(model);
        }

        [TestMethod]
        public void Get_all_classes_test()
        {
            //this.SetupAll();
            var repo = new ClassRepository(connString);
            var model = new ClassEntity("GR2");
            var model2 = new ClassEntity("GR1");

            repo.AddNew(model);
            repo.AddNew(model2);
            var result = repo.GetAll();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(model.Id, result[0].Id);
            Assert.AreEqual(model2.Id, result[1].Id);
        }

        [TestMethod]
        public void Get_class_by_id_test()
        {
            //this.SetupAll();
            var repo = new ClassRepository(connString);
            var model = new ClassEntity("GR2");
            var model2 = new ClassEntity("GR1");

            repo.AddNew(model);
            repo.AddNew(model2);
            var result = repo.GetById(model2.Id);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Id, model2.Id);
        }


        private void SetupAll()
        {
            string directoryPath = @"D:\Users\aneta\Desktop\LibrusWP\LibrusWP.Tests\Databases\";
            string file1Path = directoryPath + "SqlLiteEmptyDatabase.sqlite";
            string file2Path = directoryPath + "TestDatabase.sqlite";

            if(File.Exists(file2Path))
            {
                File.Delete(file2Path);
            }

            File.Copy(file1Path, file2Path);
        }
    }
}
