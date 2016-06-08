namespace SurveySays.Controllers {

    export class DesignController {
        public categories: SurveySays.Models.IQuestionCategory[];
        public questionTypes: SurveySays.Models.IQuestionType[];
        public question: SurveySays.Models.IQuestion;
        public survey: SurveySays.Models.ISurvey;
        //public question;
        public accordionArray = [];
        public status = { isFirstOpen: true, isFirstDisabled: false };
        public answerChoiceArray = ["", "", ""];
        public matrixOptionsArray = ["", "", ""];

        constructor(public $scope: ng.IScope, private questionService: SurveySays.Services.QuestionService, private questionCategoryService: SurveySays.Services.QuestionCategoryService, private questionTypeService: SurveySays.Services.QuestionTypeService, $stateParams: ng.ui.IStateParamsService) {
            if ($stateParams['id']) {
                this.getQuestion($stateParams['id']);
            }
            this.getCategories();
            this.getTypes();
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
            console.log('yo');
            if (type == 'choice') {
                if (checkLast) {
                    //if last, add one to the array
                    this.answerChoiceArray[index + 1] = "";
                }
            }
            if (type == 'option') {
                if (checkLast) {
                    //if last, add one to the array
                    this.matrixOptionsArray[index + 1] = "";
                }
            }
            //Reminder: Make sure to chop empty string off of array when saving to database. Also limit answer choices in matrix template to 6.
        }

        public addChoice(index: number, type: string) {
            console.log(type);
            if (type == 'choice') {
                this.answerChoiceArray.splice(index + 1, 0, "");
            }
            if (type == 'option') {
                this.matrixOptionsArray.splice(index + 1, 0, "");
            }
        }

        public deleteChoice(index: number, type: string) {
            if (type == 'choice') {
                this.answerChoiceArray.splice(index, 1);
            }
            if (type == 'option') {
                this.matrixOptionsArray.splice(index, 1);
            }
        }

    }
    angular.module("SurveySays").controller("designController", DesignController);
}