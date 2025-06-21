/* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
//import { UserLoginRequest } from "@/app/Services/service";   //loginResponse  loginUser, 
//import { FormProps, Button, Form, Input, Space } from 'antd';
//import Title from "antd/es/typography/Title";
import { useEffect } from "react";         //useState
//import Link from "next/link";
import PatientRegistration from '../Components/patientRegistrationComponent';
//import ModalComponent from '../Components/ModalComponent';





export default function entrancePatient() {
    //const [currentRole, setCurrentRole] = useState("");
    //const [loading, setLoading] = useState(true);

    useEffect(() => {
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
        //setLoading(false);
    }, []);


    return (
        <div>
            <br></br>
            <br></br>
            <br></br>
            <h2>Регистрация пациента</h2>
            <br></br>

                <div >
                <PatientRegistration></PatientRegistration>
                </div >
        </div>
    );
}