namespace SurveySays.Models {
    
    export interface ISurveyToTake {
        id: number;
        firstName: string;
        lastName: string;
        anonymous: boolean;
        dateTaken: string;
        troopNum: number;
        course: ICourse;
        survey: ISurvey;
        answers: IAnswer[];
    }

    export class SurveyToTake implements ISurveyToTake {
        id: number;
        firstName: string;
        lastName: string;
        anonymous: boolean;
        dateTaken: string;
        troopNum: number;
        course: ICourse;
        survey: ISurvey;
        answers: IAnswer[];
    }

}