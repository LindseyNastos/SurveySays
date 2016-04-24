namespace SurveySays.Controllers {

    export class NewSurveyController {
        public survey: SurveySays.Models.ISurvey;
        public courses: number[];
        constructor(private surveyService: SurveySays.Services.SurveyService, $stateParams: ng.ui.IStateParamsService) {
            this.survey = this.surveyService.getSurvey($stateParams['id']);
        }
    }

}