namespace SurveySays.Controllers {

    export class EditSurveyController {
        public survey: SurveySays.Models.ISurvey;
        constructor(private surveyService: SurveySays.Services.SurveyService, $stateParams: ng.ui.IStateParamsService) {
            this.survey = this.surveyService.getSurvey($stateParams['id']);
        }
        public saveChanges(survey) {
            this.surveyService.saveSurvey(survey);
        }
    }

}