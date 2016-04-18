namespace SurveySays.Models {
    
    export interface ISurveyToTake {
        id: number;
        firstName: string;
        lastName: string;
        anonymous: boolean;
        course: number;
        survey: ISurvey;
    }
}