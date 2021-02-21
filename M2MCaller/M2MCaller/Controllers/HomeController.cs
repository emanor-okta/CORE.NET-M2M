using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using M2MCaller.Models;
using M2MCaller.Services;
using M2MCaller.TokenService;

namespace M2MCaller.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiService apiService;
        private readonly ITokenService tokenService;

        public HomeController(ILogger<HomeController> logger, IApiService apiService, ITokenService tokenService)
        {
            _logger = logger;
            this.apiService = apiService;
            this.tokenService = tokenService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetToken()
        {
            var token = await tokenService.GetToken();
            ViewData["token"] = token;
            return View();
        }

        public async Task<IActionResult> CallApi()
        {
            var values = await apiService.GetValues();
            return View(values);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
