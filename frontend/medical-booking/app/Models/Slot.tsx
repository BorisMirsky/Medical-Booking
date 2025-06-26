
export interface Slot {
    //[x: string]: number;
    id: string;
    datetimeStart: string;
    datetimeStop: string;
    doctorId: string;
    isBooked: number;
    patientId: string;
}


export interface SlotObject {
    [x: string]: any;
    id: string;
    datetimeStart: string;
    datetimeStop: string;
    doctorId: string;
    isBooked: number;
    patientId: string;
}