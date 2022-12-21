using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IItemService<T>
    {
        Task<IEnumerable<T>> GetAllItems();

        Task<T> GetItemById(int iid);

        void AddItem(T item);

        void EditItem(T item);

        void DeleteItem(int item);
    }

}