 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnSearch.Web.Data;
using OnSearch.Web.Entities;
using OnSearch.Web.Enums;
using OnSearch.Web.Helpers;

namespace OnSearch.Web.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly DataContext _context;
        private readonly UserHelper _userHelper;

        public CompaniesController(DataContext context, UserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        // GET: Companies
        [Authorize(Roles = "UserS")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Companies.Where(p => p.UserF == User.Identity.Name).FirstAsync());
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        [Authorize(Roles = "User")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Create([Bind("Id,Name,NIT,Number")] Company company)
        {
            company.UserF = User.Identity.Name;
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                string email = User.Identity.Name;
                User user = await _userHelper.GetUserAsync(email);
                user.UserType = UserType.UserS;
                await _userHelper.RemoveFromRoleAsync(user, "User");
                await _userHelper.AddUserToRoleAsync(user, "UserS");               
                await _userHelper.UpdateUserAsync(user);
                await _userHelper.RefreshSignInAsync(user);

                return RedirectToAction("Index", "Home");
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,NIT,Number")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("NotFound");
            }

            var unit = await _context.Companies.FindAsync(id);
            if (unit == null)
            {
                return new NotFoundViewResult("NotFound");
            }

            try
            {
                _context.Companies.Remove(unit);
                await _context.SaveChangesAsync();
                string email = User.Identity.Name;
                User user = await _userHelper.GetUserAsync(email);
                user.UserType = UserType.UserS;
                await _userHelper.RemoveFromRoleAsync(user, "UserS");
                await _userHelper.AddUserToRoleAsync(user, "User");
                await _userHelper.UpdateUserAsync(user);
                await _userHelper.RefreshSignInAsync(user);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.ToUpper().Contains("REFERENCE"))
                {
                    return new NotFoundViewResult("ErrorDelete");
                }
                else
                {
                    return new NotFoundViewResult("ErrorDelete");
                }
            }
        }

        public IActionResult ErrorDelete()
        {
            return this.View();
        }


        private bool CompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
