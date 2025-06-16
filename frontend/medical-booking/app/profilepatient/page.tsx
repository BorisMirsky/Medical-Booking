/* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import { getDoctorsBySpeciality } from "@/app/Services/service";
import { Doctor } from "@/app/Models/Doctor";
//loginResponse  loginUser, 
//import { Button, Space } from 'antd';
import { Select, Space, DatePicker } from 'antd';
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";
//import Link from "next/link";
//import ModalComponent from '../Components/ModalComponent';
//general practitioner - GP




export default function profilePatient() {
    //let specialitySelected = undefined;
    //const [currentRole, setCurrentRole] = useState("");
    //const [order, setOrder] = useState<Order[]>([]);
    const [doctors, setDoctors] = useState<Doctor[]>([]);  
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
        setLoading(false);
    }, []);


    const handleSelectSpeciality = (value: string) => {
        setDoctors([]);
        const getDoctors = async () => {
            const responce = await getDoctorsBySpeciality(value);
            setLoading(false);
            setDoctors(responce);
        }
        getDoctors();
    };

    const doctorsData = doctors.map((doctor, index) => ({
        key: index,
        value: doctor.userName,
        label: doctor.userName
    })); 


    const handleSelectName = (value: string) => {
        console.log(`selected ${value}`);
    };

    const onSelectSlot = (value: string) => {
        console.log(`selected ${value}`);
    };


    return (
        <div>
            <br></br>
            <br></br>
            <br></br>
            <h2>Профиль пациента</h2>
            <br></br>
            <br></br>
            <br></br>
            {
                <div >
                    {loading ? (
                        <Title>Loading ...</Title>
                    ) : (
                            <div>
                                <div>
                                <Space size='large'>
                                Подбор врача по специализации 
                                <Select
                                    style={{ width: 200 }}
                                    onChange={handleSelectSpeciality}
                                    options={[
                                        { value: 'Neurologist', label: 'Невролог' },
                                        { value: 'Surgeon', label: 'Хирург' },
                                        { value: 'Oncologist', label: 'Онколог' },
                                        { value: 'Dentist', label: 'Дантист' }
                                    ]}
                                        />
                                </Space>
                                </div>

                                <br></br>
                                <br></br>
                                <br></br>

                                <div>
                                <Space size='large'>
                                Подбор врача по имени
                                <Select
                                    style={{ width: 200 }}
                                    onChange={handleSelectName}
                                    options={doctorsData}
                                    />
                                </Space>
                                </div>

                                <br></br>
                                <br></br>
                                <br></br>

                                <div>
                                    <Space size='large'>
                                        Подбор даты и времени
                                        <DatePicker onChange={onSelectSlot} />
                                    </Space>
                                </div>


                            </div>
                    )}
                    <br></br>
                    <br></br>
                </div >
            }
        </div>
    );
}