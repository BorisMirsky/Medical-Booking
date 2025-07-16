///* eslint-disable @typescript-eslint/no-explicit-any */
///* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import {
    getBookingsByPatient,
    updateTimeslot, TimeSlotUpdateRequest,
    BookingCreateRequest, createBooking
} from "@/app/Services/service";
import { Booking } from "@/app/Models/Booking";
import { Table, Button } from "antd";
import { useEffect, useState } from "react";  
import "../globals.css";
//import Title from "antd/es/typography/Title";
//import moment from 'moment';





export default function PatientBookings() {
    //const [currentRole, setCurrentRole] = useState("");
    const [bookings, setBookings] = useState<Booking[]>([]);


    const columns = [
        {
            title: 'N',
            dataIndex: 'n',
            key: 'n',
        },
        {
            title: 'Врач',
            dataIndex: 'username',
            key: 'username',
        },
        {
            title: 'Специальность',
            dataIndex: 'speciality',
            key: 'speciality',
        },
        //{
        //    title: 'Slot Id',
        //    dataIndex: 'timeslotId',
        //    key: 'timeslotId',
        //},
        {
            title: 'Статус',
            dataIndex: 'isBooked',
            key: 'isBooked',
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
            title: 'Отмена',
            dataIndex: 'cancel',
            key: 'cancel',
            render: (text: string, record: object) => (
                <Button
                    onClick={() => cancelBooking(record['key' as keyof typeof record])}
                    disabled={!bookings[record['key' as keyof typeof record]].isBooked} 
                >
                      {"Отмена"}
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
            const responce = await getBookingsByPatient("A157E16F-26EA-44FB-B01E-FD26A4ACDDCD");
            setBookings(responce);
        }
        getBookings();
    }, []);

    const data = bookings.map((booking: Booking, index: number) => ({
        key: index,
        n: (index + 1),
        username: booking.doctorUserName,
        speciality: booking.doctorSpeciality,
        timeslotId: booking.timeslotId,
        isBooked: ((booking.isBooked.toString() == "true") ? "Вы записаны" : "Запись отменена"), //booking.isBooked.toString(),
        timeslotStart: booking.timeslotDatetimeStart,
        timeslotStop: booking.timeslotDatetimeStop,
        cancel: ""  
    }));


    const timeslotRequest: TimeSlotUpdateRequest = {
        patientid: '',
        slotid: '',
        isbooked: false
    };


    const bookingRequest: BookingCreateRequest = {
        slotid: "",
        patientid: "",
        doctorid: "",
        doctorusername: "",
        isbooked: false,
    };


    const cancelBooking = (key: number) => {
        timeslotRequest.slotid = bookings[key].timeslotId;
        timeslotRequest.patientid = "A157E16F-26EA-44FB-B01E-FD26A4ACDDCD";
        timeslotRequest.isbooked = false;
        //
        bookingRequest.slotid = bookings[key].timeslotId;
        bookingRequest.patientid = "A157E16F-26EA-44FB-B01E-FD26A4ACDDCD";
        bookingRequest.doctorid = bookings[key].doctorId;
        bookingRequest.doctorusername = bookings[key].doctorUserName;
        bookingRequest.isbooked = false;
        updateTimeslot(timeslotRequest);
        createBooking(bookingRequest);
    }  



    return (
        <div>
            <br></br>
            <h2>Мои записи к врачам (бронирования)</h2>
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



