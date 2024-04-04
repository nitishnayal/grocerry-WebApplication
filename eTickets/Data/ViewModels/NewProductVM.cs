using eTickets.Data.Base;
using eTickets.Data.Enums;
using eTickets.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Data.ViewModels
{
    public class NewProductVM
    {
        public int? Id { get; set; }

        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Product is required")]
        public string? Name { get; set; }

        [Display(Name = "Product description")]
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }


        [Range(0, double.MaxValue,ErrorMessage ="price should be greater than zero")]
        [Display(Name = "Price in Rs")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Product poster URL")]
        [Required(ErrorMessage = "Product poster URL is required")]
        public string? ImageURL { get; set; }

        [Display(Name = "Product start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Product end date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Product category is required")]
        public ProductCategory ProductCategory { get; set; }

        //Relationships
        [Display(Name = "Select company(s)")]
        [Required(ErrorMessage = "Product company(s) is required")]
        public List<int> CompanyIds { get; set; }

        [Display(Name = "Select a Store")]
        [Required(ErrorMessage = "Product Store is required")]
        public int StoreId { get; set; }

     
    }
}
