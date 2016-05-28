namespace SurveySays.Models {

    export interface IAnswer {
        id: number;
        ans: string;
        value: number;
        questionId: number;
    }

    export class Answer implements IAnswer {
        id: number;
        ans: string;
        value: number;
        questionId: number;
    }
}