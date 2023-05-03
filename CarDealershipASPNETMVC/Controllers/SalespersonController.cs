using CarDealershipASPNETMVC.Data;
using CarDealershipASPNETMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipASPNETMVC.Controllers
{
    public class SalespersonController : Controller
    {
        private readonly DataAccess dataAccess;

        public SalespersonController()
        {
            dataAccess = new DataAccess();
        }

        // View Car Accessories All Data
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SalespersonModel> ListSalespersons = await dataAccess.SalespersonsViewData();

            return await Task.Run(() => View("Index", ListSalespersons));
        }

        // Customer Search Dynamic SQL
        [HttpGet]
        [ActionName("Search")]
        public async Task<IActionResult> Search_Get()
        {
            ViewBag.Sex = await dataAccess.SexViewData();

            ViewBag.Country = await dataAccess.CountryViewData();

            ViewBag.SpokenLangues = await dataAccess.SpokenLanguesViewData();

            ViewBag.Manager = await dataAccess.ManagerViewData();

            return View();
        }
        [HttpPost]
        [ActionName("Search")]
        public async Task<IActionResult> Search_Post()
        {
            SalespersonModel searchedSalesperson = new SalespersonModel();

            await TryUpdateModelAsync(searchedSalesperson);

            List<SalespersonModel> listSalespersonsSearchResult = await dataAccess.SalespersonsViewData(searchedSalesperson);

            return await Task.Run(() => View("Index", listSalespersonsSearchResult));

        }

        [HttpGet]
        [ActionName("Create")]
        public async Task<IActionResult> Create_Get()
        {
            ViewBag.Sex = await dataAccess.SexViewData();

            ViewBag.Country = await dataAccess.CountryViewData();

            ViewBag.SpokenLangues = await dataAccess.SpokenLanguesViewData();

            ViewBag.Manager = await dataAccess.ManagerViewData();

            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create_Post()
        {
            if (ModelState.IsValid)
            {
                SalespersonModel insertedSalesperson = new SalespersonModel();

                await TryUpdateModelAsync(insertedSalesperson);

                await dataAccess.SalespersonsUpdateOrInsert(insertedSalesperson);

                // inserts the email address into the tbl Login table
                // fügt die E-Mail-Adresse in die tbl-Login-Tabelle ein
                await dataAccess.EmailUpload(insertedSalesperson.Email);

                return RedirectToAction("Index");
            }
            return View();
        }

        // Update
        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Get(int id)
        {
            ViewBag.Sex = await dataAccess.SexViewData();

            ViewBag.Country = await dataAccess.CountryViewData();

            ViewBag.SpokenLangues = await dataAccess.SpokenLanguesViewData();
            
            ViewBag.Manager = await dataAccess.ManagerViewData();

            List<SalespersonModel> listSalespersons = await dataAccess.SalespersonsViewData();

            SalespersonModel findSalesperson = listSalespersons.Single(salesperson => salesperson.SalesId == id);

            return View(findSalesperson);
        }
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Post(SalespersonModel modelSalesperson)
        {
            List<SalespersonModel> listSalespersons = await dataAccess.SalespersonsViewData();

            SalespersonModel findUpdatedSalesperson = listSalespersons.Single(salesperson => salesperson.SalesId == modelSalesperson.SalesId);

            await TryUpdateModelAsync(findUpdatedSalesperson);

            if (ModelState.IsValid)
            {
                await dataAccess.SalespersonsUpdateOrInsert(findUpdatedSalesperson);

                return RedirectToAction("Index");
            }
            return View(findUpdatedSalesperson);
        }

        // Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await dataAccess.SalespersonsDelete(id);

            return RedirectToAction("Index");
        }

    }
}
