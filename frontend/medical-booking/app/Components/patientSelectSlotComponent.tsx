﻿
"use client"

import React from 'react';
import { getDoctorsBySpeciality, DoctorSheduleRequest } from "@/app/Services/service";
import { Doctor } from "@/app/Models/Doctor";
import { Select, Space, DatePicker, Button, Form, FormProps } from 'antd';
import { useEffect, useState } from "react";
import dayjs from 'dayjs';



export default function SelectSlot() {
    //const [currentRole, setCurrentRole] = useState("");
    const [doctors, setDoctors] = useState<Doctor[]>([]);


    useEffect(() => {
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
    }, []);

    const [form] = Form.useForm();

    const onFinishFailed: FormProps<DoctorSheduleRequest>['onFinishFailed'] = (errorInfo: any) => {
        console.log('onFinishFailed:', errorInfo);
    }


    const onFinish: FormProps<DoctorSheduleRequest>['onFinish'] = (values: any) => {

        for (const variable in doctors) {
            if (doctors[variable].userName == values.username && doctors[variable].speciality == values.speciality) {
                values.id = doctors[variable].id;
            }
        }
        values.day = dayjs(values.day).format('MM-DD-YYYY');
        //getSlotsByDoctorIdAndDay(values.id, values.day)
        //console.log('values ', values);
        form.resetFields();
    }



    const handleSelectSpeciality = (value: string) => {
        setDoctors([]);
        const getDoctors = async () => {
            const responce = await getDoctorsBySpeciality(value);
            setDoctors(responce);
        }
        getDoctors();
    };

    const doctorsData = doctors.map((doctor: Doctor, index:number) => ({
        key: index,
        value: doctor.userName,
        label: doctor.userName
    }));




    return (
        <Form
            labelCol={{ span: 8 }}
            wrapperCol={{ span: 16 }}
            style={{ maxWidth: 600 }}
            onFinish={onFinish}
            onFinishFailed={onFinishFailed}
            autoComplete="off"
            form={form}
        >

            <Form.Item<DoctorSheduleRequest>
                label="Специализация врача"
                name="speciality"
                rules={[{ required: true, message: 'Please input speciality!' }]}
            >
                <Select
                    style={{ width: 200 }}
                    onChange={handleSelectSpeciality}
                    options={[
                        { value: 'Neurologist', label: 'Невролог' },
                        { value: 'Surgeon', label: 'Хирург' },
                        { value: 'Oncologist', label: 'Онколог' },
                        { value: 'Dentist', label: 'Дантист' }
                    ]}
                />
            </Form.Item>

            <Form.Item<DoctorSheduleRequest>
                label="Имя врача"
                name="username"
                rules={[{ required: true, message: 'Please input username!' }]}
            >
                <Select
                    style={{ width: 200 }}
                    options={doctorsData}
                />
            </Form.Item>

            <Form.Item<DoctorSheduleRequest>
                label="Выбрать день"
                name="day"
                rules={[{ required: true, message: 'Please input startday!' }]}
            >
                <DatePicker
                    //className="custom-datepicker"
                />
            </Form.Item>

            <Space size='large'>
                <Button
                    type="primary"
                    htmlType="submit"
                >
                    Получить расписание
                </Button>
                <Button htmlType="reset">
                    Сбросить
                </Button>
            </Space>

        </Form>

    );
}

