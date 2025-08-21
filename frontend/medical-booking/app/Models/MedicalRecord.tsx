export interface MedicalRecord {
    id: string;
    patientId: string;
    //doctorId: string;
    doctorUserName: string;
    //timeslotId: string;
    //bookingid: string;
    //appointmentid: string;
    symptoms: string;
    diagnosis: string;
    prescribedTreatment: string;
    visualExamination: string;
    referralTests: string;
    finalCost: string;
    timeslotDatetimeStart: string;
}


