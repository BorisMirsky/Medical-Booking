"use client"

import React from 'react';
import PatientRegistration from '../Components/patientRegistrationComponent';
import { Space } from 'antd';
import Title from "antd/es/typography/Title";



export default function entrancePatient() {

    return (
        <div>
                <Space
                    direction="vertical"
                    size="large"
                    style={{ margin: '2rem', width: '50%' }}
                >
                    <Title level={2}>Регистрация пациента</Title>
                </Space>
            <br />
                <div >
                <PatientRegistration></PatientRegistration>
                </div >
        </div>
    );
}