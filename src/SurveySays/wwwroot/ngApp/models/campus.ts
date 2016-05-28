namespace SurveySays.Models {

    export interface ICampus {
        id: number;
        location: string;
    }

    export class Campus implements ICampus {
        id: number;
        location: string;
    }
}