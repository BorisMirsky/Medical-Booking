export interface Booking {
    id: string;
    patientId: string;
    doctorId: string;
    slotId: string;
    isBooked: boolean;
}