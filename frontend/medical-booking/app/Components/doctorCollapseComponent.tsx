import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse } from 'antd';
//import DoctorRegistration from '../Components/RegistrationComponent';
//import SelectSlot from '../Components/patientSelectSlotComponent';
import DoctorSheduleWatchOnly from '../Components/doctorSheduleWatchOnlyComponent';

//  Выбрать специальность - выбрать врача - выбрать слот
//  Все мои записи
//  Все мои посещения


const items: CollapseProps['items'] = [
    {
        key: '1',
        label: 'Расписание врача',
        children: <DoctorSheduleWatchOnly></DoctorSheduleWatchOnly>,
    },
    {
        key: '2',
        label: 'Приём пациента',
        children: <p>лылылылы</p>,
    },
    {
        key: '3',
        label: 'Отработанные посещения',
        children: <p>лылылылы</p>,
    },
    {
        key: '4',
        label: 'Статистика врача',
        children: <p>ups...</p>,
    }
];

const CollapseElement: React.FC = () => <Collapse accordion items={items} />;

export default CollapseElement;