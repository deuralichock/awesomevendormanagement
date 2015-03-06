/// <reference path="../../angular.min.js" />
angular.module("venderCategoryModule").

    service("venderCategoryService", ['$http', function ($http) {
    var categoryService = {};
        categoryService.getAllCategories = function () {
            return $http.get('/VendorCategory/GetAllVendorCategories');
        }

        categoryService.saveCategory = function (vendorCategoryViewModel) {
            return $http.post('/VendorCategory/SaveVendorCategory', vendorCategoryViewModel);
        }
        categoryService.removeVenderCategory = function (vendorCategoryId) {
            return $http.post('/VendorCategory/RemoveVendorCategory/' + vendorCategoryId);

        }

        categoryService.editVendorCategory = function (vendorCategoryViewModel) {
            return $http.post('/VendorCategory/EditVendorCategory', vendorCategoryViewModel);
        }
    return categoryService;
}]);



