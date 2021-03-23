using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sewit.Contracts;
using Sewit.Models;
using Sewit.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Controllers
{
    public class SewController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITopComponentRepository _topComponentRepository;
        private readonly ISkirtComponentRepository _skirtComponentRepository;
        private readonly ISleeveComponentRepository _sleeveComponentRepository;
        private readonly IRecommendationService _recommendationService;
        private static Dictionary<string, int> _preferences;


        public SewController(IMapper mapper,
                             ITopComponentRepository topComponentRepository,
                             ISkirtComponentRepository skirtComponentRepository,
                             ISleeveComponentRepository sleeveComponentRepository,
                             IRecommendationService recommendationService)
        {
            _mapper = mapper;
            _topComponentRepository = topComponentRepository;
            _skirtComponentRepository = skirtComponentRepository;
            _sleeveComponentRepository = sleeveComponentRepository;
            _recommendationService = recommendationService;

        }

        public IActionResult Index()
        {
            _preferences = new Dictionary<string, int>();
            return View();
        }

        public IActionResult Top()
        {
            var tops = _topComponentRepository.FindAll();
            var model = _mapper.Map<List<TopComponentVM>>(tops);
            ViewBag.Progress = 25;
            ViewBag.ProgressLabel = "Top";
            ViewBag.Next = "Skirt";
            return View(model);
        }

        public IActionResult Skirt(int id)
        {
            _preferences["Top"] = id;
            var skirts = _skirtComponentRepository.FindAll();
            var model = _mapper.Map<List<SkirtComponentVM>>(skirts);
            ViewBag.Progress = 50;
            ViewBag.ProgressLabel = "Skirt";
            ViewBag.Next = "Sleeve";

            return View(model);
        }

        public IActionResult Sleeve(int id)
        {
            _preferences["Skirt"] = id;
            var sleeves = _sleeveComponentRepository.FindAll();
            var model = _mapper.Map<List<SleeveComponentVM>>(sleeves);
            ViewBag.Progress = 75;
            ViewBag.ProgressLabel = "Sleeve";
            ViewBag.Next = "Recommend";

            return View(model);
        }

        public IActionResult Recommend(int id)
        {
            _preferences["Sleeve"] = id;

            var recommendations = _recommendationService.RecommnedDresses(_preferences);
            var model = _mapper.Map<List<DressVM>>(recommendations);

            return View(model);
        }
    }
}
