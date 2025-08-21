import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse } from 'antd';
import DoctorCreateAppointment from '../Components/doctorCreateAppointmentComponent';
import DoctorAppointment from '../Components/doctorAppointmentComponent';
import DoctorSheduleWatchOnly from '../Components/doctorSheduleWatchOnlyComponent';
import { useState } from "react";
import { Booking } from "@/app/Models/Booking";




const CollapseElement: React.FC = () => {
    const [activeKey, setActiveKey] = useState<string | string[]>();
    const [sharedBooking, setSharedBooking] = useState<Booking | undefined>(undefined);
    //const [sharedBooking, setSharedBooking] = useState<Booking | undefined>();

    const handleNext = (booking: Booking) => {
        setSharedBooking(booking);
        setActiveKey("3");
    };

    const items: CollapseProps['items'] = [
        {
            key: '1',
            label: 'Моё расписание',
            children: <DoctorSheduleWatchOnly></DoctorSheduleWatchOnly>,
        },
        {
            key: '2',
            label: 'Мои бронирования. Создать "Приём пациента"',
            children: <DoctorCreateAppointment onNext={handleNext}></DoctorCreateAppointment>,
        },
        {
            key: '3',
            label: 'Приём пациента',
            children: <DoctorAppointment booking={sharedBooking} />,
        }
    ];

    const handleChange = (key: string | string[]) => {
        setActiveKey(key);
        if (key !== '2') {
            setSharedBooking(undefined);
        }
    };

    return (
        <Collapse
            accordion
            onChange={handleChange}
            items={items}
            activeKey={activeKey}
        />
    );
};


export default CollapseElement;