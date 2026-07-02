///* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import { getDoctorsFetch } from "@/app/Services/service";
import { Doctor } from "@/app/Models/Doctor";
import { Table } from "antd";
import { useEffect, useState } from "react";
import "../globals.css";
import { Space } from 'antd';
import Title from "antd/es/typography/Title";


export default function AllDoctors() {
    const [, setCurrentRole] = useState("");
    const [doctors, setDoctors] = useState<Doctor[]>([]);

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
            title: 'Специализация',
            dataIndex: 'speciality',
            key: 'speciality',
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
        setDoctors([]);
        const getDoctors = async () => {
            const responce = await getDoctorsFetch();
            setDoctors(responce);
        }
        getDoctors();
    }, []);


    const data = doctors.map((doctor: Doctor, index: number) => ({
        key: index,
        n: (index + 1),
        username: doctor.userName,
        speciality: doctor.speciality,
        gender: doctor.gender
    })); 



    return (
            <div>
                <Space
                    direction="vertical"
                    size="large"
                    style={{ margin: '2rem', width: '50%' }}
                >
                    <Title level={1}>Все врачи клиники</Title>
                </Space>
                        <Table
                            dataSource={data}
                            columns={columns}
                            pagination={false}
                            footer={() => ""}
                            bordered
                        />
        </div>
    );    
}

