namespace SurveySays.Models {

    export interface ISurvey {
        id: number;
        surveyName: string;
        course: SurveySays.Models.ICourse;
    }
}