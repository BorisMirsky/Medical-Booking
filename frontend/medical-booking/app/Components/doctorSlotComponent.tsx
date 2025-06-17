/* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import {
    getDoctorsBySpeciality,
    TimeSlotCreateRequest,
    CreateShedule} from "@/app/Services/service";    
import { Doctor } from "@/app/Models/Doctor";
import { Select, Space, DatePicker, Button, Form, FormProps } from 'antd';
import { useEffect, useState } from "react";
//import type { InputNumberProps } from 'antd';
import { InputNumber } from 'antd';
import { TimePicker } from 'antd';
import dayjs from 'dayjs';
//import moment from 'moment';




export default function CreateSlots() {
    //const [currentRole, setCurrentRole] = useState("");
    const [doctors, setDoctors] = useState<Doctor[]>([]);


    useEffect(() => {
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
    }, []);

    const [form] = Form.useForm();

    const onFinishFailed: FormProps<TimeSlotCreateRequest>['onFinishFailed'] = (errorInfo) => {
        console.log('onFinishFailed:', errorInfo);
    }


    const onFinish: FormProps<TimeSlotCreateRequest>['onFinish'] = (values) => {
        const request: TimeSlotCreateRequest = {
            id: '',
            speciality: '',
            username: '',
            startday: '',
            days: '',
            timestart: '',
            timestop: '',
            timechunk: ''
        };

        for (const variable in doctors) {
            if (doctors[variable].userName == values.username && doctors[variable].speciality == values.speciality) {
                request.id = doctors[variable].id;
            }
        }
        request.speciality = values.speciality;
        request.username = values.username;
        request.startday = dayjs(values.startday).format('YYYY-MM-DD');
        request.days = values.days;
        request.timestart = dayjs(values.timestart).format('HH-mm');
        request.timestop = dayjs(values.timestop).format('HH-mm');
        request.timechunk = dayjs(values.timechunk).format('mm');
        CreateShedule(request);
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

    const doctorsData = doctors.map((doctor, index) => ({
        key: index,
        value: doctor.userName,
        label: doctor.userName
    }));

    //const handleSelectName = (value: string) => {
    //    //console.log(`handleSelectName ${value}`);
    //    for (const variable in doctors) {
    //        if (doctors[variable].userName == value) {
    //            console.log(`!!!!!!!!!!!!1 `, doctors[variable].id);
    //        }
    //    }
    //};

    const timeFormat = 'HH:mm';
    const timeFormat1 = 'mm';

    const myOptions: number[] = [];  
    for (let i = 1; i <= 50; i++) {
        myOptions.push(i);
    }
    
    //const handleTimeStart = (value: string) => {
    //    console.log(`handleTimeStart ${value}`);
    //}

    //const handleTimeStop = (value: dayjs) => {
    //    console.log(`handleTimeStop ${value.toString()}`);
    //}


    return (
        <Form
            name="basic"
            labelCol={{ span: 8 }}
            wrapperCol={{ span: 16 }}
            style={{ maxWidth: 600 }}
            onFinish={onFinish}
            onFinishFailed={onFinishFailed}
            autoComplete="off"
            form={form}
        >

            <Form.Item<TimeSlotCreateRequest>
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

            <Form.Item<TimeSlotCreateRequest>
                label="Имя врача"
                name="username"
                rules={[{ required: true, message: 'Please input username!' }]}
            >
                <Select
                    style={{ width: 200 }}
                    //onChange={handleSelectName}
                    options={doctorsData}
                />
            </Form.Item>

            <Form.Item<TimeSlotCreateRequest>
                label="Первый день расписания"
                name="startday"
                rules={[{ required: true, message: 'Please input startday!' }]}
            >                      
                <DatePicker
                />
            </Form.Item>

            <Form.Item<TimeSlotCreateRequest>
                label="Сколько рабочих дней (до 50)"
                name="days"
                rules={[{ required: true, message: 'Please input days!' }]}
            >             
                    <InputNumber
                        min={1}
                        max={50}
                    />
            </Form.Item>

            <Form.Item<TimeSlotCreateRequest>
                label="Начало рабочего дня"
                name="timestart"
                rules={[{ required: true, message: 'Please input timestart!' }]}
            >  
                    <TimePicker
                        format={timeFormat}
                    />
            </Form.Item>

            <Form.Item<TimeSlotCreateRequest>
                label="Окончание рабочего дня"
                name="timestop"
                rules={[{ required: true, message: 'Please input timestop!' }]}
            >  
                    <TimePicker
                        format={timeFormat}
                    />
            </Form.Item>
 
            <Form.Item<TimeSlotCreateRequest>
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
                        //onClick={handleCreateShedule}
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

