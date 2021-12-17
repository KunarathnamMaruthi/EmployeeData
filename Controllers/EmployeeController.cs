using EmployeeData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeData.Controllers
{
    public class EmployeeController : Controller
    {


        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _context.Employees.ToListAsync();

            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(employee);
        }


            public async Task<IActionResult> Edit(int? EmployeeId)
        {
            if (EmployeeId == null || EmployeeId <= 0)
                return BadRequest();
            var employeeinDb = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == EmployeeId);

            if (employeeinDb == null)
                return NotFound();

            return View(employeeinDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
        {
            if (!ModelState.IsValid)
                return View(employee);

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }



        public async Task<IActionResult> Delete(int? Employeeid)
        {
            if (Employeeid == null || Employeeid <= 0)
                return BadRequest();

            var employeeinDb = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == Employeeid);

            if (employeeinDb == null)
                return NotFound();

            _context.Employees.Remove(employeeinDb);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));



        

        }
            
    }
}