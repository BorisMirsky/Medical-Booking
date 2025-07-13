import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse, Button, Space } from 'antd';  
import { useState } from "react";


let value1 = false;
let value2 = false;
let value3 = false;


const Element3 = () => {
    return (
        <div>
            <p>Дочерний блок для коллапса</p>
            <p>Родительский для блока с кнопками</p>
            <br></br><br></br>
            <div>
                <ChildElement3 />
            </div>
        </div>
    );
}

const ChildElement3 = () => {

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
        <p>Grandchild для коллапса</p>
        <p>child для того что выше</p>
            <br></br>
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

const Element4 = () => {
    return (
        <div><p>Дочерний блок № 2 для коллапса</p>
            <br></br><br></br>
            <div>
                <p>value1 <b>{value1.toString()}</b></p>
                <p>value2 <b>{value2.toString()}</b></p>
                <p>value3 <b>{value3.toString()}</b></p>
            </div>
        </div>
    );
}

////////////

interface Car {
    type: string;
    model: string;
    year: number;
}

interface Element1Props {
    onNext: (car: Car) => void;
}

const Element1: React.FC<Element1Props> = ({ onNext }) => {
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

interface Element2Props {
    car?: Car;
}

const Element2: React.FC<Element2Props> = ({ car }) => {
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
            children: <Element1 onNext={handleNext} />
        },
        {
            key: '2',
            label: 'Element2',
            children: <Element2 car={sharedCar} />
        },
        {
            key: '3',
            label: 'Element3',
            children: <Element3 />
        },
        {
            key: '4',
            label: 'Element4',
            children: <Element4 />
        }
    ];

    const handleChange = (key: string | string[]) => {
        setActiveKey(key);
        // Optional: clear car data if user manually opens panel 2
        if (key !== '2') {
            setSharedCar(undefined);
        }
    };

    return (
        <Collapse activeKey={activeKey} onChange={handleChange} items={items} />
    );
};

export default CollapseComponent;