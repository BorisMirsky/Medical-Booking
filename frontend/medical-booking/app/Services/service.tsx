//import ModalComponent from '../Components/ModalComponent';
//import { useState } from 'react';


export interface OrderRequest {
    cityFrom: string;
    adressFrom: string;
    cityTo: string;
    adressTo: string;
    weight: number,
    date: Date,
    specialNote?: string
}


export interface UserRegistrationRequest {
    email: string;
    password: string;
    username: string;
    role: string;
}


export interface UserLoginRequest {
    email: string;
    password: string;
}


//FilterInterface URLSearchParams
export interface FilterInterface {
    search: string;
    sortItem: string;
    sortOrder: string;
}


export interface CurrentUser {
    id: string;
    username: string;
    role: string;
    isactive: boolean;
    token: string;
    password: string;
}
