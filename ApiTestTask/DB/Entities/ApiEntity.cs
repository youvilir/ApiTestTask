using ApiTestTask.Enums;

namespace ApiTestTask.DB.Entities
{
    public class ApiEntity : Entity
    {
        public Status Status { get; set; }

        public ApiEntity()
        {
            Status = Status.Created;
        }
    }
}
