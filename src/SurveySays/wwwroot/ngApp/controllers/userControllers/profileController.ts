namespace SurveySays.Controllers {

    export class ProfileController {
        public instructor: SurveySays.Models.IUser;
        public surveys: SurveySays.Models.ISurvey[];
        constructor(private profileService: SurveySays.Services.ProfileService) {
            this.profileService.getProfile("lindsey.nastos@codercamps.com").then((data) => {
                this.instructor = data;
                this.surveys = data.surveys;
            });
        }
    }

}