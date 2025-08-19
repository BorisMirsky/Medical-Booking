
"use client"

import React from 'react';
import "../globals.css";
//import { Doctor } from "@/app/Models/Doctor";
import {
    DoctorSheduleRequest, getSlotsByDoctorId   //getDoctorsBySpeciality
} from "@/app/Services/service";
//import { Doctor } from "@/app/Models/Doctor";
import { Slot } from "@/app/Models/Slot";
import TimeslotsButtonsWatchOnly from "../Components/timeslotsButtonsWatchOnlyComponent";
import { Space, DatePicker, Button, Form, FormProps } from 'antd';         
import { useState, useEffect } from "react";
import dayjs, { Dayjs } from 'dayjs';
import moment from "moment";




export default function DoctorSheduleWatchOnly() {
    const [slots_, setSlots] = useState<Slot[]>([]);            // all slots all days
    const [slots1, setSlots1] = useState<Slot[]>([]);          // slots one day
    const [buttonsFlag, setButtonsFlag] = useState<number>(0);


    useEffect(() => {
        const id = localStorage.getItem("id") || "";
        //console.log("DoctorSheduleWatchOnly ", id);
        getAllSlots(id);
        processSlots(slots_);
        // СТРОКУ НИЖЕ НЕ ТРОГАТЬ!
        // eslint-disable-next-line react-hooks/exhaustive-deps        
    }, [slots_]);


    const [form] = Form.useForm();

    const onFinishFailed: FormProps<DoctorSheduleRequest>['onFinishFailed'] = (errorInfo: object) => {
        console.log('onFinishFailed:', errorInfo);
    }

    const onFinish: FormProps<DoctorSheduleRequest>['onFinish'] = (values: DoctorSheduleRequest) => {
        console.log('onFinish ', values);
        setSlots1(processedSlots[selectedDay]);
        setButtonsFlag(1);
    }


    const getAllSlots = (id:string) => {
        setSlots([]);
        const getSlots = async () => {
            //console.log("DoctorSheduleWatchOnly ", id);
            const responce = await getSlotsByDoctorId(id);
            setSlots(responce);
        }
        getSlots();
    };



    // даты приёма врача
    const uniquePrefixes = new Set(slots_.map(item => item.datetimeStart.split(' ')[0]));


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


    //                        поле 'Выбрать день'
    let selectedDay: string = "";

    const selectDate = (value: string) => {
        // Обработка удаления даты через 'x'
        try {
            selectedDay = moment(value.toString()).format('YYYY-DD-MM');
        } catch (e) {
            console.log(e);
        }
    };


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

                    <Button htmlType="reset">
                        Сбросить
                    </Button>

                </Space>

            </Form>

            <br></br><br></br><br></br>
            <div>
                {
                    (buttonsFlag === 0) ? (
                        <div></div>
                    ) : (
                        <div>
                                <TimeslotsButtonsWatchOnly {...slots1} />
                        </div>
                    )
                }
            </div>
        </div>
    );
}

