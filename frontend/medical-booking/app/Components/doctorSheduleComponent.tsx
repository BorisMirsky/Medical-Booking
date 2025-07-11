﻿
"use client"

import React from 'react';
import "../globals.css";
import {
    getDoctorsBySpeciality, DoctorSheduleRequest, getSlotsByDoctorId 
} from "@/app/Services/service";   
import { Doctor } from "@/app/Models/Doctor";
import { Slot } from "@/app/Models/Slot";         
import TimeslotsButtons from "../Components/timeslotsButtonsComponent"; 
import { Select, Space, DatePicker, Button, Form, FormProps } from 'antd';
import { useState, useEffect} from "react";  
import dayjs, { Dayjs } from 'dayjs'; 
import moment from "moment";   



export default function DoctorShedule() {
    //const [currentRole, setCurrentRole] = useState("");
    //const [state, setState] = useState(0);
    const [doctors, setDoctors] = useState<Doctor[]>([]);
    const [slots, setSlots] = useState<Slot[]>([]);
    const [slots1, setSlots1] = useState<Slot[]>([]);
    const [buttonsFlag, setButtonsFlag] = useState<number>(0);
    //const [count, setCount] = useState(0);


    useEffect(() => {
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
        processSlots(slots);
        // eslint-disable-next-line react-hooks/exhaustive-deps   
    }, [slots]);


    const [form] = Form.useForm();

    const onFinishFailed: FormProps<DoctorSheduleRequest>['onFinishFailed'] = (errorInfo: object) => {
        console.log('onFinishFailed:', errorInfo);
    }


    const onFinish: FormProps<DoctorSheduleRequest>['onFinish'] = (values: DoctorSheduleRequest) => {
        console.log('onFinish ', values);
        setSlots1(processedSlots[selectedDay]);
        setButtonsFlag(1);
    }


    //                      поле 'выбор специальности'
    const handleSelectSpeciality = (value: string) => {
        setDoctors([]);
        const getDoctors = async () => {
            const responce = await getDoctorsBySpeciality(value);
            setDoctors(responce);
        }
        getDoctors();
    }


    //                        поле 'выбор врача'
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

    // даты приёма врача
    const uniquePrefixes = new Set(slots.map(item => item.datetimeStart.split(' ')[0]));

    interface MyResult {
        [key: string]: Array<Slot>;
    }

    const processedSlots: MyResult = {};

    // преобразование массива слотов
    const processSlots = (data: Array<Slot>) => {
        uniquePrefixes.forEach(prefix => {
            processedSlots[prefix] = data.filter(item => item.datetimeStart.startsWith(prefix));
        })
    };

    // даты для календаря
    const allowedDates = Array.from(uniquePrefixes.values())
        .map(date => dayjs(date, 'YYYY-DD-MM'));

    function disabledDateFunc(current: Dayjs): boolean {
        return current && !allowedDates.some(allowed => allowed.isSame(current, 'day'));
    };


    //                        поле 'выбор даты'
    let selectedDay: string = "";

    const selectDate = (value: string) => {
        // Обработка удаления даты через 'x'
        try {
            selectedDay = moment(value.toString()).format('YYYY-DD-MM');
        } catch (e) {
            console.log(e);
        }
    };

    const forceRerender = () => {
        setSlots1([]);
    }

    return (
            <div>
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
                        className="custom-datepicker"
                    />

                </Form.Item>

                <Space size='large'>

                    <Button
                        htmlType="submit"
                        type="default"
                    >
                        Получить расписание
                    </Button>

                    <Button
                        htmlType="reset"
                        onClick={forceRerender}
                    >
                        Сбросить
                    </Button>

                </Space>

            </Form>

            <br></br><br></br><br></br>
            <div>
                {
                    (buttonsFlag === 0) ? (
                        <div> </div>
                    ) : (
                            <div>
                                <TimeslotsButtons
                                    {...slots1}
                                />
                            </div>
                    )
                }
            </div>
        </div>
        );
}

