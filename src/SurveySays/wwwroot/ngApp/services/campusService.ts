namespace SurveySays.Services {

    export class CampusService {
        private CampusResource;
        constructor($resource: ng.resource.IResourceService) {
            this.CampusResource = $resource('/api/campuses/:id');
        }

        public listCampuses() {
            return this.CampusResource.query();
        }

        public getCampus(id: number) {
            return this.CampusResource.get({ id: id }).$promise;
        }

        public saveCampus(campus) {
            return this.CampusResource.save(campus).$promise;
        }

        public deleteCampus(id: number) {
            return this.CampusResource.delete({ id: id }).$promise;
        }
    }
    angular.module("SurveySays").service("campusService", CampusService);

}