using CarDealershipASPNETMVC.Data;
using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipASPNETMVC.Controllers
{
    public class CarController : Controller
    {
        private readonly DataAccess dataAccess;

        public CarController()
        {
            dataAccess = new DataAccess();
        }

        // View Car All Data
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CarModel> ListCars = await dataAccess.CarsViewData();

            return await Task.Run(() => View("Index", ListCars));
        }

        // Car Search Dynamic SQL
        [HttpGet]
        [ActionName("Search")]
        public async Task<IActionResult> Search_Get()
        {
            ViewBag.Fuel = await dataAccess.FuelViewData();
            
            ViewBag.Gearbox = await dataAccess.GearboxViewData();
            
            return View();
        }
        [HttpPost]
        [ActionName("Search")]
        public async Task<IActionResult> Search_Post()
        {
            CarModel searchedCar = new CarModel();

            await TryUpdateModelAsync(searchedCar);

            List<CarModel> listCarSearchResult = await dataAccess.CarsViewData(searchedCar);

            return await Task.Run(() => View("Index", listCarSearchResult));

        }

        [HttpGet]
        [ActionName("Create")]
        public async Task<IActionResult> Create_Get()
        {
            ViewBag.Fuel = await dataAccess.FuelViewData();

            ViewBag.Gearbox = await dataAccess.GearboxViewData();

            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create_Post()
        {
            if (ModelState.IsValid)
            {
                CarModel insertedCar = new CarModel();

                await TryUpdateModelAsync(insertedCar);

                await dataAccess.CarsUpdateOrInsert(insertedCar);

                return RedirectToAction("Index");
            }
            return View();
        }

        // Update
        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Get(int id)
        {
            ViewBag.Fuel = await dataAccess.FuelViewData();

            ViewBag.Gearbox = await dataAccess.GearboxViewData();

            List<CarModel> listCar = await dataAccess.CarsViewData();

            CarModel findCar = listCar.Single(car => car.CarId == id);

            return View(findCar);
        }
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Post(CarModel modelCar)
        {
            List<CarModel> listCar = await dataAccess.CarsViewData();

            CarModel findUpdatedCar = listCar.Single(car => car.CarId == modelCar.CarId);

            await TryUpdateModelAsync(findUpdatedCar);

            if (ModelState.IsValid)
            {
                await dataAccess.CarsUpdateOrInsert(findUpdatedCar);

                return RedirectToAction("Index");
            }
            return View(findUpdatedCar);
        }

        // Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await dataAccess.CarsDelete(id);

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
