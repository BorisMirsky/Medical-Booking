
"use client"

import React from 'react';
import CollapseElement from '../Components/doctorCollapseComponent';
import { useEffect, useState } from "react";
import Title from "antd/es/typography/Title";
import { Space } from 'antd';


export default function ProfileDoctor() { 
    const [currentUserName, setCurrentUserName] = useState("");
    const [currentUserRole, setCurrentUserRole] = useState("");
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        setLoading(false);
        const getUser = async () => {
            const name = localStorage.getItem("username") || "";
            const role = localStorage.getItem("role") || "";
            if (name != undefined) {
                setCurrentUserName(name);
                setCurrentUserRole(role);
            }
        }
        getUser();
    }, []);

    return (
        <div>
            <div>

                {
                    (currentUserRole === 'doctor') ? (
                <div >

                            <Space
                                direction="vertical"
                                size="large"
                                style={{ margin: '2rem', width: '50%' }}
                            >
                                <Title level={2}>Профиль врача {currentUserName}</Title>
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
                        <div> Только для залогинившегося врача</div>
                    )}
            </div>
            </div>
        );
}