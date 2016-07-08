namespace SurveySays.Controllers {

    export class PreviewController {
        public survey: SurveySays.Models.ISurvey;
        public questions: any = [];
        constructor(private surveyService: SurveySays.Services.SurveyService, $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {
            surveyService.getFullSurvey($stateParams['surveyId']).then((data) => {
                this.survey = data.survey;
                this.questions = data.questions;
            });
        }
        public edit(id: number) {
            this.$state.go("editSurvey.design", { id: id });
        }
    }

}