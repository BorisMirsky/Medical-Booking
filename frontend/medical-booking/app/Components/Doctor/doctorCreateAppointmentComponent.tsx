
"use client"

import React from 'react';
import { getBookingsByDoctor, IDoctorCreateAppointmentProps, DataType1 } from "@/app/Services/service";
import { Booking } from "@/app/Models/Booking";
import { Table, Button, Space } from "antd";
import { useEffect, useState } from "react";
import "@/app/globals.css";
import Title from "antd/es/typography/Title";



const DoctorCreateAppointment: React.FC<IDoctorCreateAppointmentProps> = ({ onNext }) => {
    const [, setCurrentId] = useState("");
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
            sorter: (a: DataType1, b: DataType1) => a.timeslotStart.localeCompare(b.timeslotStart),
            defaultSortOrder: 'descend' as const
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


    const data = bookings
        .sort((a, b) => a.timeslotDatetimeStart.localeCompare(b.timeslotDatetimeStart))
        .map((booking: Booking, index: number) => ({
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
            <Space
                direction="vertical"
                size="large"
                style={{ margin: '2rem', width: '50%' }}
            >
                <Title level={2}>Мои бронирования</Title>
            </Space>
            <div>
                <Table
                    dataSource={data}
                    columns={columns}
                    pagination={false}
                    //footer={() => ""}
                    bordered
                    />
            </div>
        </div>
    );
}



export default DoctorCreateAppointment;