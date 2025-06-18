import React from 'react';
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
        label: 'Расписание врача',
        children: <SelectSlot></SelectSlot>,
    },
    {
        key: '2',
        label: 'Отработанные посещения',
        children: <p>лылылылы</p>,
    },
    {
        key: '3',
        label: 'Статистика врача',
        children: <p>ups...</p>,
    }
];

const CollapseElement: React.FC = () => <Collapse accordion items={items} />;

export default CollapseElement;