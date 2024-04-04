using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
	public class Store :IEntityBase
	{
		[Key]
		public int? Id { get; set; }



		[Display(Name = "Store Logo")]
		[Required(ErrorMessage = "Store logo is required")]
		public string? Logo { get; set; }





		[Display(Name = "Store Name")]
		[Required(ErrorMessage = "Store name is required")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Use letters only please")]
        public string? Name { get; set; }





		[Display(Name = "Description")]
		[Required(ErrorMessage = "Store description is required")]
		public string? Description { get; set; }





		//Relationships
		public List<Product>? Products { get; set; }
	}
}
