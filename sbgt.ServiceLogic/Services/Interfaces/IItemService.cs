namespace sbgt. ServiceLogic.Services.Interfaces;

public interface IItemService
{
    Task<ClientModel.Item> GetItemByGuid(Guid guid, CancellationToken cancellationToken);
    Task<List<ClientModel.Item>> GetAllItems(CancellationToken cancellationToken);
}