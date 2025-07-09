import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse } from 'antd';
import DoctorCreateAppointment from '../Components/doctorCreateAppointmentComponent';
import DoctorSheduleWatchOnly from '../Components/doctorSheduleWatchOnlyComponent';



const items: CollapseProps['items'] = [
    {
        key: '1',
        label: 'Расписание врача',
        children: <DoctorSheduleWatchOnly></DoctorSheduleWatchOnly>,
    },
    {
        key: '2',
        label: 'Мои бронирования. Создать "Приём пациента"',
        children: <DoctorCreateAppointment></DoctorCreateAppointment>,
    },
    {
        key: '3',
        label: 'Приём пациента',
        children: <p>лылылылы</p>,
    },
    {
        key: '4',
        label: 'Отработанные посещения',
        children: <p>лылылылы</p>,
    },
    {
        key: '5',
        label: 'Статистика врача',
        children: <p>ups...</p>,
    }
];

const CollapseElement: React.FC = () => {
    //const [activeKey, setActiveKey] = useState(1);
    //function handleClick(key) {
    //    setActiveKey(key);
    //}


    return (
        <Collapse
            accordion
            items={items} />
    );
};

export default CollapseElement;