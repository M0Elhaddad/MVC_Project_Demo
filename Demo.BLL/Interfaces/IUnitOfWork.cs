using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IitemRepository ItemRepository { get; set; }
        IStoreRepository StoreRepository { get; set; }
        IStoreItemRepository StoreItemRepository { get; set; }
        int Complete();
    }
}
