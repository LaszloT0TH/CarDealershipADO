using CarDealershipASPNETMVC.Data;
using CarDealershipASPNETMVC.Global;
using CarDealershipASPNETMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace CarDealershipASPNETMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DataAccess dataAccess;

        public CustomerController()
        {
            dataAccess = new DataAccess();
        }

        // View Car Accessories All Data
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<CustomerModel> ListCustomers = await dataAccess.CustomersViewData();

            return await Task.Run(() => View("Index", ListCustomers));
        }

        // Customer Search Dynamic SQL
        [HttpGet]
        [ActionName("Search")]
        public async Task<IActionResult> Search_Get()
        {
            ViewBag.Sex = await dataAccess.SexViewData();
            
            ViewBag.Country = await dataAccess.CountryViewData();

            return View();
        }
        [HttpPost]
        [ActionName("Search")]
        public async Task<IActionResult> Search_Post()
        {
            CustomerModel searchedCustomer = new CustomerModel();

            await TryUpdateModelAsync(searchedCustomer);

            List<CustomerModel> listCustomersSearchResult = await dataAccess.CustomersViewData(searchedCustomer);

            return await Task.Run(() => View("Index", listCustomersSearchResult));

        }

        [HttpGet]
        [ActionName("Create")]
        public async Task<IActionResult> Create_Get()
        {
            ViewBag.Sex = await dataAccess.SexViewData();

            ViewBag.Country = await dataAccess.CountryViewData();

            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> Create_Post()
        {
            if (ModelState.IsValid)
            {
                CustomerModel insertedCustomer = new CustomerModel();

                await TryUpdateModelAsync(insertedCustomer);

                await dataAccess.CustomersUpdateOrInsert(insertedCustomer);

                // If you don't have a user ID yet, you will be redirected to the login page, if you have one, you will be redirected to the Customer menu
                // Wenn Sie noch keine Benutzer-ID haben, werden Sie auf die Anmeldeseite weitergeleitet, wenn Sie eine haben, werden Sie zum Kundenmenü weitergeleitet
                if (GlobalData.UserId == 0)
                {
                    // inserts the email address into the tbl Login table
                    // fügt die E-Mail-Adresse in die tbl-Login-Tabelle ein
                    await dataAccess.EmailUpload(insertedCustomer.Email);

                    return RedirectToAction("Edit","Login");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            // In case of incorrect filling, if you do not have a user ID, you will be redirected to the registration page, if you have one, you will be redirected to the Create menu item
            // Falls Sie keine Benutzer-ID haben, werden Sie bei einer falschen Eingabe auf die Registrierungsseite weitergeleitet, falls Sie eine haben, werden Sie zum Menüpunkt Erstellen weitergeleitet
            if (GlobalData.UserId == 0)
            {
                return RedirectToAction("Create", "Customer");
            }
            else
            {
                return View();
            }          
        }

        // Update
        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Get(int id)
        {
            ViewBag.Sex = await dataAccess.SexViewData();

            ViewBag.Country = await dataAccess.CountryViewData();

            List<CustomerModel> listCustomers = await dataAccess.CustomersViewData();

            CustomerModel findCustomer = listCustomers.Single(customer => customer.CustomerId == id);

            return View(findCustomer);
        }
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit_Post(CustomerModel modelCustomer)
        {
            List<CustomerModel> listCustomers = await dataAccess.CustomersViewData();

            CustomerModel findUpdatedCustomer = listCustomers.Single(customer => customer.CustomerId == modelCustomer.CustomerId);

            await TryUpdateModelAsync(findUpdatedCustomer);

            if (ModelState.IsValid)
            {
                await dataAccess.CustomersUpdateOrInsert(findUpdatedCustomer);

                return RedirectToAction("Index");
            }
            return View(findUpdatedCustomer);
        }

        // Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await dataAccess.CustomersDelete(id);

            return RedirectToAction("Index");
        }

    }
}
