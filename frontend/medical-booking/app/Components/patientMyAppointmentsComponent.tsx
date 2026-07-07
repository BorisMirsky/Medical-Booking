///* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import { getAppointmentsByPatientId } from "@/app/Services/service";
import { Appointment } from "@/app/Models/Appointment";
import { Table, Space } from "antd";
import { useEffect, useState } from "react";
import "../globals.css";
import Title from "antd/es/typography/Title";



export default function PatientMyAppointments() {
    const [, setCurrentUserId] = useState("");
    const [apps, setApps] = useState<Appointment[]>([]);

    useEffect(() => {
        const id = localStorage.getItem("id") || "";
        setCurrentUserId(id);
        setApps([]);
        const getApps = async () => {
            const responce = await getAppointmentsByPatientId(id);           
            setApps(responce);
        }
        getApps();
    }, []);


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
            title: 'Дата. Начало приёмa',
            dataIndex: 'date',
            key: 'date',
        },
    ]


    const data = apps.map((app: Appointment, index: number) => ({
        key: index,
        n: (index + 1),
        doctorusername:  app.doctorUserName,
        doctorspeciality: app.patientUserName,    
        date: app.timeslotDatetimeStart
    }));


    return (
        <div>
            <Space
                direction="vertical"
                size="large"
                style={{ margin: '2rem', width: '50%' }}
            >
                <Title level={2}>Мои посещения врачей</Title>
            </Space>
            <div>
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

