namespace ClientService.Curriculum
{
    public interface ICurriculumService
    {
        Task<IEnumerable<ApplicationCore.Model.Curriculum>> GetAll();
        Task<IEnumerable<ApplicationCore.Model.Curriculum>> GetAllWithArea();
        Task<IEnumerable<ApplicationCore.Model.Curriculum>> GetAllByAreaId(int areaId);
        Task<ApplicationCore.Model.Curriculum> GetById(int id);
        Task Create(ApplicationCore.Model.Curriculum curriculum);
        Task Update(ApplicationCore.Model.Curriculum curriculum);
        Task Delete(int id);
    }
}
