﻿///* eslint-disable @typescript-eslint/no-explicit-any */
///* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import {
    getBookingsByDoctor
    //updateTimeslot, TimeSlotUpdateRequest,
    //BookingCreateRequest, createBooking
} from "@/app/Services/service";
import { Booking } from "@/app/Models/Booking";
import { Table, Button } from "antd";
import { useEffect, useState } from "react";
import "../globals.css";
//import Title from "antd/es/typography/Title";
//import moment from 'moment';





export default function DoctorCreateAppointment() {
    //const [currentRole, setCurrentRole] = useState("");
    const [bookings, setBookings] = useState<Booking[]>([]);


    const columns = [
        {
            title: 'N',
            dataIndex: 'n',
            key: 'n',
        },
        {
            title: 'Пациент',
            dataIndex: 'username',
            key: 'username',
        },
        {
            title: 'Начало приёма',
            dataIndex: 'timeslotStart',
            key: 'timeslotStart',
        },
        {
            title: 'Конец приёма',
            dataIndex: 'timeslotStop',
            key: 'timeslotStop',
        },
        {
            title: 'Создать "Приём пациента"',
            dataIndex: 'cancel',
            key: 'cancel',
            render: (text: string, record: object) => (
                <Button
                    onClick={() => createAppointment(record['key' as keyof typeof record])}
                    //disabled={!bookings[record['key' as keyof typeof record]].isBooked}
                >
                    {"Создать"}
                </Button>
            ),
        }
    ]


    useEffect(() => {
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
        setBookings([]);
        const getBookings = async () => {
            const responce = await getBookingsByDoctor("835A9D1F-9A58-487B-A419-8D33556B20FA");
            setBookings(responce);
        }
        getBookings();
    }, []);

    const data = bookings.map((booking: Booking, index: number) => ({
        key: index,
        n: (index + 1),
        username: booking.patientId,
        timeslotStart: booking.timeslotDatetimeStart,
        timeslotStop: booking.timeslotDatetimeStop,
        create: ""
    }));


    //const timeslotRequest: TimeSlotUpdateRequest = {
    //    patientid: '',
    //    slotid: '',
    //    isbooked: false
    //};


    //const bookingRequest: BookingCreateRequest = {
    //    slotid: "",
    //    patientid: "",
    //    doctorid: "",
    //    doctorusername: "",
    //    isbooked: false,
    //};


    const createAppointment = (key: number) => {
        console.log('createAppointment ', bookings[key]);
    }



    return (
        <div>
            <br></br>
            <h2>Мои бронирования</h2>
            <div>
                <br></br><br></br>
                <Table
                    dataSource={data}
                    columns={columns}
                    pagination={false}
                    footer={() => ""}
                    bordered
                />
            </div>
        </div>
    );
}



