using Demo.BLL.Interfaces;
using Demo.DAL.Data;
using Demo.DAL.Models;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace Demo.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IUnitOfWork unitOfWork,AppDbContext dbContext,ILogger<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewData["Item"] = _unitOfWork.ItemRepository.GetAll();
            ViewData["Store"] = _unitOfWork.StoreRepository.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ItemStore itemstore)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.StoreItemRepository.Add(itemstore);
                _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
                
            }
            return View(itemstore);
        }
        [HttpGet]
        public IActionResult GetItemStoreDetails(int storeId, int itemId)
        {
            var itemStore = _dbContext.ItemStores
                .Where(i => i.StoreId == storeId && i.ItemId == itemId)
                .Select(i => new
                {
                    Quantity = i.Quantity,
                    Balance = i.Balance
                })
                .FirstOrDefault();

            if (itemStore != null)
            {
                return Json(new { quantity = itemStore.Quantity, balance = itemStore.Balance });
            }

            return Json(null);
        }


        [HttpPost]
        public IActionResult SaveItemStoreDetails(int storeId, int itemId, int quantity, int balance)
        {
            var itemStore = _dbContext.ItemStores
                .FirstOrDefault(i => i.StoreId == storeId && i.ItemId == itemId);

            if (itemStore != null)
            {
                itemStore.Quantity = quantity;
                itemStore.Balance = balance;
            }
            else
            {
                itemStore = new ItemStore
                {
                    StoreId = storeId,
                    ItemId = itemId,
                    Quantity = quantity,
                    Balance = balance
                };

                _unitOfWork.StoreItemRepository.Add(itemStore);
            }

            _dbContext.SaveChanges();

            return Json(new { success = true });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
