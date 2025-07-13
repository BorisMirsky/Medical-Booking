import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse } from 'antd';
import DoctorShedule from '../Components/doctorSheduleComponent';
import PatientBookings from '../Components/patientMyBookingsComponent';
//import { useState } from "react";          //useCallback




const items: CollapseProps['items'] = [
    {
        key: '1',
        label: 'Запись к врачу',
        children: <DoctorShedule />
    },
    {
        key: '2',
        label: 'Мои записи к врачам (возможность  отмены)',
        children: <PatientBookings />
    }, 
    {
        key: '3',
        label: 'Мои посещения врачей',
        children: <p>ups...</p>,
    }
];


const CollapseElement: React.FC = () =>
{
    return (
        <Collapse accordion items={items} />
    );
}

export default CollapseElement;