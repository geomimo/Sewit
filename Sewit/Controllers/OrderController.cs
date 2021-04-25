using AutoMapper;
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
    public class OrderController : Controller
    {
        private static OrderVM order = new OrderVM()
        {
            Dresses = new List<DressVM>()
        };
        private readonly IDressRepository _dressRepository;
        private readonly IMapper _mapper;

        public OrderController(IDressRepository dressRepository, IMapper mapper)
        {
            _dressRepository = dressRepository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(order);
        }

        public IActionResult AddItem(DressVM dress)
        {
            var size = dress.SelectedSize;
            dress = _mapper.Map<DressVM>(_dressRepository.FindById(dress.DressId));
            dress.SelectedSize = size;
            order.Dresses.Add(dress);
            order.TotalPrice = order.Dresses.Sum(d => d.Price);
            return RedirectToAction("Index");
        }
    }
}
