using CarDealershipASPNETMVC.Data;
using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace CarDealershipASPNETMVC.Controllers
{
    public class SettingsSpokenLanguesController : Controller
    {
        private readonly DataAccess dataAccess;

        public SettingsSpokenLanguesController()
        {
            dataAccess = new DataAccess();
        }

        // View SpokenLanguesModel All Data
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SpokenLanguesModel> ListSpokenLangues = await dataAccess.SpokenLanguesViewData();

            return await Task.Run(() => View("Index", ListSpokenLangues));
        }

        // SpokenLangues Search Dynamic SQL
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
            SpokenLanguesModel searchedSpokenLangues = new SpokenLanguesModel();

            await TryUpdateModelAsync(searchedSpokenLangues);

            List<SpokenLanguesModel> listSpokenLanguesResult = await dataAccess.SpokenLanguesViewData(searchedSpokenLangues);

            return await Task.Run(() => View("Index", listSpokenLanguesResult));

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
                SpokenLanguesModel insertedSpokenLangues = new SpokenLanguesModel();

                await TryUpdateModelAsync(insertedSpokenLangues);

                await dataAccess.SpokenLanguesUpdateOrInsert(insertedSpokenLangues);

                return RedirectToAction("Index");
            }
            return View();
        }

        // Update
        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Get(int id)
        {
            List<SpokenLanguesModel> listSpokenLangues = await dataAccess.SpokenLanguesViewData();
           
            SpokenLanguesModel findSpokenLangues = listSpokenLangues.Single(sp => sp.SpokenLanguesId == id);

            return View(findSpokenLangues);
        }
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Post(SpokenLanguesModel spokenLangues)
        {
            List<SpokenLanguesModel> listSpokenLangues = await dataAccess.SpokenLanguesViewData();

            SpokenLanguesModel findSpokenLangues = listSpokenLangues.Single(sp => sp.SpokenLanguesId == spokenLangues.SpokenLanguesId);


            await TryUpdateModelAsync(findSpokenLangues);

            if (ModelState.IsValid)
            {
                await dataAccess.SpokenLanguesUpdateOrInsert(findSpokenLangues);

                return RedirectToAction("Index");
            }
            return View(findSpokenLangues);
        }

        // Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await dataAccess.SpokenLanguesDelete(id);

            return RedirectToAction("Index");
        }

    }
}
