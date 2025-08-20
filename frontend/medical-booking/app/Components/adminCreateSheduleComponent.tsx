
"use client"

import React from 'react';
import {
    getDoctorsBySpeciality,
    SheduleCreateRequest,
    createShedule} from "@/app/Services/service";    
import { Doctor } from "@/app/Models/Doctor";
import { Select, Space, DatePicker, Button, Form, FormProps } from 'antd';
import { useEffect, useState } from "react";
import { InputNumber } from 'antd';
import { TimePicker } from 'antd';
import dayjs from 'dayjs';



export default function CreateShedule() {
    const [currentRole, setCurrentRole] = useState("");
    const [doctors, setDoctors] = useState<Doctor[]>([]);


    useEffect(() => {
        const role = localStorage.getItem("role") || "";
        setCurrentRole(role);
        console.log("CreateShedule currentRole ", currentRole, role);
    }, []);

    const [form] = Form.useForm();

    const onFinishFailed: FormProps<SheduleCreateRequest>['onFinishFailed'] = (errorInfo) => {
        console.log('onFinishFailed:', errorInfo);
    }


    const onFinish: FormProps<SheduleCreateRequest>['onFinish'] = (values) => {

        for (const variable in doctors) {
            if (doctors[variable].userName == values.username && doctors[variable].speciality == values.speciality) {
                values.doctorid = doctors[variable].id;
            }
        }
        values.startday = dayjs(values.startday).format('YYYY-MM-DD');
        values.timestart = dayjs(values.timestart).format('HH');
        values.timestop = dayjs(values.timestop).format('HH');
        values.timechunk = dayjs(values.timechunk).format('mm');
        createShedule(values);
        //console.log("createShedule(values) ", values)
        form.resetFields();
    }


    function handleSelectSpeciality(value: string) {
        setDoctors([]);
        const getDoctors = async () => {
            const responce = await getDoctorsBySpeciality(value);
            setDoctors(responce);
        }
        getDoctors();
    };

    const doctorsData = doctors.map((doctor, index) => ({
        key: index,
        value: doctor.userName,
        label: doctor.userName
    }));


    const timeFormat = 'HH';
    const timeFormat1 = 'mm';

    const myOptions: number[] = [];  
    for (let i = 1; i <= 50; i++) {
        myOptions.push(i);
    }



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

            <Form.Item<SheduleCreateRequest>
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

            <Form.Item<SheduleCreateRequest>
                label="Имя врача"
                name="username"
                rules={[{ required: true, message: 'Please input username!' }]}
            >
                <Select
                    style={{ width: 200 }}
                    options={doctorsData}
                />
            </Form.Item>

            <Form.Item<SheduleCreateRequest>
                label="Первый день расписания"
                name="startday"
                rules={[{ required: true, message: 'Please input startday!' }]}
            >                      
                <DatePicker
                />
            </Form.Item>

            <Form.Item<SheduleCreateRequest>
                label="Сколько рабочих дней (до 50)"
                name="days"
                rules={[{ required: true, message: 'Please input days!' }]}
            >             
                    <InputNumber
                        min={1}
                        max={50}
                    />
            </Form.Item>

            <Form.Item<SheduleCreateRequest>
                label="Начало рабочего дня"
                name="timestart"
                rules={[{ required: true, message: 'Please input timestart!' }]}
            >  
                    <TimePicker
                        format={timeFormat}
                    />
            </Form.Item>

            <Form.Item<SheduleCreateRequest>
                label="Окончание рабочего дня"
                name="timestop"
                rules={[{ required: true, message: 'Please input timestop!' }]}
            >  
                    <TimePicker
                        format={timeFormat}
                    />
            </Form.Item>
 
            <Form.Item<SheduleCreateRequest>
                label="Норма времени на пациента"
                name="timechunk"
                rules={[{ required: true, message: 'Please input timechunk!' }]}
            > 
                    <TimePicker
                        format={timeFormat1}
                    />
            </Form.Item>

           <Space size='large'>
                    <Button
                        type="primary"
                        htmlType="submit"
                    >
                        Создать расписание
                    </Button>
                    <Button htmlType="reset">
                        Сбросить
                    </Button>
            </Space>
            </Form>
    );
}

