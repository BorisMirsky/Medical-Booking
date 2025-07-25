﻿///* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import { getAppointmentsByPatientId } from "@/app/Services/service";
import { Appointment } from "@/app/Models/Appointment";
import { Table } from "antd";
import { useEffect, useState } from "react";
import "../globals.css";



export default function PatientMyAppointments() {
    //const [currentRole, setCurrentRole] = useState("");
    const [apps, setApps] = useState<Appointment[]>([]);


    const columns = [
        {
            title: 'N',
            dataIndex: 'n',
            key: 'n',
        },
        {
            title: 'Врач',
            dataIndex: 'doctorusername',
            key: 'doctorusername',
        },
        {
            title: 'Специализация врача',
            dataIndex: 'doctorspeciality',
            key: 'doctorspeciality',
        },
        {
            title: 'Дата',
            dataIndex: 'date',
            key: 'date',
        },

    ]


    useEffect(() => {
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
        //
        setApps([]);
        const getApps = async () => {
            const responce = await getAppointmentsByPatientId("BA29102B-AA29-475F-BEC5-F57F173947CD");
            setApps(responce);
        }
        getApps();
    }, []);


    const data = apps.map((app: Appointment, index: number) => ({
        key: index,
        n: (index + 1),
        uniqueid: app.id,
        doctorusername: app.doctorusername,
        doctorspeciality: app.doctorspeciality,
        date: app.timeslotdatetimestart
    }));



    return (
        <div>
            <br></br><br></br>
            <h1>Мои посещения врачей</h1>
            <br></br><br></br>
            <div>
                <br></br><br></br><br></br>
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

