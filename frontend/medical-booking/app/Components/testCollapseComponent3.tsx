import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse, Button, Space } from 'antd';
import { useState } from "react";


type ButtonStates = { [key: string]: boolean };

interface Element1Props {
    buttonStates: ButtonStates;
    onButtonClick: (key: string) => void;
}


// doctorSheduleComponent    parent
const Element1Parent = ({ buttonStates, onButtonClick }: Element1Props) => {   
    return (
        <div>
            <br />
            <br />
            <br />
            <div>
                <Element1
                    buttonStates={buttonStates}
                    onButtonClick={onButtonClick} />
            </div>
        </div>

    );
};


// TimeslotsButtonsComponent       child
const Element1 = ({ buttonStates, onButtonClick }: Element1Props) => {      //buttonStates
    return (
        <Space>
            <Button
                type="primary"
                //ghost={buttonStates.btn1}
                color={buttonStates.btn1 ? "danger" : "default"}
                onClick={() => onButtonClick('btn1')}
            >
                Button1
            </Button>
            <Button
                type="primary"
                danger={buttonStates.btn2}
                //color={(!buttonStates.btn2) ? "primary" : "danger"}
                onClick={() => onButtonClick('btn2')}
            >
                Button2
            </Button>
            <Button
                type="primary"
                danger={buttonStates.btn3}
                //color={(!buttonStates.btn3) ? "primary" : "danger"}
                onClick={() => onButtonClick('btn3')}
            >
                Button3
            </Button>
        </Space>
    );
};



// patientCollapseComponent
const CollapseComponent: React.FC = () => {
    const [buttonStates, setButtonStates] = useState<ButtonStates>({
        btn1: false,
        btn2: false,
        btn3: false,
    });

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
        //{
        //    key: '2',
        //    label: 'Element2 (See Results Here)',
        //    children: <Element2 buttonStates={buttonStates} />,
        //},
    ];

    return <Collapse defaultActiveKey={['1', '2']} items={items} />;
};


export default CollapseComponent;