/// <reference path="../../../assets/admin/libs/angular/angular.js" />

/// Có nhiệm vụ include các directive bên ngoài


(function () {
    angular.module('shopexample.common',
        ['ui.router',
            'ngBootbox',
            'ngCkeditor',
            'LocalStorageModule',
            'ngMessages',
            'angular-loading-bar'
        ])
        .config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
            // Thay đổi màu sắc của loading bar
            cfpLoadingBarProvider.includeSpinner = true;
            cfpLoadingBarProvider.includeBar = true;
            cfpLoadingBarProvider.parentSelector = '#loading-bar-container';
            cfpLoadingBarProvider.spinnerTemplate = '<div><span class="fa fa-spinner">Loading...</div>';
        }])


})();