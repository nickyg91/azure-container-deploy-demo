using Azure.Docker.Datalayer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Docker.Datalayer.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly List<Item> _items;
        public ItemRepository()
        {
            _items = new List<Item>();
        }

        public Item GetItemById(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public List<Item> GetItems()
        {
            return _items;
        }

        public void SaveItem(Item item)
        {
            _items.Add(item);
        }
    }
}