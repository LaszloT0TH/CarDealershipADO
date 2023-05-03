using CarDealershipASPNETMVC.Data;
using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace CarDealershipASPNETMVC.Controllers
{
    public class SettingsCountryController : Controller
    {
        private readonly DataAccess dataAccess;

        public SettingsCountryController()
        {
            dataAccess = new DataAccess();
        }

        // View Country All Data
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CountryModel> ListCountries = await dataAccess.CountrysViewData();

            return await Task.Run(() => View("Index", ListCountries));
        }

        // Country Search Dynamic SQL
        [HttpGet]
        [ActionName("Search")]
        public async Task<IActionResult> Search_Get()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Search")]
        public async Task<IActionResult> Search_Post()
        {
            CountryModel searchedCountry = new CountryModel();

            await TryUpdateModelAsync(searchedCountry);

            List<CountryModel> listCountrySearchResult = await dataAccess.CountrysViewData(searchedCountry);

            return await Task.Run(() => View("Index", listCountrySearchResult));

        }

        [HttpGet]
        [ActionName("Create")]
        public async Task<IActionResult> Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create_Post()
        {
            if (ModelState.IsValid)
            {
                CountryModel insertedCountry = new CountryModel();

                await TryUpdateModelAsync(insertedCountry);

                await dataAccess.CountrysUpdateOrInsert(insertedCountry);

                return RedirectToAction("Index");
            }
            return View();
        }

        // Update
        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Get(int id)
        {
            List<CountryModel> listCar = await dataAccess.CountrysViewData();

            CountryModel findCountry = listCar.Single(Country => Country.CountryId == id);

            return View(findCountry);
        }
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Post(CountryModel modelCountry)
        {
            List<CountryModel> listCountry = await dataAccess.CountrysViewData();

            CountryModel findUpdatedCountry = listCountry.Single(Country => Country.CountryId == modelCountry.CountryId);

            await TryUpdateModelAsync(findUpdatedCountry);

            if (ModelState.IsValid)
            {
                await dataAccess.CountrysUpdateOrInsert(findUpdatedCountry);

                return RedirectToAction("Index");
            }
            return View(findUpdatedCountry);
        }

        // Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await dataAccess.CountrysDelete(id);

            return RedirectToAction("Index");
        }

    }
}
