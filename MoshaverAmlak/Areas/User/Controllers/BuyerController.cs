using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
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
            SendDataToView<IQueryable<Buyer>> sendDataToView = new SendDataToView<IQueryable<Buyer>>();
            var data = _buyerService.GetAllBuyers();
            if (data.Result.StatusResult != (int)Result.Status.OK) return NotFound();
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
            var result = await _buyerService.CreateBuyer(new Buyer()
            {
                Id = buyerviewmodel.Id,
                FullName = buyerviewmodel.FullName,
                InvestimentFrom = buyerviewmodel.FromInvestment,
                InvestimentTo = buyerviewmodel.ToInvestment,
                Description = buyerviewmodel.Description
            });
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _buyerService.GetBuyerById(id);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Buyer buyer)
        {
            var result = await _buyerService.DeleteBuyer(buyer.Id);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var data = _buyerService.GetBuyerById(id);

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
