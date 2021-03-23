﻿using AutoMapper;
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
        private readonly IPhotoUploadService _photoUploadService;


        public DressController(IMapper mapper, IDressRepository dressRepository, IPhotoUploadService photoUploadService)
        {
            _mapper = mapper;
            _dressRepository = dressRepository;
            _photoUploadService = photoUploadService;
        }

        public IActionResult Index()
        {
            var dresses = _dressRepository.FindAll();
            var model = _mapper.Map<List<DressVM>>(dresses);
            return View(model);
        }

        public IActionResult Create()
        {
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

        public IActionResult Detail(int id)
        {
            var dress = _dressRepository.FindById(id);
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
