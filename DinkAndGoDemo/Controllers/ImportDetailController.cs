using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinkAndGoDemo.Data.Interfaces;
using DinkAndGoDemo.Data.Models;
using DinkAndGoDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DinkAndGoDemo.Controllers
{
    public class ImportDetailController : Controller
    {
        private readonly IImportDetailRepository _importDetailRepository;
        private readonly IImportRepositoy _importRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ImportDetailController(IImportDetailRepository importDetailRepository, IImportRepositoy importRepository, ICategoryRepository categoryRepository)
        {
            _importDetailRepository = importDetailRepository;
            _importRepository = importRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            IEnumerable<ImportDetail> importDetails;
            importDetails = _importDetailRepository.GetAll();

            var importDetail = new ImportDetailViewModel()
            {
                ImportDetails = importDetails
            };


            return View(importDetail);
        }

        public IActionResult Create()
        {
            ViewBag.Imports = _importRepository.GetAll();
            ViewBag.Categories = _categoryRepository.GetAll();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ImportDetail importDetail)
        {
            ViewBag.Imports = _importRepository.GetAll();
            ViewBag.Categories = _categoryRepository.GetAll();

            if (ModelState.IsValid)
            {
                await _importDetailRepository.CreateImportDetail(importDetail);
                return RedirectToAction("Index");
            }

            return View(importDetail);
        }


        public async Task<IActionResult> Edit(int? ImportDetailId)
        {
            ViewBag.Imports = _importRepository.GetAll();
            ViewBag.Categories = _categoryRepository.GetAll();

            if (ImportDetailId == null)
            {
                return NotFound();
            }

            var importDetail = await _importDetailRepository.GetById(ImportDetailId);

            if (importDetail == null)
            {
                return NotFound();
            }

            return View(importDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ImportDetail importDetail)
        {
            ViewBag.Imports = _importRepository.GetAll();
            ViewBag.Categories = _categoryRepository.GetAll();

            //if(importDetail.CategoryId == 0)
            //{
            //    importDetail.CategoryId = int.Parse(null);
            //}

            //if (importDetail.ImportId == 0)
            //{
            //    importDetail.ImportId = int.Parse(null);
            //}

            if (ModelState.IsValid)
            {
                _importDetailRepository.UpdateImportDetail(importDetail);

                return RedirectToAction("Index");
            }

            return View(importDetail);
        }

        public async Task<IActionResult> Delete(int? ImportDetailId)
        {
            if (ImportDetailId == null)
            {
                return NotFound();
            }

            var importDetail = await _importDetailRepository.GetById(ImportDetailId);

            if (importDetail == null)
            {
                return NotFound();
            }

            await _importDetailRepository.DeleteImportDetail(importDetail);

            return RedirectToAction("Index");
        }
    }
}