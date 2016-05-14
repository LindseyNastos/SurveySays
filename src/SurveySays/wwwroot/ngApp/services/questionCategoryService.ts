namespace SurveySays.Services {
    export class QuestionCategoryService {
        private CategoryResource;
        constructor($resource: ng.resource.IResourceService) {
            this.CategoryResource = $resource('/api/questionCategories/:id');
        }
        public listCategories() {
            return this.CategoryResource.query();
        }
        public getCategory(id: number) {
            return this.CategoryResource.get({ id: id }).$promise;
        }
        public saveCategory(category) {
            return this.CategoryResource.save(category).$promise;
        }
        public deleteCategory(id: number) {
            return this.CategoryResource.delete({ id: id }).$promise;
        }
    }
    angular.module('SurveySays').service('questionCategoryService', QuestionCategoryService);
}