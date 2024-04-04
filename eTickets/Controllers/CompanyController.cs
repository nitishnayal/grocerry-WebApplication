using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{

    [Authorize(Roles = UserRoles.Admin)]
    public class Companycontroller : Controller

    {
        //ICompanyService  _service is used for handling business related tasks 
        private readonly ICompanyService _service;

        public Companycontroller(ICompanyService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Company/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //Bind- It’s used to specify which properties of a model should be included in model binding
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Company company)
        {

            if (!ModelState.IsValid)
            {
                return View(company);
            }
            await _service.AddAsync(company);
            return RedirectToAction(nameof(Index));
        }

    
        public async Task<IActionResult> Details(int id)
        {
            var companyDetails = await _service.GetByIdAsync(id);

            if (companyDetails == null) return View("NotFound");
            return View(companyDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var companyEdits = await _service.GetByIdAsync(id);
            if (companyEdits == null) return View("NotFound");
            return View(companyEdits);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Company company)
        {
            if (!ModelState.IsValid)
            {
                return View(company);
            }
            await _service.UpdateAsync(id, company);
            return RedirectToAction(nameof(Index));
        }

  
        public async Task<IActionResult> Delete(int id)
        {
            var companyDelete = await _service.GetByIdAsync(id);
            if (companyDelete == null) return View("NotFound");
            return View(companyDelete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyDelete = await _service.GetByIdAsync(id);
            if (companyDelete == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
