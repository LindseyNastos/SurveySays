namespace SurveySays.Models {

    export interface IQuestion {
        id: number;
        quest: string;
        questionType: number;
        answerOptions: IAnswer[];
        matrixQuestions: IOption[];
    }
}