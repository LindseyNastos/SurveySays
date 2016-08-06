namespace SurveySays.Controllers {

    export class DesignController {
        public categories: SurveySays.Models.IQuestionCategory[];
        public categoryId: number;
        public questionTypes: SurveySays.Models.IQuestionType[];
        public question: SurveySays.Models.IQuestion;
        public survey: SurveySays.Models.ISurvey;
        public accordionArray = [];
        public status = { isFirstOpen: true, isFirstDisabled: false };
        public answerChoiceArray: SurveySays.Models.IOption[] =
        [new SurveySays.Models.Option, new SurveySays.Models.Option, new SurveySays.Models.Option];
        public matrixOptionsArray: SurveySays.Models.IOption[] =
        [new SurveySays.Models.Option, new SurveySays.Models.Option, new SurveySays.Models.Option];
        public questionType: string;
        public surveyId;

        constructor(private $scope: ng.IScope, private surveyService: SurveySays.Services.SurveyService, private questionService: SurveySays.Services.QuestionService, private questionCategoryService: SurveySays.Services.QuestionCategoryService, private questionTypeService: SurveySays.Services.QuestionTypeService, $stateParams: SurveySays.Models.IStateParams, private $uibModal: angular.ui.bootstrap.IModalService, private $state: ng.ui.IStateService) {
            this.checkStateParams($stateParams['id']);
            this.getCategories();
            this.surveyId = $stateParams.surveyId;
        }

        public checkStateParams(params) {
            let self = this;
            if (params) {
                let stateParamNum = parseInt(params);
                if (isNaN(stateParamNum)) {
                    self.question = new SurveySays.Models.Question();
                    self.question.questionType = new SurveySays.Models.QuestionType();
                    self.question.questionType.type = params;
                    self.questionTypeService.getType(params).then((data) => {
                        self.question.questionType = data;
                    });
                }
                else {
                    self.getQuestion(params);
                }
            }
        }

        public getCategories() {
            this.categories = this.questionCategoryService.listCategories();
        }

        public getQuestion(id: number) {
            this.questionService.getQuestion(id).then((data: SurveySays.Models.IQuestion) => {
                this.question = data;
                this.categoryId = data.questionCategoryId;
                this.answerChoiceArray = data.answerOptions;
                this.matrixOptionsArray = data.matrixQuestions;
            });
        }

        public saveQuestion() {
            this.question.answerOptions = this.cleanArray(this.answerChoiceArray);
            this.question.matrixQuestions = this.cleanArray(this.matrixOptionsArray);
            let vm: any = {};
            vm.surveyId = this.surveyId;
            vm.categoryId = this.categoryId;
            vm.question = this.question;
            this.questionService.saveQuestion(vm).then(() => {
                this.questionSaved();
            }).catch((errors) => {
                this.errorOnSave(errors);
            });
        }

        public cleanArray(array: SurveySays.Models.IOption[]) {
            for (let i = (array.length - 1); i >= 0; i--) {
                if (!array[i].opt) {
                    array.splice(i, 1);
                }
            }
            for (let i = 0; i < array.length; i++) {
                (array[i].opt).trim();
            }
            return array;
        }

        public isLast(checkLast: boolean, index: number, type: string) {
            if (type == 'choice') {
                let arrayLength = this.answerChoiceArray.length;
                if (arrayLength > 1 && arrayLength < 6) {
                    if (checkLast) {
                        //if last, add one to the array
                        let newAnswerOption = new SurveySays.Models.Option;
                        newAnswerOption.opt = "";
                        this.answerChoiceArray[index + 1] = newAnswerOption;
                    }
                }
            }
            if (type == 'option') {
                let arrayLength = this.matrixOptionsArray.length;
                if (arrayLength > 1 && arrayLength < 6) {
                    if (checkLast) {
                        //if last, add one to the array
                        let newMatrixQuestion = new SurveySays.Models.Option;
                        newMatrixQuestion.opt = "";
                        this.matrixOptionsArray[index + 1] = newMatrixQuestion;
                    }
                }
            }
        }

        public addChoice(index: number, type: string) {
            if (type == 'choice') {
                let arrayLength = this.answerChoiceArray.length;
                let newAnswerOption = new SurveySays.Models.Option;
                newAnswerOption.opt = "";
                if (arrayLength < 6) {
                    this.answerChoiceArray.splice(index + 1, 0, newAnswerOption);
                }
            }
            if (type == 'option') {
                let arrayLength = this.matrixOptionsArray.length;
                let newMatrixQuestion = new SurveySays.Models.Option;
                newMatrixQuestion.opt = "";
                if (arrayLength < 6) {
                    this.matrixOptionsArray.splice(index + 1, 0, newMatrixQuestion);
                }
            }
        }


        public deleteChoice(index: number, type: string) {
            if (type == 'choice') {
                let arrayLength = this.answerChoiceArray.length;
                if (arrayLength > 1) {
                    this.answerChoiceArray.splice(index, 1);
                }
            }
            if (type == 'option') {
                let arrayLength = this.matrixOptionsArray.length;
                if (arrayLength > 1) {
                    this.matrixOptionsArray.splice(index, 1);
                }
            }
        }

        public reset() {
            this.$state.go("editSurvey.design", { id: null });
        }

        public questionSaved() {
            this.$uibModal.open({
                templateUrl: '/ngApp/views/modals/questionSaved.html',
                controller: SurveySays.Controllers.QuestionSavedDialogController,
                controllerAs: 'modal'
            });
        }

        public errorOnSave(errors) {
            this.$uibModal.open({
                templateUrl: '/ngApp/views/modals/errorOnSave.html',
                controller: SurveySays.Controllers.ErrorOnSaveDialogController,
                controllerAs: 'modal',
                resolve: {
                    errors: () => errors
                },
                size: 'sm'
            });
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

    angular.module("SurveySays").controller("designController", DesignController);
}






















//HappyCoding123