using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Data;
using Demo.DAL.Models;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Demo.PL.Controllers
{
    public class StoreController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StoreController(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var store = _unitOfWork.StoreRepository.GetAll();
            var mappedStore = _mapper.Map<IEnumerable<Store>, IEnumerable<StoreViewModel>>(store);
            return View(mappedStore);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StoreViewModel storeVM)
        {
            if (ModelState.IsValid)
            {
                var mappedStore =_mapper.Map<StoreViewModel,Store>(storeVM);
                 _unitOfWork.StoreRepository.Add(mappedStore);
                var count = _unitOfWork.Complete();
                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Details(int? id, string ViewName = "Details")
        {
            if (!id.HasValue)
                return BadRequest();
            var store = _unitOfWork.StoreRepository.Get(id.Value);
            var mappedStore = _mapper.Map<Store , StoreViewModel>(store);
            if (store == null)
                return NotFound();
            return View(ViewName, mappedStore);
        }
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute]int? id, StoreViewModel storeVM)
        {
            if(id.Value != storeVM.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var mappedStore = _mapper.Map<StoreViewModel, Store>(storeVM);
                    _unitOfWork.StoreRepository.Update(mappedStore);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(storeVM);

        }
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute]int? id, StoreViewModel storeVM)
        {
            if(id.Value != storeVM.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var mappedStore = _mapper.Map<StoreViewModel, Store>(storeVM);
                    _unitOfWork.StoreRepository.Delete(mappedStore);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(storeVM);

        }



            


    }
}
