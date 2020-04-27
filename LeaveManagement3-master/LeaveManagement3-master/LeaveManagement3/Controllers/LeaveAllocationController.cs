using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LeaveManagement3.Contracts;
using LeaveManagement3.Data;
using LeaveManagement3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement3.Controllers
{

    [Authorize(Roles = "Administrator")]

        public class LeaveAllocationController : Controller
    {
        public readonly ILeaveTypeRepository _repoLeaveType;
        public readonly ILeaveAllocationRepository _repoLeaveAllocation;
        public readonly IMapper _mapper;
        public readonly UserManager<IdentityUser> _userManager;
        public LeaveAllocationController(ILeaveTypeRepository repoLeaveType, ILeaveAllocationRepository repoLeaveAllocation, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _repoLeaveAllocation = repoLeaveAllocation;
            _repoLeaveType = repoLeaveType;
            _mapper = mapper;
            _userManager = userManager;
        }

        // GET: LeaveAllocation
        public ActionResult Index()
        {
            var leaveTypes = _repoLeaveType.FindAll().ToList();
            //var model = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leaveTypes);
            var mappedLeaveTypes = _mapper.Map<List<LeaveType>, List<LeaveTypeVM>>(leaveTypes);
            var model = new CreateLeaveAllocationVM
            {
                leaveTypes = mappedLeaveTypes,
                NumberUpdates = 0
            };
            return View(model);
        }
        public ActionResult SetLeave(int id)
        {
            var leaveTypes = _repoLeaveType.FindById(id);
            var employees = _userManager.GetUsersInRoleAsync("Employee").Result;
            foreach (var emp in employees)
            {
                if (!_repoLeaveAllocation.CheckLeaveAllocation(id, emp.Id))
                    {
                    var allocation = new LeaveAllocationVM
                    {
                        DateCreated = DateTime.Now,
                        EmployeeId = emp.Id,
                        LeaveTypeId = id,
                        NumberOfDays = leaveTypes.DefaultDays,
                        Period = DateTime.Now.Year
                    };
                    var leaveallocation = _mapper.Map<LeaveAllocation>(allocation);
                    _repoLeaveAllocation.Create(leaveallocation);
                                     }
            }
            return RedirectToAction(nameof(Index));
        }


        // GET: LeaveAllocation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LeaveAllocation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveAllocation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveAllocation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaveAllocation/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LeaveAllocation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveAllocation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}