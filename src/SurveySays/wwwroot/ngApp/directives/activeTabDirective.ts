namespace SurveySays.Directives {

    class ActiveTabDirective implements ng.IDirective {
        public restrict: 'A';
        public scope = true;
        public link = (scope: any, element: ng.IAugmentedJQuery, attrs: ng.IAttributes, ctrl: any) => {
            this.changeActiveTab(scope.value);
            
        }

        constructor(public $state: ng.ui.IStateService) { }

        public static Factory() {
            var directive = function ($state) {
                return new ActiveTabDirective($state);
            };
            return directive;
        }

        public changeActiveTab(state) {
            if (this.$state.is("editSurvey.summary")) {
                console.log("sum page");
                //let elem = document.getElementById("summary-tab");
                //elem.setActive;
                //or maybe
                //attrs.$set('active', 'active');
            }
            else if (this.$state.is("editSurvey.design")) {
                console.log("des page");
                //let elem = document.getElementById("summary-tab");
                //elem.setActive;
            }
            //else {
            //    console.log("not working");
            //}
        }

    }
    angular.module("SurveySays").directive('activeTabDirective', ActiveTabDirective.Factory());
}