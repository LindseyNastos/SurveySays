namespace SurveySays.Providers {

    export class ActiveTabProvider {
        public changeActiveTab() {
            if (this.$state.is("editSurvey.summary")) {
                console.log('sum sum');
                let elem = <HTMLLIElement>document.getElementById("summary-tab");
                elem.setAttribute("active", "active");
            }
            else if (this.$state.is("editSurvey.design")) {
                let elem = <HTMLLIElement>document.getElementById("design-tab");
                elem.setAttribute("active", "active");
            }
            else if (this.$state.is("editSurvey.preview")) {
                let elem = <HTMLLIElement>document.getElementById("preview-tab");
                elem.setAttribute("active", "active");
            }
            else if (this.$state.is("editSurvey.collect")) {
                let elem = <HTMLLIElement>document.getElementById("collect-tab");
                elem.setAttribute("active", "active");
            }
            else if (this.$state.is("editSurvey.analyze")) {
                let elem = <HTMLLIElement>document.getElementById("analyze-tab");
                elem.setAttribute("active", "active");
            }
        }
        constructor(public $state: ng.ui.IStateService) { }
    }
    angular.module("SurveySays").service('activeTabProvider', ActiveTabProvider);
}