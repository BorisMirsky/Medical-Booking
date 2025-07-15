"use client"

import React from 'react';
import {
    MedicalRecordRequest, DoctorAppointmentProps, createMedicalRecord
} from "@/app/Services/service";
import { FormProps, InputNumber, Button, Form, Input, Space } from "antd";
const { TextArea } = Input;
import "../globals.css";
import { useState } from "react";   



const FormMedicalRecord: React.FC<DoctorAppointmentProps> = ({ booking }) => {
    const [componentDisabled, setComponentDisabled] = useState<boolean>(false);
    const [form] = Form.useForm();

    const onFinishFailed: FormProps<MedicalRecordRequest>['onFinishFailed'] = (errorInfo) => {
        console.log('onFinishFailed:', errorInfo);
    }

    const onFinish: FormProps<MedicalRecordRequest>['onFinish'] = (values) => {
        const result: MedicalRecordRequest = {
            bookingid: booking.id,
            doctorid: booking.doctorId,
            patientid: booking.patientId,
            timeslotid: booking.timeslotId,
            appointmentid: booking.timeslotId,   
            symptoms: values.symptoms,
            diagnosis: values.diagnosis,
            prescribedtreatment: values.prescribedtreatment,
            visualexamination: values.visualexamination,
            referraltests: values.referraltests,
            finalcost: values.finalcost
        };
        createMedicalRecord(result);
        //console.log("FormMedicalRecord ", result);
        form.resetFields();
        setComponentDisabled(true);
    }

    return (
        <div>

            <Form
                name="basic1"
                labelCol={{ span: 8 }}
                wrapperCol={{ span: 16 }}
                style={{ maxWidth: 800 }}
                onFinish={onFinish}
                onFinishFailed={onFinishFailed}
                autoComplete="off"
                form={form}
                disabled={componentDisabled}
            >
                <Form.Item<MedicalRecordRequest>
                    label="Симптомы"
                    name="symptoms"
                    rules={[{ required: true, message: 'Надо заполнить' }]}
                >
                    <TextArea rows={4} />
                </Form.Item>

                <Form.Item<MedicalRecordRequest>
                    label="Диагноз"
                    name="diagnosis"
                    rules={[{ required: true, message: 'Надо заполнить' }]}
                >
                    <TextArea rows={4} />
                </Form.Item>

                <Form.Item<MedicalRecordRequest>
                    label="Назначенное лечение"
                    name="prescribedtreatment"
                    rules={[{ required: true, message: 'Надо заполнить' }]}
                >
                    <TextArea rows={4} />
                </Form.Item>

                <Form.Item<MedicalRecordRequest>
                    label="Осмотр"
                    name="visualexamination"
                    rules={[{ required: true, message: 'Надо заполнить' }]}
                >
                    <TextArea rows={4} />
                </Form.Item>

                <Form.Item<MedicalRecordRequest>
                    label="Дополнительные анализы"
                    name="referraltests"
                    rules={[{ required: true, message: 'Надо заполнить' }]}
                >
                    <TextArea rows={4} />
                </Form.Item>

                <Form.Item<MedicalRecordRequest>
                    label="Стоимость приёма"
                    name="finalcost"
                    rules={[{ required: true, message: 'Надо заполнить' }]}
                >
                    <InputNumber
                        min={5000}
                        max={50000}
                    />
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
    );
}


export default FormMedicalRecord;
