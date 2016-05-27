namespace SurveySays.Controllers {

    export class DesignController {
        public categories: SurveySays.Models.IQuestionCategory[];
        public questionTypes: SurveySays.Models.IQuestionType[];
        //public question: SurveySays.Models.IQuestion;
        public survey: SurveySays.Models.ISurvey;
        public question;
        public accordionArray = [];
        public status = {
            isFirstOpen: true,
            isFirstDisabled: false
        };

        constructor(private questionService: SurveySays.Services.QuestionService, private questionCategoryService: SurveySays.Services.QuestionCategoryService, private questionTypeService: SurveySays.Services.QuestionTypeService, $stateParams: ng.ui.IStateParamsService) {
            this.categories = questionCategoryService.listCategories();
            //this.question = { questionType: { type: "TextBox" } };

            if ($stateParams['id']){
                this.getQuestion($stateParams['id']);
            }

            this.getTypes();
            
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

    }
}