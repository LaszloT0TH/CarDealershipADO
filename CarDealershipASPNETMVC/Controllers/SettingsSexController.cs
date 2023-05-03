using CarDealershipASPNETMVC.Data;
using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace CarDealershipASPNETMVC.Controllers
{
    public class SettingsSexController : Controller
    {
        private readonly DataAccess dataAccess;

        public SettingsSexController()
        {
            dataAccess = new DataAccess();
        }


        // View Car All Data
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SexModel> ListSexs = await dataAccess.SexsViewData();

            return await Task.Run(() => View("Index", ListSexs));
        }

        // Car Search Dynamic SQL
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
            SexModel searchedSex = new SexModel();

            await TryUpdateModelAsync(searchedSex);

            List<SexModel> listSexsSearchResult = await dataAccess.SexsViewData(searchedSex);

            return await Task.Run(() => View("Index", listSexsSearchResult));

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
                SexModel insertedSex = new SexModel();

                await TryUpdateModelAsync(insertedSex);

                await dataAccess.SexsUpdateOrInsert(insertedSex);

                return RedirectToAction("Index");
            }
            return View();
        }

        // Update
        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Get(int id)
        {
            List<SexModel> listSex = await dataAccess.SexsViewData();

            SexModel findSex = listSex.Single(car => car.SexId == id);

            return View(findSex);
        }
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Post(SexModel modelSex)
        {
            List<SexModel> listSex = await dataAccess.SexsViewData();

            SexModel findUpdatedSex = listSex.Single(car => car.SexId == modelSex.SexId);

            await TryUpdateModelAsync(findUpdatedSex);

            if (ModelState.IsValid)
            {
                await dataAccess.SexsUpdateOrInsert(findUpdatedSex);

                return RedirectToAction("Index");
            }
            return View(findUpdatedSex);
        }

        // Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await dataAccess.SexsDelete(id);

            return RedirectToAction("Index");
        }

    }
}
