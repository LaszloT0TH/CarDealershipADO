using CarDealershipASPNETMVC.Data;
using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace CarDealershipASPNETMVC.Controllers
{
    public class SettingsCarAccessoriesUnitController : Controller
    {
        private readonly DataAccess dataAccess;

        public SettingsCarAccessoriesUnitController()
        {
            dataAccess = new DataAccess();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CarAccessoriesUnitModel> ListCAU = await dataAccess.CarAccessoriesUnitsViewData();

            return await Task.Run(() => View("Index", ListCAU));
        }

        // Search Dynamic SQL
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
            CarAccessoriesUnitModel searchedCAU = new CarAccessoriesUnitModel();

            await TryUpdateModelAsync(searchedCAU);

            List<CarAccessoriesUnitModel> listCAUSearchResult = await dataAccess.CarAccessoriesUnitsViewData(searchedCAU);

            return await Task.Run(() => View("Index", listCAUSearchResult));

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
                CarAccessoriesUnitModel insertedCAU = new CarAccessoriesUnitModel();

                await TryUpdateModelAsync(insertedCAU);

                await dataAccess.CarAccessoriesUnitsUpdateOrInsert(insertedCAU);

                return RedirectToAction("Index");
            }
            return View();
        }

        // Update
        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Get(int id)
        {
            List<CarAccessoriesUnitModel> listCAU = await dataAccess.CarAccessoriesUnitsViewData();

            CarAccessoriesUnitModel findCAU = listCAU.Single(carAU => carAU.CAUId == id);

            return View(findCAU);
        }
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Post(CarAccessoriesUnitModel CAu)
        {
            List<CarAccessoriesUnitModel> listCAU = await dataAccess.CarAccessoriesUnitsViewData();

            CarAccessoriesUnitModel findUpdatedCAU = listCAU.Single(carAU => carAU.CAUId == CAu.CAUId);

            await TryUpdateModelAsync(findUpdatedCAU);

            if (ModelState.IsValid)
            {
                await dataAccess.CarAccessoriesUnitsUpdateOrInsert(findUpdatedCAU);

                return RedirectToAction("Index");
            }
            return View(findUpdatedCAU);
        }

        // Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await dataAccess.CarAccessoriesUnitsDelete(id);

            return RedirectToAction("Index");
        }

    }
}
