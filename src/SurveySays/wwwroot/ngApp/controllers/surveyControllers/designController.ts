namespace SurveySays.Controllers {

    export class DesignController {
        public categories: SurveySays.Models.IQuestionCategory[];
        public questionTypes: SurveySays.Models.IQuestionType[];
        public question: SurveySays.Models.IQuestion;
        public survey: SurveySays.Models.ISurvey;
        public accordionArray = [];
        public status = { isFirstOpen: true, isFirstDisabled: false };
        public answerChoiceArray = ["", "", ""];
        public matrixOptionsArray = ["", "", ""];
        public questionType: string;
        public surveyId;

        constructor(private $scope: ng.IScope, private surveyService: SurveySays.Services.SurveyService, private questionService: SurveySays.Services.QuestionService, private questionCategoryService: SurveySays.Services.QuestionCategoryService, private questionTypeService: SurveySays.Services.QuestionTypeService, $stateParams: SurveySays.Models.IStateParams) {
            this.checkStateParams($stateParams['id']);
            this.getCategories();
            //this.survey = surveyService.getBasicSurvey($stateParams.surveyId);
            this.surveyId = $stateParams.surveyId;
        }

        //------MAIN DESIGN PAGE--------

        public checkStateParams(params) {
            if (params) {
                let stateParamNum = parseInt(params);
                if (isNaN(stateParamNum)) {
                    this.question = new SurveySays.Models.Question();
                    this.question.questionType = new SurveySays.Models.QuestionType();
                    this.question.questionType.type = params;
                }
                else {
                    this.getQuestion(params);
                }
            }
        }

        public getCategories() {
            this.categories = this.questionCategoryService.listCategories();
        }

        //public getTypes() {
        //    this.questionTypeService.listTypes().then((data) => {
        //        this.questionTypes = data;
        //    });
        //}

        public getQuestion(id: number) {
            this.questionService.getQuestion(id).then((data) => {
                this.question = data;
            });
        }

        public saveQuestion() {
            this.questionService.saveQuestion(this.survey.id, this.question);
        }

        public isLast(checkLast: boolean, index: number, type: string) {
            if (type == 'choice') {
                var arrayLength = this.answerChoiceArray.length;
                if (arrayLength > 1 && arrayLength < 6) {
                    if (checkLast) {
                        //if last, add one to the array
                        this.answerChoiceArray[index + 1] = "";
                    }
                }
            }
            if (type == 'option') {
                var arrayLength = this.matrixOptionsArray.length;
                if (arrayLength > 1 && arrayLength < 6) {
                    if (checkLast) {
                        //if last, add one to the array
                        this.matrixOptionsArray[index + 1] = "";
                    }
                }
            }
            //Reminder: Make sure to chop empty string off of array when saving to database. 
            // Also limit answer choices in matrix template to 6. Must have at least 1.
        }

        public addChoice(index: number, type: string) {
            if (type == 'choice') {
                var arrayLength = this.answerChoiceArray.length;
                if (arrayLength < 7) {
                    this.answerChoiceArray.splice(index + 1, 0, "");
                }
            }
            if (type == 'option') {
                var arrayLength = this.matrixOptionsArray.length;
                if (arrayLength < 7) {
                    this.matrixOptionsArray.splice(index + 1, 0, "");
                }
            }
        }


        public deleteChoice(index: number, type: string) {
            if (type == 'choice') {
                var arrayLength = this.answerChoiceArray.length;
                if (arrayLength > 1) {
                    this.answerChoiceArray.splice(index, 1);
                }
            }
            if (type == 'option') {
                var arrayLength = this.matrixOptionsArray.length;
                if (arrayLength > 1) {
                    this.matrixOptionsArray.splice(index, 1);
                }
            }
        }
    }

    angular.module("SurveySays").controller("designController", DesignController);
}