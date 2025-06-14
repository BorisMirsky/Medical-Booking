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


export default function profilePatient() {
    //const [currentRole, setCurrentRole] = useState("");
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
        setLoading(false);
    }, []);

    const handleChange = (value: string) => {
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
                                Подбор врача по специализации 
                                <Select
                                    defaultValue="lucy"
                                    style={{ width: 120 }}
                                    onChange={handleChange}
                                    options={[
                                        { value: 'Хирург', label: 'Jack' },
                                        { value: 'Терапевт', label: 'Lucy' },
                                        { value: 'Окулист', label: 'yiminghe' },
                                        { value: 'disabled', label: 'Disabled', disabled: true },
                                    ]}
                                />
                            </div>
                    )}
                    <br></br>
                    <br></br>
                </div >
            }
        </div>
    );
}