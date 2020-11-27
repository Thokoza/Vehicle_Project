using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Project_Vehicle.Data;

namespace Project_Vehicle.Models
{
    public class WaybillsController : Controller
    {
        private readonly VehicleContext _context;

        public WaybillsController(VehicleContext context)
        {
            _context = context;
        }

        // GET: Waybills
        public async Task<IActionResult> Index()
        {
            var allwaybills =   _context.Waybill.ToList();
            var allvehicles = _context.Vehicle.ToList();

            var waybill = from waybillList in allwaybills
                          join veh in allvehicles on waybillList.VehicleId equals veh.Id
                          select new Waybill
                          {
                              Id = waybillList.Id,
                                WaybilNumber =  waybillList.WaybilNumber,
                                VehicleName = veh.Name,
                                VehicleId = waybillList.VehicleId,
                               From =  waybillList.From,
                               To =  waybillList.To,
                              Quantity = waybillList.Quantity,
                               Weight =  waybillList.Weight,
                               Date = waybillList.Date
                          };

            return View(waybill);
        }

        // GET: Waybills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waybill = await _context.Waybill
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waybill == null)
            {
                return NotFound();
            }

            return View(waybill);
        }

        // GET: Waybills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Waybills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WaybilNumber,From,To,Date,Weight,Quantity")] Waybill waybill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waybill);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(waybill);
        }

        // GET: Waybills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waybill = await _context.Waybill.FindAsync(id);
            if (waybill == null)
            {
                return NotFound();
            }
            return View(waybill);
        }

        // POST: Waybills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WaybilNumber,From,To,Date,Weight,Quantity")] Waybill waybill)
        {
            if (id != waybill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waybill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaybillExists(waybill.Id))
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
            return View(waybill);
        }

        // GET: Waybills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waybill = await _context.Waybill
                .FirstOrDefaultAsync(m => m.Id == id);
            if (waybill == null)
            {
                return NotFound();
            }

            return View(waybill);
        }

        // POST: Waybills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waybill = await _context.Waybill.FindAsync(id);
            _context.Waybill.Remove(waybill);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WaybillExists(int id)
        {
            return _context.Waybill.Any(e => e.Id == id);
        }
    }
}
