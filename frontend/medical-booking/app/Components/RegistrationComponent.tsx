//import '../App.css';
import { Select, FormProps, Button, Form, Input, Space } from 'antd';
const { Option } = Select;



export interface DoctorRegisterRequest {
    email: string;
    password: string;
    username: string;
    role: string;
    speciality: string;
    gender: string;
}



export default function DoctorRegistration() {

    const onFinishFailed: FormProps<DoctorRegisterRequest>['onFinishFailed'] = (errorInfo) => {
        console.log('onFinishFailed:', errorInfo);
    }

    const onFinish: FormProps<DoctorRegisterRequest>['onFinish'] = (values) => {
        console.log('values ', values)
    }


    return (
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
            <Form.Item<DoctorRegisterRequest>
                label="Email"
                name="email"
                rules={[{ required: true, message: 'Please input login!' }]}
            >
                <Input />
            </Form.Item>

            <Form.Item<DoctorRegisterRequest>
                label="Password"
                name="password"
                rules={[{ required: true, message: 'Please input password!' }]}
            >
                <Input />
            </Form.Item>

            <Form.Item<DoctorRegisterRequest>
                label="UserName"
                name="username"
                rules={[{ required: true, message: 'Please input username!' }]}
            >
                <Input />
            </Form.Item>

            <Form.Item<DoctorRegisterRequest>
                label="Role"
                name="role"
                rules={[{ required: true, message: 'Please input role!' }]}
            >
                <Input
                    defaultValue="doctor"
                />
            </Form.Item>

            <Form.Item<DoctorRegisterRequest>
                label="Speciality"
                name="speciality"
                rules={[{ required: true, message: 'Please input speciality!' }]}
            >
                <Select
                    placeholder="Select a speciality"
                >
                    <Option value="oncologist">Oncologist</Option>
                    <Option value="neurologist">Neurologist</Option>
                    <Option value="surgeon">Surgeon</Option>
                </Select>
            </Form.Item>

            <Form.Item<DoctorRegisterRequest>
                label="Gender"
                name="gender"
                rules={[{ required: true, message: 'Please input gender!' }]}
            >
                <Select
                    placeholder="Select a gender"
                >
                    <Option value="male">male</Option>
                    <Option value="female">female</Option>
                </Select>
            </Form.Item>
            <br></br>
            <br></br>
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
    );
}
