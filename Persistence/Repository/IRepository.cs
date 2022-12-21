using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{

    public interface IRepository<T>
    {
        public Task<List<T>> GetAll();

        public Task<T> GetById(int Id);

        public Task<T> Add(T record);

        public void Update(T record);

        public void Delete(T record);

    }
}
