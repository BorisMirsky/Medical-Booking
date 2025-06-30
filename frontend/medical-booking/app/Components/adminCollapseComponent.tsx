///* eslint-disable @typescript-eslint/no-unused-vars */
import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse } from 'antd';
import DoctorRegistration from '../Components/RegistrationComponent';
import CreateShedule from '../Components/adminCreateSheduleComponent';
//import DoctorShedule from '../Components/doctorSheduleComponent';
import DoctorSheduleWatchOnly from '../Components/doctorSheduleWatchOnlyComponent';
import AllDoctors from '../Components/adminAllDoctorsComponent';
import AllPatients from '../Components/adminAllPatientsComponent';
//import DisabledComponent from '../Components/disabledDateComponent';



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
        children: <DoctorSheduleWatchOnly></DoctorSheduleWatchOnly>
    },
    {
        key: '4',
        label: 'Пациенты с нарушениями дисциплины (need?) ',
        children: <p>тобi пiзда, тiкай с городу</p>
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

const CollapseElement: React.FC = () => <Collapse accordion items={items} />;

export default CollapseElement;