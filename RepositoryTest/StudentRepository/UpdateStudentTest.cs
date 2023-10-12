using Core.Domains;
using Microsoft.EntityFrameworkCore.Internal;
using Repository;
using Repository.Implementations;
using Repository.Interfaces;

namespace RepositoryTest.StudentRepository
{
    [TestClass]
    public class UpdateStudentTest
    {
        ISchoolRepository<Student> _repository;

        [TestInitialize]
        public void Init()
        {
            _repository = new SchoolRepository<Student>(new Repository.Data.SchoolContext());
        }

        [TestMethod]
        public void UpdateStudentTest01()
        {
            try
            {
                var currentDate = DateTime.Now;

                var input = _repository.Read(1);
                Assert.IsNotNull(input);

                input.FirstName = Guid.NewGuid().ToString();
                input.MiddleName = Guid.NewGuid().ToString();
                input.LastName = Guid.NewGuid().ToString();
                input.BirthDate = DateTime.Now;

                var output = _repository.Update(input);
                Assert.AreNotEqual(0, output);

                Console.WriteLine($"Student with Id: {input.Id} was updated.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        ///     Update a non existing record
        /// </summary>
        [TestMethod]
        public void UpdateStudentTest02()
        {
            try
            {

                var input = new Student();
                input.Id = 38391;
                input.FirstName = Guid.NewGuid().ToString();
                input.MiddleName = Guid.NewGuid().ToString();
                input.LastName = Guid.NewGuid().ToString();
                input.BirthDate = DateTime.Now;

                var output = _repository.Update(input);
                Assert.AreEqual(0, output);

                Console.WriteLine($"Student with Id:{input} does not exists.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }
    }
}