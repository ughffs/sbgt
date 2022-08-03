namespace sbgt. ServiceLogic.Services.Interfaces;

public interface IItemService
{
    Task GetItemByGuid(Guid guid, CancellationToken cancellationToken);
}