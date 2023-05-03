using Microsoft.AspNetCore.Mvc;

namespace CarDealershipASPNETMVC.Controllers
{
    public class SettingsWithManagerAccess : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Gearbox()
        {
            return RedirectToAction("Index", "SettingsGearbox");
        }
        public IActionResult Fuel()
        {
            return RedirectToAction("Index", "SettingsFuel");
        }
        public IActionResult CarAccessoriesUnit()
        {
            return RedirectToAction("Index", "SettingsCarAccessoriesUnit");
        }
        public IActionResult CarAccessoriesProductGroup()
        {
            return RedirectToAction("Index", "SettingsCarAccessoriesProductGroup");
        }
        public IActionResult OrderStatus()
        {
            return RedirectToAction("Index", "SettingsOrderStatus");
        }
        public IActionResult Sex()
        {
            return RedirectToAction("Index", "SettingsSex");
        }
        public IActionResult Country()
        {
            return RedirectToAction("Index", "SettingsCountry");
        }
        public IActionResult SpokenLangues()
        {
            return RedirectToAction("Index", "SettingsSpokenLangues");
        }
    }
}
