namespace SurveySays.Controllers {

    export class DeleteQuestionDialogController {
        public questionToDelete: SurveySays.Models.IQuestion;

        constructor(public question: SurveySays.Models.IQuestion, private $uibModalInstance: angular.ui.bootstrap.IModalServiceInstance, private questionService: SurveySays.Services.QuestionService, private $state: ng.ui.IStateService) {
            this.questionToDelete = question;
        }

        public cancel() {
            this.$uibModalInstance.close();
        }

        public confirmDelete() {
            this.questionService.deleteQuestion(this.questionToDelete.id).then(() => {
                this.$uibModalInstance.close();
                this.$state.reload();
            });
        }

    }

}