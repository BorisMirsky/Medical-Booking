import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse, Button, Space } from 'antd';
import { useState } from "react";


let value1 = false;
let value2 = false;
let value3 = false;


interface Props {
    numbers: number[];
    setNumbers: (values: number[]) => void;
}


const Element1 = ({ numbers, setNumbers }: Props) => {

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
        setNumbers(oldNumbers => [...oldNumbers, 1]);
        //console.log("handleClick numbers ", numbers);
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


const CollapseComponent: React.FC = () => {
    const [numbers, setNumbers] = useState<number[]>([]);
    //console.log("CollapseComponent numbers ", numbers);
    const items: CollapseProps['items'] = [
        {
            key: '1',
            label: 'Element1',
            children: <Element1 numbers={numbers} setNumbers={setNumbers} />
        },
        {
            key: '2',
            label: 'Element2',
            children: <Element2 />
        }
    ];

    return (
        <div>
            <Collapse items={items} />
        </div>            
    );
};


export default CollapseComponent;