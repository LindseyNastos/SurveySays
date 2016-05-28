namespace SurveySays.Models {

    export interface IOption {
        id: number;
        opt: string;
    }

    export class Option implements IOption {
        id: number;
        opt: string;
    }
}