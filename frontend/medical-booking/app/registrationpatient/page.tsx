"use client"

import React from 'react';
import PatientRegistration from '../Components/patientRegistrationComponent';


export default function entrancePatient() {

    return (
        <div>
            <br/>
            <br />
            <br />
            <h2>Регистрация пациента</h2>
            <br />
                <div >
                <PatientRegistration></PatientRegistration>
                </div >
        </div>
    );
}