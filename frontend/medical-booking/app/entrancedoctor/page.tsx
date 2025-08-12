/* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
//import { UserLoginRequest } from "@/app/Services/service";  
import { FormProps, Button, Form, Input, Space } from 'antd';
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";
import { loginDoctor, UserLoginRequest } from "@/app/Services/service"; 
//import Link from "next/link";
//import ModalComponent from '../Components/ModalComponent';


export default function entranceDoctor() {
    const [currentRole, setCurrentRole] = useState("");
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const role = localStorage.getItem("role") || "";
        setCurrentRole(role);
        localStorage.clear();
        setLoading(false);
    }, []);

    const onFinishFailed: FormProps<UserLoginRequest>['onFinishFailed'] = (errorInfo) => {
        console.log('onFinishFailed:', errorInfo);
    }

    const onFinish: FormProps<UserLoginRequest>['onFinish'] = (values) => {
        console.log('values ', values)
        loginDoctor(values);
        //window.location.href = 'profiledoctor';
    }

    return (
        <div>
            {
                (!currentRole) ? (

        <div>
            <br></br>
            <br></br>
            <br></br>
            <h2>Вход для врача</h2>
            <br></br>
            <br></br>
            <br></br>
            {
                <div >
                    {loading ? (
                        <Title>Loading ...</Title>
                    ) : (
                        <Form
                            name="basic"
                            labelCol={{ span: 8 }}
                            wrapperCol={{ span: 16 }}
                            style={{ maxWidth: 600 }}
                            initialValues={{ remember: true }}
                            onFinish={onFinish}
                            onFinishFailed={onFinishFailed}
                            autoComplete="off"
                        >
                            <Form.Item<UserLoginRequest>
                                label="Email"
                                name="email"
                                rules={[{ required: true, message: 'Please input login!' }]}
                            >
                                <Input />
                            </Form.Item>

                            <Form.Item<UserLoginRequest>
                                label="Password"
                                name="password"
                                rules={[{ required: true, message: 'Please input password!' }]}
                            >
                                <Input />
                            </Form.Item>

                            <Form.Item label={null}>
                                <Space size='large'>
                                    <Button
                                        type="primary"
                                        htmlType="submit"
                                    >
                                        Залогиниться
                                    </Button>
                                    <Button htmlType="reset">
                                        Сбросить
                                    </Button>
                                </Space>
                            </Form.Item>
                        </Form>
                    )}
                    <br></br>
                    <br></br>
                </div >
            }
                    </div>
                )
                    : (
                        <div></div>
                    )
            }
        </div>
    );
}