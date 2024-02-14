using Microsoft.EntityFrameworkCore;
using ApiEntity = WebApiFile.DB.Entities.ApiEntity;

namespace WebApiFile.DB.Repositories.EntityRepository
{
    public class ApiEntityRepository : RepositoryBase<ApiEntity>
    {
        public ApiEntityRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
