﻿import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse } from 'antd';
//import DoctorRegistration from '../Components/RegistrationComponent';
import SelectSlot from '../Components/patientSelectSlotComponent';


//  Выбрать специальность - выбрать врача - выбрать слот
//  Все мои записи
//  Все мои посещения


const items: CollapseProps['items'] = [
    {
        key: '1',
        label: 'Запись к врачу',
        children: <SelectSlot></SelectSlot>,
    },
    {
        key: '2',
        label: 'Мои записи к врачам',
        children: <p>лылылылы</p>,
    },
    {
        key: '3',
        label: 'Мои посещения врачей',
        children: <p>ups...</p>,
    }
];

const CollapseElement: React.FC = () => <Collapse accordion items={items} />;

export default CollapseElement;