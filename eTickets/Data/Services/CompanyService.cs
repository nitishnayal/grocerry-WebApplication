using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class CompanyService : EntityBaseRepository<Company>,ICompanyService
    {
        public CompanyService(AppDbContext context) : base(context) { }
    }
}
