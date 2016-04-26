namespace SurveySays.Controllers {

    export class NewSurveyController {
        public survey: SurveySays.Models.ISurvey;
        public courses: SurveySays.Models.ICourse[];
        constructor(
            private surveyService: SurveySays.Services.SurveyService,
            private courseService: SurveySays.Services.CourseService
        ) {
            this.courses = this.courseService.listCourses();
        }

        public saveNewSurvey(survey): void {
            this.surveyService.saveSurvey(survey);
            //then redirect to editSurvey
        }
    }

}