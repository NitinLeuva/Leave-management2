using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LeaveManagement3.Contracts;
using LeaveManagement3.Mapping;
using LeaveManagement3.Models;
using AutoMapper;
using LeaveManagement3.Data;

namespace LeaveManagement3.Controllers
{
    public class LeaveTypesController : Controller
    {
        public readonly ILeaveTypeRepository _repo;
        public readonly IMapper _mapper;

        public LeaveTypesController(ILeaveTypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;

        }
        
        // GET: LeaveTypes
        
        public ActionResult Index()
        {
            var leaveTypes = _repo.FindAll().ToList();
            var model = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leaveTypes);
            return View(model);
        }


        // GET: LeaveTypes/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.IsExists(id))
            {
                return NotFound();
            }
            var leaveType = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(leaveType);
            return View(model);
        }

        // GET: LeaveTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeaveTypeVM model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var LeaveType = _mapper.Map<LeaveType>(model);
                LeaveType.DateCreated = System.DateTime.Now;

                var isSuccess = _repo.Create(LeaveType);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "something went wrong");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypes/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.IsExists(id))
            {
                return NotFound();
            }

            var LeaveType = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(LeaveType);
            return View(model);
        }

        // POST: LeaveTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LeaveTypeVM model)
        {
            try
            { 
             if (!ModelState.IsValid)
            {
                return View(model);
            }

            var LeaveType = _mapper.Map<LeaveType>(model);
            LeaveType.DateCreated = System.DateTime.Now;

            var isSuccess = _repo.Update(LeaveType);

            if (!isSuccess)
            {
                ModelState.AddModelError("", "something went wrong");
                return View(model);
            }

            return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveTypes/Delete/5
        public ActionResult Delete(int id)
        {
            if (!_repo.IsExists(id))
            {
                return NotFound();
            }

            var LeaveType = _repo.FindById(id);
            var model = _mapper.Map<LeaveTypeVM>(LeaveType);
            return View(model);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(LeaveTypeVM model)
        {
            try
            {
                if (!_repo.IsExists(model.Id))
                {
                    return NotFound();
                }

                var LeaveType = _mapper.Map<LeaveType>(model);
                LeaveType = _repo.FindById(model.Id);               

                var isSuccess = _repo.Delete(LeaveType);

                if (!isSuccess)
                {
                    ModelState.AddModelError("", "something went wrong");
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}