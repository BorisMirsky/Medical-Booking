"use client"

import React from 'react';
import { getMedicalRecordsByPatient, DoctorAppointmentProps } from "@/app/Services/service";
import { MedicalRecord } from "@/app/Models/MedicalRecord";
import { Table } from "antd";
import { useEffect, useState } from "react";
import "../globals.css";



//interface PatientAllMedicalRecordsProps {
//    patientid: string;
//}


const PatientAllMedicalRecords: React.FC<DoctorAppointmentProps> = ({booking }) => {
    //const [currentRole, setCurrentRole] = useState("");
    const [medrecords, setMedrecords] = useState<MedicalRecord[]>([]);


    const columns = [
        {
            title: 'N',
            dataIndex: 'n',
            key: 'n',
        },
        {
            title: 'Пациент',
            dataIndex: 'username',
            key: 'username',
        },
        {
            title: 'Когда был приём',
            dataIndex: 'appointment',
            key: 'appointment',
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
            title: 'Назначенное лечение',
            dataIndex: 'prescribedTreatment',
            key: 'prescribedTreatment',
        }
    ]


    useEffect(() => {
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
        setMedrecords([]);
        const getMedrecords = async () => {
            const responce = await getMedicalRecordsByPatient(booking.patientId);
            setMedrecords(responce);
            console.log('medrecords ', medrecords);
        }
        getMedrecords();
    }, []);



    const data = medrecords.map((medicalrecord: MedicalRecord, index: number) => ({
        key: index,
        n: (index + 1),
        username: booking.patientUserName,
        appointment: booking.timeslotDatetimeStart.split(" ")[0] + "   " +
                            booking.timeslotDatetimeStart.split(" ")[1] +
                            " - " + booking.timeslotDatetimeStop.split(" ")[1],
        symptoms: medicalrecord.symptoms,
        visualExamination: medicalrecord.visualexamination,
        referralTests: medicalrecord.referraltests,
        diagnosis: medicalrecord.diagnosis,
        prescribedTreatment: medicalrecord.prescribedtreatment
    }));



    return (
        <div>
            <br></br>
            <h2>Медицинская карта пациента</h2>
            <div>
                <br></br><br></br>
                <Table
                    dataSource={data}
                    columns={columns}
                    pagination={false}
                    footer={() => ""}
                    bordered
                />
            </div>
        </div>
    );
}



export default PatientAllMedicalRecords;