import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse, Button, Space } from 'antd';  
import { useState } from "react";


type ButtonStates = { [key: string]: boolean };

interface Element1Props {
    buttonStates: ButtonStates;
    onButtonClick: (key: string) => void;
}

interface Element2Props {
    buttonStates: ButtonStates;
}


// DoctorShedule 
const Element1Parent = ({ buttonStates, onButtonClick }: Element1Props) => {
    return (
        <div>
            <p>value1 <b>{buttonStates.btn1.toString()}</b></p>
            <p>value2 <b>{buttonStates.btn2.toString()}</b></p>
            <p>value3 <b>{buttonStates.btn3.toString()}</b></p>
            <br/>
            <br/>
            <br/>
        <div>
            <Element1
                buttonStates={buttonStates}
                onButtonClick={onButtonClick} />
        </div>
        </div>

    );
};



// DoctorShedule/TimeslotsButtons
const Element1 = ({ buttonStates, onButtonClick }: Element1Props) => {
    return (
        <Space>
            <Button
                type="primary"
                danger={buttonStates.btn1}
                onClick={() => onButtonClick('btn1')}
            >
                Button1
            </Button>
            <Button
                type="primary"
                danger={buttonStates.btn2}
                onClick={() => onButtonClick('btn2')}
            >
                Button2
            </Button>
            <Button
                type="primary"
                danger={buttonStates.btn3}
                onClick={() => onButtonClick('btn3')}
            >
                Button3
            </Button>
        </Space>
    );
};



// PatientBookings
const Element2 = ({ buttonStates }: Element2Props) => {
    return (
        <div>
            <p>value1 <b>{buttonStates.btn1.toString()}</b></p>
            <p>value2 <b>{buttonStates.btn2.toString()}</b></p>
            <p>value3 <b>{buttonStates.btn3.toString()}</b></p>
        </div>
    );
};



// patientCollapseComponent
const CollapseComponent: React.FC = () => {
    // State is "lifted up" to the parent component
    const [buttonStates, setButtonStates] = useState<ButtonStates>({
        btn1: false,
        btn2: false,
        btn3: false,
    });

    // This function updates the state and is passed to the child
    const handleButtonClick = (key: string) => {
        setButtonStates(prevStates => ({
            ...prevStates,
            [key]: true,
        }));
    };

    const items: CollapseProps['items'] = [
        {
            key: '1',
            label: 'Element1 (Click Buttons Here)',
            children: <Element1Parent
                buttonStates={buttonStates}
                onButtonClick={handleButtonClick} />,
        },
        {
            key: '2',
            label: 'Element2 (See Results Here)',
            children: <Element2 buttonStates={buttonStates} />,
        },
    ];

    return <Collapse defaultActiveKey={['1', '2']} items={items} />;
};


export default CollapseComponent;