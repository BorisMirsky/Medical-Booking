/* eslint-disable react-hooks/rules-of-hooks */
"use client"

import React from 'react';
import { UserLoginRequest, registerAdmin, loginAdmin } from "@/app/Services/service";   
import { FormProps, Button, Form, Input, Space } from 'antd';
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";
//import Link from "next/link";
//import ModalComponent from '../Components/ModalComponent';


export default function entranceAdmin() {
    //const [currentRole, setCurrentRole] = useState("");
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        //const role = localStorage.getItem("role") || "";
        //setCurrentRole(role);
        //localStorage.clear();
        setLoading(false);
    }, []);



    /// Register
    const onFinishFailedRegister: FormProps<UserLoginRequest>['onFinishFailed'] = (errorInfo) => {
        console.log('onFinishFailed:', errorInfo);
    }

    const onFinishRegister: FormProps<UserLoginRequest>['onFinish'] = (values) => {
        console.log('values ', values)
        //window.location.href = 'profileadmin';
        registerAdmin(values);
    }



    /////// LogIn
    const onFinishFailedLogin: FormProps<UserLoginRequest>['onFinishFailed'] = (errorInfo) => {
        console.log('onFinishFailed:', errorInfo);
    }

    const onFinishLogin: FormProps<UserLoginRequest>['onFinish'] = (values) => {
        console.log('values ', values)
        window.location.href = 'profileadmin';
        loginAdmin(values);
    }

    return (
        <div>
            <br></br>
            <br></br>
            <h2>Вход для админа</h2>
            <br></br>
            <br></br>
            <h2>Зарегиться (только один раз)</h2>
            <br></br>
            <br></br>
            <Form
                name="basic"
                labelCol={{ span: 8 }}
                wrapperCol={{ span: 16 }}
                style={{ maxWidth: 600 }}
                initialValues={{ remember: true }}
                onFinish={onFinishRegister}
                onFinishFailed={onFinishFailedRegister}
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
                            Регистрация
                        </Button>
                        <Button htmlType="reset">
                            Сбросить
                        </Button>
                    </Space>
                </Form.Item>
            </Form>
            <br></br>
            <br></br>
            <br></br>
            <h2>Залогиниться</h2>
            <br></br>
            <br></br>
            {
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
                        <br></br>
                        <br></br>
                    </div >
            }
        </div>
    );
}