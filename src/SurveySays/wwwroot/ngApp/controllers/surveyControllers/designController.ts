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
            this.questionTypes = questionTypeService.listTypes();
        }
    }
}