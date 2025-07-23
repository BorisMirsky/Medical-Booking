import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse } from 'antd';
import DoctorShedule from '../Components/doctorSheduleComponent';
import PatientBookings from '../Components/patientMyBookingsComponent';
import PatientMyAppointments from '../Components/patientMyAppointmentsComponent';
import { useState, useEffect } from "react";            //useEffect
import { DoctorSheduleProps1  } from "@/app/Services/service";



const CollapseElement: React.FC = () => {
    //const [numbers, setNumbers] = useState([]);
    const [count, setCount] = useState<number>(0);
    //console.log("CollapseElement counter", counter);

    const numbers: number[] = []; 
    useEffect(() => {
        numbers.push(count);
        console.log(numbers); 
    }, [count]);

    //const props: DoctorSheduleProps = {
    //    numbers: numbers,
    //    setNumbers: setNumbers,
    //    slots: []
    //}

    const props1: DoctorSheduleProps1 = {
        count: count,
        setCount: setCount,
        slots: []
    }

    const items: CollapseProps['items'] = [
        {
            key: '1',
            label: 'Запись к врачу',
            children: <DoctorShedule
                {...props1}
            />
        },
        {
            key: '2',
            label: 'Мои записи к врачам (возможность  отмены)',
            children: <PatientBookings />
        },
        {
            key: '3',
            label: 'Мои посещения врачей',
            children: <PatientMyAppointments />,
        }
    ];

    return (
            <Collapse accordion items={items} />
        );
    }

export default CollapseElement;