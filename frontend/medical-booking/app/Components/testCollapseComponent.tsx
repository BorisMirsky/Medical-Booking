import React from 'react';
import type { CollapseProps } from 'antd';
import { Collapse, Button, Space } from 'antd';
//import { useState } from 'react';

let value1 = false;
let value2 = false;
let value3 = false;



//  child 1
export function ChildElement1() {

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
        <p>Это дочерний блок с тремя кнопками</p>
            <br></br>
            <div>
                <Space>
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


//  child 1
export function Element1() {
    return (
        <div>
            <p>Это родительский блок.</p>
            <p>Выглядит бессмысленно, но надо сымитировать вложенность</p>
            <br></br><br></br>
            <div>
              <ChildElement1/>
            </div>
        </div>
    );
}







//  child 2
export function Element2() {
    //const [value2, setCount] = useState(0);
    //const value1 = props.value1;
    //const incrementCount = () => {
    //    setCount(value2 => value2 + 1);
    //};
    //const formattedNow = moment().format('YYYY-MM-DD HH:mm:ss');

    return (
        <div>
            <div>

            </div>
        </div>
    );
}


//  parent  {"Element1"}
const items: CollapseProps['items'] = [
    {
        key: '1',
        label: 'panel 1',
        children: <Element1></Element1>,
    },
    {
        key: '2',
        label: 'panel 2',
        children: <Element2></Element2>,
    }
];


const CollapseComponent: React.FC = () => {
    return (
        <Collapse accordion items={items} />
    );
}


export default CollapseComponent;