/* eslint-disable @typescript-eslint/no-explicit-any */
///* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import {
    getBookingsByPatient,
    updateTimeslot, TimeSlotUpdateRequest,
    createBooking, BookingCreateRequest
} from "@/app/Services/service";
import { Booking } from "@/app/Models/Booking";
import { Table, Button } from "antd";
import { useEffect, useState, useReducer } from "react";
import "../globals.css";
//import Title from "antd/es/typography/Title";
//import moment from 'moment';




// profilepatient  --- Мои записи к врачам (возможность отмены)
export default function PatientBookings() {
    //const [currentRole, setCurrentRole] = useState("");
    const [bookings, setBookings] = useState<Booking[]>([]);
    const [, forceUpdate] = useReducer(x => x + 1, 0)

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
                <Button onClick={() => cancelBooking(record['key' as keyof typeof record])}>
                    {"Отмена"}
                </Button>
            ),
        }
    ]


    useEffect(() => {
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
        //
        setBookings([]);
        const getBookings = async () => {        
            const responce = await getBookingsByPatient("192A59D9-43DF-43EC-943A-8E4290386B1E");
            //console.log("responce ", responce);
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
        //console.log("bookings ", bookings[key], key); 
        //if (value.isBooked) {
        timeslotRequest.slotid = bookings[key].timeslotId;
        timeslotRequest.patientid = "192A59D9-43DF-43EC-943A-8E4290386B1E";
        timeslotRequest.isbooked = false;
        //
        bookingRequest.slotid = bookings[key].timeslotId;
        bookingRequest.patientid = "192A59D9-43DF-43EC-943A-8E4290386B1E";
        bookingRequest.doctorid = bookings[key].doctorId;
        bookingRequest.doctorusername = bookings[key].doctorUserName;
        bookingRequest.isbooked = false;
        updateTimeslot(timeslotRequest);
        //createBooking(bookingRequest);
        //forceUpdate();
        //}
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

