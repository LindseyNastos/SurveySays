﻿namespace SurveySays.Models {

    export interface IQuestion {
        id: number;
        quest: string;
        answerRequired: boolean;
        questionType: SurveySays.Models.IQuestionType;
        answerOptions: IOption[];
        matrixQuestions: IOption[];
    }

    export class Question implements IQuestion {
        id: number;
        quest: string;
        answerRequired: boolean;
        questionType: SurveySays.Models.IQuestionType;
        answerOptions: IOption[];
        matrixQuestions: IOption[];
    }

}