
"use client"

import React from 'react';
import { DoctorAppointmentProps } from "@/app/Services/service";
import { Card, Space } from "antd"; 
import FormAppointment from "../Components/formCreateAppointmentComponent";
import FormMedicalRecord from "../Components/formCreateMedicalRecordComponent"; 
import PatientAllMedicalRecords from '../Components/patientAllMedicalRecordsComponent';
//import { useState, useEffect } from "react";       // useEffect
import "../globals.css";




const DoctorAppointment: React.FC<DoctorAppointmentProps> = ({ booking }) => {
    //const [bookingClosed, setBookingClosed] = useState(false);
    //bookingStatus={bookingClosed}
    const patientusername: string = !booking ? "" : booking.patientUserName;

    const _title = `Медицинская карта пациента ${patientusername}`;

    if (!booking) {
        return <div>Выберите бронирование в предыдущей панели</div>;
    }

    return (
        <div>
            <br></br>
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
                            <FormMedicalRecord booking={booking} />
                        </div>
                    </Card>

                    <Card
                        title={_title}
                        style={{ width: 1000 }}
                    >
                        <div>
                            <PatientAllMedicalRecords booking={booking} />
                        </div>
                    </Card>

                </Space>
            </div>
        </div>
    );
}



export default DoctorAppointment;
