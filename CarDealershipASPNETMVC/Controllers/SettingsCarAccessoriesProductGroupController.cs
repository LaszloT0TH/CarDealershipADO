using CarDealershipASPNETMVC.Data;
using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace CarDealershipASPNETMVC.Controllers
{
    public class SettingsCarAccessoriesProductGroupController : Controller
    {
        private readonly DataAccess dataAccess;

        public SettingsCarAccessoriesProductGroupController()
        {
            dataAccess = new DataAccess();
        }

        // View All Data
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CarAccessoriesProductGroupModel> ListCAPG = await dataAccess.CarAccessoriesProductGroupsViewData();

            return await Task.Run(() => View("Index", ListCAPG));
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
            CarAccessoriesProductGroupModel searchedCAPG = new CarAccessoriesProductGroupModel();

            await TryUpdateModelAsync(searchedCAPG);

            List<CarAccessoriesProductGroupModel> listCAPGSearchResult = await dataAccess.CarAccessoriesProductGroupsViewData(searchedCAPG);

            return await Task.Run(() => View("Index", listCAPGSearchResult));

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
                CarAccessoriesProductGroupModel insertedCAPG = new CarAccessoriesProductGroupModel();

                await TryUpdateModelAsync(insertedCAPG);

                await dataAccess.CarAccessoriesProductGroupsUpdateOrInsert(insertedCAPG);

                return RedirectToAction("Index");
            }
            return View();
        }

        // Update
        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Get(int id)
        {
            List<CarAccessoriesProductGroupModel> listCAPG = await dataAccess.CarAccessoriesProductGroupsViewData();

            CarAccessoriesProductGroupModel findCAPG = listCAPG.Single(carA => carA.CAPGId == id);

            return View(findCAPG);
        }
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Post(CarAccessoriesProductGroupModel CAPG)
        {
            List<CarAccessoriesProductGroupModel> listCAPG = await dataAccess.CarAccessoriesProductGroupsViewData();

            CarAccessoriesProductGroupModel findUpdatedCAPG = listCAPG.Single(carA => carA.CAPGId == CAPG.CAPGId);

            await TryUpdateModelAsync(findUpdatedCAPG);

            if (ModelState.IsValid)
            {
                await dataAccess.CarAccessoriesProductGroupsUpdateOrInsert(findUpdatedCAPG);

                return RedirectToAction("Index");
            }
            return View(findUpdatedCAPG);
        }

        // Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await dataAccess.CarAccessoriesProductGroupsDelete(id);

            return RedirectToAction("Index");
        }
    }
}
