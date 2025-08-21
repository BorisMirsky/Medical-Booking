///* eslint-disable @typescript-eslint/no-unused-vars */
import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse } from 'antd';
import DoctorRegistration from '../Components/doctorRegistrationComponent';
import CreateShedule from '../Components/adminCreateSheduleComponent';
import DoctorShedule from '../Components/doctorSheduleComponent';
//import DoctorSheduleWatchOnly from '../Components/doctorSheduleWatchOnlyComponent';
import AllDoctors from '../Components/adminAllDoctorsComponent';
import AllPatients from '../Components/adminAllPatientsComponent';
import PatientsMisbehavior from '../Components/patientMisbehaviorComponent';
//import DisabledComponent from '../Components/disabledDateComponent';
import { Slot } from "@/app/Models/Slot";  
import { useState } from "react"; 


const CollapseElement: React.FC = () => {
    const [numbers, setNumbers] = useState<number[]>([]);
    const slots: Array<Slot> = [];


    const items: CollapseProps['items'] = [
        {
            key: '1',
            label: 'Регистрация врача',
            children: <DoctorRegistration></DoctorRegistration>,
        },
        {
            key: '2',
            label: 'Создать расписание для врача',
            children: <CreateShedule></CreateShedule>,
        },
        {
            key: '3',
            label: 'Просмотр расписания врача',
            children: <DoctorShedule numbers={numbers} setNumbers={setNumbers} slots={slots} ></DoctorShedule>
        },
        {
            key: '4',
            label: 'Пациенты с нарушениями дисциплины',
            children: <PatientsMisbehavior></PatientsMisbehavior>
        },
        {
            key: '5',
            label: 'Все пациенты',
            children: <AllPatients></AllPatients>
        },
        {
            key: '6',
            label: 'Все врачи',
            children: <AllDoctors></AllDoctors>
        }
    ];
    return (
        <div>
            <p>{numbers}</p>
            <br /><br />
            <Collapse accordion items={items} />
        </div>
    );
}

export default CollapseElement;