namespace SurveySays.Models {

    export interface IQuestionCategory {
        id: number;
        name: string;
        qualifier: string;
        questions: IQuestion[];
    }

    export class QuestionCategory implements IQuestionCategory {
        id: number;
        name: string;
        qualifier: string;
        questions: IQuestion[];
    }

}