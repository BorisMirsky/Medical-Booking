/* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
//import { getDoctorsBySpeciality } from "@/app/Services/service";
//import { Doctor } from "@/app/Models/Doctor";
////loginResponse  loginUser, 
////import { Button, Space } from 'antd';
//import { Select, Space, DatePicker } from 'antd';
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";
//import CollapseElement from '../Components/patientCollapseComponent';
//import Link from "next/link";
//import ModalComponent from '../Components/ModalComponent';
//general practitioner - GP
import CollapseElement from '../Components/patientCollapseComponent';
import TestCollapseElement from '../Components/testCollapseComponent';


export default function profilePatient() {
    //let specialitySelected = undefined;
    //const [currentRole, setCurrentRole] = useState("");
    //const [order, setOrder] = useState<Order[]>([]);
    //const [doctors, setDoctors] = useState<Doctor[]>([]);  
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
        setLoading(false);
    }, []);


    //const handleSelectSpeciality = (value: string) => {
    //    setDoctors([]);
    //    const getDoctors = async () => {
    //        const responce = await getDoctorsBySpeciality(value);
    //        setLoading(false);
    //        setDoctors(responce);
    //    }
    //    getDoctors();
    //};

    //const doctorsData = doctors.map((doctor, index) => ({
    //    key: index,
    //    value: doctor.userName,
    //    label: doctor.userName
    //})); 


    //const handleSelectName = (value: string) => {
    //    console.log(`selected ${value}`);
    //};

    //const onSelectSlot = (value: string) => {
    //    console.log(`selected ${value}`);
    //};


    return (
        <div>
            <br></br>
            <br></br>
            <br></br>
            <h2>Профиль пациента</h2>
            <br></br>
            <br></br>
            <TestCollapseElement />
            <br></br>
            {
                <div >
                    <br></br>
                    <br></br>
                    {loading ? (
                        <Title>Loading ...</Title>
                    ) : (
                            <CollapseElement />
                    )}
                    <br></br> 
                    <br></br>
                </div >
            }
        </div>
    );
}