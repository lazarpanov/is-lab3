﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IntegratedSystems.Domain.Domain_Models;
using IntegratedSystems.Repository;
using IntegratedSystems.Service.Interface;

namespace IntegratedSystems.Web.Controllers
{
    public class VaccinationCentersController : Controller
    {
        private readonly IVaccinationCenterService vaccinationCenterService;
        private readonly IPatientService patientService;
        private readonly IVaccineService vaccineService;

        public VaccinationCentersController(IVaccineService vaccineService, IVaccinationCenterService vaccinationCenterService, IPatientService patientService)
        {
            this.vaccineService = vaccineService;
            this.vaccinationCenterService = vaccinationCenterService;
            this.patientService = patientService;
        }
        // GET: VaccinationCenters
        public async Task<IActionResult> Index()
        {
            return View(vaccinationCenterService.GetAllVaccinationCenters());
        }

        // GET: VaccinationCenters/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationCenter = vaccinationCenterService.GetDetailsForVaccinationCenter(id);
            ViewBag.Centers = vaccineService.getAll().Where(i => i.VaccinationCenter.Equals(id));
            if (vaccinationCenter == null)
            {
                return NotFound();
            }

            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VaccinationCenters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Address,MaxCapacity,Id")] VaccinationCenter vaccinationCenter)
        {
            if (ModelState.IsValid)
            {
                vaccinationCenterService.CreateNewVaccinationCenter(vaccinationCenter);
                return RedirectToAction(nameof(Index));
            }
            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationCenter = vaccinationCenterService.GetDetailsForVaccinationCenter(id);
            if (vaccinationCenter == null)
            {
                return NotFound();
            }
            return View(vaccinationCenter);
        }

        // POST: VaccinationCenters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Address,MaxCapacity,Id")] VaccinationCenter vaccinationCenter)
        {
            if (id != vaccinationCenter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vaccinationCenterService.UpdateExistingVaccinationCenter(vaccinationCenter);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccinationCenterExists(vaccinationCenter.Id))
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
            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationCenter = vaccinationCenterService.GetDetailsForVaccinationCenter(id);
            if (vaccinationCenter == null)
            {
                return NotFound();
            }

            return View(vaccinationCenter);
        }

        // POST: VaccinationCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vaccinationCenter = vaccinationCenterService.GetDetailsForVaccinationCenter(id);
            if (vaccinationCenter != null)
            {
                vaccinationCenterService.DeleteVaccinationCenter(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool VaccinationCenterExists(Guid id)
        {
            return vaccinationCenterService.GetDetailsForVaccinationCenter(id) != null;
        }
    }
}
