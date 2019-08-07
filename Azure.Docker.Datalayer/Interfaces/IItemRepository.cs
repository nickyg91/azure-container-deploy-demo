using System.Collections.Generic;

namespace Azure.Docker.Datalayer.Interfaces
{
    public interface IItemRepository
    {
         List<Item> GetItems();
         Item GetItemById(int id);
         void SaveItem(Item item);
    }
}