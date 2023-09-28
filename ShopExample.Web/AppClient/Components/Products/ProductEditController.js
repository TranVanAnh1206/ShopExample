(function (app) {

    app.controller('ProductEditController', ProductEditController)

    ProductEditController.$inject = ['$scope', 'ApiService', 'CommonService', '$state', 'notificationService', '$stateParams']

    function ProductEditController($scope, ApiService, CommonService, $state, notificationService, $stateParams) {
        $scope.product = {
            ModifiedDate: new Date(),
            Status: true,
        }
        $scope.ckeditorOptions = {
            language: 'vi',
            height: '400px',
            uiColor: '#AADC6E',
        }
        $scope.productCategories = []
        $scope.updateProduct = UpdateProduct
        $scope.getProductCategory = GetProductCategory
        $scope.getSEOTitle = GetSEOTitle
        $scope.loadProductDetail = LoadProdcutDetail

        function GetSEOTitle() {
            $scope.product.Alias = CommonService.getSEOTitle($scope.product.Name)
        }

        function LoadProdcutDetail() {
            ApiService.get('api/product/getbyid/' + $stateParams.id, null,
                function (result) {
                    $scope.product = result.data
                }, function (error) {
                    notificationService.displayError('Fail to load data ...')
                })
        }

        function GetProductCategory() {
            ApiService.get('api/productcategory/getallparent', null,
                function (result) {
                    $scope.productCategories = result.data
                }, function (error) {
                    notificationService.displayError('There was an error while loading the product category.')
                })
        }

        function UpdateProduct() {
            ApiService.put('api/product/update', $scope.product, function (result) {
                notificationService.displaySuccess('Update success ...')
                $state.go('products')
            }, function (error) {
                notificationService.displayError('Update failed ... ')
            })
        }

        $scope.getProductCategory()
        $scope.loadProductDetail()
    }

})(angular.module('shopexample.products'))