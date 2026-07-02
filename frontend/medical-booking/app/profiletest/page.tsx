
"use client"

import React from 'react';
import CollapseElement from '../Components/testCollapseComponent3';
import { Space } from 'antd';
import Title from "antd/es/typography/Title";


export default function profileTest() {

    return (
        <div>
            <Space
                direction="vertical"
                size="large"
                style={{ margin: '2rem', width: '50%' }}
            >
                <Title level={2}>test profile</Title>
            </Space>
            <CollapseElement />
        </div>
    );
}