using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services
{
    public class StoreService : EntityBaseRepository<Store>, IStoreService
    {
        public StoreService(AppDbContext context) : base(context)
        {
        }
    }
}
