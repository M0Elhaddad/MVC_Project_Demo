using AutoMapper;
using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Demo.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Demo.PL.Controllers
{
    public class ItemController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ItemController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            
        }
        public IActionResult Index()
        {
            var item = _unitOfWork.ItemRepository.GetAll();
            var mappedItem = _mapper.Map<IEnumerable<Item>, IEnumerable<ItemViewModel>>(item);
            return View(mappedItem);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ItemViewModel itemVM)
        {
            if (ModelState.IsValid)
            {
                var mappedItem = _mapper.Map<ItemViewModel,Item>(itemVM);
                _unitOfWork.ItemRepository.Add(mappedItem);
                var count = _unitOfWork.Complete();
                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Details([FromRoute] int? id, string ViewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var item = _unitOfWork.ItemRepository.Get(id.Value);
            var mappedItem = _mapper.Map<Item,ItemViewModel>(item);
            if (item is null)
                return NotFound();
            return View(ViewName, mappedItem);
        }
        public IActionResult Edit(int? id)
        {
            return Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int? id, ItemViewModel itemVM)
        {
            if (id.Value != itemVM.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var mappedItem = _mapper.Map<ItemViewModel, Item>(itemVM);
                    _unitOfWork.ItemRepository.Update(mappedItem);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(itemVM);

        }
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int? id, ItemViewModel itemVM)
        {
            if (id.Value != itemVM.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    var mappedItem = _mapper.Map<ItemViewModel, Item>(itemVM);
                    _unitOfWork.ItemRepository.Delete(mappedItem);
                    _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(itemVM);

        }
    }
}
