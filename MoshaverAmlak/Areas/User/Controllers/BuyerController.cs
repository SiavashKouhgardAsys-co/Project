using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MoshaverAmlak.Areas.User.Controllers
{
    [Area("User")]
    public class BuyerController : Controller
    {
        private readonly IBuyerService _buyerService;
        public BuyerController(IBuyerService buyerService)
        {
            _buyerService = buyerService;
        }
        public IActionResult Index(string resultStatus)
        {
            SendDataToView<List<BuyerViewmodel>> sendDataToView = new SendDataToView<List<BuyerViewmodel>>();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _buyerService.GetAllBuyers(userId);
            sendDataToView.Entity = data.Entity;
            if (resultStatus != null)
                sendDataToView.Message = Result.GetMessage(resultStatus);
            return View(sendDataToView);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(BuyerViewmodel buyerviewmodel)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var result = await _buyerService.CreateBuyer(new Buyer()
            {
                UserId = userId,    
                Id = buyerviewmodel.Id,
                FullName = buyerviewmodel.FullName,
                InvestimentFrom = buyerviewmodel.FromInvestment,
                InvestimentTo = buyerviewmodel.ToInvestment,
                Description = buyerviewmodel.Description
            });
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult CreateBuyerTel(int buyerId , string statusResult = null)
        {
            SendDataToView<List<BuyerTelViewmodel>> sendDataToView = new SendDataToView<List<BuyerTelViewmodel>>();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _buyerService.GetBuyerById(buyerId , userId);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            var tels = _buyerService.GetAllBuyerTelByUserId(buyerId);
            if (tels.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = tels.Result.StatusResult }));
            BuyerTelViewmodel buyerTelViewmodel = new BuyerTelViewmodel()
            {
                Buyer = data.Entity,
                Tels = tels.Entity,
                BuyerInfo = new BuyerTel()
            };
            if (statusResult != null)
                sendDataToView.Message = Result.GetMessage(statusResult);
            return View(buyerTelViewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBuyerTel(BuyerTelViewmodel buyerTelViewmodel)
        {
            var result = await _buyerService.CreateBuyerTel(new BuyerTel()
            {  
                BuyerId = buyerTelViewmodel.BuyerInfo.BuyerId,
                Tel = buyerTelViewmodel.BuyerInfo.Tel
            });
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _buyerService.GetBuyerById(id , userId);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }
        
        [HttpPost]
        public async Task<IActionResult> Delete(Buyer buyer)
        {
            var result = await _buyerService.DeleteBuyer(buyer.Id);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        //[HttpGet] Get nemkhad chon View ro mkhaym az hamun View ActionMethode : CreateBuyerTel estefade konim!!!
        //public IActionResult DeleteBuyerTel(int id)
        //{
        //    var data = _buyerService.GetBuyerTelById(id);
        //    if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
        //    return RedirectToAction("");
        //}

        [HttpGet]
        public async Task<IActionResult> DeleteBuyerTel(string telId,string buyerId)
        {
            var result = await _buyerService.DeleteBuyerTel(int.Parse(telId));
            return RedirectToAction("CreateBuyerTel" , new RouteValueDictionary (new { buyerId = buyerId , resultStatus = result.StatusResult}));
        }
        
        [HttpGet]
        public IActionResult Details(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _buyerService.GetBuyerById(id, userId);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            BuyerViewmodel buyerViewmodel = new BuyerViewmodel()
            {
                Id = data.Entity.Id,
                FullName = data.Entity.FullName,
                FromInvestment = data.Entity.InvestimentFrom,
                ToInvestment = data.Entity.InvestimentTo,
                Description = data.Entity.Description
            };
            return View(buyerViewmodel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _buyerService.GetBuyerById(id, userId);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            BuyerViewmodel buyerViewmodel = new BuyerViewmodel()
            {
                Id = data.Entity.Id,
                FullName = data.Entity.FullName,
                FromInvestment = data.Entity.InvestimentFrom,
                ToInvestment = data.Entity.InvestimentTo,
                Description = data.Entity.Description
            };
            return View(buyerViewmodel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BuyerViewmodel buyerViewmodel)
        {
            var result = await _buyerService.EditBuyer(new Buyer()
            {
                Id = buyerViewmodel.Id,
                FullName = buyerViewmodel.FullName,
                InvestimentFrom = buyerViewmodel.FromInvestment,
                InvestimentTo = buyerViewmodel.ToInvestment,
                Description = buyerViewmodel.Description,
            });
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

    }
}
