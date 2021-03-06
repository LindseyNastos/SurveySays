﻿namespace SurveySays.Controllers {

    export class EditSurveyController {
        public survey: SurveySays.Models.ISurvey;
        public isActive: boolean;
        constructor(private $scope: ng.IScope, private surveyService: SurveySays.Services.SurveyService, private $stateParams: ng.ui.IStateParamsService) {
            this.getSurvey();
            $scope.$applyAsync(this.removeActive);
        }

        public getSurvey() {
            this.surveyService.getBasicSurvey(this.$stateParams['surveyId']).then((data) => {
                this.survey = data;
            });
        }

        public saveChanges(survey) {
            this.surveyService.saveSurvey(survey);
        }

        public removeActive() {
            let defaultTab = <HTMLLIElement>document.getElementById('analyze-tab');
            defaultTab.classList.remove("active");
        }
    }
}