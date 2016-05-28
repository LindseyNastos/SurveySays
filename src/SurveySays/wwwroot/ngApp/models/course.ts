namespace SurveySays.Models {

    export interface ICourse {
        id: number;
        name: string;
    }

    export class Course implements ICourse {
        id: number;
        name: string;
    }

}