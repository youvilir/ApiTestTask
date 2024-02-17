using ApiTestTask.DB.Entities;

namespace ApiTestTask.DB.Repositories.EntityRepository
{
    public class ApiEntityRepository : RepositoryBase<ApiEntity>
    {
        public ApiEntityRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
