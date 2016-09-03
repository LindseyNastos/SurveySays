namespace SurveySays.Controllers {

    export class PreviewController {
        public survey: SurveySays.Models.ISurvey;
        public surveyId: number;
        public questions: any = [];
        public categories: SurveySays.Models.IQuestionCategory[];
        public categoryId: number;
        public category: SurveySays.Models.IQuestionCategory;
        constructor(private $uibModal: angular.ui.bootstrap.IModalService, private surveyService: SurveySays.Services.SurveyService, private questionCategoryService: SurveySays.Services.QuestionCategoryService, private $stateParams: SurveySays.Models.IStateParams, private $state: ng.ui.IStateService) {
            this.surveyId = $stateParams.surveyId;
            this.getCategories();
            this.checkParams(this.$stateParams['id']);
        }
        public checkParams(params) {
            let stateParamNum = parseInt(params);
            if (!this.$stateParams['id']) {
                this.getSurveyInfo();
            }
            else if (isNaN(stateParamNum)) {
                console.log("Error: state parameters not valid.");
                this.getSurveyInfo();
            }
            else if (this.$stateParams['id'] && !isNaN(stateParamNum)) {
                this.categoryId = this.$stateParams['id'];
                this.getQuestionsByCategory(stateParamNum);
            }
            else {
                console.log("Error: state parameters not valid.");
                this.getSurveyInfo();
            }
        }

        public getSurveyInfo() {
            this.surveyService.getFullSurvey(this.surveyId).then((data) => {
                this.survey = data.survey;
                this.questions = data.questions;
            });
        }

        public getQuestionsByCategory(categoryId: number) {
            this.questionCategoryService.getQuestionsByCategory(categoryId, this.surveyId).then((data) => {
                this.questions = data;
            });
        }

        public getCategories() {
            this.categories = this.questionCategoryService.listCategories();
        }

        public edit(id: number) {
            this.$state.go("editSurvey.design", { id: id });
        }

        public deleteQuestion(question: SurveySays.Models.IQuestion) {
            this.$uibModal.open({
                templateUrl: '/ngApp/views/modals/deleteQuestionDialog.html',
                controller: SurveySays.Controllers.DeleteQuestionDialogController,
                controllerAs: 'modal',
                resolve: {
                    question: () => question
                }
            });
        }
    }

}