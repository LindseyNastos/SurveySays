namespace SurveySays.Controllers {

    export class SummaryController {
        public status: string;
        public survey: SurveySays.Models.ISurvey;
        constructor(private surveyService: SurveySays.Services.SurveyService, $stateParams: ng.ui.IStateParamsService) {
            this.surveyService.getBasicSurvey($stateParams['id']).then((data) => {
                this.survey = data;
                this.checkStatus(this.survey.released);
            });
        }
        public checkStatus(status: boolean) {
            if (status == true) {
                this.status = "Released";
            }
            else {
                this.status = "Draft";
            }
        }
    }
}