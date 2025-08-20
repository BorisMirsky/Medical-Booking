///* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import { getDoctorsFetch } from "@/app/Services/service";
import { Doctor } from "@/app/Models/Doctor";
import { Table } from "antd";
import { useEffect, useState } from "react";
import Link from "next/link";
import "../globals.css";



export default function PatientsWithViolationsOfDiscipline() {
    const [currentRole, setCurrentRole] = useState("");
    const [patients, setPatients] = useState<Doctor[]>([]);

    const columns = [
        {
            title: 'N',
            dataIndex: 'n',
            key: 'n',
        },
        //{
        //    title: 'UniqueId',
        //    dataIndex: 'uniqueid',
        //    key: 'uniqueid',
        //    render: (id: string) => (
        //        <Link
        //            href={{
        //                pathname: "profiledoctor",
        //                query: {
        //                    id: id
        //                }
        //            }}
        //            //legacyBehavior={true}
        //        >
        //            {/*<a className="tableLink" >*/}
        //                {id}
        //            {/*</a>*/}
        //        </Link>
        //    )
        //},
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
        //setCurrentRole(role);
        //setDoctors([]);
        //const getDoctors = async () => {
        //    const responce = await getDoctorsFetch();
        //    setDoctors(responce);
        //}
        //getDoctors();
    }, []);


    const data = patients.map((doctor: Doctor, index: number) => ({
        key: index,
        n: (index + 1),
        //uniqueid: doctor.id,
        username: doctor.userName,
        speciality: doctor.speciality,
        gender: doctor.gender
        //date: moment(order.date).format("DD/MM/YYYY")
    }));



    return (
        <div>
            <br /><br />
            <h1>Все врачи клиники</h1>
            <br /><br />
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

