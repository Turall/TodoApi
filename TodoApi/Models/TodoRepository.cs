using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoRepository : ITodoRepository
    {
        private static ConcurrentDictionary<string, StatusInfo> _todos = new ConcurrentDictionary<string, StatusInfo>();

        public TodoRepository()
        {
            Add(new StatusInfo { Azercell = "Test" });
        }

        public void Add(StatusInfo item)
        {
            item.Key = Guid.NewGuid().ToString();
            _todos[item.Key] = item;
        }

        public StatusInfo Find(string key)
        {
            StatusInfo item;
            _todos.TryGetValue(key, out item);
            return item;
        }

        public IEnumerable<StatusInfo> GetAll()
        {
            return _todos.Values;
        }

        public StatusInfo Remove(string key)
        {
            StatusInfo item;
            _todos.TryRemove(key, out item);
            return item;
        }

        public void Update(StatusInfo item)
        {
            _todos[item.Key] = item;
        }
    }
}
