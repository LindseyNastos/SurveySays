namespace SurveySays.Services {
    export class ProfileService {
        private ProfileResource;
        constructor($resource: ng.resource.IResourceService) {
            this.ProfileResource = $resource('/api/profiles/:userId');
        }
        public getProfile(userId: string) {
            
            return this.ProfileResource.get({ userId: userId }).$promise;
        }
    }
    angular.module('SurveySays').service('profileService', ProfileService);
}