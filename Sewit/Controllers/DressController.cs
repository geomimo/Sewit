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
    public class DressController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDressRepository _dressRepository;
        private readonly ITopComponentRepository _topComponentRepository;
        private readonly IPhotoUploadService _photoUploadService;
        private readonly IRecommendationService _recommendationService;
        private readonly ISleeveComponentRepository _sleeveComponentRepository;
        private readonly ISkirtComponentRepository _skirtComponentRepository;

        public DressController(IMapper mapper, 
                               IDressRepository dressRepository,
                               ITopComponentRepository topComponentRepository,
                               ISleeveComponentRepository sleeveComponentRepository,
                               ISkirtComponentRepository skirtComponentRepository,
                               IPhotoUploadService photoUploadService, 
                               IRecommendationService recommendationService)
        {
            _mapper = mapper;
            _dressRepository = dressRepository;
            _topComponentRepository = topComponentRepository;
            _sleeveComponentRepository = sleeveComponentRepository;
            _skirtComponentRepository = skirtComponentRepository;
            _photoUploadService = photoUploadService;
            _recommendationService = recommendationService;
        }

        
        public IActionResult Index()
        {
            var dresses = _dressRepository.FindAll();
            var model = _mapper.Map<List<DressVM>>(dresses);
            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.Tops = _topComponentRepository.FindAll();
            ViewBag.Sleeves = _sleeveComponentRepository.FindAll();
            ViewBag.Skirts = _skirtComponentRepository.FindAll();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DressCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dress = _mapper.Map<Dress>(model);

            dress.PhotoPath = _photoUploadService.UploadImage(model.Photo);
            _dressRepository.Create(dress);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var dress = _dressRepository.FindById(id);
            var model = _mapper.Map<DressEditVM>(dress);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DressEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var dress = _mapper.Map<Dress>(model);

            
            _dressRepository.Update(dress);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var dress = _dressRepository.FindById(id);

            var categories = new Dictionary<string, int>()
            {
                { "Top", dress.TopId },
                { "Skirt", dress.SkirtId },
                { "Sleeve", dress.SleeveId }
            };

            var recommendations = _recommendationService.RecommnedDresses(categories, id).Where(d=>d.DressId != dress.DressId).Take(4).ToList();

            ViewBag.Recommendations = _mapper.Map<List<DressVM>>(recommendations);

            var model = _mapper.Map<DressVM>(dress);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var dress = _dressRepository.FindById(id);
            _dressRepository.Delete(dress);

            return RedirectToAction("Index");
        }
    }
}
