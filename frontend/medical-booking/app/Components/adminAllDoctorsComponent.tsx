///* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import { getDoctorsFetch } from "@/app/Services/service";
import { Doctor } from "@/app/Models/Doctor";
//import { Slot } from "@/app/Models/Slot";
//import { Select, Space, DatePicker, Button, Form, FormProps } from 'antd';
import { Table } from "antd";
import { useEffect, useState } from "react";
import Link from "next/link";
import "../globals.css";
//import Title from "antd/es/typography/Title";
//import moment from 'moment';



export default function AllDoctors() {
    //const [currentRole, setCurrentRole] = useState("");
    const [doctors, setDoctors] = useState<Doctor[]>([]);

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
                        pathname: "profiledoctor",
                        query: {
                            id: id
                        }
                    }}
                    //legacyBehavior={true}
                >
                    {/*<a className="tableLink" >*/}
                        {id}
                    {/*</a>*/}
                </Link>
            )
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
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
        //
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
        uniqueid: doctor.id,
        username: doctor.userName,
        speciality: doctor.speciality,
        gender: doctor.gender
        //date: moment(order.date).format("DD/MM/YYYY")
    })); 



    return (
            <div>
                <br></br><br></br>
                <h1>Все врачи клиники</h1>
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

