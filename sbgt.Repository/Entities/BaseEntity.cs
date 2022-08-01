using System.ComponentModel.DataAnnotations;
using sbgt.Repository.Entities.Interfaces;

namespace sbgt.Repository.Entities;

public class BaseEntity
    : IUpdatableEntity,
        IDeletableEntity
{
    [Key]
    [Required]
    public Guid Id { get; set; }

    public DateTime? UpdatedDateTime { get; set; }
    public DateTime? DeletedDateTime { get; set; }
}