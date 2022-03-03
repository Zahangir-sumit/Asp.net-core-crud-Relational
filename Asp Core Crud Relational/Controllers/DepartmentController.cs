using Asp_Core_Crud_Relational.Infrastructure;
using Asp_Core_Crud_Relational.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_Core_Crud_Relational.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly StudentContext _Db;

        public DepartmentController(StudentContext Db)
        {
            _Db = Db;
        }
        public IActionResult Departments()
        {

            try
            {
                var DptList = _Db.tbl_Departments.ToList();

                return View(DptList);
            }
            catch (Exception ex)
            {

                return View();
            }
            
        }

        public IActionResult Create(Departments obj)
        {
            
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(Departments obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.ID==0)
                    {
                        _Db.tbl_Departments.Add(obj);
                        await _Db.SaveChangesAsync();

                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }
                    return RedirectToAction("");
                }
                return View(obj);
            }
            catch (Exception ex)
            {
                return RedirectToAction("");

            }
        }

        public async Task<IActionResult> Deletedpt(int id)
        {
            try
            {
                var dpt = await _Db.tbl_Departments.FindAsync(id);
                if (dpt != null)
                {
                    _Db.tbl_Departments.Remove(dpt);
                    await _Db.SaveChangesAsync();
                }
                return RedirectToAction("");
            }
            catch (Exception)
            {

                return RedirectToAction("");
            }
        }
    }
}
