//* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import { getAllAppointments } from "@/app/Services/service";
import { Appointment } from "@/app/Models/Appointment";
import { Table } from "antd";
import { useEffect, useState } from "react";
import "../globals.css";



export default function PatientsMisbehavior() {
    const [currentRole, setCurrentRole] = useState("");
    const [apps, setApps] = useState<Appointment[]>([]);

    const columns = [
        {
            title: 'N',
            dataIndex: 'n',
            key: 'n',
        },
        {
            title: 'Пациент',
            dataIndex: 'patient',
            key: 'patient',
        },
        {
            title: 'Врач',
            dataIndex: 'doctor',
            key: 'doctor',
        },
        {
            title: 'Дата',
            dataIndex: 'date',
            key: 'date',
        },
        {
            title: 'Пациент пришёл',
            dataIndex: 'iscame',
            key: 'iscame',
        },
        {
            title: 'Пациент опоздал',
            dataIndex: 'islate',
            key: 'islate',
        },
        {
            title: 'Пациент плохо себя вёл',
            dataIndex: 'badbehavior',
            key: 'badbehavior',
        }
    ]


    useEffect(() => {
        const role = localStorage.getItem("role") || "";
        setCurrentRole(role);
        setApps([]);
        const getApps = async () => {
            const responce = await getAllAppointments();
            setApps(responce);
        }
        getApps();
    }, []);


    const data = apps.map((app: Appointment, index: number) => ({
        key: index,
        n: (index + 1),
        patient: app.patientUserName,
        doctor: app.doctorUserName,
        date: app.timeslotDatetimeStart,
        iscame: app.patientCame,
        islate: app.patientIsLate,
        badbehavior: app.patientUnacceptableBehavior
    }));



    return (
        <div>
            <br /><br />
            <h1>Пациенты с нарушениями дисциплины</h1>
            <div>
                <br /><br /><br />
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

