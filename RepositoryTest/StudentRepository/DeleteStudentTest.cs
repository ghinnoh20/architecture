using Core.Domains;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using Repository;
using Repository.Implementations;
using Repository.Interfaces;

namespace RepositoryTest.StudentRepository
{
    [TestClass]
    public class DeleteStudentTest
    {
        ISchoolRepository<Student> _repository;

        [TestInitialize]
        public void Init()
        {
            _repository = new SchoolRepository<Student>(new Repository.Data.SchoolContext());
        }

        [TestMethod]
        public void DeleteStudentTest01()
        {
            try
            {
                var input = 1;
                var output = _repository.Delete(input);

                Assert.AreEqual(1, output);
                Console.WriteLine(JsonConvert.SerializeObject(output));
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        ///     Delete a non existing data
        /// </summary>
        [TestMethod]
        public void DeleteStudentTest02()
        {
            try
            {
                var input = 32878;
                var output = _repository.Delete(input);


                Assert.AreNotEqual(1, output);
                Console.WriteLine($"Student with Id:{input} does not exists.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.Fail();
            }
        }
    }
}