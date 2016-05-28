namespace SurveySays.Models {

    export interface ISurvey {
        id: number;
        surveyName: string;
        userId: string;
        dateCreated: any; //datetime
        lastModified: any; //datetime
        numResponses: number;
        numUnseenResponses: number;
        numQuestions: number;
        released: boolean;
        currentTroop: number;
        course: ICourse;
    }

    export class Survey implements ISurvey {
        id: number;
        surveyName: string;
        userId: string;
        dateCreated: any; //datetime
        lastModified: any; //datetime
        numResponses: number;
        numUnseenResponses: number;
        numQuestions: number;
        released: boolean;
        currentTroop: number;
        course: ICourse;
    }

}