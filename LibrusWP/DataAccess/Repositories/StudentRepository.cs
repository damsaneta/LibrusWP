﻿using LibrusWP.DataAccess.Entities;
using LibrusWP.DataAccess.Repositories;
using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess
{
    public class StudentRepository: IStudentRepository
    {
        private readonly LibrusDataContext context;

        public StudentRepository(LibrusDataContext context)
        {
            this.context = context;
        }

        public IList<StudentEntity> GetAll()
        {
            return this.context.Students.ToList();
        }

        public IList<StudentEntity> GetAllByClass(string classId)
        {
            return this.context.Students.Where(x => x.Class.Id == classId)
                .OrderBy(x => x.Surname).ThenBy(x => x.Name).ToList();
        }

        public void AddNew(StudentEntity model)
        {
            this.context.Students.InsertOnSubmit(model);
            this.context.SubmitChanges();
        }

        public StudentEntity GetById(int id)
        {
            return this.context.Students.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
