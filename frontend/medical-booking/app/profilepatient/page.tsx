/* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
//import { UserLoginRequest } from "@/app/Services/service";   //loginResponse  loginUser, 
//import { Button, Space } from 'antd';
import { Select } from 'antd';
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";
//import Link from "next/link";
//import ModalComponent from '../Components/ModalComponent';
//general practitioner - GP

export default function profilePatient() {
    let specialitySelected = false;
    //const [currentRole, setCurrentRole] = useState("");
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
        setLoading(false);
    }, []);


    const handleSelectSpeciality = (value: string) => {
        specialitySelected = true; 
        console.log(`selected ${value}`);
    };


    const handleSelectName = (value: string) => {
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
                                Подбор врача по специализации 
                                <Select
                                    //defaultValue="lucy"
                                    style={{ width: 120 }}
                                    onChange={handleSelectSpeciality}
                                    options={[
                                        { value: 'neurologist', label: 'Невролог' },
                                        { value: 'surgeon', label: 'Хирург' },
                                        { value: 'oncologist', label: 'Гастроэнтеролог' }
                                    ]}
                                    />
                                 </div>
                                <br></br>
                                <br></br>

                                <div>
                                    Подбор врача по имени
                                    <Select
                                        //defaultValue="lucy"
                                        style={{ width: 120 }}
                                        onChange={handleSelectSpeciality}
                                        options={[
                                            { value: 'neurologist', label: 'Невролог' },
                                            { value: 'surgeon', label: 'Хирург' },
                                            { value: 'gastroenterologist', label: 'Гастроэнтеролог' },
                                            { value: 'disabled', label: 'Disabled', disabled: true },
                                        ]}
                                    />
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