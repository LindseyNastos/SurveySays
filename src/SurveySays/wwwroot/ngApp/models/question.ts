namespace SurveySays.Models {

    export interface IQuestion {
        id: number;
        quest: string;
        questionType: SurveySays.Models.IQuestionType;
        answerOptions: IAnswer[];
        matrixQuestions: IOption[];
    }
}