using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiTestTask.DB.Entities
{
    public class Entity: IEntity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? ID { get; set; }

        [DisplayName("Создано")]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual DateTime? Created { get; set; }

        [DisplayName("Дата обновления")]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual DateTime? Changed { get; set; }

        public virtual void BeforeInsert()
        {
            if (ID == null) ID = Guid.NewGuid();
            Created = DateTime.UtcNow;
            Changed = Created;
        }

        public virtual void BeforeUpdate()
        {
            Changed = DateTime.UtcNow;
        }
    }
}
