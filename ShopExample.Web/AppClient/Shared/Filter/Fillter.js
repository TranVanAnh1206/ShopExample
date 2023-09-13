/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function (app) {

    app.filter('StatusFilter', () => {
        return function (input) {
            if (input === true) {
                return 'Kích hoạt'
            } else {
                return 'Khóa'
            }
        }
    })

})(angular.module('shopexample.common'))