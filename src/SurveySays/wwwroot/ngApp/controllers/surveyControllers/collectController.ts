namespace SurveySays.Controllers {

    export class CollectController {
        public courses: SurveySays.Models.ICourse[];
        constructor(private courseService: SurveySays.Services.CourseService) {
            this.courses = courseService.listCourses();
        }
    }
}