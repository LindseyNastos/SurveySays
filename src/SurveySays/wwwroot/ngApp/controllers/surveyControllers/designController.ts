namespace SurveySays.Controllers {

    export class DesignController {
        public categories: SurveySays.Models.IQuestionCategory[];
        public questionTypes: SurveySays.Models.IQuestionType[];
        public accordionArray = [];
        public status = {
            isFirstOpen: true,
            isFirstDisabled: false
        };

        constructor(private questionCategoryService: SurveySays.Services.QuestionCategoryService, private questionTypeService: SurveySays.Services.QuestionTypeService) {
            this.categories = questionCategoryService.listCategories();
            questionTypeService.listTypes().then((data) => {
                this.questionTypes = data;
                this.addIcons();
            });
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