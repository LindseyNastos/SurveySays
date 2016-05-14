namespace SurveySays.Services {
    export class QuestionTypeService {
        private TypeResource;
        constructor($resource: ng.resource.IResourceService) {
            this.TypeResource = $resource("/api/questionTypes/:id");
        }
        public listTypes() {
            return this.TypeResource.query();
        }
    }
    angular.module("SurveySays").service("questionTypeService", QuestionTypeService);
}