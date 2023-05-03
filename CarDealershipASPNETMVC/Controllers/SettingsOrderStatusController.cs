using CarDealershipASPNETMVC.Data;
using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.AspNetCore.Mvc;


namespace CarDealershipASPNETMVC.Controllers
{
    public class SettingsOrderStatusController : Controller
    {
        private readonly DataAccess dataAccess;

        public SettingsOrderStatusController()
        {
            dataAccess = new DataAccess();
        }


        // View All Data
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<OrderStatusModel> ListOrderStatus = await dataAccess.OrderStatusViewData();

            return await Task.Run(() => View("Index", ListOrderStatus));
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
            OrderStatusModel searchedOrderStatus = new OrderStatusModel();

            await TryUpdateModelAsync(searchedOrderStatus);

            List<OrderStatusModel> listOrderStatusSearchResult = await dataAccess.OrderStatusViewData(searchedOrderStatus);

            return await Task.Run(() => View("Index", listOrderStatusSearchResult));

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
                OrderStatusModel insertedOrderStatus = new OrderStatusModel();

                await TryUpdateModelAsync(insertedOrderStatus);

                await dataAccess.OrderStatusUpdateOrInsert(insertedOrderStatus);

                return RedirectToAction("Index");
            }
            return View();
        }

        // Update
        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Get(int id)
        {
            List<OrderStatusModel> listOrderStatus = await dataAccess.OrderStatusViewData();

            OrderStatusModel findOrderStatus = listOrderStatus.Single(OS => OS.OrderStatusId == id);

            return View(findOrderStatus);
        }
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Post(OrderStatusModel modelOrderStatus)
        {
            List<OrderStatusModel> listOrderStatus = await dataAccess.OrderStatusViewData();

            OrderStatusModel findUpdatedOrderStatus = listOrderStatus.Single(OS => OS.OrderStatusId == modelOrderStatus.OrderStatusId);

            await TryUpdateModelAsync(findUpdatedOrderStatus);

            if (ModelState.IsValid)
            {
                await dataAccess.OrderStatusUpdateOrInsert(findUpdatedOrderStatus);

                return RedirectToAction("Index");
            }
            return View(findUpdatedOrderStatus);
        }

        // Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await dataAccess.OrderStatusDelete(id);

            return RedirectToAction("Index");
        }

    }
}
