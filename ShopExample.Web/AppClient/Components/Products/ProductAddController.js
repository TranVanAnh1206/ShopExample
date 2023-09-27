(function (app) {
    app.controller('ProductAddController', ProductAddController)

    ProductAddController.$inject = ['$scope', 'ApiService', 'notificationService', '$state', 'CommonService']

    function ProductAddController($scope, ApiService, notificationService, $state, CommonService) {
        $scope.product = {
            CreatedDate: new Date(),
            Status: true,
            HomeFlag: true,
            HotFlag: false,
        }

        $scope.categories = []
        $scope.addProduct = AddProduct
        $scope.getSEOTitle = GetSEOTitle
        $scope.ckeditorOptions = {
            language: 'en',
            height: '200px',
            uiColor = '#AADC6E',
        }
        $scope.chooseImage = ChooseImage

        function GetSEOTitle() {
            $scope.product.Alias = CommonService.getSEOTitle($scope.product.Name)
        }

        function GetProductCategory() {
            ApiService.get('api/productcategory/getallparent', null, (result) => {
                $scope.categories = result.data
            }, (error) => {
                notificationService.displayError('Can not get product category....')
            })
        }

        function AddProduct() {
            ApiService.post('api/product/addnew', $scope.product, function (result) {
                notificationService.displaySuccess('Successfully created a new product.')
                $state.go('products')
            }, function (error) {
                notificationService.displayError('Can not create new product ...')

            })
        }

        function ChooseImage() {
            var finder = new CKFinder()
            finder.selectActionFunction = function (fileUrl) {
                $scope.product.Image = fileUrl
            }
            finder.popup()
        }

        GetProductCategory()
    }
})(angular.module('shopexample.products'));