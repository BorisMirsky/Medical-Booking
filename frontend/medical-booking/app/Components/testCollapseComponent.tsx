import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse, Button } from 'antd';
import moment from 'moment';
import { useState } from 'react';

interface commonProps {
    value1: number;
    value2: number;
}


const myProps: commonProps = {
    value1: 0,
    value2: 0,
}


//  child 1
export function Element1(props: any) {
    const [value1, setCount] = useState(0);
    const value2 = props.value2;
    const incrementCount = () => {
        setCount(value1 => value1 + 1);
    };
    const formattedNow = moment().format('YYYY-MM-DD HH:mm:ss');

    return (
        <div>
            <p>{formattedNow}</p>
            <p>value1 {value1}</p>
            <p>value2 {value2}</p>
            <div>
                <Button onClick={ incrementCount }>Button1
                    </Button>
            </div>
        </div>
    );
}


//  child 2
export function Element2(props: any) {
    const [value2, setCount] = useState(0);
    const value1 = props.value1;
    const incrementCount = () => {
        setCount(value2 => value2 + 1);
    };
    const formattedNow = moment().format('YYYY-MM-DD HH:mm:ss');

    return (
        <div>
            <p>{formattedNow}</p>
            <p>value1 {value1}</p>
            <p>value2 {value2}</p>
            <div>
                <Button onClick={incrementCount}>Button2
                </Button>
            </div>
        </div>
    );
}


//  parent
const items: CollapseProps['items'] = [
    {
        key: '1',
        label: 'panel 1',
        children: <Element1 props={myProps}>{"Element1"}</Element1>,
    },
    {
        key: '2',
        label: 'panel 2',
        children: <Element2 props={myProps}>{"Element2"}</Element2>,
    }
];


const TestCollapseElement: React.FC = () => {
    return (
        <Collapse accordion items={items} />
    );
}


export default TestCollapseElement;