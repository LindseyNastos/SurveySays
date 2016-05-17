namespace SurveySays.Controllers {

    export class PreviewController {
        public survey: SurveySays.Models.ISurvey;
        public questions: any = [];
        constructor(private surveyService: SurveySays.Services.SurveyService, $stateParams: ng.ui.IStateParamsService) {
            surveyService.getFullSurvey($stateParams['id']).then((data) => {
                this.survey = data.survey;
                this.questions = data.questions;
            });

        }
    }

}