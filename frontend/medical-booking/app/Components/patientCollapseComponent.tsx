import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse } from 'antd';
import DoctorRegistration from '../Components/RegistrationComponent';
import SelectDoctorBySpeciality from '../Components/SelectComponent';




const items: CollapseProps['items'] = [
    {
        key: '1',
        label: 'Запись к врачу',
        children: <p></p>,
    },
    {
        key: '2',
        label: 'Ещё там шняга какая-то',
        children: <p></p>,
    },
    {
        key: '3',
        label: 'И ещё',
        children: <p>ups...</p>,
    }
];

const CollapseElement: React.FC = () => <Collapse accordion items={items} />;

export default CollapseElement;