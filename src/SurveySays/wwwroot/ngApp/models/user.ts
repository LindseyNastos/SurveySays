namespace SurveySays.Models {

    export interface IUser {
        firstName: string;
        lastName: string;
        email: string;
        courseTaught: ICourse;
        location: ICampus;
        surveys: ISurvey[];
    }
}