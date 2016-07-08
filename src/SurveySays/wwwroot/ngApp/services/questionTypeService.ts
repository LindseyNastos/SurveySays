namespace SurveySays.Services {
    export class QuestionTypeService {
        private TypeResource;
        constructor($resource: ng.resource.IResourceService) {
            this.TypeResource = $resource("/api/questionTypes/:qType");
        }
        public listTypes() {
            return this.TypeResource.query().$promise;
        }
        public getType(qType: string) {
            return this.TypeResource.get({ qType: qType }).$promise;
        }
    }
    angular.module("SurveySays").service("questionTypeService", QuestionTypeService);
}