/* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";
import CollapseElement from '../Components/adminCollapseComponent';
import { Space } from 'antd';


export default function profileAdmin() {
    const [currentRole, setCurrentRole] = useState("");
    const [currentName, setCurrentName] = useState("");
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const role = localStorage.getItem("role") || "";
        const name = localStorage.getItem("username") || "";
        setCurrentRole(role);
        setCurrentName(name);
        setLoading(false);
    }, []);




    return (

        <div>
            {
                    (currentRole === 'Admin') ? (
            <div>

                        <Space
                            direction="vertical"
                            size="large"
                            style={{ margin: '2rem', width: '50%' }}
                        >
                            <Title level={2}>Профиль админа {currentName}</Title>
                        </Space>

                    {loading ? (
                            <Space
                                direction="vertical"
                                size="large"
                                style={{ margin: '2rem', width: '50%' }}
                            >
                                <Title level={2}>Loading ...</Title>
                            </Space>
                    ) : (
                            <CollapseElement />
                    )}

                </div >
                    ) : (
                        <div><h2> Только для залогинившегося Админа</h2></div>
            )}
        </div>
    );
}