/// <reference path="../angular.min.js" />
angular.module("venderModule")
   .config(function (ngModalDefaultsProvider) {
       return ngModalDefaultsProvider.set({
           closeButtonHtml: "<i class='fa fa-times'></i>"
       });
   });

angular.module("venderModule").controller('venderController',
   ['$scope', '$location', 'venderService', 'venderCategoryService',
    function ($scope, $location, venderService, venderCategoryService) {


        $scope.venderCategories = [];

        loadVendorCategories();
        function loadVendorCategories() {

            venderCategoryService.getAllCategories()
           .then(function (vendorCategory) {
               $scope.venderCategories = vendorCategory.data;
           });

        }


        $scope.venders = [];

       $scope.createVendorModel = {

           vendorName: "",
           vendorDescription: "",
           vendorAddress1: "",
           vendorAddress2: "",
           vendorCity: "",
           vendorState: "",
           vendorZipCode: "",
           vendorZipCode: "",
           vendorCountry: "",
           contactPersonFirstName: "",
           contactPersonMiddleName: "",
           ContactPersonLastName: "",
           contactPersonHomePhone: "",
           contactPersonCellPhone: "",
           contactPersonEmail: "",
           vendorNameErrorMessage : ""
       }

       $scope.toggleVendorDetailsModalDomain = {
           modalShown: false,
           vendorId : 0

       }


       $scope.editVendorModel = {
           modalShown: false,
           vendorId: 0,
           vendorAddress1: "",
           vendorAddress2: "",
           vendorCity: "",
           vendorState: "",
           vendorZipCode: "",
           vendorZipCode: "",
           vendorCountry: "",
           contactPersonFirstName: "",
           contactPersonMiddleName: "",
           ContactPersonLastName: "",
           contactPersonHomePhone: "",
           contactPersonCellPhone: "",
           contactPersonEmail: "",
           vendorName: "",
           vendorDescription : ""

       }

       $scope.toggleVendorEditModal = function (vendor) {
           $scope.editVendorModel.modalShown = true;
           $scope.editVendorModel.venderId = vendor.Id;

           //alert(vendor.VendorName);
          
           $scope.editVendorModel.vendorName = vendor.VendorName;
           $scope.editVendorModel.vendorDescription = vendor.VendorDescription;
           $scope.editVendorModel.vendorAddress1 = vendor.VendorAddress1;
           $scope.editVendorModel.vendorAddress2 = vendor.VendorAddress2;
           $scope.editVendorModel.vendorCity = vendor.VendorCity;

           $scope.editVendorModel.vendorState = vendor.VendorState;
           $scope.editVendorModel.vendorZipCode = vendor.VendorZipCode;
           $scope.editVendorModel.vendorCountry = vendor.VendorCountry;

           $scope.editVendorModel.contactPersonFirstName = vendor.ContactPersonFirstName;
           $scope.editVendorModel.contactPersonMiddleName = vendor.ContactPersonMiddleName;
           $scope.editVendorModel.ContactPersonLastName = vendor.ContactPersonLastName;
           $scope.editVendorModel.contactPersonHomePhone = vendor.ContactPersonHomePhone;
           $scope.editVendorModel.contactPersonCellPhone = vendor.ContactPersonCellPhone;
           $scope.editVendorModel.contactPersonEmail = vendor.ContactPersonEmail;

           $scope.editVendorModel.vendorCategory = vendor.VendorCategoryId;


       }

       $scope.editVendorModel = function(vendor){
           // alert($scope.editVendorModel.venderId);


           var venderViewModel = {
               VendorName: $scope.editVendorModel.vendorName,
               VendorDescription: $scope.editVendorModel.vendorDescription,
               VendorAddress1: $scope.editVendorModel.vendorAddress1,
               VendorAddress2: $scope.editVendorModel.vendorAddress2,
               VendorCity: $scope.editVendorModel.vendorCity,
               VendorState: $scope.editVendorModel.vendorState,
               VendorZipCode: $scope.editVendorModel.vendorZipCode,
               VendorCountry: $scope.editVendorModel.vendorCountry,
               ContactPersonFirstName: $scope.editVendorModel.contactPersonFirstName,
               ContactPersonMiddleName: $scope.editVendorModel.contactPersonMiddleName,
               ContactPersonLastName: $scope.editVendorModel.ContactPersonLastName,
               ContactPersonHomePhone: $scope.editVendorModel.contactPersonHomePhone,
               ContactPersonCellPhone: $scope.editVendorModel.contactPersonCellPhone,
               ContactPersonEmail: $scope.editVendorModel.contactPersonEmail,
               VendorCategoryName: $scope.editVendorModel.vendorCategory
           };


           venderService.updateVendor(venderViewModel, $scope.editVendorModel.venderId)
           .then(function (status) {
               if (status.data.status == "Successful") {
                   $scope.editVendorModel.modalShown = false;
                   window.location.reload();
               }
               else { alert("something went awry!!"); }

           });

       }

       $scope.currentVendors = [];
       $scope.toggleDetailsModal = function (vender) {

           $scope.toggleVendorDetailsModalDomain.modalShown = true;
           $scope.toggleVendorDetailsModalDomain.venderId = vender.Id;
           venderService.getVendorsById($scope.toggleVendorDetailsModalDomain.venderId)
          .then(function (vendor) {
              console.log(vender);
              $scope.currentVendors = [vender];
          });
           

       }


       $scope.invalidData = false;

       loadVendors();
       function loadVendors() {

          venderService.getVendors()
          .then(function (vendors) {
              console.log(vendors);
              $scope.venders = vendors.data;
          });

       }




       $scope.createValidationErrors = [];
       function isNullOrEmpty(value){
       

           //alert(value)
           return value === undefined 
               || value === null 
               || value === '' 
       }
       function hasValidDataOnCreate() {
           if (isNullOrEmpty($scope.createVendorModel.vendorName)) {
              // $scope.invalidData = true;
               // $scope.createValidationErrors.push("Please enter vendor Name");
               $scope.createVendorModel.vendorNameErrorMessage = "Please enter vendor Name";
           }

           return $scope.createValidationErrors.length == 0;
       }

      
       $scope.toggleCreateVendorModalDomain = {


           modalShown : false
       };
       $scope.toggleCreateVendorModal = function () {
           $scope.toggleCreateVendorModalDomain.modalShown = true;
       };

       $scope.createVendorModel = function () {

           var venderViewModel = {
               VendorName: $scope.createVendorModel.vendorName,
               VendorDescription: $scope.createVendorModel.vendorDescription,
               VendorAddress1: $scope.createVendorModel.vendorAddress1,
               VendorAddress2: $scope.createVendorModel.vendorAddress2,
               VendorCity: $scope.createVendorModel.vendorCity,
               VendorState: $scope.createVendorModel.vendorState,
               VendorZipCode: $scope.createVendorModel.vendorZipCode,
               VendorCountry: $scope.createVendorModel.vendorCountry,
               ContactPersonFirstName: $scope.createVendorModel.contactPersonFirstName,
               ContactPersonMiddleName: $scope.createVendorModel.contactPersonMiddleName,
               ContactPersonLastName: $scope.createVendorModel.ContactPersonLastName,
               ContactPersonHomePhone: $scope.createVendorModel.contactPersonHomePhone,
               ContactPersonCellPhone: $scope.createVendorModel.contactPersonCellPhone,
               ContactPersonEmail: $scope.createVendorModel.contactPersonEmail,
               VendorCategoryName: $scope.createVendorModel.vendorCategory

           };
           venderService.saveVendor(venderViewModel)
           .then(function (response) {
               var status = response.data;
               if (status.status == "Successful") {
                   loadVendors();
               }
           });

       }

       $scope.vendorDeleteData = {
           modalShown: false,
           venderId: 0
       }

       $scope.toggleDeleteModal = function (vender) {
           $scope.vendorDeleteData.venderId = vender.Id;
           $scope.vendorDeleteData.modalShown = true;

       };


        $scope.UsStates =
       [
               { "name": "Alabama", "abbreviation": "AL" },
               { "name": "Alaska", "abbreviation": "AK" },
               { "name": "Arizona", "abbreviation": "AZ" },
               { "name": "Arkansas", "abbreviation": "AR" },
               { "name": "California", "abbreviation": "CA" },
               { "name": "Colorado", "abbreviation": "CO" },
               { "name": "Connecticut", "abbreviation": "CT" },
               { "name": "Delaware", "abbreviation": "DE" },
               { "name": "District of Columbia", "abbreviation": "DC" },
               { "name": "Florida", "abbreviation": "FL" },
               { "name": "Georgia", "abbreviation": "GA" },
               { "name": "Hawaii", "abbreviation": "HI" },
               { "name": "Idaho", "abbreviation": "ID" },
               { "name": "Illinois", "abbreviation": "IL" },
               { "name": "Indiana", "abbreviation": "IN" },
               { "name": "Iowa", "abbreviation": "IA" },
               { "name": "Kansa", "abbreviation": "KS" },
               { "name": "Kentucky", "abbreviation": "KY" },
               { "name": "Lousiana", "abbreviation": "LA" },
               { "name": "Maine", "abbreviation": "ME" },
               { "name": "Maryland", "abbreviation": "MD" },
               { "name": "Massachusetts", "abbreviation": "MA" },
               { "name": "Michigan", "abbreviation": "MI" },
               { "name": "Minnesota", "abbreviation": "MN" },
               { "name": "Mississippi", "abbreviation": "MS" },
               { "name": "Missouri", "abbreviation": "MO" },
               { "name": "Montana", "abbreviation": "MT" },
               { "name": "Nebraska", "abbreviation": "NE" },
               { "name": "Nevada", "abbreviation": "NV" },
               { "name": "New Hampshire", "abbreviation": "NH" },
               { "name": "New Jersey", "abbreviation": "NJ" },
               { "name": "New Mexico", "abbreviation": "NM" },
               { "name": "New York", "abbreviation": "NY" },
               { "name": "North Carolina", "abbreviation": "NC" },
               { "name": "North Dakota", "abbreviation": "ND" },
               { "name": "Ohio", "abbreviation": "OH" },
               { "name": "Oklahoma", "abbreviation": "OK" },
               { "name": "Oregon", "abbreviation": "OR" },
               { "name": "Pennsylvania", "abbreviation": "PA" },
               { "name": "Rhode Island", "abbreviation": "RI" },
               { "name": "South Carolina", "abbreviation": "SC" },
               { "name": "South Dakota", "abbreviation": "SD" },
               { "name": "Tennessee", "abbreviation": "TN" },
               { "name": "Texas", "abbreviation": "TX" },
               { "name": "Utah", "abbreviation": "UT" },
               { "name": "Vermont", "abbreviation": "VT" },
               { "name": "Virginia", "abbreviation": "VA" },
               { "name": "Washington", "abbreviation": "WA" },
               { "name": "West Virginia", "abbreviation": "WV" },
               { "name": "Wisconsin", "abbreviation": "WI" },
               { "name": "Wyoming", "abbreviation": "WY" }
       ]
      
   }]);

