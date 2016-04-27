namespace SurveySays.Models {
    
    export interface ISurveyToTake {
        id: number;
        firstName: string;
        lastName: string;
        anonymous: boolean;
        dateTaken: string;
        troopNum: number;
        course: SurveySays.Models.ICourse;
        survey: ISurvey;
    }
}