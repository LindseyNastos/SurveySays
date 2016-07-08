namespace SurveySays.Services {

    export class QuestionService {
        private QuestionResource
        constructor($resource: ng.resource.IResourceService) {
            this.QuestionResource = $resource("/api/questions/:id");
        }
        public listQuestions() {
            return this.QuestionResource.query();
        }
        public getQuestion(id: number) {
            return this.QuestionResource.get({ id: id }).$promise;
        }
        public saveQuestion(vm) {
            return this.QuestionResource.save(vm).$promise;
        }
        public deleteQuestion(id: number) {
            return this.QuestionResource.delete({ id: id }).$promise;
        }
    }
    angular.module("SurveySays").service("questionService", QuestionService);
}