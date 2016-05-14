namespace SurveySays.Models {

    export interface IQuestionCategory {
        id: number;
        name: string;
        qualifier: string;
        questions: SurveySays.Models.IQuestion[];
    }

}