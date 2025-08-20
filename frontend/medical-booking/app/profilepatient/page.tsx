/* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";
import CollapseElement from '../Components/patientCollapseComponent';


export default function profilePatient() {
    const [currentRole, setCurrentRole] = useState("");
    const [currentName, setCurrentName] = useState("");
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const role = localStorage.getItem("role") || "";
        const name = localStorage.getItem("username") || "";
        setCurrentRole(role);
        setCurrentName(name);
        setLoading(false);
    }, []);


    return (
        <div>
            <br />
            <br />
            <br />
            <br />
            <br />
            {
                (currentRole === 'patient') ? (
                    <div>
                        <br />
                        <h2>Профиль пациента {currentName}</h2>
                        <br />
                        <br />
                        <br />
                        {loading ? (
                            <Title>Loading ...</Title>
                        ) : (
                            <CollapseElement />
                        )}

                    </div >
                ) : (
                        <div><h2> Только для залогинившегося пациента</h2></div>
                )}
        </div>
    );
}