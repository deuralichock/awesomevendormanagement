using AutoMapper;
using AwesomeVenderManagement.DataAccess;
using AwesomeVenderManagement.Models;
using AwesomeVenderManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwesomeVenderManagement.Controllers
{
    [Authorize]
    public class VendorCategoryController : Controller
    {

        private readonly IVenderCategoryRepository _vendorCategoryRepository;
        private readonly IVendorRepository _vendorRepository;
        public VendorCategoryController (
            IVenderCategoryRepository venderCategoryRepository,
            IVendorRepository vendorRepository)
        {
            _vendorCategoryRepository = venderCategoryRepository;
            _vendorRepository = vendorRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new VendorCategoryViewModel());
        }

        [HttpPost]
        public ActionResult Create(VendorCategoryViewModel vendorCategoryViewModel)
        {
            return RedirectToAction("Index");
        }

        public JsonResult GetAllVendorCategories() 
        {
            return 
                Json(_vendorCategoryRepository.GetAll()
                .Select(vm=>new VendorCategoryViewModel {
                    VendorName = vm.Name,
                    VendorDescription = vm.Description,
                    Id = vm.Id
                    }),
             JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveVendorCategory(VendorCategoryViewModel vendorCategoryViewModel)
        {
            try
            {
                this._vendorCategoryRepository.Save(new VendorCategory{
                    Name = vendorCategoryViewModel.VendorName,
                    Description = vendorCategoryViewModel.VendorDescription
                });

                return
                    Json(new { status = "Successful" });
            }
            catch(ApplicationException apx)
            {
                return
                    Json(new { status = "failure" });
            }
        }

        [HttpPost]
        public JsonResult EditVendorCategory(VendorCategoryViewModel vendorCategoryViewModel)
        {
            try
            {
                var currentVendorCategory = _vendorCategoryRepository.GetEntityById(vendorCategoryViewModel.Id);
                currentVendorCategory.Name = vendorCategoryViewModel.VendorName;
                currentVendorCategory.Description = vendorCategoryViewModel.VendorDescription;
                this._vendorCategoryRepository.Update(currentVendorCategory);
                return
                    Json(new { status = "Successful" });
            }
            catch (ApplicationException apx)
            {
                return
                    Json(new { status = "failure" });
            }
        }


        [HttpPost]
        public JsonResult RemoveVendorCategory(int id)
        {
            var data = id;

            try
            {
                this._vendorCategoryRepository.Delete(id);
                return
                    Json(new { status = "Successful" });
            }

            catch(ApplicationException apx)
            {
                return
                    Json(new { status = "Failure" });
            }
        }

        private void SomeTempUnitTesting()
        {

        }

	}
}