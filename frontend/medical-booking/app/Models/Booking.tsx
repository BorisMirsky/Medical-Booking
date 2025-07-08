export interface Booking {
    id: string;
    isBooked: boolean;
    patientId: string;
    doctorId: string;
    timeslotId: string;
    doctorSpeciality: string;
    doctorUserName: string;
    timeslotDatetimeStart: string;
    timeslotDatetimeStop: string;
}
