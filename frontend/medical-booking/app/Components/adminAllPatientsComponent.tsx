///* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import { getPatientsFetch } from "@/app/Services/service";
import { Patient } from "@/app/Models/Patient";
import {  Space } from 'antd';
import { Table } from "antd";
import { useEffect, useState } from "react";
import "../globals.css";
import Title from "antd/es/typography/Title";




export default function AllPatients() {
    const [ , setCurrentRole] = useState("");
    const [patients, setPatients] = useState<Patient[]>([]);


    const columns = [
        {
            title: 'N',
            dataIndex: 'n',
            key: 'n',
        },
        {
            title: 'Имя',
            dataIndex: 'username',
            key: 'username',
        },
        {
            title: 'Гендер',
            dataIndex: 'gender',
            key: 'gender',
        }
    ]


    useEffect(() => {
        const role = localStorage.getItem("role") || "";
        setCurrentRole(role);
        setPatients([]);
        const getPatients = async () => {
            const responce = await getPatientsFetch();
            setPatients(responce);
        }
        getPatients();
    }, []);


    const data = patients.map((patient: Patient, index: number) => ({
        key: index,
        n: (index + 1),
        username: patient.userName,
        gender: patient.gender
    }));



    return (
        <div>
            <Space
                direction="vertical"
                size="large"
                style={{ margin: '2rem', width: '50%' }}
            >
                <Title level={1}>Все пациенты клиники</Title>
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

