import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse } from 'antd';
//import SelectSlot from '../Components/patientSelectSlotComponent';
import DoctorShedule from '../Components/doctorSheduleComponent';



//  Выбрать специальность - выбрать врача - выбрать слот
//  Все мои записи
//  Все мои посещения


const items: CollapseProps['items'] = [
    {
        key: '1',
        label: 'Запись к врачу',
        children: <DoctorShedule></DoctorShedule>
    },
    {
        key: '2',
        label: 'Мои записи к врачам',
        children: <p>xxx</p>
    },
    {
        key: '3',
        label: 'Мои посещения врачей',
        children: <p>ups...</p>,
    }
];

const CollapseElement: React.FC = () => <Collapse accordion items={items} />;

export default CollapseElement;