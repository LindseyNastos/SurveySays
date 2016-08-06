namespace SurveySays.Controllers {
    export class QuestionSavedDialogController {
        constructor(private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private $state: ng.ui.IStateService) { }

        public ok() {
            this.$uibModalInstance.close();
            this.$state.go("editSurvey.design", { id: null });
        }
    }
}