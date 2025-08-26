import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse } from 'antd';
import DoctorShedule from '../Components/doctorSheduleComponent';
import PatientBookings from '../Components/patientMyBookingsComponent';
import PatientMyAppointments from '../Components/patientMyAppointmentsComponent';
import { useState } from "react";            //useEffect
//import { DoctorSheduleProps  } from "@/app/Services/service";
import { Slot } from "@/app/Models/Slot";   


const CollapseElement: React.FC = () => {
    const [numbers, setNumbers] = useState<number[]>([]);
    const slots: Array<Slot> = [];


    const items: CollapseProps['items'] = [
        {
            key: '1',
            label: 'Запись к врачу',
            children: <DoctorShedule
                numbers={numbers}
                setNumbers={setNumbers}
                slots={slots}
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
            <br/><br/>
            <Collapse accordion items={items} />
        </div>
        );
    }

export default CollapseElement;