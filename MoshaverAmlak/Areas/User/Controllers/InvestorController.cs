using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MoshaverAmlak.Core.Repository.Service.Interface;
using MoshaverAmlak.DataLayer.Common;
using MoshaverAmlak.DataLayer.Entity;
using MoshaverAmlak.DataLayer.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MoshaverAmlak.Areas.User.Controllers
{
    [Area("User")]
    public class InvestorController : Controller
    {
        private readonly IInvestorService _investorService;
        public InvestorController(IInvestorService investorService)
        {
            _investorService = investorService;
        }
        public IActionResult Index(string resultStatus)
        {
            SendDataToView<List<InvestorViewmodel>> sendDataToView = new SendDataToView<List<InvestorViewmodel>>();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _investorService.GetAllInvestors(userId);
            sendDataToView.Entity = data.Entity;
            if (resultStatus != null)
                sendDataToView.Message = Result.GetMessage(resultStatus);
            return View(sendDataToView);
        }

        
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(InvestorViewmodel investorViewmodel)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _investorService.CreateInvestor(new Investor()
            {
                UserId = userId,
                Id = investorViewmodel.Id,
                AmountOfInvestiment = investorViewmodel.AmountOfInvestiment,
                FullName = investorViewmodel.FullName,
                Description = investorViewmodel.Description
            });
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _investorService.GetInvestorById(id, userId);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Investor investor)
        {
            var result = await _investorService.DeleteInvestor(investor.Id);
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _investorService.GetInvestorById(id, userId); 
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            InvestorViewmodel investorViewmodel = new InvestorViewmodel()
            {
                Id = data.Entity.Id,
                FullName = data.Entity.FullName,
                AmountOfInvestiment = data.Entity.AmountOfInvestiment,
                Description = data.Entity.Description,
            };
            return View(investorViewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(InvestorViewmodel investorViewmodel)
        {
            var result = await _investorService.EditInvestor(new Investor()
            {
                Id = investorViewmodel.Id,
                FullName = investorViewmodel.FullName,
                Description = investorViewmodel.Description,
                AmountOfInvestiment = investorViewmodel.AmountOfInvestiment
            });
            return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = result.StatusResult }));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _investorService.GetInvestorByIdForDetails(id, userId);
            //if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));
            return View(data.Entity);
        }

        [HttpGet]
        public IActionResult CreateInvestorTel(int investorId , string statusResult = null)
        {
            SendDataToView<List<InvestorTelViewmodel>> sendDataToView = new SendDataToView<List<InvestorTelViewmodel>>();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _investorService.GetInvestorById(investorId, userId);
            if (data.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = data.Result.StatusResult }));

            var tels = _investorService.GetAllInvestorTelByUserId(investorId);
            if (tels.Result.StatusResult != (int)Result.Status.OK) return RedirectToAction("Index", new RouteValueDictionary(new { resultStatus = tels.Result.StatusResult }));

            InvestorTelViewmodel investorTelViewmodel = new InvestorTelViewmodel()
            {
                Investor = data.Entity,
                Tels = tels.Entity,
                InvestorInfo = new InvestorTel()
            };
            
            if (statusResult != null)
                sendDataToView.Message = Result.GetMessage(statusResult);

            return View(investorTelViewmodel);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateInvestorTel(InvestorTelViewmodel investorTelViewmodel)
        {
            var result = await _investorService.CreateInvestorTel(new InvestorTel()
            {
                InvestorId = investorTelViewmodel.InvestorInfo.InvestorId,
                Tel = investorTelViewmodel.InvestorInfo.Tel
            });
            return RedirectToAction("CreateInvestorTel" , new RouteValueDictionary(new { resultStatus = result.StatusResult, investorId = investorTelViewmodel.InvestorInfo.InvestorId }));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteInvestorTel(string telId, string investorId)
        {
            var result = await _investorService.DeleteInvestorTel(int.Parse(telId));
            return RedirectToAction("CreateInvestorTel", new RouteValueDictionary(new { investorId = investorId, resultStatus = result.StatusResult }));
        }

    }
}
