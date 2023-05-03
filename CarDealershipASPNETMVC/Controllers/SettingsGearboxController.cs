using CarDealershipASPNETMVC.Data;
using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace CarDealershipASPNETMVC.Controllers
{
    public class SettingsGearboxController : Controller
    {
        private readonly DataAccess dataAccess;

        public SettingsGearboxController()
        {
            dataAccess = new DataAccess();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<GearboxModel> ListGearbox = await dataAccess.GearboxsViewData();

            return await Task.Run(() => View("Index", ListGearbox));
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
            GearboxModel searchedGearbox = new GearboxModel();

            await TryUpdateModelAsync(searchedGearbox);

            List<GearboxModel> listGearboxSearchResult = await dataAccess.GearboxsViewData(searchedGearbox);

            return await Task.Run(() => View("Index", listGearboxSearchResult));

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
                GearboxModel insertedGearbox = new GearboxModel();

                await TryUpdateModelAsync(insertedGearbox);

                await dataAccess.GearboxsUpdateOrInsert(insertedGearbox);

                return RedirectToAction("Index");
            }
            return View();
        }

        // Update
        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Get(int id)
        {
            List<GearboxModel> listGearbox = await dataAccess.GearboxsViewData();

            GearboxModel findGearbox = listGearbox.Single(gearbox => gearbox.GearboxId == id);

            return View(findGearbox);
        }
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Post(GearboxModel carGearbox)
        {
            List<GearboxModel> listGearbox = await dataAccess.GearboxsViewData();

            GearboxModel findUpdatedGearbox = listGearbox.Single(gearbox => gearbox.GearboxId == carGearbox.GearboxId);

            await TryUpdateModelAsync(findUpdatedGearbox);

            if (ModelState.IsValid)
            {
                await dataAccess.GearboxsUpdateOrInsert(findUpdatedGearbox);

                return RedirectToAction("Index");
            }
            return View(findUpdatedGearbox);
        }

        // Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await dataAccess.GearboxsDelete(id);

            return RedirectToAction("Index");
        }

    }
}
