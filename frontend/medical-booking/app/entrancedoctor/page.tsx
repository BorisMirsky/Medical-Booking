/* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import { FormProps, Button, Form, Input, Space } from 'antd';
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";
import { loginDoctor, UserLoginRequest } from "@/app/Services/service"; 


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
        loginDoctor(values);
    }

    return (
        <div>
            {
                (!currentRole) ? (
                    <div>
                        <Space
                            direction="vertical"
                            size="large"
                            style={{ margin: '2rem', width: '50%' }}
                        >
                        <Title level={2}>Вход для врача</Title>                   
                    </Space>
                        {
                    <div>
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
                                <br />
                                <br />
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