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
            <br />
            <br />
            <h2>Вход для админа</h2>
            <br />
            <br />
            <br />
            <h2>Залогиниться</h2>
            <br />
            <br />
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
                    <div> Только для незалогинившегося юзера (надеюсь что Админа)</div>
                )
            }
        </div>
    );
}





///                              Register admin
//const onFinishFailedRegister: FormProps<UserLoginRequest>['onFinishFailed'] = (errorInfo) => {
//    console.log('onFinishFailed:', errorInfo);
//}
//const onFinishRegister: FormProps<UserLoginRequest>['onFinish'] = (values) => {
//    registerAdmin(values);
//}
//<Form
//    name="basic"
//    labelCol={{ span: 8 }}
//    wrapperCol={{ span: 16 }}
//    style={{ maxWidth: 600 }}
//    initialValues={{ remember: true }}
//    onFinish={onFinishRegister}
//    onFinishFailed={onFinishFailedRegister}
//    autoComplete="off"
//>
//    <Form.Item<UserLoginRequest>
//        label="Email"
//        name="email"
//        rules={[{ required: true, message: 'Please input login!' }]}
//    >
//        <Input />
//    </Form.Item>

//    <Form.Item<UserLoginRequest>
//        label="Password"
//        name="password"
//        rules={[{ required: true, message: 'Please input password!' }]}
//    >
//        <Input />
//    </Form.Item>

//    <Form.Item label={null}>
//        <Space size='large'>
//            <Button
//                type="primary"
//                htmlType="submit"
//            >
//                Регистрация
//            </Button>
//            <Button htmlType="reset">
//                Сбросить
//            </Button>
//        </Space>
//    </Form.Item>
//</Form>