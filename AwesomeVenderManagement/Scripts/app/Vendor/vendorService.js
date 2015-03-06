/// <reference path="../../angular.min.js" />
angular.module("venderModule").

    service("venderService", ['$http', function ($http) {
        var vs = {};
        vs.getVendors = function () {
            return $http.post('/Vendor/GetAllVendors');
        }

        vs.saveVendor = function (venderViewModel) {
            return $http.post('/Vendor/CreateVender', venderViewModel);
        }

        vs.getVendorsById = function (id) {
            return $http.post('/Vendor/GetVendorByVendorId', {vendorId: id});
        }


        vs.updateVendor = function (vendorViewModel, vendorId) {
            alert(vendorId);
            return $http.post('/Vendor/EditVendor',
                    {
                        vendorViewModel: vendorViewModel,
                        vendorId: vendorId
                    });

        }
        return vs;
    }]);



