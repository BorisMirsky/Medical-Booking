"use client"

import React from 'react';
import { getMedicalRecordsByPatient, DoctorAppointmentProps } from "@/app/Services/service";
import { MedicalRecord } from "@/app/Models/MedicalRecord";
import { Table, Space } from "antd";
import { useEffect, useState } from "react";
import "../globals.css";



const PatientAllMedicalRecords: React.FC<DoctorAppointmentProps> = ({booking }) => {
    const [medrecords, setMedrecords] = useState<MedicalRecord[]>([]);

    const columns = [
        {
            title: 'N',
            dataIndex: 'n',
            key: 'n',
        },
        {
            title: 'Пациент',
            dataIndex: 'patient',
            key: 'patient',
        },
        {
            title: <><div>Врач</div><div>имя</div></>,
            dataIndex: 'doctorName',
            key: 'doctorName',
        },
        {
            title: <><div>Врач</div><div>специализация</div></>,
            dataIndex: 'doctorSpecialization',
            key: 'doctorSpecialization',
        },
        {
            title: 'Когда был приём',
            dataIndex: 'appointment',
            key: 'appointment',
            render: (text: string) => {
                return <div style={{ whiteSpace: 'pre-wrap' }}>{text}</div>;
            }
        },
        {
            title: 'Симптомы',
            dataIndex: 'symptoms',
            key: 'symptoms',
        },
        {
            title: 'Осмотр',
            dataIndex: 'visualExamination',
            key: 'visualExamination',
        },
        {
            title: 'Направление на анализы',
            dataIndex: 'referralTests',
            key: 'referralTests',
        },
        {
            title: 'Диагноз',
            dataIndex: 'diagnosis',
            key: 'diagnosis',
        },
        {
            title: <><div>Назначенное</div><div>лечение</div></>,
            dataIndex: 'prescribedTreatment',
            key: 'prescribedTreatment',
        }
    ]


    useEffect(() => {
        if (!booking) return;

        setMedrecords([]);
        const getMedrecords = async () => {
            const responce = await getMedicalRecordsByPatient(booking.patientId);
            setMedrecords(responce);
        }
        getMedrecords();
    }, [booking]);


    if (!booking) {
        return <div>Нет данных о бронировании</div>;
    }

    const data = medrecords.map((medicalrecord: MedicalRecord, index: number) => ({
        key: index,
        n: (index + 1),
        patient: booking.patientUserName,
        doctorName: medicalrecord.doctorUserName,                
        doctorSpecialization: "???",
        appointment: medicalrecord.timeslotDatetimeStart.split(" ")[0] + '\n' + medicalrecord.timeslotDatetimeStart.split(" ")[1],
        symptoms: medicalrecord.symptoms,
        visualExamination: medicalrecord.visualExamination,
        referralTests: medicalrecord.referralTests,
        diagnosis: medicalrecord.diagnosis,
        prescribedTreatment: medicalrecord.prescribedTreatment
    })); 



    return (
        <div>
            <div>
                <Space
                    direction="vertical"
                    size="large"
                    style={{ margin: '2rem', width: '50%' }}
                >                   </Space>            
                <Table
                    dataSource={data}
                    columns={columns}
                    pagination={false}
                    bordered
                    />

            </div>
        </div>
    );
}



export default PatientAllMedicalRecords;