/// <reference path="../../../assets/admin/libs/angular/angular.min.js" />

(function (app) {
    app.controller('PostCategoryListController', PostCategoryListController)

    PostCategoryListController.$inject = ['$scope', 'ApiService', 'notificationService', '$ngBootbox', '$filter']

    function PostCategoryListController($scope, ApiService, notificationService, $ngBootbox, $filter) {
        $scope.postcategoryList = []
        $scope.GetListPostcategory = GetListPostcategory

        function GetListPostcategory() {
            ApiService.get('/api/postcategory/getall', null, function (result) {
                if (result.data != null) {
                    $scope.postcategoryList = result.data
                }
                else {
                    console.log('null post category')
                }
            }, function (error) {
                notificationService.DisplayError('Load list post category failed.')
            })
        }

        $scope.GetListPostcategory()
    }
})(angular.module('shopexample.post_category'));