namespace SurveySays.Models {

    export interface ISurvey {
        id: number;
        surveyName: string;
        dateCreated: string;
        numResponses: number;
        course: ICourse;
    }
}