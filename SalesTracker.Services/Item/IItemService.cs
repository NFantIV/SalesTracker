
public interface IItemService
{
    Task<bool> CreateItemAsync(ItemCreate itemCreate);
    Task<IEnumerable<ItemListItem>> GetAllItemsAsync();
    Task<ItemDetails> GetItemByIdAsync(int itemId);
    Task<bool> EditItemAsync(ItemEdit request);
    Task<bool> DeleteItemAsync(int itemId);
}
