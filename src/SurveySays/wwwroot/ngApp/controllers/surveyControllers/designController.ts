﻿namespace SurveySays.Controllers {

    export class DesignController {
        public categories: SurveySays.Models.IQuestionCategory[];
        public questionTypes: SurveySays.Models.IQuestionType[];
        public question: SurveySays.Models.IQuestion;
        public survey: SurveySays.Models.ISurvey;
        public accordionArray = [];
        public status = { isFirstOpen: true, isFirstDisabled: false };
        public answerChoiceArray = ["", "", ""];
        public matrixOptionsArray = ["", "", ""];

        constructor(private $scope: ng.IScope, private questionService: SurveySays.Services.QuestionService, private questionCategoryService: SurveySays.Services.QuestionCategoryService, private questionTypeService: SurveySays.Services.QuestionTypeService, $stateParams: ng.ui.IStateParamsService) {
            if ($stateParams['id']) {
                this.getQuestion($stateParams['id']);
            }
            this.getCategories();
            this.getTypes();
            //$scope.$applyAsync(this.addIcons);
        }

        //------MAIN DESIGN PAGE--------

        public getCategories() {
            this.categories = this.questionCategoryService.listCategories();
        }

        public getTypes() {
            this.questionTypeService.listTypes().then((data) => {
                this.questionTypes = data;
                this.addIcons();
            });
        }

        public getQuestion(id: number) {
            this.questionService.getQuestion(id).then((data) => {
                this.question = data;
            });
        }

        public saveQuestion() {
            this.questionService.saveQuestion(this.survey.id, this.question);
        }

        public addIcons() {
            setTimeout(() => {
                for (var q of this.questionTypes) {
                    let id = (q.id).toString();
                    let elem = <HTMLSpanElement>document.getElementById(id);
                    elem.innerHTML = q.icon;
                }
            }, 1);
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