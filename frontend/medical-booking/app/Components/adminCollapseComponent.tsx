import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse } from 'antd';
import DoctorRegistration from '../Components/RegistrationComponent';
import CreateSlots from '../Components/doctorSlotComponent';



const items: CollapseProps['items'] = [
    {
        key: '1',
        label: 'Регистрация врача',
        children: <DoctorRegistration></DoctorRegistration>,
    },
    {
        key: '2',
        label: 'Создать расписание для врача',
        children: <CreateSlots></CreateSlots>,
    },
    {
        key: '3',
        label: 'Просмотр расписания врача',
        children: <p>Выбор врача --- Выбор дня --- Все слоты</p>,
    }
];

const CollapseElement: React.FC = () => <Collapse accordion items={items} />;

export default CollapseElement;