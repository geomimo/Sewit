using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sewit.Contracts;
using Sewit.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Controllers
{
    public class DesignController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDressRepository _dressRepository;
        private readonly ITopComponentRepository _topComponentRepository;
        private readonly ISkirtComponentRepository _skirtComponentRepository;
        private readonly ISleeveComponentRepository _sleeveComponentRepository;
        private readonly IRecommendationService _recommendationService;
        private static Dictionary<string, int> _preferences;


        public DesignController(IMapper mapper,
                                ITopComponentRepository topComponentRepository,
                                ISkirtComponentRepository skirtComponentRepository,
                                ISleeveComponentRepository sleeveComponentRepository)
        {
            _mapper = mapper;
            _topComponentRepository = topComponentRepository;
            _skirtComponentRepository = skirtComponentRepository;
            _sleeveComponentRepository = sleeveComponentRepository;

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
