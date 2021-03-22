using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sewit.Contracts;
using Sewit.Data;
using Sewit.Models;
using Sewit.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Controllers
{
    [Authorize]
    public class SkirtController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISkirtComponentRepository _skirtComponentRepository;
        private readonly IPhotoUploadService _photoUploadService;

        public SkirtController(IMapper mapper, ISkirtComponentRepository skirtComponentRepository, IPhotoUploadService photoUploadService)
        {
            _mapper = mapper;
            _skirtComponentRepository = skirtComponentRepository;
            _photoUploadService = photoUploadService;
        }

        public IActionResult Index()
        {
            var skirts = _skirtComponentRepository.FindAll();
            var model = _mapper.Map<List<SleeveComponentVM>>(skirts);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SkirtComponentCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var skirt = _mapper.Map<SkirtComponent>(model);

            skirt.PhotoPath = _photoUploadService.UploadImage(model.Photo);
            _skirtComponentRepository.Create(skirt);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var skirt = _skirtComponentRepository.FindById(id);
            var model = _mapper.Map<SkirtComponentEditVM>(skirt);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SkirtComponentEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var skirt = _mapper.Map<SkirtComponent>(model);
            _skirtComponentRepository.Update(skirt);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var skirt = _skirtComponentRepository.FindById(id);
            _skirtComponentRepository.Delete(skirt);

            return RedirectToAction("Index");
        }
    }
}
