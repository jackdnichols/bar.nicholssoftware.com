using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bar.mobile.Models;

namespace bar.mobile.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Rusty Bucket Restaurant & Tavern", Description="42874 Woodward Ave MI. (248) 239-3663" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "D’Marcos Italian Restaurant and Wine Bar", Description="401 S Main St. MI. (248) 759-4951" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "X-Golf Rochester Hills", Description="1134 S Rochester Rd MI. (248) 759-4195" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Orion Sports Bar & Grill", Description="1172 S Lapeer Rd MI. (248) 693-3015" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Old Detroit Bar and Grille", Description="741 S Lapeer Rd MI. (248) 814-8109" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Wine Social", Description="135 S Broadway St MI. (248) 783-7111" }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}