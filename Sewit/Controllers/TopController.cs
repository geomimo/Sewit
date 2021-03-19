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
    public class TopController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITopComponentRepository _topComponentRepository;

        public TopController(IMapper mapper, ITopComponentRepository topComponentRepository)
        {
            _mapper = mapper;
            _topComponentRepository = topComponentRepository;
        }

        public IActionResult Index()
        {
            var tops = _topComponentRepository.FindAll();
            var model = _mapper.Map<List<TopComponentVM>>(tops);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TopComponentCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var top = _mapper.Map<TopComponent>(model);
            _topComponentRepository.Create(top);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var top = _topComponentRepository.FindById(id);
            var model = _mapper.Map<TopComponentEditVM>(top);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TopComponentEditVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var top = _mapper.Map<TopComponent>(model);
            _topComponentRepository.Update(top);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var top = _topComponentRepository.FindById(id);
            _topComponentRepository.Delete(top);

            return RedirectToAction("Index");
        }
    }
}
