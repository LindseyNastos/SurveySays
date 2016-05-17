namespace SurveySays.Models {

    export interface ISurvey {
        id: number;
        surveyName: string;
        dateCreated: any;
        numResponses: number;
        numQuestions: number;
        released: boolean;
        course: ICourse;
    }
}