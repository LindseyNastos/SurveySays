namespace SurveySays.Controllers {

    export class PreviewController {
        public survey: SurveySays.Models.ISurvey;
        public questions: any = [];
        constructor(private surveyService: SurveySays.Services.SurveyService, $stateParams: ng.ui.IStateParamsService) {
            surveyService.getFullSurvey($stateParams['id']).then((data) => {
                this.survey = data.survey;
                this.questions = data.questions;
                for (let q of this.questions) {
                    this.addHtml(q);
                };
            });
        }

        public addHtml(question: SurveySays.Models.IQuestion) {
            //let htmlAnswers = [];
            debugger;
            if (question.questionType.type == "TextBox") {
                //htmlAnswers.push('<input class="form-control" type="text" name="{{question.id}}" /><br />');
                let x = <HTMLElement>document.getElementById((question.id).toString());
                x.innerHTML = '<input class="form-control" type="text" name="{{question.id}}" /><br />';
            }
            else if (question.questionType.type == "Multiple Choice") {
                //for (let a of question.answerOptions) {
                //    htmlAnswers.push('<div ng-repeat="answer in question.answerOptions"><input type="radio" name="{{question.id}}" value="{{answer.id}}" />{{answer.opt}}<br /></div>');
                //}
                for (let a of question.answerOptions) {
                    let x = <HTMLElement>document.getElementById((question.id).toString());
                    x.innerHTML = '<div ng-repeat="answer in question.answerOptions"><input type="radio" name="{{question.id}}" value="{{answer.id}}" />{{answer.opt}}<br /></div>';
                }
            }
            else if (question.questionType.type == "Ranking") {
                //htmlAnswers.push('<div ng-repeat="answer in question.answerOptions"><input type="number" name="{{question.id}}" />{{answer.opt}}<br /></div>');
                let x = <HTMLElement>document.getElementById((question.id).toString());
                x.innerHTML = '<div ng-repeat="answer in question.answerOptions"><input type="number" name="{{question.id}}" />{{answer.opt}}<br /></div>';

            }
            else if (question.questionType.type == "Dropdown List") {
                //htmlAnswers.push('<select class="form-control"><option value="{{answer.id}}" ng-repeat="answer in question.answerOptions">{{answer.opt}}</option></select>');
                let x = <HTMLElement>document.getElementById((question.id).toString());
                x.innerHTML = '<select class="form-control"><option value="{{answer.id}}" ng-repeat="answer in question.answerOptions">{{answer.opt}}</option></select>';
            }
            else if (question.questionType.type == "Matrix Rating") {
                //htmlAnswers.push('');
                console.log("Matrix Questions: " + question.matrixQuestions);
                console.log("Matrix Answers: " + question.answerOptions);
            }
            else {
                console.log("Error: HTML answer type generator has failed.");
            }
            //return htmlAnswers;
        }

    }

}