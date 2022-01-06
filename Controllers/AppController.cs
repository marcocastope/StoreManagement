using Microsoft.AspNetCore.Mvc;
using StoreManagement.Data;
using System;
using System.Linq;

namespace StoreManagement.Controllers
{
    public class AppController : Controller
    {
        private readonly IStoreRepository repository;

        public AppController(IStoreRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("about")]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet("shop")]
        public IActionResult Shop()
        {
            var result = repository.GetAllProducts();
            return View(result);
        }
    }
}
