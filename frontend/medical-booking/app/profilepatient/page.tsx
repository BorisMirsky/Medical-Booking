/* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";
import CollapseElement from '../Components/patientCollapseComponent';
import { Space } from 'antd';


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

            {
                (currentRole === 'patient') ? (
                    <div>
                        <Space
                            direction="vertical"
                            size="large"
                            style={{ margin: '2rem', width: '50%' }}
                        >
                            <Title level={2}>Профиль пациента {currentName}</Title>
                        </Space>
                        {loading ? (
                            <Title>Loading ...</Title>
                        ) : (
                            <CollapseElement />
                        )}

                    </div >
                ) : (
                        <Title level={2}> Только для залогинившегося пациента</Title>
                )}
        </div>
    );
}