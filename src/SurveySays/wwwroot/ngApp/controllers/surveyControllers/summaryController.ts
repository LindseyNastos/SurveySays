namespace SurveySays.Controllers {

    export class SummaryController {
        public status: string;
        public survey: SurveySays.Models.ISurvey;
        constructor(private surveyService: SurveySays.Services.SurveyService,
            $stateParams: ng.ui.IStateParamsService,
            public $state: ng.ui.IStateService)
        {
            this.surveyService.getBasicSurvey($stateParams['surveyId']).then((data) => {
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