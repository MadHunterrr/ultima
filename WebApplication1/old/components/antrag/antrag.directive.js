;(function () {

    'use strict';

    angular.module('directive.antrag', [])
        .directive('antrag', antrag);


    function antrag() {
        return {
            restrict: 'E',
            scope: {
                parent: '=',
                index: '@'
            },
            templateUrl: 'components/antrag/antrag.html',
            controller: 'AntragController',
            controllerAs: 'vm',
            link: function (scope, elem, attrs) {
                console.log(scope);
            }
        };
    }
})();