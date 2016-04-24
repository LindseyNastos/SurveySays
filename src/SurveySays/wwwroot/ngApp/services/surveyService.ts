namespace SurveySays.Services {

    export class SurveyService {
        private SurveyResource;
        constructor($resource: ng.resource.IResourceService) {
            this.SurveyResource = $resource('api/surveys/:id');
        }
        public listSurveys() {
            return this.SurveyResource.query();
        }
        public getSurvey(id:number) {
            return this.SurveyResource.get({ id: id }).$promise;
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