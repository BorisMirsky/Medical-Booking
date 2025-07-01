export interface Booking {
    id: string;
    patientId: string;
    doctorId: string;
    //doctorName: string;
    slotId: string;
    isBooked: boolean;
}