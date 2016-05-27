namespace SurveySays.Directives {

    class QuestionTypeDirective implements ng.IDirective {
        public restrict: 'E';
        public scope = { question: '=surveyQuestion', pageView: '@' };
        public link = (scope: any, element: ng.IAugmentedJQuery, attrs: ng.IAttributes, ctrl: any) => {
            let answerTemplate = this.checkType(scope.question, scope.pageView);
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

        public checkType(question:SurveySays.Models.IQuestion, view: string): string {
            let answerTemplate: string;
            if (view === 'design'){
                if (question.questionType.type == "TextBox") {
                    answerTemplate = '/ngApp/views/createTemplates/textbox.html';
                }
                else if (question.questionType.type == "Multiple Choice") {
                    answerTemplate = '/ngApp/views/createTemplates/multipleChoice.html';
                }
                else if (question.questionType.type == "Ranking") {
                    answerTemplate = '/ngApp/views/createTemplates/ranking.html';
                }
                else if (question.questionType.type == "Dropdown List") {
                    answerTemplate = '/ngApp/views/createTemplates/dropdownList.html';
                }
                else if (question.questionType.type == "Matrix Rating") {
                    answerTemplate = '/ngApp/views/createTemplates/matrixRating.html';
                }
                else {
                    console.log("Error: HTML design answer types have failed (question-type-directive).");
                }
            }
            else if (view === 'preview'){
                if (question.questionType.type == "TextBox") {
                    answerTemplate = '/ngApp/views/questionTemplates/textbox.html';
                }
                else if (question.questionType.type == "Multiple Choice") {
                    answerTemplate = '/ngApp/views/questionTemplates/multipleChoice.html';
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
                    console.log("Error: HTML preview answer types have failed (question-type-directive).");
                }
            }
            else {
                console.log("Error: Question type directive has failed.");
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

