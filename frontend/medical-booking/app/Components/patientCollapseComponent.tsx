import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse } from 'antd';
import DoctorShedule from '../Components/doctorSheduleComponent';
import PatientBookings from '../Components/patientMyBookingsComponent';
import PatientMyAppointments from '../Components/patientMyAppointmentsComponent';
import { useState } from "react";           
import { Slot } from "@/app/Models/Slot";   



const CollapseElement: React.FC = () => {
    const [slots, setSlots] = useState<Array<Slot>>([]);
    const [numbers, setNumbersAction] = useState<number[]>([]);

    const updateSlots = (newSlots: Slot[]): void => {
        setSlots(newSlots);
    };


    const items: CollapseProps['items'] = [
        {
            key: '1',
            label: 'Запись к врачу',
            children: <DoctorShedule
                numbers={numbers}
                setNumbersAction={setNumbersAction}
                slots={slots}          
                updateSlots={updateSlots} 

            />
        },
        {
            key: '2',
            label: 'Мои записи к врачам (возможность  отмены)',
            children: <PatientBookings />
        },
        {
            key: '3',
            label: 'Мои прошедшие посещения врачей',
            children: <PatientMyAppointments />,
        }
    ];

    return (
        <div>

                <Collapse accordion items={items} />

        </div>
        );
    }

export default CollapseElement;