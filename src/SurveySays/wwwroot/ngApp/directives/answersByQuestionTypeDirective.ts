namespace SurveySays.Directives {

    class QuestionTypeDirective implements ng.IDirective {
        public restrict: 'E';
        public scope = { question: '=surveyQuestion' };
        public link = (scope: any, element: ng.IAugmentedJQuery, attrs: ng.IAttributes, ctrl: any) => {
            let answerTemplate = this.checkType(scope.question);
            this.$templateRequest(answerTemplate).then((html) => {
                // Convert template to actual html
                let template = angular.element(html);
                // Append it to the directive element
                element.append(template);
                // And let Angular $compile it
                this.$compile(template)(scope);
            });
        }

        constructor(public $compile: ng.ICompileService, public $templateRequest: ng.ITemplateRequestService) {

        }

        public static Factory() {
            var directive = function ($compile, $templateRequest) {
                return new QuestionTypeDirective($compile, $templateRequest);
            };
            return directive;
        }

        public checkType(question: SurveySays.Models.IQuestion): string {
            let answerTemplate: string;
            if (question.questionType.type == "TextBox") {
                answerTemplate = '/ngApp/views/questionTemplates/textbox.html';
            }
            else if (question.questionType.type == "Multiple Choice") {
                for (let a of question.answerOptions) {
                    answerTemplate = '/ngApp/views/questionTemplates/multipleChoice.html';
                }
            }
            else if (question.questionType.type == "Ranking") {
                answerTemplate = '/ngApp/views/questionTemplates/ranking.html';
            }
            else if (question.questionType.type == "Dropdown List") {
                answerTemplate = '/ngApp/views/questionTemplates/dropdownList.html';
            }
            else if (question.questionType.type == "Matrix Rating") {
                answerTemplate = '/ngApp/views/questionTemplates/matrixRating.html';
            }
            else {
                console.log("Error: HTML answer type generator has failed.");
            }
            return answerTemplate;
        }
    }
    angular.module("SurveySays").directive('questionTypeDirective', QuestionTypeDirective.Factory());
}




//--------------JavaScript Version-------------------

    //angular.module("SurveySays").directive('questionTypeDirective', function ($compile, $templateRequest) {
    //    function checkType(question: SurveySays.Models.IQuestion) {
    //        let answerTemplate: string;
    //        if (question.questionType.type == "TextBox") {
    //            answerTemplate = '/ngApp/views/questionTemplates/textbox.html';
    //        }
    //        else if (question.questionType.type == "Multiple Choice") {
    //            for (let a of question.answerOptions) {
    //                answerTemplate = '/ngApp/views/questionTemplates/multipleChoice.html';
    //            }
    //        }
    //        else if (question.questionType.type == "Ranking") {
    //            answerTemplate = '/ngApp/views/questionTemplates/ranking.html';

    //        }
    //        else if (question.questionType.type == "Dropdown List") {
    //            answerTemplate = '/ngApp/views/questionTemplates/dropdownList.html';
    //        }
    //        else if (question.questionType.type == "Matrix Rating") {
    //            answerTemplate = '/ngApp/views/questionTemplates/matrixRating.html';
    //        }
    //        else {
    //            console.log("Error: HTML answer type generator has failed.");
    //        }
    //        return answerTemplate;
    //    }

    //    return {
    //        restrict: 'E',
    //        scope: {
    //            question: '=surveyQuestion'
    //        },
    //        link: function (scope: any, element, attrs) {
    //            var answerTemplate = checkType(scope.question);
    //            $templateRequest(answerTemplate).then(function (html) {
    //                // Convert template to actual html
    //                var template = angular.element(html);
    //                // Append it to the directive element
    //                element.append(template);
    //                // And let Angular $compile it
    //                $compile(template)(scope);
    //            });
    //        },
    //    };
    //});

