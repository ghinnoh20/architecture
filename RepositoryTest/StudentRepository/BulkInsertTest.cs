using Core.Domains;
using Microsoft.EntityFrameworkCore.Internal;
using Repository;
using Repository.Implementations;
using Repository.Interfaces;

namespace RepositoryTest.StudentRepository
{
    [TestClass]
    public class BulkInsertTest
    {
        #region Declarations
        ISchoolRepository<Student> _repository;
        List<Student> _students; 
        #endregion

        #region Methods

        public List<Student> Get500DummyStudens()
        {
            var output = new List<Student>();


            output.Add(new Student()
            {
                FirstName = Guid.NewGuid().ToString(),
                MiddleName = Guid.NewGuid().ToString(),
                LastName = Guid.NewGuid().ToString(),
                BirthDate = DateTime.Now
            });

            output.Add(new Student()
            {
                FirstName = Guid.NewGuid().ToString(),
                MiddleName = Guid.NewGuid().ToString(),
                LastName = Guid.NewGuid().ToString(),
                BirthDate = DateTime.Now
            });


            output.Add(new Student()
            {
                FirstName = Guid.NewGuid().ToString(),
                MiddleName = Guid.NewGuid().ToString(),
                LastName = Guid.NewGuid().ToString(),
                BirthDate = DateTime.Now
            });

            return output;
        }

        public List<Student> Get1000DummyStudens()
        {
            var output = new List<Student>();


            output.Add(new Student()
            {
                FirstName = Guid.NewGuid().ToString(),
                MiddleName = Guid.NewGuid().ToString(),
                LastName = Guid.NewGuid().ToString(),
                BirthDate = DateTime.Now
            });

            output.Add(new Student()
            {
                FirstName = Guid.NewGuid().ToString(),
                MiddleName = Guid.NewGuid().ToString(),
                LastName = Guid.NewGuid().ToString(),
                BirthDate = DateTime.Now
            });


            output.Add(new Student()
            {
                FirstName = Guid.NewGuid().ToString(),
                MiddleName = Guid.NewGuid().ToString(),
                LastName = Guid.NewGuid().ToString(),
                BirthDate = DateTime.Now
            });

            return output;
        } 
        #endregion


        [TestInitialize]
        public void Init()
        {
            _repository = new SchoolRepository<Student>(new Repository.Data.SchoolContext());


        }

        /// <summary>
        ///     Insert 500 students
        /// </summary>
        [TestMethod]
        public void BulkInsertTest01()
        {
            try
            {
                _students = Get500DummyStudens();

                var output = _repository.BulkInsert(_students);

                Assert.AreEqual(3, output);

                Console.WriteLine($"Total of {output} students inserted.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        ///     Insert 1000 students
        /// </summary>
        [TestMethod]
        public void BulkInsertTest02()
        {
            try
            {
                _students = Get1000DummyStudens();

                var output = _repository.BulkInsert(_students);

                Assert.AreEqual(3, output);

                Console.WriteLine($"Total of {output} students inserted.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }

    }
}