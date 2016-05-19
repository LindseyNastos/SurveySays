namespace SurveySays.Controllers {

    export class SummaryController {
        public status: string;
        public survey: SurveySays.Models.ISurvey;
        constructor(private surveyService: SurveySays.Services.SurveyService, $stateParams: ng.ui.IStateParamsService, public $state: ng.ui.IStateService) {
            this.surveyService.getBasicSurvey($stateParams['id']).then((data) => {
                this.survey = data;
                this.checkStatus(this.survey.released);
            });
            this.changeActiveTab();
        }
        public checkStatus(status: boolean) {
            if (status == true) {
                this.status = "Released";
            }
            else {
                this.status = "Draft";
            }
        }
        public changeActiveTab() {
            if (this.$state.is("editSurvey.summary")) {
                let elem = document.getElementById("");
            }
        }
    }
}