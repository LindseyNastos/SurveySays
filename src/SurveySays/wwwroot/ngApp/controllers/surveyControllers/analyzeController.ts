namespace SurveySays.Controllers {

    export class AnalyzeController {
        public survey: SurveySays.Models.ISurvey;
        constructor(private surveyService: SurveySays.Services.SurveyService, $stateParams: ng.ui.IStateParamsService) {
            this.survey = surveyService.getBasicSurvey($stateParams['id']);
        }
    }
}