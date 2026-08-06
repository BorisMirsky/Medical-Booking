"use client"

import React from 'react';
import "@/app/globals.css";
import {
    getDoctorsBySpeciality, DoctorSheduleRequest,
    getSlotsByDoctorId, DoctorSheduleProps
} from "@/app/Services/service";
import { Doctor } from "@/app/Models/Doctor";
import { Slot } from "@/app/Models/Slot";
import TimeslotsButtons from "./timeslotsButtonsComponent";
import { Select, Space, DatePicker, Button, Form, FormProps } from 'antd';
import { useState, useEffect } from "react";
import dayjs, { Dayjs } from 'dayjs';
import moment from "moment";



export default function DoctorShedule({
                                        numbers,
                                        setNumbersAction,
                                        slots: parentSlots,
                                        updateSlots
                                    }: DoctorSheduleProps) {
    const [doctors, setDoctors] = useState<Doctor[]>([]);
    const [slots_, setSlots] = useState<Slot[]>([]);
    const [slots1, setSlots1] = useState<Slot[]>([]);
    const [buttonsFlag, setButtonsFlag] = useState<number>(0);
    const [selectedDayState, setSelectedDayState] = useState<string>("");
    // состояние для хранения обработанных слотов
    const [processedSlots, setProcessedSlots] = useState<{ [key: string]: Slot[] }>({});

    useEffect(() => {
        if (parentSlots && parentSlots.length > 0) {
            setSlots1(parentSlots);
        }
    }, [parentSlots]);

    useEffect(() => {
        processSlots(slots_);
        // eslint-disable-next-line react-hooks/exhaustive-deps   
    }, [slots_]);

    const [form] = Form.useForm();

    const onFinishFailed: FormProps<DoctorSheduleRequest>['onFinishFailed'] = (errorInfo: object) => {
        console.log('onFinishFailed:', errorInfo);
    }

    const onFinish: FormProps<DoctorSheduleRequest>['onFinish'] = (values: DoctorSheduleRequest) => {
        if (selectedDayState && processedSlots[selectedDayState]) {
            setSlots1(processedSlots[selectedDayState]);
            setButtonsFlag(1);
        } else {
            console.log(values, "No slots found for selected day");
        }
    }

    const handleSelectSpeciality = (value: string) => {
        setDoctors([]);
        const getDoctors = async () => {
            const responce = await getDoctorsBySpeciality(value);
            setDoctors(responce);
        }
        getDoctors();
    }

    const doctorsData = doctors.map((doctor: Doctor, index: number) => ({
        key: index,
        value: doctor.userName,
        label: doctor.userName
    }));

    const handleSelectDoctor = (value: string) => {
        let id: string = '';
        for (const variable in doctors) {
            if (doctors[variable].userName == value) {
                id = doctors[variable].id;
            }
        }
        setSlots([]);
        const getSlots = async () => {
            const responce = await getSlotsByDoctorId(id);
            const converted = responce.map((slot: Slot) => ({                       // ?
                ...slot,
                isBooked: slot.isBooked ? 1 : 0
            }));
            setSlots(converted);
        }
        getSlots();
    };

    const uniquePrefixes = new Set(slots_.map(item => item.datetimeStart.split(' ')[0]));


    const processSlots = (data: Array<Slot>) => {
        const newProcessedSlots: { [key: string]: Slot[] } = {};
        uniquePrefixes.forEach(prefix => {
            newProcessedSlots[prefix] = data.filter(item => item.datetimeStart.startsWith(prefix));
        });
        setProcessedSlots(newProcessedSlots);
    };

    const allowedDates = Array.from(uniquePrefixes.values())
        .map(date => dayjs(date, 'YYYY-DD-MM'));

    function disabledDateFunc(current: Dayjs): boolean {
        return current && !allowedDates.some(allowed => allowed.isSame(current, 'day'));
    };

    const selectDate = (value: string) => {
        try {
            const day = moment(value.toString()).format('YYYY-DD-MM');
            setSelectedDayState(day);
        } catch (e) {
            console.log("Error in selectDate:", e);
        }
    };

    const cleanData = () => {
        setSlots1([]);
        setButtonsFlag(0);
        setSelectedDayState("");
        setProcessedSlots({}); 
        form.resetFields();
        if (updateSlots) {
            updateSlots([]);
        }
    }

    const handleSlotsUpdate = (updatedSlots: Slot[]) => {
        setSlots1(updatedSlots);
        if (updateSlots) {
            updateSlots(updatedSlots);
        }
    }

    const props = {
        numbers: numbers,
        setNumbersAction: setNumbersAction,
        slots: slots1,
        onSlotsUpdate: handleSlotsUpdate
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
                        onClick={cleanData}
                    >
                        Сбросить
                    </Button>
                </Space>
            </Form>

            <div>
                {
                    (buttonsFlag === 0) ? (
                        <div> </div>
                    ) : (
                        <Space
                            direction="vertical"
                            size="large"
                            style={{ margin: '2rem', width: '50%' }}
                        >
                            <div>
                                <TimeslotsButtons
                                    {...props}
                                />
                            </div>
                        </Space>
                    )
                }
            </div>
        </div>
    );
}