///* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import { getBookingsByPatient } from "@/app/Services/service";
import { Booking } from "@/app/Models/Booking";
import { Table, Button } from "antd";
import { useEffect, useState } from "react";
import "../globals.css";
//import Title from "antd/es/typography/Title";
//import moment from 'moment';




// profilepatient  --- Мои записи к врачам (возможность отмены)
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
        {
            title: 'Время приёма',
            dataIndex: 'timeslot',
            key: 'timeslot',
        },
        {
            title: 'Id слота',
            dataIndex: 'timeslotId',
            key: 'timeslotId',
        },
        {
            title: 'Отмена',
            dataIndex: 'cancel',
            key: 'cancel',
            render: (text: string, record: string) => (
                <Button onClick={() => console.log(record)}>
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
        timeslotId: booking.slotId,
        timeslot: "q",  //booking.slots,
        cancel: ""  
    }));



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

