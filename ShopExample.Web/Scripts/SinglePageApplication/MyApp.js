/// <reference path="../plugins/angular.js" />

var myApp = angular.module("MyModule", [])

myApp.controller("MyController", MyController)
//myApp.controller("MyController2", MyController2)
//myApp.controller("ParentController", ParentController)
myApp.service("Validator", Validator)
myApp.directive("shopExampleDirective", shopExampleDirective)

MyController.$inject = ['$scope', 'Validator']
//MyController2.$inject = ['$scope']

//function ParentController($scope) {
//    $scope.message = "This is message from Parent"
//}

function MyController($scope, Validator) {
    //$rootScope.Handsome = "Đẹp trai"

    $scope.message = "This is message from controller"

    //$scope.result = Validator.checkNumber(2)

    $scope.checkNum = function () {
        $scope.result = Validator.checkNumber($scope.num)
    }

}

//function MyController2($scope) {
//    $scope.message = "My name is Trần Văn Anh đẹp trai"
//}


// khi khai báo $rootScope thì tất cả controller đều sử dụng được biến được khi báo bởi $rootScope
// $scope lồng nhau

// Service
// tự tạo một service custom
function Validator($window) {
    return {
        checkNumber: checkNumber,
    }

    function checkNumber(num) {
        if (num % 2 === 0) {
            return "this is so chan"
        }
        else {
            return "this is so le"
        }
    }
}

// Directive ttrong angular JS
//là một tính năng của nagularJS giúp mở rộng thuộc tính cho html nhằm muc đích nào đó
// các directive thường có tiền tố 'ng-"directive"'
/*
 
các directive
- ng-app: khởi tạo ứng dụng 
- ng-model: gắn kết dữ liệu với các thẻ html (input, select, textarea ...)

 */

function shopExampleDirective() {
    return {
        template: '<h1>Trần VĂn Anh đẹp trai</h1>'
    }
}

//cũng có thể truyền vào một file html
function shopExampleHtmlDirective() {
    return {
        restrict: 'A',
        templateUrl: 'Scripts/Demo/Demo.html'
    }
}

/*
 Hạn chế truy cập cho directive
 E: cho element
 A: cho Attr
 C: class
 M: Comment
 Mặc định: giá trị EA sẽ hạn chế cả element và attr
 
 */