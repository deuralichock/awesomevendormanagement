/// <reference path="../angular.min.js" />
 angular.module("venderCategoryModule")
    .config(function (ngModalDefaultsProvider) {
        return ngModalDefaultsProvider.set({
            closeButtonHtml: "<i class='fa fa-times'></i>"
        });
});

 angular.module("venderCategoryModule").controller('venderCategoryController',
    ['$scope','$location', 'venderCategoryService',
    function ($scope, $location, venderCategoryService) {
        $scope.venderCategories = [];
        
        loadVendorCategories();
        function loadVendorCategories() {

            $scope.venderCategories = venderCategoryService.getAllCategories()
           .then(function (vendorCategory) {
               console.log(vendorCategory);
               $scope.venderCategories = vendorCategory.data;
           });

        }

        $scope.vendorCategoryCreateData = {
            venderCategoryName: "",
            venderCategoryDescription: ""
        }


        $scope.vendorCategoryEditData = {

            modalShown: false,
            venderCategoryName: "",
            venderCategoryDescription: "",
            venderCategoryId : 0
        }

        $scope.createVenderCategory = function () {

            $scope.status = "";
            var vendorCategoryViewModel = {
                VendorName: $scope.categoryName,
                VendorDescription: $scope.categoryDescription
            };
            venderCategoryService.saveCategory(vendorCategoryViewModel)
            .then(function (response) {
                var status = response.data;
                if (status.status == "Successful") {
                   // $location.('/VendorCategory/Index')
                }
            });

        }


        $scope.vendorCategoryDeleteData = {
            modalShown: false,
            venderCategoryId: 0
        }

        $scope.togleDeleteModal = function (venderategory) {
            $scope.vendorCategoryDeleteData.venderCategoryId = venderategory.Id;
            $scope.vendorCategoryDeleteData.modalShown = true;

        };

        $scope.deleteVendorCategory = function () {

            alert($scope.vendorCategoryDeleteData.venderCategoryId);
            if ($scope.vendorCategoryDeleteData.venderCategoryId > 0) {
                venderCategoryService.removeVenderCategory($scope.vendorCategoryDeleteData.venderCategoryId)
                .then(function (response) {
                    if (response.data.status == "Successful") {
                       // window.location.reload();
                        $scope.togleDeleteModal.modalShown = false;
                        window.location.reload();


                    }
                });


            }
        }

        $scope.modalShown = false;


        $scope.vendorCategoryEdit = '';

        $scope.toggleModal = function (venderategory) {
            $scope.modalShown = true;
        };

        $scope.toggleEditModal = function (venderategory) {
            $scope.vendorCategoryEditData.venderCategoryName = venderategory.VendorName;
            $scope.vendorCategoryEditData.venderCategoryDescription = venderategory.VendorDescription;
            $scope.vendorCategoryEditData.venderCategoryId = venderategory.Id;
            $scope.vendorCategoryEditData.modalShown = true;

        };

        $scope.editVendorCategory = function () {

            var vendorCategoryViewModel = {
                VendorName: $scope.vendorCategoryEditData.venderCategoryName,
                VendorDescription: $scope.vendorCategoryEditData.venderCategoryDescription,
                Id: $scope.vendorCategoryEditData.venderCategoryId
            };


            venderCategoryService.editVendorCategory(vendorCategoryViewModel)
            .then(function (response) {
                var status = response.data;
                if (status.status == "Successful") {
                    window.location.reload();
                }
            });
        }


        $scope.createNewVendorCategory = function () {

            var vendorCategoryViewModel = {
                VendorName: $scope.vendorCategoryCreateData.venderCategoryName,
                VendorDescription: $scope.vendorCategoryCreateData.venderCategoryDescription
            };
            venderCategoryService.saveCategory(vendorCategoryViewModel)
            .then(function (response) {
                var status = response.data;
                if (status.status == "Successful") {
                    loadVendorCategories();

                }
            });
            $scope.modalShown = false;
        }
}]);

