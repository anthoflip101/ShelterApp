namespace SheltersApp {

    angular.module('SheltersApp', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: SheltersApp.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: SheltersApp.Controllers.AnimalController,
                controllerAs: 'controller',
                data: {
                    requiresAuthentication: true,
                }
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: SheltersApp.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: SheltersApp.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: SheltersApp.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            }) 
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: SheltersApp.Controllers.AboutController,
                controllerAs: 'controller'
            }).state('Details', {
                url: '/details/:id',
                templateUrl: '/ngApp/views/details.html',
                controller: SheltersApp.Controllers.AnimalDetailsController,
                controllerAs: 'controller'
            })
            .state('Delete', {
                url: '/delete/:id',
                templateUrl: '/ngApp/views/delete.html',
                controller: SheltersApp.Controllers.AnimalDeleteController,
                controllerAs: 'controller'
            })
            .state('Edit', {
                url: '/edit/:id',
                templateUrl: '/ngApp/views/edit.html',
                controller: SheltersApp.Controllers.AnimalEditController,
                controllerAs: 'controller'
            })
            .state('Add', {
                url: '/add',
                templateUrl: '/ngApp/views/add.html',
                controller: SheltersApp.Controllers.AnimalAddController,
                controllerAs: 'controller'
                    
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('SheltersApp').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('SheltersApp').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });
    angular.module('SheltersApp').run((
        $rootScope: ng.IRootScopeService,
        $state: ng.ui.IStateService,
        accountService: SheltersApp.Services.AccountService
    ) => {
        $rootScope.$on('$stateChangeStart', (e, to) => {
            // protect non-public views
            if (to.data && to.data.requiresAuthentication) {
                if (!accountService.isLoggedIn()) {
                    e.preventDefault();
                    $state.go('login');
                }
            }
        });
    });

    

}
