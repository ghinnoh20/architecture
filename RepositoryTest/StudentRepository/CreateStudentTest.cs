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
        ITestRepository<Student> _repository;

        [TestInitialize]
        public void Init()
        {
            _repository = new TestRepository<Student>(new Repository.Data.TestContext());
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
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }
    }
}