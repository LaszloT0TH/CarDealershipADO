using CarDealershipASPNETMVC.Data;
using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealershipASPNETMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly DataAccess dataAccess;

        public ShoppingCartController()
        {
            dataAccess = new DataAccess();
        }

        
        // compilation of draft order based on identifiers
        [HttpGet]
        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            List<OrderModel> listNewOrders = await dataAccess.AllDataShoppingCartTable(GlobalData.UserId);

            foreach (OrderModel order in listNewOrders)
            {
                order.CustomerFirstName = dataAccess.CustomerFirstName((int)order.CustomerId).Result;
                order.CustomerLastName = dataAccess.CustomerLastName((int)order.CustomerId).Result;
                order.SalesPersonFirstName = dataAccess.SalesPersonFirstName((int)order.SalesPersonId).Result;
                order.SalesPersonLastName = dataAccess.SalesPersonLastName((int)order.SalesPersonId).Result;
                order.ProductGroup = dataAccess.CarsAccessoriesProductGroup((int)order.ProductId).Result;
                order.ProductName = dataAccess.CarsAccessoriesProductName((int)order.ProductId).Result;
                order.CarModel = dataAccess.CarModel((int)order.ProductId).Result;
                order.CarColor = dataAccess.CarColor((int)order.ProductId).Result;
                order.SaleAmount = dataAccess.SaleAmount((int)order.ProductId).Result;
                order.TaxPercentageValue = dataAccess.CustomerCountryTaxPercentageValue((int)order.CustomerId).Result;
            }

            // Query the null values from the shopping cart list, as long as there is a null value, the buy button option will not appear
            // Fragen Sie die Nullwerte aus der Warenkorbliste ab, solange es einen Nullwert gibt, wird die Schaltfläche "Kaufen" nicht angezeigt
            ViewBag.CustomerIdCountNullCount = await dataAccess.ShoppingCartCustomerIdNullCount(GlobalData.UserId);

            // The buy button is not visible until the list is empty
            // Der Kaufen-Button ist erst sichtbar, wenn die Liste leer ist
            ViewBag.NewOrdersListCount = listNewOrders.Count;


            return await Task.Run(() => View("Index", listNewOrders));
        }
       
        // Update
        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Get(int id)
        {
            List<OrderModel> listOrders = await dataAccess.AllDataShoppingCartTable(GlobalData.UserId);

            OrderModel findOrder = listOrders.Single(order => order.OrderId == id);

            ViewBag.CustomersList = await dataAccess.CustomersListViewData();
            ViewBag.SalesPersonsList = await dataAccess.SalesPersonsListViewData();
            ViewBag.CarAccessoriesList = await dataAccess.CarAccessoriesListViewData();
            ViewBag.OrderStatusList = await dataAccess.OrderStatusViewData();

            findOrder.ProductGroup = dataAccess.CarsAccessoriesProductGroup((int)findOrder.ProductId).Result;
            findOrder.ProductName = dataAccess.CarsAccessoriesProductName((int)findOrder.ProductId).Result;
            findOrder.CarModel = dataAccess.CarModel((int)findOrder.ProductId).Result;
            findOrder.CarColor = dataAccess.CarColor((int)findOrder.ProductId).Result;
            findOrder.SaleAmount = dataAccess.SaleAmount((int)findOrder.ProductId).Result;
            findOrder.TaxPercentageValue = dataAccess.CustomerCountryTaxPercentageValue((int)findOrder.CustomerId).Result;

            return await Task.Run(() => { return View(findOrder); });
        }
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Post(OrderModel modelOrder)
        {
            // if salespersons order
            if (modelOrder.CustomerId != null)
            {
                List<OrderModel> listOrders = await dataAccess.AllDataShoppingCartTable(GlobalData.UserId);

                OrderModel findUpdatedOrder = listOrders.Single(order => order.OrderId == GlobalData.ShoppingCartOrderId);

                await TryUpdateModelAsync(findUpdatedOrder);

                findUpdatedOrder.UserId = GlobalData.UserId;

                await dataAccess.UpdateShoppingCartTable(findUpdatedOrder);

            }
            // if customers order
            else
            {
                List<OrderModel> listOrders = await dataAccess.AllDataShoppingCartTable(GlobalData.UserId);

                OrderModel findUpdatedOrder = listOrders.Single(order => order.OrderId == GlobalData.ShoppingCartOrderId);

                findUpdatedOrder.Quantity = modelOrder.Quantity;

                findUpdatedOrder.UserId = GlobalData.UserId;

                await dataAccess.UpdateShoppingCartTable(findUpdatedOrder);

            }


            return await Task.Run(() => { return RedirectToAction("Index"); });
        }

        // Delete rows
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await dataAccess.DeleteRowShoppingCartTable(id, GlobalData.UserId);

            return await Task.Run(() => { return RedirectToAction("Index"); });
        }

        //sending draft order
        [HttpGet]
        [ActionName("AddOrder")]
        public async Task<IActionResult> AddOrder()
        {
            List<OrderModel> listNewOrders = await dataAccess.AllDataShoppingCartTable(GlobalData.UserId);

            foreach (OrderModel order in listNewOrders)
            {
                OrderModel newOrder = new OrderModel();

                newOrder.CustomerId = order.CustomerId;
                newOrder.SalesPersonId = order.SalesPersonId;
                newOrder.ProductId = order.ProductId;
                newOrder.Quantity = order.Quantity;
                newOrder.OrderStatusId = order.OrderStatusId;
                newOrder.Discount = order.Discount;

                await dataAccess.OrdersUpdateOrInsert(newOrder);

            }
            await dataAccess.DeleteAllRowsShoppingCartTable(GlobalData.UserId);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("AddCustoner")]
        public async Task<IActionResult> AddCustoner_Get()
        {
            // add the selected customer ID to all orders
            // die ausgewählte Kunden-ID zu allen Bestellungen hinzufügen
            ViewBag.CustomersList = await dataAccess.CustomersListViewData();

            return await Task.Run(() => { return View(); });
        }

        [HttpPost]
        [ActionName("AddCustoner")]
        public async Task<IActionResult> AddCustoner_Post(CustomerModel customer)
        {
            List<OrderModel> listOrders = await dataAccess.AllDataShoppingCartTable(GlobalData.UserId);

            foreach (OrderModel order in listOrders)
            {
                OrderModel updatedOrder = new OrderModel();

                updatedOrder.UserId = GlobalData.UserId;
                updatedOrder.OrderId = order.OrderId;
                updatedOrder.CustomerId = customer.CustomerId;               
                updatedOrder.SalesPersonId = order.SalesPersonId;
                updatedOrder.ProductId = order.ProductId;
                updatedOrder.Quantity = order.Quantity;
                updatedOrder.OrderStatusId = order.OrderStatusId;
                updatedOrder.Discount = order.Discount;
                               
                await dataAccess.UpdateShoppingCartTable(updatedOrder);

            }

            return RedirectToAction("Index");
        }
    }
}
