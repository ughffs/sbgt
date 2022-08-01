namespace sbgt.Repository.Entities.Interfaces;
public interface IDeletableEntity
{
    public DateTime? DeletedDateTime { get; set; }
}