/* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import { UserLoginRequest, loginAdmin } from "@/app/Services/service";     //registerAdmin
import { FormProps, Button, Form, Input, Space } from 'antd';
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";



export default function entranceAdmin() {
    const [loading, setLoading] = useState(true);
    const [currentRole, setCurrentRole] = useState("");

    useEffect(() => {
        setLoading(false);
        const role = localStorage.getItem("role") || "";
        setCurrentRole(role);
    }, []);


    const onFinishFailedLogin: FormProps<UserLoginRequest>['onFinishFailed'] = (errorInfo) => {
        console.log('onFinishFailed:', errorInfo);
    }

    const onFinishLogin: FormProps<UserLoginRequest>['onFinish'] = (values) => {
        loginAdmin(values);
    }

    return (
        <div>
            <Space
                direction="vertical"
                size="large"
                style={{ margin: '2rem', width: '50%' }}
            >
                <Title level={2}>Вход для админа</Title>
            </Space>
            <Space
                direction="vertical"
                size="large"
                style={{ margin: '2rem', width: '50%' }}
            >
                <Title level={2}>Залогиниться</Title>
            </Space>

            {
                (currentRole === '') ? (
                    <div >
                        {loading ? (
                            <Title>Loading ...</Title>
                        ) : (
                            <Form
                                name="basic1"
                                labelCol={{ span: 8 }}
                                wrapperCol={{ span: 16 }}
                                style={{ maxWidth: 600 }}
                                initialValues={{ remember: true }}
                                onFinish={onFinishLogin}
                                onFinishFailed={onFinishFailedLogin}
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
                ) : (
                        <Space
                            direction="vertical"
                            size="large"
                            style={{ margin: '2rem', width: '50%' }}
                        >
                            <Title level={2}>Только для незалогинившегося юзера</Title>
                        </Space>
                )
            }
        </div>
    );
}
