using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sewit.Contracts;
using Sewit.Data;
using Sewit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Controllers
{
    [Authorize]
    public class SleeveController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISleeveComponentRepository _sleeveComponentRepository;
        private readonly IPhotoUploadService _photoUploadService;

        public SleeveController(IMapper mapper, ISleeveComponentRepository sleeveComponentRepository, IPhotoUploadService photoUploadService)
        {
            _mapper = mapper;
            _sleeveComponentRepository = sleeveComponentRepository;
            _photoUploadService = photoUploadService;
        }

        public IActionResult Index()
        {
            var sleeves = _sleeveComponentRepository.FindAll();
            var model = _mapper.Map<List<SleeveComponentVM>>(sleeves);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SleeveComponentCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var sleeve = _mapper.Map<SleeveComponent>(model);

            sleeve.PhotoPath = _photoUploadService.UploadImage(model.Photo);
            _sleeveComponentRepository.Create(sleeve);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var sleeve = _sleeveComponentRepository.FindById(id);
            var model = _mapper.Map<SleeveComponentEditVM>(sleeve);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SleeveComponentEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var sleeve = _mapper.Map<SleeveComponent>(model);
            _sleeveComponentRepository.Update(sleeve);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var sleeve = _sleeveComponentRepository.FindById(id);
            _sleeveComponentRepository.Delete(sleeve);

            return RedirectToAction("Index");
        }
    }
}
