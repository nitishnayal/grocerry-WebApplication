using eTickets.Models;

namespace eTickets.Data.ViewModels
{
   
    public class NewProductDropdownsVM
    {
        public NewProductDropdownsVM()
        {
          
            Stores = new List<Store>();
            Companies = new List<Company>();
        }

     
        public List<Store>? Stores { get; set; }
        public List<Company>? Companies { get; set; }
    }
}
