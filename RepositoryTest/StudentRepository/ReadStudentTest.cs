using Core.Domains;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using Repository;
using Repository.Implementations;
using Repository.Interfaces;

namespace RepositoryTest.StudentRepository
{
    [TestClass]
    public class ReadStudentTest
    {
        ISchoolRepository<Student> _repository;

        [TestInitialize]
        public void Init()
        {
            _repository = new SchoolRepository<Student>(new Repository.Data.SchoolContext());
        }

        [TestMethod]
        public void ReadStudentTest01()
        {
            try
            {
                var input = 1;
                var output = _repository.Read(input);

                Assert.IsNotNull(output);
                Console.WriteLine(JsonConvert.SerializeObject(output));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        ///     Read non existing record
        /// </summary>
        [TestMethod]
        public void ReadStudentTest02()
        {
            try
            {
                var input = 293021;
                var output = _repository.Read(input);

                Assert.IsNull(output);
                Console.WriteLine($"Student with Id:{input} does not exists.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }
    }
}