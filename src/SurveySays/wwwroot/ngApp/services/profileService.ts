namespace SurveySays.Services {
    export class ProfileService {
        private ProfileResource;
        constructor($resource: ng.resource.IResourceService) {
            this.ProfileResource = $resource('api/profiles/:userName');
        }
        public getProfile(userName: string) {
            return this.ProfileResource.get({ userName: userName }).$promise;
        }
    }
    angular.module('SurveySays').service('profileService', ProfileService);
}