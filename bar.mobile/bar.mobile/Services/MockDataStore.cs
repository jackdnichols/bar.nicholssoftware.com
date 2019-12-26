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
                new Item { Id = Guid.NewGuid().ToString(), Text = "Rusty Bucket Restaurant & Tavern", Description="42874 Woodward Ave MI. (248) 239-3663", ImageUrl="https://s3-media0.fl.yelpcdn.com/bphoto/-qYFoL7TuHTZ0PQjfREeAw/ls.jpg" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "D’Marcos Italian Restaurant and Wine Bar", Description="401 S Main St. MI. (248) 759-4951", ImageUrl="https://s3-media0.fl.yelpcdn.com/bphoto/QgqDpulJBeLyZAGtLb8oTw/ls.jpg" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "X-Golf Rochester Hills", Description="1134 S Rochester Rd MI. (248) 759-4195", ImageUrl="https://s3-media0.fl.yelpcdn.com/bphoto/_Ji0axbYlvLdMI2FnyMvKg/ls.jpg" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Orion Sports Bar & Grill", Description="1172 S Lapeer Rd MI. (248) 693-3015", ImageUrl="https://s3-media0.fl.yelpcdn.com/bphoto/rdP8OKCEqcW8WS_PNo7qEg/ls.jpg" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Old Detroit Bar and Grille", Description="741 S Lapeer Rd MI. (248) 814-8109", ImageUrl="https://s3-media0.fl.yelpcdn.com/bphoto/Qks0oTkt9glBMUkIKb-gJw/ls.jpg" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Wine Social", Description="135 S Broadway St MI. (248) 783-7111", ImageUrl="https://s3-media0.fl.yelpcdn.com/bphoto/gwnFcnlEJ-gXX-2Bnhs9QA/ls.jpg" }
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