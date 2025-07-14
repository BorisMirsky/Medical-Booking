///* eslint-disable @typescript-eslint/no-explicit-any */
///* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import {
    createAppointment, AppointmentRequest, MedicalCardRequest
} from "@/app/Services/service";
import { Booking } from "@/app/Models/Booking";
import { Card, FormProps, Button, Form, Input, Space } from "antd";
import FormAppointment from "../Components/formCreateAppointmentComponent"; 
//const { Option } = Select;
//import { useEffect, useState } from "react";
import "../globals.css";
//import Title from "antd/es/typography/Title";
//import moment from 'moment';


interface DoctorAppointmentProps {
    booking: Booking;
}


//export interface AppointmentRequest {
//    //id: string;
//    bookingid: string;
//    doctorid: string;
//    patientid: string;
//    timeslotid: string;
//    medicalcardid: string;
//    patientcame?: string;
//    patientislate?: string;
//    patientunacceptablebehavior?: string;
//}


const DoctorAppointment: React.FC<DoctorAppointmentProps> = ({ booking }) => {

    const [form] = Form.useForm();

    const onFinishFailed: FormProps<AppointmentRequest>['onFinishFailed'] = (errorInfo) => {
        console.log('onFinishFailed:', errorInfo);
    }

    const initialValues = {
        bookingid: booking.id, doctorid: booking.doctorId, patientid: booking.patientId,
        timeslotid: booking.timeslotId, medicalcardid: booking.timeslotId
    };


    const onFinish: FormProps<AppointmentRequest>['onFinish'] = (values) => {
        createAppointment(values);
        form.resetFields();
        console.log('values ', values)
        console.log('initialValues ', initialValues)
    }


    if (!booking) {
        return <div>Выберите бронирование в предыдущей панели</div>;
    }

    return (
        <div>
            <br></br>

            <div>
                <Space direction="vertical" size={16}>
                    <Card
                        title="Визит к врачу"
                        //extra={<a href="#">More</a>}
                        style={{ width: 500 }}
                    >
                        <div>

                            <Form
                                name="basic"
                                labelCol={{ span: 8 }}
                                wrapperCol={{ span: 16 }}
                                style={{ maxWidth: 800 }}
                                initialValues={initialValues}
                                onFinish={onFinish}
                                onFinishFailed={onFinishFailed}
                                autoComplete="off"
                                form={form}
                            >
                                <Form.Item<AppointmentRequest>
                                    label="BookingId"
                                    name="bookingid"
                                >
                                    <Input disabled={true} />
                                </Form.Item>

                                <Form.Item<AppointmentRequest>
                                    label="DoctorId"
                                    name="doctorid"
                                >
                                    <Input disabled={true} />
                                </Form.Item>

                                <Form.Item<AppointmentRequest>
                                    label="PatientId"
                                    name="patientid"
                                >
                                    <Input disabled={true} />
                                </Form.Item>

                                <Form.Item<AppointmentRequest>
                                    label="TimeslotId"
                                    name="timeslotid"
                                >
                                    <Input disabled={true} />
                                </Form.Item>

                                <Form.Item<AppointmentRequest>
                                    label="MedicalCardId"
                                    name="medicalcardid"
                                >
                                    <Input disabled={true} />
                                </Form.Item>

                                <Form.Item<AppointmentRequest>
                                    label="Пациент пришёл"
                                    name="patientcame"

                                >
                                    <Input placeholder="Да" />
                                </Form.Item>

                                <Form.Item<AppointmentRequest>
                                    label="Пациент опоздал"
                                    name="patientislate"

                                >
                                    <Input placeholder="Нет" />
                                </Form.Item>

                                <Form.Item<AppointmentRequest>
                                    label={<p style = {{ fontSize: "13px" }}> Неподобающее <br /> поведение </p>}
                                    name="patientunacceptablebehavior"
                                >
                                    <Input placeholder="Нет" />
                                </Form.Item>

                                <br></br>
                                <br></br>

                            <Form.Item label={null}>
                                <Space size='large'>
                                <Button
                                    type="primary"
                                    htmlType="submit"
                                >
                                    Создать посещение
                                    </Button>

                                <Button htmlType="reset">
                                    Сбросить
                                    </Button>
                                </Space>
                                </Form.Item>
                            </Form>

                        </div>
                    </Card>
                    
                    <Card
                        title="Медицинская карта пациента"
                        style={{ width: 500 }}
                    >
                        <div>
                            <Form
                                name="basic"
                                labelCol={{ span: 8 }}
                                wrapperCol={{ span: 16 }}
                                style={{ maxWidth: 800 }}
                                initialValues={initialValues}
                                onFinish={onFinish}
                                onFinishFailed={onFinishFailed}
                                autoComplete="off"
                                form={form}
                            >
                                <Form.Item<MedicalCardRequest>
                                    label="BookingId"
                                    name="bookingid"
                                >
                                    <Input disabled={true} />
                                </Form.Item>

                                <Form.Item<MedicalCardRequest>
                                    label="DoctorId"
                                    name="doctorid"
                                >
                                    <Input disabled={true} />
                                </Form.Item>

                                <Form.Item<MedicalCardRequest>
                                    label="PatientId"
                                    name="patientid"
                                >
                                    <Input disabled={true} />
                                </Form.Item>

                                <Form.Item<MedicalCardRequest>
                                    label="TimeslotId"
                                    name="timeslotid"
                                >
                                    <Input disabled={true} />
                                </Form.Item>

                                <Form.Item<MedicalCardRequest>
                                    label="Симптомы"
                                    name="symptoms"

                                >
                                    <Input />
                                </Form.Item>

                                <Form.Item<MedicalCardRequest>
                                    label="Диагноз"
                                    name="diagnosis"
                                >
                                    <Input />
                                </Form.Item>

                                <Form.Item<MedicalCardRequest>
                                    label="Назначенное лечение"
                                    name="prescribedtreatment"
                                >
                                    <Input placeholder="Да" />
                                </Form.Item>

                                <Form.Item<MedicalCardRequest>
                                    label="Осмотр"
                                    name="visualexamination"
                                >
                                    <Input placeholder="Да" />
                                </Form.Item>

                                <Form.Item<MedicalCardRequest>
                                    label="Дополнительные анализы"
                                    name="referraltests"
                                >
                                    <Input placeholder="Да" />
                                </Form.Item>

                                <Form.Item<MedicalCardRequest>
                                    label="Стоимость приёма"
                                    name="finalcost"
                                >
                                    <Input placeholder="00000.00" />
                                </Form.Item>

                                <br></br>
                                <br></br>

                                <Form.Item label={null}>
                                    <Space size='large'>
                                        <Button
                                            type="primary"
                                            htmlType="submit"
                                        >
                                            Создать Запись в мед. карту
                                        </Button>

                                        <Button htmlType="reset">
                                            Сбросить
                                        </Button>
                                    </Space>
                                </Form.Item>
                            </Form>

                        </div>
                    </Card>
                    {/*<div>*/}

                    {/*    <Card*/}
                    {/*        title="Визит к врачу"*/}
                    {/*        //extra={<a href="#">More</a>}*/}
                    {/*        style={{ width: 500 }}*/}
                    {/*    >*/}
                    {/*        <div>*/}
                             
                    {/*        </div>*/}
                    {/*    </Card>*/}
                    {/*</div>*/}
                </Space>
            </div>
        </div>
    );
}



export default DoctorAppointment;
