import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse } from 'antd';
import DoctorRegistration from '../Components/RegistrationComponent';
import SelectDoctorBySpeciality from '../Components/SelectComponent';




const items: CollapseProps['items'] = [
    {
        key: '1',
        label: 'Регистрация врача',
        children: <DoctorRegistration></DoctorRegistration>,
    },
    {
        key: '2',
        label: 'Создать расписание для врача',
        children: <SelectDoctorBySpeciality></SelectDoctorBySpeciality>,
    }
];

const CollapseElement: React.FC = () => <Collapse accordion items={items} />;

export default CollapseElement;