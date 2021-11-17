import { Room } from "./room";

export interface Service {
    id: number;
    sDesc: string;
    serviceDate: Date;
    checkIn: Date;
    totalPersons: number;
    bookingDays: number;
    advance: number;
    amount: number;
    room: Room;
}