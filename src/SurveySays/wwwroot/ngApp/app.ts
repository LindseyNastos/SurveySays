namespace SurveySays {

    angular.module('SurveySays', ['ui.router', 'ngResource', 'ui.bootstrap', 'ngDraggable']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html'
            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html'
            })
            .state('newSurvey', {
                url: '/newSurvey',
                templateUrl: '/ngApp/views/newSurvey.html',
                controller: SurveySays.Controllers.NewSurveyController,
                controllerAs: 'vm'
            })
            .state('editSurvey', {
                url: '/editSurvey/:surveyId',
                templateUrl: '/ngApp/views/editSurvey.html',
                controller: SurveySays.Controllers.EditSurveyController,
                controllerAs: 'vm',
                resolve: {
                    // Expose surveyId parameter to child states
                    surveyId: ['$stateParams', ($stateParams) => {
                        return $stateParams.surveyId;
                    }]
                },
            })
            .state('editSurvey.summary', {
                url: '/summary',
                templateUrl: '/ngApp/views/editSurveyChildViews/summary.html',
                controller: SurveySays.Controllers.SummaryController,
                controllerAs: 'vm'
            })
            .state('editSurvey.design', {
                url: '/design/:id?',
                templateUrl: '/ngApp/views/editSurveyChildViews/design.html',
                controller: SurveySays.Controllers.DesignController,
                controllerAs: 'vm'
            })
            .state('editSurvey.preview', {
                url: '/preview/:id?',
                templateUrl: '/ngApp/views/editSurveyChildViews/preview.html',
                controller: SurveySays.Controllers.PreviewController,
                controllerAs: 'vm'
            })
            .state('editSurvey.collect', {
                url: '/collect',
                templateUrl: '/ngApp/views/editSurveyChildViews/collect.html',
                controller: SurveySays.Controllers.CollectController,
                controllerAs: 'vm'
            })
            .state('editSurvey.analyze', {
                url: '/analyze',
                templateUrl: '/ngApp/views/editSurveyChildViews/analyze.html',
                controller: SurveySays.Controllers.AnalyzeController,
                controllerAs: 'vm'
            })
            .state('takeSurvey', {
                url: '/takeSurvey',
                templateUrl: '/ngApp/views/takeSurvey.html',
                controller: SurveySays.Controllers.TakeSurveyController,
                controllerAs: 'vm'
            })
            .state('profile', {
                url: '/profile/:userId',
                templateUrl: '/ngApp/views/profile.html',
                controller: SurveySays.Controllers.ProfileController,
                controllerAs: 'vm'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: SurveySays.Controllers.LoginController,
                controllerAs: 'vm'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: SurveySays.Controllers.RegisterController,
                controllerAs: 'vm'
            })
            .state('adminDash', {
                url: '/adminDash',
                templateUrl: '/ngApp/views/adminDash.html',
                //controller: SurveySays.Controllers.AdminDashController,
                //controllerAs: 'vm'
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

    
    angular.module('SurveySays').factory('authInterceptor', (
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

    angular.module('SurveySays').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
