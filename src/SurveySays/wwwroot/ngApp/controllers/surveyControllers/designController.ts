namespace SurveySays.Controllers {

    export class DesignController {
        public categories: SurveySays.Models.IQuestionCategory[];
        public questionTypes: SurveySays.Models.IQuestionType[];
        public question;
        public questionToAdd: SurveySays.Models.IQuestion;
        public questionToEdit: SurveySays.Models.IQuestion;
        public accordionArray = [];
        public status = {
            isFirstOpen: true,
            isFirstDisabled: false
        };

        constructor(private questionService: SurveySays.Services.QuestionService, private questionCategoryService: SurveySays.Services.QuestionCategoryService, private questionTypeService: SurveySays.Services.QuestionTypeService) {
            this.categories = questionCategoryService.listCategories();
            this.question = { questionType: { type: "TextBox" } };
            //questionService.getQuestion(1).then((data) => {
            //    this.question = data;
            //});
            questionTypeService.listTypes().then((data) => {
                this.questionTypes = data;
                this.addIcons();
            });
        }

        //public editQuestion() {
        //    this.questionService.saveQuestion(this.questionToEdit).then(() => {
                
        //    });
        //}

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