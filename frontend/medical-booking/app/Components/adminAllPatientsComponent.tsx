///* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import { getPatientsFetch } from "@/app/Services/service";
import { Patient } from "@/app/Models/Patient";
//import { Slot } from "@/app/Models/Slot";
//import { Select, Space, DatePicker, Button, Form, FormProps } from 'antd';
import { Table } from "antd";
//import { Order } from "@/app/Models/Order";
import { useEffect, useState } from "react";
import Link from "next/link";
import "../globals.css";
//import Title from "antd/es/typography/Title";
//import moment from 'moment';





export default function AllPatients() {
    //const [currentRole, setCurrentRole] = useState("");
    const [patients, setPatients] = useState<Patient[]>([]);


    const columns = [
        {
            title: 'N',
            dataIndex: 'n',
            key: 'n',
        },
        {
            title: 'UniqueId',
            dataIndex: 'uniqueid',
            key: 'uniqueid',
            render: (id: string) => (
                <Link
                    href={{
                        pathname: "oneorder",
                        query: {
                            id: id
                        }
                    }}
                    legacyBehavior={true}
                >
                    <a className="tableLink" >
                        {id}
                    </a>
                </Link>
            )
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
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
        //
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
        uniqueid: patient.id,
        username: patient.userName,
        gender: patient.gender
        //date: moment(order.date).format("DD/MM/YYYY")
    }));



    return (
        <div>
            <br></br><br></br>
            <h1>Все пациенты клиники</h1>
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

