using CarDealershipASPNETMVC.Data;
using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipASPNETMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataAccess dataAccess;

        public LoginController()
        {
            dataAccess = new DataAccess();
        }
        
        [HttpGet]
        [ActionName("Edit")]
        public IActionResult Edit()
        {
            return View();
        }


        // Email Customer = nehler.tine@gmail.com
        // Salesperson = dfg.vienna@gmail.com
        // Manager = hbsfg.vnna@gmail.com
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Post()
        {
            LoginModel log = new LoginModel();

            await TryUpdateModelAsync(log);

            GlobalData.UserId = await dataAccess.LoginData(log.Email);
            if (GlobalData.UserId > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return await Task.Run(() => View("Edit"));
            }

        }

    }
}
