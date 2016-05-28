namespace SurveySays.Models {

    export interface IUser {
        id: string;
        firstName: string;
        lastName: string;
        email: string;
        courseTaught: ICourse;
        location: ICampus;
        surveys: ISurvey[];
    }

    export class User implements IUser {
        id: string;
        firstName: string;
        lastName: string;
        email: string;
        courseTaught: ICourse;
        location: ICampus;
        surveys: ISurvey[];
    }

}