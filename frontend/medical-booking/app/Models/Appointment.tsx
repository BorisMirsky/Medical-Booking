export interface Appointment {
    id: string;
    patientId: string;
    doctorId: string;
    timeslotId: string;
    bookingId: string;
    patientUserName: string;
    doctorUserName: string,
    doctorSpeciality: string,
    timeslotDatetimeStart: string;
    timeslotDatetimeStop: string;
    //patientcame: string;
    //patientislate: string;
    //patientunacceptablebehavior: string;
}

