using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ProductService : EntityBaseRepository<Product>, IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                StoreId = data.StoreId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                ProductCategory = data.ProductCategory,
                
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.CompanyIds)
            {
                var newCompanyProduct = new Company_Product()
                {
                    ProductId = newProduct.Id,
                    CompanyId = actorId
                };
                await _context.Company_Products.AddAsync(newCompanyProduct);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await _context.Products
                .Include(c => c.Store)
                .Include(am => am.Company_Products).ThenInclude(a => a.Company)
                .FirstOrDefaultAsync(n => n.Id == id);

            return productDetails;
        }

        public async Task<NewProductDropdownsVM> GetNewProductDropdownsValues()
        {
            var response = new NewProductDropdownsVM()
            {
                Companies = await _context.Companies.OrderBy(n => n.FullName).ToListAsync(),
                Stores = await _context.Stores.OrderBy(n => n.Name).ToListAsync(),
               
            };

            return response;
        }

        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbProduct != null)
            {
                dbProduct.Name = data.Name;
                dbProduct.Description = data.Description;
                dbProduct.Price = data.Price;
                dbProduct.ImageURL = data.ImageURL;
                dbProduct.StoreId = data.StoreId;
                dbProduct.StartDate = data.StartDate;
                dbProduct.EndDate = data.EndDate;
                dbProduct.ProductCategory = data.ProductCategory;
              
                await _context.SaveChangesAsync();
            }

            //Remove existing company
            var existingcompanyDb = _context.Company_Products.Where(n => n.ProductId == data.Id).ToList();
            _context.Company_Products.RemoveRange(existingcompanyDb);
            await _context.SaveChangesAsync();

            //Add Product company
            foreach (var actorId in data.CompanyIds)
            {
                var newProductCompany = new Company_Product()
                {
                    ProductId = data.Id,
                    CompanyId = actorId
                };
                await _context.Company_Products.AddAsync(newProductCompany);
            }
            await _context.SaveChangesAsync();
        }
    }
}


