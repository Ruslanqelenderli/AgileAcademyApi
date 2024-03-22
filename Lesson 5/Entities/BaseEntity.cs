using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson_5.Entities
{
    public class BaseEntity
    {
        [Column("IS_DELETED")]
        public bool IsDeleted { get; set; }
        public int Id { get; set; }
    }
}
