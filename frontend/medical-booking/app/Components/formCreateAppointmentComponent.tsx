"use client"

import React from 'react';
import {
    createAppointment, AppointmentRequest, DoctorAppointmentProps
} from "@/app/Services/service";
//import { Booking } from "@/app/Models/Booking";
import { FormProps, Button, Form, Input, Space } from "antd";
import "../globals.css";
import { useState } from "react";      //useEffect



const FormAppointment: React.FC<DoctorAppointmentProps> = ({ booking }) => {
    const [componentDisabled, setComponentDisabled] = useState<boolean>(false);
    const [form] = Form.useForm();

    const onFinishFailed: FormProps<AppointmentRequest>['onFinishFailed'] = (errorInfo) => {
        console.log('onFinishFailed:', errorInfo);
    }

    const onFinish: FormProps<AppointmentRequest>['onFinish'] = (values) => {
        const result: AppointmentRequest = {
            bookingid: booking.id,
            doctorid: booking.doctorId,
            patientid: booking.patientId,
            timeslotid: booking.timeslotId,
            patientcame: values.patientcame,
            patientislate: values.patientislate,
            patientunacceptablebehavior: values.patientunacceptablebehavior
        };
        createAppointment(result);
        //console.log("FormAppointment ", result);
        form.resetFields();
        setComponentDisabled(true);
    }

    return (
        <div>

            <Form
                name="basic"
                labelCol={{ span: 8 }}
                wrapperCol={{ span: 16 }}
                style={{ maxWidth: 800 }}
                onFinish={onFinish}
                onFinishFailed={onFinishFailed}
                autoComplete="off"
                form={form}
                disabled={componentDisabled}
            >
                <Form.Item<AppointmentRequest>
                    label="Пациент пришёл"
                    name="patientcame"
                    rules={[{ required: true, message: 'Надо заполнить' }]}
                >
                    <Input />
                </Form.Item>

                <Form.Item<AppointmentRequest>
                    label="Пациент опоздал"
                    name="patientislate"
                    rules={[{ required: true, message: 'Надо заполнить' }]}
                >
                    <Input/>
                </Form.Item>

                <Form.Item<AppointmentRequest>
                    label={<p style={{ fontSize: "13px" }}> Неподобающее <br /> поведение </p>}
                    name="patientunacceptablebehavior"
                    rules={[{ required: true, message: 'Надо заполнить' }]}
                >
                    <Input />
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
