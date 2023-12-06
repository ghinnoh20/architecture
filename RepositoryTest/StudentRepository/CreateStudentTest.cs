using Core.Domains;
using Microsoft.EntityFrameworkCore.Internal;
using Repository;
using Repository.Implementations;
using Repository.Interfaces;

namespace RepositoryTest.StudentRepository
{
    [TestClass]
    public class CreateStudentTest
    {
        ISchoolRepository<Student> _repository;
        List<Student> _students;
        public List<Student> GetDummyStudens()
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


        [TestInitialize]
        public void Init()
        {
            _repository = new SchoolRepository<Student>(new Repository.Data.SchoolContext());

            _students = GetDummyStudens();
        }

        [TestMethod]
        public void CreateStudentTest01()
        {
            try
            {
                var input = new Student();
                input.FirstName = Guid.NewGuid().ToString();
                input.MiddleName = Guid.NewGuid().ToString();
                input.LastName = Guid.NewGuid().ToString();
                input.BirthDate = DateTime.Now;

                var output = _repository.Create(input);

                Assert.AreNotEqual(0, output);

                Console.WriteLine($"New student with Id: {input.Id} created");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }


        /// <summary>
        ///     Add new user without Lastname
        /// </summary>
        [TestMethod]
        public void CreateStudentTest02()
        {
            try
            {
                var input = new Student();
                input.FirstName = Guid.NewGuid().ToString();
                input.MiddleName = Guid.NewGuid().ToString();
                input.LastName = null;
                input.BirthDate = DateTime.Now;

                var output = _repository.Create(input);

                Assert.AreEqual(0, output);

                Console.WriteLine($"New student with Id: {input.Id} created");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.Fail();

            }
        }


        /// <summary>
        ///     Insert list of stundent to DB
        /// </summary>
        [TestMethod]
        public void CreateStudentTest03()
        {
            try
            {
                foreach (var input in _students)
                {
                    var output = _repository.Create(input);

                    Assert.AreNotEqual(0, output);

                    Console.WriteLine($"New student with Id: {input.Id} created");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }
    }
}