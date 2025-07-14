"use client"

import React from 'react';
import {
    createAppointment
} from "@/app/Services/service";
import { Booking } from "@/app/Models/Booking";
import { FormProps, Button, Form, Input, Space } from "antd";
import "../globals.css";


interface DoctorAppointmentProps {
    booking: Booking;
}


export interface AppointmentRequest {
    //id: string;
    bookingid: string;
    doctorid: string;
    patientid: string;
    timeslotid: string;
    medicalcardid: string;
    patientcame?: string;
    patientislate?: string;
    patientunacceptablebehavior?: string;
}


const FormAppointment: React.FC<DoctorAppointmentProps> = ({ booking }) => {

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
                    label={<p style={{ fontSize: "13px" }}> Неподобающее <br /> поведение </p>}
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
    );
}



export default FormAppointment;
