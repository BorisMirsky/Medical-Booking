///* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import {
    getDoctorsBySpeciality, DoctorSheduleRequest, getSlotsByDoctorId //, uniqueDays
} from "@/app/Services/service";   
import { Doctor } from "@/app/Models/Doctor";
import { Slot } from "@/app/Models/Slot";
import { Select, Space, DatePicker, Button, Form, FormProps } from 'antd';
import { useState, useEffect } from "react";  
import dayjs, { Dayjs } from 'dayjs'; 
import moment from "moment";   




export default function DoctorShedule() {
    //const [currentRole, setCurrentRole] = useState("");
    const [doctors, setDoctors] = useState<Doctor[]>([]);
    const [slots, setSlots] = useState<Slot[]>([]);
    //const [uniqueDays, setUniqueDays] = useState<Slot[]>([]);
    //const doctorWorkingDays = new Set(); 


    useEffect(() => {
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
        //processSlots(slots);
        uniqueDays(slots);
        //console.log('slots1 from useEffect ', slots1);
    }, [slots]);


    const [form] = Form.useForm();

    const onFinishFailed: FormProps<DoctorSheduleRequest>['onFinishFailed'] = (errorInfo: object) => {
        console.log('onFinishFailed:', errorInfo);
    }


    const onFinish: FormProps<DoctorSheduleRequest>['onFinish'] = (values: DoctorSheduleRequest) => {
        console.log('values ', values);
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
    }


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




    //let allowedDates1 = new Array<Dayjs>();

    const uniqueDays = (slotsArray: Slot[]) => {
        const mySet = new Set<string>();
        for (let i = 0; i < slotsArray.length; i++) {
            let elem = slotsArray[i].datetimeStart.split(" ")[0];
            let elem1 = elem.split("/");


            //mySet.add(slotsArray[i].datetimeStart.split(" ")[0]);
        }
        console.log('mySet ', mySet);                    // {'6/26/2025', '6/27/2025'}
        const allowedDates1 = Array.from(mySet);
        allowedDates1.map(date => dayjs(date, 'YYYY-DD-MM'));
        console.log('allowedDates1 ', allowedDates1); //['6/26/2025', '6/27/2025']
        //return allowedDates; 
    }



    //const allowedDates = uniqueDays(slotsArray); 
    //processSlots


    const allowedDates = ['2025-27-06', '2025-30-06', '2025-05-07', '2025-10-07'].map(date =>
        dayjs(date, 'YYYY-DD-MM')
    );

    function disabledDateFunc(current: Dayjs): boolean {
        //console.log('from disabledDateFunc  ', allowedDates);
        return current && !allowedDates.some(allowed => allowed.isSame(current, 'day'));
    }


    //                   выбор даты
    // должен возвращать 'day' : [slots...]
    const selectDate = (value: string) => {
        const selectedDay = moment(value.toString()).format("MM/DD/YYYY");
        console.log(selectedDay);
        //console.log('selectDate ', slots[2]);
        //console.log(doctorWorkingDays);
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
                        onChange={selectDate}
                        disabledDate={disabledDateFunc}
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

