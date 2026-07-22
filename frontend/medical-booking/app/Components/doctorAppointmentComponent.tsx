
"use client"

import React from 'react';
import { getMedicalRecordsByPatient, DoctorAppointmentProps } from "@/app/Services/service";
import { Card, Space } from "antd"; 
import FormAppointment from "../Components/formCreateAppointmentComponent";
import FormMedicalRecord from "../Components/formCreateMedicalRecordComponent"; 
import PatientAllMedicalRecords from '../Components/patientAllMedicalRecordsComponent';
import { useState, useEffect } from "react";
import { MedicalRecord } from "@/app/Models/MedicalRecord";
import "../globals.css";




const DoctorAppointment: React.FC<DoctorAppointmentProps> = ({ booking }) => {
    const [, setCurrentId] = useState("");
    const patientusername: string = !booking ? "" : booking.patientUserName;
    const [medicalRecords, setMedicalRecords] = useState<MedicalRecord[]>([]);

    const loadMedicalRecords = async () => {
        if (!booking) return;

        try {
            const records = await getMedicalRecordsByPatient(booking.patientId);
            setMedicalRecords(records);
        } catch (error) {
            console.error("Ошибка при загрузке медицинских записей:", error);
        }
    };

    useEffect(() => {
        loadMedicalRecords();
    }, [booking]);

    const handleMedicalRecordSaved = () => {
        loadMedicalRecords();
    };


    useEffect(() => {
        const id = localStorage.getItem("id") || "";
        setCurrentId(id);
    }, []);

    const _title = `Медицинская карта пациента ${patientusername}`;

    if (!booking) {
        return <div>Выберите бронирование в предыдущей панели</div>;
    }

    return (
        <div>
            <div>
                <Space direction="vertical" size={16}>
                    <Card
                        title="Данные визита"
                        style={{ width: 500 }}
                    >
                        <p>День визита <b>{booking.timeslotDatetimeStart.toString().split(" ")[0]}</b></p>
                        <p>Время визита <b>{booking.timeslotDatetimeStart.toString().split(" ")[1]} {" - "} {booking.timeslotDatetimeStop.toString().split(" ")[1]} </b></p>
                        <p>Пациент <b>{booking.patientUserName}</b></p>
                    </Card>

                    <Card
                        title="Визит к врачу"
                        style={{ width: 500 }}
                    >
                        <div>
                            <FormAppointment   booking={booking} />
                        </div>
                    </Card>
                    
                    <Card
                        title="Запись в медицинскую карту пациента"
                        style={{ width: 600 }}
                    >
                        <div>
                            <FormMedicalRecord
                                booking={booking}
                                onSave={handleMedicalRecordSaved}
                            />
                        </div>
                    </Card>

                    <Card
                        title={_title}
                        style={{ width: 1500 }}
                    >
                        <div>
                            <PatientAllMedicalRecords
                                booking={booking}
                                medicalRecords={medicalRecords}
                            />
                        </div>
                    </Card>

                </Space>
            </div>
        </div>
    );
}



export default DoctorAppointment;
