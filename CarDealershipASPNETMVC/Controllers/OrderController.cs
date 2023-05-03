using CarDealershipASPNETMVC.Data;
using CarDealershipASPNETMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipASPNETMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly DataAccess dataAccess;

        public OrderController()
        {
            dataAccess = new DataAccess();
        }

        // View Car Accessories All Data
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<OrderModel> ListOrders = await dataAccess.OrdersViewData();

            List<StockReplenishmentListModel> StockReplenishmentList = await dataAccess.StockReplenishmentListViewData();
            ViewBag.StockReplenishmentListCount = StockReplenishmentList.Count;

            return await Task.Run(() => View("Index", ListOrders));
        }

        // Order Search Dynamic SQL
        [HttpGet]
        [ActionName("Search")]
        public async Task<IActionResult> Search_Get()
        {
            ViewBag.CustomersList = await dataAccess.CustomersListViewData();
            ViewBag.SalesPersonsList = await dataAccess.SalesPersonsListViewData();
            ViewBag.CarAccessoriesList = await dataAccess.CarAccessoriesListViewData();
            ViewBag.CarAccessoriesProductGroupList = await dataAccess.CarAccessoriesProductGroupViewData();
            ViewBag.OrderStatusList = await dataAccess.OrderStatusViewData();
            return View();
        }
        [HttpPost]
        [ActionName("Search")]
        public async Task<IActionResult> Search_Post()
        {
            OrderModel searchedOrder = new OrderModel();

            await TryUpdateModelAsync(searchedOrder);

            List<OrderModel> listOrdersSearchResult = await dataAccess.OrdersViewData(searchedOrder);

            return await Task.Run(() => View("Index", listOrdersSearchResult));

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
                OrderModel insertedOrder= new OrderModel();

                await TryUpdateModelAsync(insertedOrder);

                await dataAccess.OrdersUpdateOrInsert(insertedOrder);

                return RedirectToAction("Index");
            }
            return View();
        }

        // Update
        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Get(int id)
        {
            // You either sell the car or you don't. It is not possible to edit a car or change it to a car part,
            // if you didn't want a car originally, you have to delete it
            // the online shop is only available for spare parts, the car's sold status is automatically reset to false in the database when deleted
            // Entweder du verkaufst das Auto oder nicht. Es ist nicht möglich, ein Auto zu bearbeiten oder in ein Autoteil umzuwandeln,
            // wenn Sie ein Auto ursprünglich nicht wollten, müssen Sie es löschen
            // Der Online-Shop ist nur für Ersatzteile verfügbar, der Verkauft-Status des Autos wird beim Löschen automatisch in der Datenbank auf false zurückgesetzt
            ViewBag.CustomersList = await dataAccess.CustomersListViewData();
            ViewBag.SalesPersonsList = await dataAccess.SalesPersonsListViewData();
            ViewBag.CarAccessoriesList = await dataAccess.CarAccessoriesListViewData();
            ViewBag.OrderStatusList = await dataAccess.OrderStatusViewData();

            List<OrderModel> listOrders = await dataAccess.OrdersViewData();

            OrderModel findOrder = listOrders.Single(order => order.OrderId == id);

            return View(findOrder);
        }
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Post(OrderModel modelOrder)
        {
            List<OrderModel> listOrders = await dataAccess.OrdersViewData();

            OrderModel findUpdatedOrder = listOrders.Single(order => order.OrderId == modelOrder.OrderId);

            await TryUpdateModelAsync(findUpdatedOrder);

            // if the amount received is equal to or greater than the amount to be paid,
            // the order status is set to completed and the sale time is time stamped
            if (findUpdatedOrder.SaleAmountPaid >= findUpdatedOrder.SaleAmount)
            {
                findUpdatedOrder.OrderStatusId = 4;
                findUpdatedOrder.SaleTime = DateTime.Now;
            }

            await dataAccess.OrdersUpdateOrInsert(findUpdatedOrder);

            return RedirectToAction("Index");
        }

        // Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await dataAccess.OrdersDelete(id);

            return RedirectToAction("Index");
        }


        // StockReplenishmentList
        [HttpGet]
        public async Task<IActionResult> StockReplenishmentList()
        {
            List<StockReplenishmentListModel> StockReplenishmentList = await dataAccess.StockReplenishmentListViewData();

            return await Task.Run(() => View("StockReplenishmentList", StockReplenishmentList));
        }
    }
}
