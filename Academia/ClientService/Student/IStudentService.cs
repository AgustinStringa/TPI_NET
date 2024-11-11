namespace ClientService.Student
{
    public interface IStudentService
    {
        public Task<IEnumerable<ApplicationCore.Model.Student>> GetAll();
        public Task<ApplicationCore.Model.Student> GetById(int id);
        public Task Create(ApplicationCore.Model.Student student);
        public Task Update(ApplicationCore.Model.Student student);
        public Task Delete(int id);
    }
}
