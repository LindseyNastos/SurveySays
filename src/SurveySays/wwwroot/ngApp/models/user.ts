namespace SurveySays.Models {

    export interface IUser {
        firstName: string;
        lastName: string;
        email: string;
        courseTaught: SurveySays.Models.ICourse;
        location: SurveySays.Models.ICampus;
        surveys: ISurvey[];
    }
}