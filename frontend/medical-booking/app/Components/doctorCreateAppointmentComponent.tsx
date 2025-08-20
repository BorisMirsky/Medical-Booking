
"use client"

import React from 'react';
import { getBookingsByDoctor } from "@/app/Services/service";
import { Booking } from "@/app/Models/Booking";
import { Table, Button } from "antd";
import { useEffect, useState } from "react";
import "../globals.css";



interface IDoctorCreateAppointmentProps {
    onNext: (booking: Booking) => void;
}


const DoctorCreateAppointment: React.FC<IDoctorCreateAppointmentProps> = ({ onNext }) => {
    const [currentId, setCurrentId] = useState("");
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
                    //onClick={() => onNext(record['key' as keyof typeof record])}
                    onClick={() => createAppointment(record['key' as keyof typeof record])}
                    //disabled={!bookings[record['key' as keyof typeof record]].isBooked}
                >
                    {"Создать"}
                </Button>
            )
        }
    ]

    useEffect(() => {
        const id = localStorage.getItem("id") || "";
        setCurrentId(id);
        setBookings([]);
        const getBookings = async () => {
            const responce = await getBookingsByDoctor(id);
            setBookings(responce);
        }
        getBookings();
    }, []);

    const data = bookings.map((booking: Booking, index: number) => ({
        key: index,
        n: (index + 1),
        username: booking.patientUserName,
        timeslotStart: booking.timeslotDatetimeStart,
        timeslotStop: booking.timeslotDatetimeStop,
        create: ""
    }));


    const createAppointment = (key: number) => {
        onNext(bookings[key]);
    }


    return (
        <div>
            <br />
            <h2>Мои бронирования</h2>
            <div>
                <br /><br />
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



export default DoctorCreateAppointment;