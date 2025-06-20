///* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import {
    getDoctorsBySpeciality, DoctorSheduleRequest,
    getSlotsByDoctorId
} from "@/app/Services/service";   
import { Doctor } from "@/app/Models/Doctor";
import { Slot } from "@/app/Models/Slot";
import { Select, Space, DatePicker, Button, Form, FormProps } from 'antd';
import { useEffect, useState } from "react";
//import dayjs from 'dayjs';
//import { Dayjs } from 'dayjs';   
import moment from "moment";   //, { Moment }
//import * as moment from 'moment'


export default function DoctorShedule() {
    //const [currentRole, setCurrentRole] = useState("");
    const [doctors, setDoctors] = useState<Doctor[]>([]);
    const [slots, setSlots] = useState<Slot[]>([]);
    const doctorWorkingDays = new Set(); 


    //useEffect(() => {
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
    //}, []);

    const [form] = Form.useForm();

    const onFinishFailed: FormProps<DoctorSheduleRequest>['onFinishFailed'] = (errorInfo: object) => {
        console.log('onFinishFailed:', errorInfo);
    }


    const onFinish: FormProps<DoctorSheduleRequest>['onFinish'] = (values: DoctorSheduleRequest) => {
        console.log('values ', values);
        console.log('doctorWorkingDays ', doctorWorkingDays);
        form.resetFields();
    }


    //                            выбор специальности
    const handleSelectSpeciality = (value: string) => {
        setDoctors([]);
        const getDoctors = async () => {
            const responce = await getDoctorsBySpeciality(value);
            setDoctors(responce);
        }
        getDoctors();
    };


    //                                 выбор врача
    const doctorsData = doctors.map((doctor: Doctor, index: number) => ({
        key: index,
        value : doctor.userName,
        label: doctor.userName
    }));


    const handleSelectDoctor = (value: string) => {
        let id: string = '';
        for (const variable in doctors) {
            if (doctors[variable].userName == value) {
                {
                    id = doctors[variable].id;
                }
            }
        }
        setSlots([]);
        const getSlots = async () => {
            const responce = await getSlotsByDoctorId(id);
            setSlots(responce);  
        }
        getSlots();
    }; 



    // need for !disabled array
    //const uniqueDays = async (mySlots: object) => {
    //    for (const variable in mySlots) {
    //        const day = mySlots[variable as keyof typeof mySlots].datetimeStart.split(" ")[0];
    //        doctorWorkingDays.add(day);
    //    }
    //};



    //function disabledDate(current: object) {               //Dayjs
    //    //return current && current < moment().endOf('day');
    //    const customDate = '2025-25-06';
    //    //console.log('typeof current ', typeof current);
    //    return current && current == moment(customDate, "YYYY-MM-DD");
    //}



    //                   выбор даты
    // должен возвращать 'day' : [slots...]
    const selectDate = (value: string) => {
        console.log("selected date", value);
        console.log("selected date", moment(value).format("M/D/YYYY"));
        console.log("slots", slots);
    };



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
                    onChange={handleSelectDoctor}
                />
            </Form.Item>

            <Form.Item<DoctorSheduleRequest>
                label="Выбрать день"
                name="day"
                rules={[{ required: true, message: 'Please input startday!' }]}
            >
                <DatePicker
                    format="YYYY-MM-DD"
                    //disabledDate={disabledDate}
                    onChange={selectDate}
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

