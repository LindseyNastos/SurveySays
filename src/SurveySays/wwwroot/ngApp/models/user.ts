namespace SurveySays.Models {

    export interface IUser {
        firstName: string;
        lastName: string;
        email: string;
        courseTaught: number;
        location: number;
        surveys: ISurvey[];
    }
}