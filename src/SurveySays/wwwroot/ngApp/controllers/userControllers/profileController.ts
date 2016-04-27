namespace SurveySays.Controllers {

    export class ProfileController {
        public instructor: SurveySays.Models.IUser;
        public surveys: SurveySays.Models.ISurvey[];
        constructor(private profileService: SurveySays.Services.ProfileService, $stateParams: ng.ui.IStateParamsService) {
            this.profileService.getProfile($stateParams['userId']).then((data) => {
                this.instructor = data;
                this.surveys = data.surveys;
                console.log($stateParams['userId']);
            });
        }
    }

}