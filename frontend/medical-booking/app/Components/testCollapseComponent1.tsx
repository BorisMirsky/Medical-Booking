import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse, Button, Space } from 'antd';
import { useState } from "react";


let value1 = false;
let value2 = false;
let value3 = false;


const Element1 = () => {

    const handleClick = (key: number) => {
        if (key == 1) {
            value1 = true
            console.log('value1 ', value1.toString())
        }
        else if (key == 2) {
            value2 = true
            console.log('value2 ', value2.toString())
        }
        else {
            value3 = true
            console.log('value3 ', value3.toString())
        }
    }

    return (
        <div>
            <div>
                <Space >
                    <Button
                        onClick={() => handleClick(1)}
                        color={!value1 ? "primary" : "danger"}
                        variant="solid"
                    >Button1
                    </Button>
                    <Button
                        onClick={() => handleClick(2)}
                        color={!value2 ? "primary" : "danger"}
                        variant="solid"
                    >Button2
                    </Button>
                    <Button
                        onClick={() => handleClick(3)}
                        color={!value3 ? "primary" : "danger"}
                        variant="solid"
                    >Button3
                    </Button>
                </Space>
            </div>
        </div>
    );
}

const Element2 = () => {
    return (
        <div>
            <div>
                <p>value1 <b>{value1.toString()}</b></p>
                <p>value2 <b>{value2.toString()}</b></p>
                <p>value3 <b>{value3.toString()}</b></p>
            </div>
        </div>
    );
}

const Element3 = () => {
    return (
        <div>empty
        </div>
    );
}

////////////////

interface Car {
    type: string;
    model: string;
    year: number;
}

interface Element4Props {
    onNext: (car: Car) => void;
}

const Element4: React.FC<Element4Props> = ({ onNext }) => {
    const car: Car = {
        type: "Toyota",
        model: "Corolla",
        year: 2009
    };

    return (
        <div>
            <Button onClick={() => onNext(car)}>Expand Next Panel</Button>
        </div>
    );
};

interface Element5Props {
    car?: Car;
}

const Element5: React.FC<Element5Props> = ({ car }) => {
    if (!car) {
        return <div>Go back to the first component and click the button</div>;
    }

    return (
        <div>
            <div><strong>Car Type:</strong> {car.type}</div>
            <div><strong>Model:</strong> {car.model}</div>
            <div><strong>Year:</strong> {car.year}</div>
        </div>
    );
};

const CollapseComponent: React.FC = () => {
    const [activeKey, setActiveKey] = useState<string | string[]>();
    const [sharedCar, setSharedCar] = useState<Car | undefined>(undefined);

    const handleNext = (car: Car) => {
        setSharedCar(car);
        setActiveKey("2");
    };

    const items: CollapseProps['items'] = [
        {
            key: '1',
            label: 'Element1',
            children: <Element1 />
        },
        {
            key: '2',
            label: 'Element2',
            children: <Element2 />
        },
        {
            key: '3',
            label: 'Element3',
            children: <Element3 />
        },
        {
            key: '4',
            label: 'Element4',
            children: <Element4 onNext={handleNext} />
        },
        {
            key: '5',
            label: 'Element5',
            children: <Element5 car={sharedCar} />
        },
    ];

    const handleChange = (key: string | string[]) => {
        setActiveKey(key);
        // Optional: clear car data if user manually opens panel 2
        if (key !== '4') {
            setSharedCar(undefined);
        }
    };


    return (
        <Collapse items={items} onChange={handleChange} activeKey={activeKey} />
    );
};

export default CollapseComponent;


