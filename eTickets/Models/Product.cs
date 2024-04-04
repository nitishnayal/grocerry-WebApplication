﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using eTickets.Data.Enums;
using eTickets.Data.Base;

namespace eTickets.Models
{
	public class Product : IEntityBase
	{
		[Key]
		public int? Id { get; set; }

		public string? Name { get; set; }
		public string? Description { get; set; }
		public double Price { get; set; }
		public string? ImageURL { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public ProductCategory ProductCategory { get; set; }

		//Relationships
		public List<Company_Product> Company_Products { get; set; }

		//Cinema
		public int? StoreId { get; set; }
		[ForeignKey("StoreId")]
		public Store Store { get; set; }



	}
}