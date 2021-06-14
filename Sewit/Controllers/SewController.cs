using AutoMapper;
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
    public class SewController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDressRepository _dressRepository;
        private readonly ITopComponentRepository _topComponentRepository;
        private readonly ISkirtComponentRepository _skirtComponentRepository;
        private readonly ISleeveComponentRepository _sleeveComponentRepository;
        private readonly IRecommendationService _recommendationService;
        private static Dictionary<string, int> _preferences;


        public SewController(IMapper mapper,
                             IDressRepository dressRepository,
                             ITopComponentRepository topComponentRepository,
                             ISkirtComponentRepository skirtComponentRepository,
                             ISleeveComponentRepository sleeveComponentRepository,
                             IRecommendationService recommendationService)
        {
            _mapper = mapper;
            _dressRepository = dressRepository;
            _topComponentRepository = topComponentRepository;
            _skirtComponentRepository = skirtComponentRepository;
            _sleeveComponentRepository = sleeveComponentRepository;
            _recommendationService = recommendationService;

        }

        public IActionResult Index()
        {
            _preferences = new Dictionary<string, int>(); // Initialize the preferences of the user

            var allDresses = _dressRepository.FindAll(); // Get 4 random dresses for the 'Our work' section
            var ourWork = new List<Dress>();
            var random = new Random();
            for(int i = 0; i < 4; i++)
            {
                int index = random.Next(allDresses.Count);
                ourWork.Add(allDresses[index]);
            }

            var model = _mapper.Map<List<DressVM>>(ourWork);
            return View(model);
        }

        public IActionResult Top()
        {
            var tops = _topComponentRepository.FindAll(); // Get all top designs 
            var model = _mapper.Map<List<TopComponentVM>>(tops);
            ViewBag.Progress = 25;
            ViewBag.ProgressLabel = "Top";
            ViewBag.Next = "Skirt";
            return View(model);
        }

        public IActionResult Skirt(int id)
        {
            _preferences["Top"] = id; // Add to preferences the top choice of the user
            var skirts = _skirtComponentRepository.FindAll(); // Get all skirt designs
            var model = _mapper.Map<List<SkirtComponentVM>>(skirts);
            ViewBag.Progress = 50;
            ViewBag.ProgressLabel = "Skirt";
            ViewBag.Next = "Sleeve";

            return View(model);
        }

        public IActionResult Sleeve(int id)
        {
            _preferences["Skirt"] = id; // Add to preferences the skirt choice of the user
            var sleeves = _sleeveComponentRepository.FindAll(); // Get all sleeve designs
            var model = _mapper.Map<List<SleeveComponentVM>>(sleeves);
            ViewBag.Progress = 75;
            ViewBag.ProgressLabel = "Sleeve";
            ViewBag.Next = "Recommend";

            return View(model);
        }

        public IActionResult Recommend(int id)
        {
            _preferences["Sleeve"] = id; // Add to preferences the sleeve choice of the user

            // Get the recommendations based on preferences
            var recommendations = _recommendationService.RecommnedDresses(_preferences); 
            var model = _mapper.Map<List<DressVM>>(recommendations);

            return View(model); // Display preferences
        }
    }
}
