namespace SurveySays.Controllers {

    export class EditSurveyController {
        public survey: SurveySays.Models.ISurvey;
        public isActive: boolean;
        constructor(private surveyService: SurveySays.Services.SurveyService, $stateParams: ng.ui.IStateParamsService) {
            this.survey = this.surveyService.getBasicSurvey($stateParams['id']);
            this.removeActive();

        }
        public saveChanges(survey) {
            this.surveyService.saveSurvey(survey);
        }
        public removeActive() {
            setTimeout(() => {
                let defaultTab = <HTMLLIElement>document.getElementById('analyze-tab');
                defaultTab.classList.remove("active");
            }, 1);
        }
    }
}