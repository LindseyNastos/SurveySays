namespace SurveySays.Services {
    export class QuestionCategoryService {
        private CategoryResource;
        constructor($resource: ng.resource.IResourceService) {
            this.CategoryResource = $resource('/api/questionCategories/:id', null, {
                getQuestions: {
                    method: 'GET',
                    url: '/api/questionCategories/getQuestions/:vm',
                    isArray: true
                }
            });
        }
        public listCategories() {
            return this.CategoryResource.query();
        }
        public getQuestionsByCategory(categoryId: number, surveyId: number) {
            let vm: any = {};
            vm.categoryId = categoryId;
            vm.surveyId = surveyId;
            return this.CategoryResource.getQuestions(vm).$promise;
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