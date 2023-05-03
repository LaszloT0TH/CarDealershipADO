using CarDealershipASPNETMVC.Data;
using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace CarDealershipASPNETMVC.Controllers
{
    public class CarAccessoriesController : Controller
    {             
        private readonly DataAccess dataAccess;

        public CarAccessoriesController()
        {
            dataAccess = new DataAccess();
        }

        // View Car Accessories All Data
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CarAccessoriesModel> ListCarAccessories = await dataAccess.CarAccessoriesViewData();

            return await Task.Run(() => View("Index", ListCarAccessories));
        }

        // Car Accessories Search Dynamic SQL
        [HttpGet]
        [ActionName("Search")]
        public async Task<IActionResult> Search_Get()
        {
            ViewBag.CarAccessoriesProductGroup = await dataAccess.CarAccessoriesProductGroupViewData();

            ViewBag.CarAccessoriesUnit = await dataAccess.CarAccessoriesUnitViewData();
            
            return View();
        }
        [HttpPost]
        [ActionName("Search")]
        public async Task<IActionResult> Search_Post()
        {
            CarAccessoriesModel searchedCarAccessories = new CarAccessoriesModel();

            await TryUpdateModelAsync(searchedCarAccessories);

            List<CarAccessoriesModel> listCarAccessoriesSearchResult =  await dataAccess.CarAccessoriesViewData(searchedCarAccessories);

            return await Task.Run(() => View("Index", listCarAccessoriesSearchResult));

        }


        [HttpGet]
        [ActionName("Create")]
        public async Task<IActionResult> Create_Get()
        {
            ViewBag.CarAccessoriesProductGroup = await dataAccess.CarAccessoriesProductGroupViewData();

            ViewBag.CarAccessoriesUnit = await dataAccess.CarAccessoriesUnitViewData();

            return View(); 
        }
         
        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create_Post()
        {
            if (ModelState.IsValid)
            {
                CarAccessoriesModel insertedCarAccessories = new CarAccessoriesModel();

                await TryUpdateModelAsync(insertedCarAccessories);

                await dataAccess.CarAccessoriesUpdateOrInsert(insertedCarAccessories);

                return RedirectToAction("Index");
            }
            return View();
        }

        // Update
        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Get(int id)
        {
            ViewBag.CarAccessoriesProductGroup = await dataAccess.CarAccessoriesProductGroupViewData();
           
            ViewBag.CarAccessoriesUnit = await dataAccess.CarAccessoriesUnitViewData();

            List<CarAccessoriesModel> listCarAccessories = await dataAccess.CarAccessoriesViewData();
            
            CarAccessoriesModel findCarAccessories = listCarAccessories.Single(car => car.CAId == id);
            
            return View(findCarAccessories);
        }
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Post(CarAccessoriesModel modelCarAccessories)
        {
            List<CarAccessoriesModel> listCarAccessories = await dataAccess.CarAccessoriesViewData();
            
            CarAccessoriesModel findUpdatedCarAccessories = listCarAccessories.Single(car => car.CAId == modelCarAccessories.CAId);

            await TryUpdateModelAsync(findUpdatedCarAccessories);

            if (ModelState.IsValid)
            {
                await dataAccess.CarAccessoriesUpdateOrInsert(findUpdatedCarAccessories);

                return RedirectToAction("Index");
            }
            return View(findUpdatedCarAccessories);
        }

        // Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await dataAccess.CarAccessoriesDelete(id);

            return RedirectToAction("Index");
        }
                
        [HttpGet]
        public async Task<IActionResult> Sale(int id)
        {
            await dataAccess.CreateShoppingCartTable(GlobalData.UserId);

            OrderModel newOrder = new OrderModel();

            newOrder.UserId = GlobalData.UserId;
            
            newOrder.ProductId = id;

            newOrder.Quantity = 1;

            await dataAccess.InsertShoppingCart(newOrder);

            return RedirectToAction("Index");

        }
    }
}
