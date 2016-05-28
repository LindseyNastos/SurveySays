﻿namespace SurveySays.Models {
    export interface IQuestionType {
        id: number;
        type: string;
        icon: string;
    }

    export class QuestionType implements IQuestionType {
        id: number;
        type: string;
        icon: string;
    }
}