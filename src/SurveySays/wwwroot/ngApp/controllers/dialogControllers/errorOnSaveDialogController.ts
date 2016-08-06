namespace SurveySays.Controllers {
    export class ErrorOnSaveDialogController {
        constructor(public errors, private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance) { }

        public ok() {
            this.$uibModalInstance.close();
        }
    }
}