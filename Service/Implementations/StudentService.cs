using Core.Domains;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class StudentService : IStudentService
    {
        private ISchoolRepository<Student> _repository;

        public StudentService(ISchoolRepository<Student> schoolRepository)
        {
            _repository = schoolRepository;
        }

        public int Create(Student entity)
        {          
            return _repository.Create(entity);
        }

        public int Delete(Student entity)
        {
            return _repository.Delete(entity);
        }

        public Student Read(int id)
        {
            return _repository.Read(id);
        }

        public IList<Student> Read(Expression<Func<Student, bool>> predicate)
        {
            return _repository.Read(predicate);
        }

        public int Update(Student entity)
        {
            return _repository.Update(entity);
        }
    }
}
