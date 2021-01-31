using System;
using System.Threading.Tasks;
using Logic.Exceptions;
using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly ILoggerService _loggerService;

        public HomeController(IHomeService homeService,  ILoggerService loggerService)
        {
            _homeService = homeService;
            _loggerService = loggerService;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Save(HomeViewModel model)
        {
            try
            { 
                await _homeService.SaveUserDataAsync(model);
            
                return View("Index", model);
            }
            catch (AlreadyCreatedException e)
            {
                _loggerService.Error(e);
                model.ErrorMessage = $"{e.Message}. Идентификатор: {e.Id}";
                
                return View("Index", model);
            }
            catch (Exception e)
            {
                _loggerService.Error(e);
                model.ErrorMessage = e.Message;
                
                return View("Index", model);
            }
        }
    }
}   