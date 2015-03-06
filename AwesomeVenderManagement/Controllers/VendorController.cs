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
    public class VendorController : BaseController
    {
        
        private readonly IVenderCategoryRepository _vendorCategoryRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;
        public VendorController(
            IVenderCategoryRepository venderCategoryRepository,
            IVendorRepository vendorRepository,
            IApplicationUserRepository applicationUserRepository)
        {
            _vendorCategoryRepository = venderCategoryRepository;
            _vendorRepository = vendorRepository;
            _applicationUserRepository = applicationUserRepository;
        }


        public ActionResult SearchVendor() 
        {
            return View(new VendorSearchViewModel { });
        }

        [HttpPost]
        public JsonResult GetVendorByVendorId(int? vendorId) 
        {

            if (vendorId.HasValue)
            {
                var currentVendor = this._vendorRepository.
                    Get(filter: vendor => vendor.Id == vendorId.Value,
                    includeProperties: "ContactPerson,VendorAddress,VenderCategory").SingleOrDefault();


                try
                {
                    return Json(convert(currentVendor));
                }

                catch (ApplicationException apx)
                {
                    return Json(new { status = "failure" });
                }
            }
             return Json(new { status = "failure" });
        }


        [HttpPost]
        public JsonResult EditVendor(VendorViewModel vendorViewModel, int vendorId) 
        {
            var currentVendor = this._vendorRepository.GetEntityById(vendorId);

            if (currentVendor != null)
            {
                currentVendor.ContactPerson.FirstName = vendorViewModel.ContactPersonFirstName;
                currentVendor.ContactPerson.MiddleName = vendorViewModel.ContactPersonMiddleName;
                currentVendor.ContactPerson.LastName = vendorViewModel.ContactPersonLastName;
                currentVendor.ContactPerson.HomePhone = vendorViewModel.ContactPersonHomePhone;
                currentVendor.ContactPerson.CellPhone = vendorViewModel.ContactPersonCellPhone;
                currentVendor.ContactPerson.Email = vendorViewModel.ContactPersonEmail;


                currentVendor.ModifiedById = base.getCurrentlyLoggedInUser(_applicationUserRepository).Id;
                currentVendor.ModifiedDate = DateTime.Now;
                currentVendor.VendorCategoryId = int.Parse( vendorViewModel.VendorCategoryName);
                currentVendor.VendorAddress.Address1 = vendorViewModel.VendorAddress1;
                currentVendor.VendorAddress.Address2 = vendorViewModel.VendorAddress2;
                currentVendor.VendorAddress.City = vendorViewModel.VendorCity;
                currentVendor.VendorAddress.State = vendorViewModel.VendorState;
                currentVendor.VendorAddress.ZipCode = vendorViewModel.VendorZipCode;
                currentVendor.VendorAddress.Country = vendorViewModel.VendorCountry;

                currentVendor.VendorDescription = vendorViewModel.VendorDescription;
                currentVendor.VendorName = vendorViewModel.VendorName;
                currentVendor.VendorCreatedById = currentVendor.VendorCreatedById;

                try
                {
                    this._vendorRepository.Update(currentVendor);
                }
                catch(Exception ex)
                {
                    return Json(new { status = ex.ToString() });

                }
                return Json(new { status = "Successful" });

            }
            return Json(new { status = "failure" });

        }

        [HttpPost]
        public JsonResult CreateVender(VendorViewModel venderViewModel)
        {
            try
            {
                var vendor = new Vendor
                {
                    ContactPerson = new VendorContactPerson
                    {
                        FirstName = venderViewModel.ContactPersonFirstName,
                        MiddleName = venderViewModel.ContactPersonMiddleName,
                        LastName = venderViewModel.ContactPersonLastName,
                        HomePhone = venderViewModel.ContactPersonHomePhone,
                        CellPhone = venderViewModel.ContactPersonCellPhone,
                        Email = venderViewModel.ContactPersonEmail
                    },
                    IsActiveVendor = true,
                    VendorCategoryId = int.Parse(venderViewModel.VendorCategoryName),// this._vendorCategoryRepository.GetEntityById(1).Id,
                    VendorAddress = new Address
                    {
                        Address1 = venderViewModel.VendorAddress1,
                        Address2 = venderViewModel.VendorAddress2,
                        City = venderViewModel.VendorCity,
                        State = venderViewModel.VendorState,
                        ZipCode = venderViewModel.VendorZipCode,
                        Country = venderViewModel.VendorZipCode

                    },
                    VendorCreatedById = base.getCurrentlyLoggedInUser(_applicationUserRepository).Id,
                    VendorCreatedDate = DateTime.Now,
                    VendorDescription = venderViewModel.VendorDescription,
                    VendorName = venderViewModel.VendorName


                };

                this._vendorRepository.Save(vendor);

                return Json(new { status= "Successfuly" });
            }

            catch(ApplicationException apx)
            {
                return Json(new { status = "failure" });
            }
        }

       

        private VendorViewModel convert(Vendor currentVendor)
        {
           return new VendorViewModel
                    {
                        Id = currentVendor.Id,
                        ContactPersonCellPhone = currentVendor.ContactPerson.CellPhone,
                        ContactPersonEmail = currentVendor.ContactPerson.Email,
                        ContactPersonFirstName = currentVendor.ContactPerson.FirstName,
                        ContactPersonHomePhone = currentVendor.ContactPerson.HomePhone,
                        ContactPersonLastName = currentVendor.ContactPerson.LastName,
                        ContactPersonMiddleName = currentVendor.ContactPerson.MiddleName,

                        VendorAddress1 = currentVendor.VendorAddress.Address1,
                        VendorAddress2 = currentVendor.VendorAddress.Address2,
                        VendorCategoryName = currentVendor.VenderCategory.Name,
                        VendorCity = currentVendor.VendorAddress.City,
                        VendorCountry = currentVendor.VendorAddress.Country,
                        VendorDescription = currentVendor.VendorDescription,
                        VendorName = currentVendor.VendorName,
                        VendorState = currentVendor.VendorAddress.State,
                        VendorZipCode = currentVendor.VendorAddress.ZipCode,
                        VendorCategoryId = currentVendor.VenderCategory.Id.ToString()
                    };
        }

        public ActionResult Create()
        {
            return View(new VendorViewModel());
        }
        public ActionResult Index()
        {
           // somePracticeMethod();

            return View(new VendorViewModel());
        }

        [HttpPost]
        public JsonResult GetAllVendors()
        {
            var vendorViewModel = this._vendorRepository
                .GetAll()
                .Select(vm => convert(vm));
            
            try {
            
                return Json(vendorViewModel);
            }
            catch (ApplicationException apx) {
                return Json(new { status = "failure" });
            }
        }

        private void somePracticeMethod()
        {
            var users = this._applicationUserRepository.Get(
                filter: appUser => appUser.UserName == "jdavis",
                orderBy: appUser => appUser.OrderBy(o => o.LastName))

                .SingleOrDefault();
        }

        private void createVendor(ApplicationUser user)
        {
            var vendor = new Vendor
            {
                ContactPerson = new VendorContactPerson
                {
                    FirstName = "john",
                    MiddleName = "m",
                    LastName = "Doe",
                    HomePhone = "455-900-0909",
                    CellPhone = "",
                    Email = "jdoe@gmail.com"
                },
                IsActiveVendor = true,
                VendorCategoryId = this._vendorCategoryRepository.GetEntityById(1).Id,
                VendorAddress = new Address
                {
                    Address1 = "Charleston street",
                    Address2 = "Suite 100",
                    City = "Glen Burnie",
                    State = "MD",
                    ZipCode = "34423",
                    Country = "USA"

                },
                VendorCreatedById = user.Id,
                VendorCreatedDate = DateTime.Now,
                VendorDescription = "Cool vendor",
                VendorName = "Nice vednor from town"


            };

            this._vendorRepository.Save(vendor);
        }

	}
}