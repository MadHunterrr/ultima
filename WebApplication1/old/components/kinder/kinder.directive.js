;(function () {

    'use strict';

    angular.module('directive.kinder', [])
        .directive('kinder', kinder);


    function kinder() {
        return {
            restrict: 'E',
            scope: {
                parent: '=',
                index: '@'
            },
            templateUrl: 'components/kinder/kinder.html',
            controller: 'KinderController',
            controllerAs: 'vm',
            link: function (scope, elem, attrs) {
                console.log(scope);
            }
        };
    }
})();