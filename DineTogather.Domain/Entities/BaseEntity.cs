using System.ComponentModel.DataAnnotations;

namespace DineTogather.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
