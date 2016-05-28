namespace SurveySays.Controllers {

    export class DesignController {
        public categories: SurveySays.Models.IQuestionCategory[];
        public questionTypes: SurveySays.Models.IQuestionType[];
        //public question: SurveySays.Models.IQuestion;
        public survey: SurveySays.Models.ISurvey;
        public question;
        public accordionArray = [];
        public status = { isFirstOpen: true, isFirstDisabled: false };
        public answerChoiceArray: string[] = [];

        constructor(public $scope: ng.IScope, private questionService: SurveySays.Services.QuestionService, private questionCategoryService: SurveySays.Services.QuestionCategoryService, private questionTypeService: SurveySays.Services.QuestionTypeService, $stateParams: ng.ui.IStateParamsService) {
            if ($stateParams['id']){
                this.getQuestion($stateParams['id']);
            }
            this.getCategories();
            this.getTypes();
        }

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

        //public value = '';
        //public hasBeenEditedBefore = false;
        //public unWatch = this.$scope.$watch("value", function () {
        //    if (this.value.length > 0) {
        //        this.hasBeenEditedBefore = true;
        //        this.$scope.unWatch();
        //    }
        //});

        public value = '';
        public hasBeenForTheFirstTime = false;
        public boolArray = [];
        public numChoices = [];

        public valueChanged() {
            this.hasBeenForTheFirstTime = true;
            console.log("isFired");
        };

        public isLast(checkLast:boolean, index:number) {
            
        }

        public fillAnswers() {
            let a = new SurveySays.Models.Answer();
            //first three to display but with no values
            //be able to detect when last index has value to add new
        }

    }
}