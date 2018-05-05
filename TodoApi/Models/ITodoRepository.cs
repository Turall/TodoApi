using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
   public interface ITodoRepository
    {
        void Add(StatusInfo item);
        IEnumerable<StatusInfo> GetAll();
        StatusInfo Find(string key);
        StatusInfo Remove(string key);
        void Update(StatusInfo item);
    }
}
