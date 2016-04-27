namespace SurveySays.Services {
    export class CourseService {
        private CourseResource;
        constructor($resource: ng.resource.IResourceService) {
            this.CourseResource = $resource('/api/courses/:id');
        }
        public listCourses() {
            return this.CourseResource.query();
        }
        public getCourse(id: number) {
            return this.CourseResource.get({ id: id }).$promise;
        }
        public saveCourse(course) {
            return this.CourseResource.save(course).$promise;
        }
        public deleteCourse(id: number) {
            return this.CourseResource.delete({ id: id }).$promise;
        }
    }
    angular.module('SurveySays').service('courseService', CourseService);
}