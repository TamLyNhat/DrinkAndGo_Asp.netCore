using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkAndGoDemo.Data.Interfaces;
using DinkAndGoDemo.Data.Models;
using DinkAndGoDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DinkAndGoDemo.Controllers
{
    public class ImportController : Controller
    {
        private readonly IImportRepositoy _importRepository;

        public ImportController(IImportRepositoy importRepositoy)
        {
            _importRepository = importRepositoy;
        }

        public IActionResult Index()
        {
            IEnumerable<Import> imports;

            imports = _importRepository.GetAll();

            var importViewModel = new ImportViewModel
            {
                Imports = imports
            };

            return View(importViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Import import)
        {

            if (ModelState.IsValid)
            {
                _importRepository.CreateImport(import);
                return RedirectToAction("Index");
            }

            return View(import);
        }


        //public IActionResult Edit(int? ImportId)
        //{
        //    if (ImportId == null)
        //    {
        //        return NotFound();
        //    }

        //    var import = _importRepository.GetById(ImportId);

        //    if (import == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(import);
        //}

        public async Task<IActionResult> Edit(int? ImportId)
        {
            if (ImportId == null)
            {
                return NotFound();
            }

            var import = await _importRepository.GetById(ImportId);

            if (import == null)
            {
                return NotFound();
            }

            return View(import);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Import import)
        {
            if (ModelState.IsValid)
            {
                _importRepository.Update(import);

                return RedirectToAction("Index");
            }

            return View(import);
        }

        public async Task<IActionResult> Delete(int? ImportId)
        {
            if (ImportId == null)
            {
                return NotFound();
            }

            var import = await _importRepository.GetById(ImportId);

            if (import == null)
            {
                return NotFound();
            }

            _importRepository.DeleteImport(import);

            return View(import);
        }
    }
}