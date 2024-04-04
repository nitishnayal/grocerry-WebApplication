using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
	public class Company :IEntityBase
	{
		[Key]
		public int? Id { get; set; }



		[Display(Name = "Profile Picture")]
		[Required(ErrorMessage = "Profile Picture is required")]
        
        public string? ProfilePictureURL { get; set; }





		[Display(Name = "Full Name")]
		[Required(ErrorMessage = "Full Name is required")]
		
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Use letters only please")]
        public string? FullName { get; set; }





		[Display(Name = "Biography")]
		[Required(ErrorMessage = "Biography is required")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Use letters only please")]


        public string? Bio { get; set; }





		//Relationships
		public List<Company_Product>? Company_Products { get; set; }
	}
}
