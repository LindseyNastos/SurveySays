namespace SurveySays.Services {

    export class SurveyService {
        private SurveyResource;
        constructor($resource: ng.resource.IResourceService) {
            this.SurveyResource = $resource('/api/surveys/:id', null, {
                getBasicSurvey: {
                    method: 'GET',
                    url: '/api/surveys/getBasicSurvey/:id',
                    isArray: false
                },
                getFullSurvey: {
                    method: 'GET',
                    url: '/api/surveys/getFullSurvey/:id',
                    isArray: false
                }
            });
        }
        public listSurveys() {
            return this.SurveyResource.query();
        }
        public getBasicSurvey(id: number) {
            return this.SurveyResource.getBasicSurvey({ id: id }).$promise;
        }
        public getFullSurvey(id: number) {
            return this.SurveyResource.getFullSurvey({ id: id }).$promise;
        }
        public saveSurvey(survey) {
            return this.SurveyResource.save(survey).$promise;
        }
        public deleteSurvey(id: number) {
            return this.SurveyResource.delete({ id: id }).$promise;
        }
    }
    angular.module('SurveySays').service('surveyService', SurveyService);

}