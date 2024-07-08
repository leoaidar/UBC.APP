using UBC.Students.Tests.Repositories;

namespace UBC.Students.Tests.QueryTests
{
    public class StudentQueryTests
    {
        private FakeStudentRepository _studentRepository;

        public StudentQueryTests()
        {
            _studentRepository = new FakeStudentRepository();
        }

        [Fact]
        public void Test_give_request_all_must_return_students()
        {
            Assert.True(_studentRepository.GetAll().Result.Count() > 0);
        }

        [Fact]
        public void Test_give_request_one_must_return_single_student()
        {
            Assert.True(_studentRepository.Get(1).Result != null);
        }

        [Fact]
        public void Test_give_request_delete_must_remove_single_student()
        {
            Assert.NotNull(_studentRepository.Delete(1));
        }
    }
}
